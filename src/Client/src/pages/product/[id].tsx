import {productApi} from '@features/product/product-api';
import ProductModule from '@features/product/ProductModule';
import {api} from '@lib/api';
import DefaultLayout from '@lib/layouts/DefaultLayout';
import {storeWrapper} from '@lib/store';
import type {NextPageWithLayout} from '@lib/types/page';
import type {GetServerSideProps} from 'next';
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
    return async ({query}) => {
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

      await Promise.all(store.dispatch(api.util.getRunningQueriesThunk()));

      return {
        props: {},
      };
    };
  });
