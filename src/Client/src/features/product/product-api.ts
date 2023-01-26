import {api} from '@lib/api';
import {productLoaded} from './product-state';
import {ProductDetailsModal} from './product-types';

export const productApi = api.injectEndpoints({
  endpoints: builder => ({
    getProductById: builder.query<
      ProductDetailsModal,
      {id: ProductDetailsModal['id']}
    >({
      query: ({id}) => ({
        url: `/catalog/GetProducts/${id}`,
        method: 'GET',
      }),
      async onQueryStarted(_arg, {queryFulfilled, dispatch}) {
        const result = await queryFulfilled;

        if (result.meta?.response?.status === 200) {
          dispatch(productLoaded({details: result.data}));
        }
        if (result.meta?.response?.status === 404) {
          dispatch(productLoaded({details: null}));
        }
      },
    }),
  }),
});
