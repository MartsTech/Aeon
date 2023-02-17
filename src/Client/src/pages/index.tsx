import {bookmarksApi} from '@features/bookmarks/bookmarks-api';
import CatalogModule from '@features/catalog/CatalogModule';
import {categoriesApi} from '@features/categories/categories-api';
import {productsApi} from '@features/products/products-api';
import {api} from '@lib/api';
import DefaultLayout from '@lib/layouts/DefaultLayout';
import {storeWrapper} from '@lib/store';
import {NextPageWithLayout} from '@lib/types/page';
import {GetServerSideProps} from 'next';
import {getSession} from 'next-auth/react';
import {ReactElement} from 'react';

const Home: NextPageWithLayout = () => {
  return <CatalogModule />;
};

export default Home;

Home.getLayout = (page: ReactElement) => {
  return <DefaultLayout>{page}</DefaultLayout>;
};

export const getServerSideProps: GetServerSideProps =
  storeWrapper.getServerSideProps(store => {
    return async ({res, req}) => {
      store.dispatch(productsApi.endpoints.getProductsList.initiate());
      store.dispatch(categoriesApi.endpoints.getCategoriesList.initiate());

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
