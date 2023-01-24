import {categoriesApi} from '@features/categories/categories-api';
import {productsApi} from '@features/products/products-api';
import {api} from '@lib/api';
import {storeWrapper} from '@lib/store';

const Home = () => {
  return null;
};

export default Home;

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
