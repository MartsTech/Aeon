import {api} from '@lib/api';
import {RootState} from '@lib/store/store-types';
import {
  checkoutProccessingChanged,
  checkoutProductsSelector,
} from './checkout-state';

export const checkoutApi = api.injectEndpoints({
  endpoints: builder => ({
    createCheckoutSession: builder.mutation<string | null, void>({
      queryFn: async (_arg, queryApi, _extraOptions, baseQuery) => {
        const state = queryApi.getState() as RootState;

        const items = checkoutProductsSelector(state);

        if (!items.length) {
          return {
            data: null,
          };
        }
        queryApi.dispatch(checkoutProccessingChanged(true));

        const result = await baseQuery({
          url: `http://localhost:3000/api/checkout/create-session`,
          method: 'POST',
          body: {
            items,
          },
        });

        queryApi.dispatch(checkoutProccessingChanged(false));

        if (
          typeof result.data === 'object' &&
          result.data !== null &&
          'sessionId' in result.data &&
          typeof result.data?.sessionId === 'string'
        ) {
          return {
            data: result.data.sessionId,
          };
        }

        return {
          data: null,
        };
      },
    }),
  }),
});
