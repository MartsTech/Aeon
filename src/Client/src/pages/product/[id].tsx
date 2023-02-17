import {bookmarksApi} from '@features/bookmarks/bookmarks-api';
import {productApi} from '@features/product/product-api';
import ProductModule from '@features/product/ProductModule';
import {api} from '@lib/api';
import DefaultLayout from '@lib/layouts/DefaultLayout';
import {storeWrapper} from '@lib/store';
import type {NextPageWithLayout} from '@lib/types/page';
import type {GetServerSideProps} from 'next';
import {getSession} from 'next-auth/react';
import type {ReactElement} from 'react';

const Product: NextPageWithLayout = () => {
  return <ProductModule />;
};

export default Product;

Product.getLayout = (page: ReactElement) => {
  return <DefaultLayout>{page}</DefaultLayout>;
};

export const getServerSideProps: GetServerSideProps =
  storeWrapper.getServerSideProps(store => {
    return async ({query, res, req}) => {
      const {id} = query;

      if (typeof id !== 'string') {
        return {
          notFound: true,
        };
      }

      try {
        await store
          .dispatch(productApi.endpoints.getProductById.initiate({id}))
          .unwrap();
      } catch (e) {
        return {
          notFound: true,
        };
      }

      const session = await getSession({req});

      if (session && session.accessToken) {
        const bookmarks = await store
          .dispatch(
            bookmarksApi.endpoints.getWishlists.initiate(session.accessToken),
          )
          .unwrap();

        if (bookmarks.length === 0) {
          store.dispatch(
            bookmarksApi.endpoints.createWishlist.initiate(session.accessToken),
          );
        }
      }

      await Promise.all(store.dispatch(api.util.getRunningQueriesThunk()));

      res.setHeader(
        'Cache-Control',
        'public, s-maxage=10, stale-while-revalidate=59',
      );

      return {
        props: {},
      };
    };
  });
