import {categoriesApi} from '@features/categories/categories-api';
import {productsApi} from '@features/products/products-api';
import {api} from '@lib/api';
import DefaultLayout from '@lib/layouts/DefaultLayout';
import {storeWrapper} from '@lib/store';
import {NextPageWithLayout} from '@lib/types/page';
import {ReactElement} from 'react';

const Home: NextPageWithLayout = () => {
  return null;
};

export default Home;

Home.getLayout = (page: ReactElement) => {
  return <DefaultLayout>{page}</DefaultLayout>;
};

export const getStaticProps = storeWrapper.getStaticProps(store => {
  return async () => {
    store.dispatch(productsApi.endpoints.getProductsList.initiate());
    store.dispatch(categoriesApi.endpoints.getCategoriesList.initiate());

    await Promise.all(store.dispatch(api.util.getRunningQueriesThunk()));

    return {
      props: {},
    };
  };
});
