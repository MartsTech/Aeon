import {api} from '@lib/api';
import {productsLoaded} from './products-state';
import type {ProductsListModal} from './products-types';

export const productsApi = api.injectEndpoints({
  endpoints: builder => ({
    getProductsList: builder.query<ProductsListModal[], void>({
      query: () => ({
        url: `/catalog/GetProducts`,
        method: 'GET',
      }),
      async onQueryStarted(_arg, {queryFulfilled, dispatch}) {
        const result = await queryFulfilled;

        if (result.meta?.response?.status === 200) {
          dispatch(productsLoaded({list: result.data}));
        }
      },
    }),
  }),
});
