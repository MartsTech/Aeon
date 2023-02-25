import {OrderModel} from '@features/orders/orders-types';
import {api} from '@lib/api';
import {RootState} from '@lib/store/store-types';
import {Stripe, StripeCardElement} from '@stripe/stripe-js';
import {
  checkoutCardHolderSelector,
  checkoutProccessingChanged,
  checkoutProductsSelector,
} from './checkout-state';

export const checkoutApi = api.injectEndpoints({
  endpoints: builder => ({
    createCheckoutSession: builder.mutation<null, Stripe>({
      queryFn: async (arg, queryApi, _extraOptions, baseQuery) => {
        const state = queryApi.getState() as RootState;

        const items = checkoutProductsSelector(state);

        if (!items.length) {
          return {
            data: null,
          };
        }
        queryApi.dispatch(checkoutProccessingChanged(true));

        const result = await baseQuery({
          url: `${process.env.NEXT_PUBLIC_CLIENT_URL}/api/checkout/create-session`,
          method: 'POST',
          body: {
            items,
          },
        });

        if (
          typeof result.data !== 'object' ||
          result.data === null ||
          !('sessionId' in result.data) ||
          typeof result.data?.sessionId !== 'string'
        ) {
          return {
            data: null,
          };
        }

        await arg.redirectToCheckout({
          sessionId: result.data.sessionId,
        });

        queryApi.dispatch(checkoutProccessingChanged(false));

        return {
          data: null,
        };
      },
    }),
    checkoutPayWithCard: builder.mutation<
      OrderModel | null,
      {stripe: Stripe; card: StripeCardElement}
    >({
      // @ts-ignore
      queryFn: async (arg, queryApi, _extraOptions, baseQuery) => {
        const state = queryApi.getState() as RootState;

        const session = state.auth.session;

        if (!session) {
          return {
            data: null,
          };
        }

        const cardHolder = checkoutCardHolderSelector(state);

        if (!cardHolder.length) {
          return {
            data: null,
          };
        }

        const items = checkoutProductsSelector(state);

        if (!items.length) {
          return {
            data: null,
          };
        }

        const total = items.reduce(
          (acc, item) => acc + item.quantity * item.price_data.unit_amount,
          0,
        );

        if (total === 0) {
          return {
            data: null,
          };
        }

        queryApi.dispatch(checkoutProccessingChanged(true));

        arg.card.update({
          disabled: true,
        });

        const result = await baseQuery({
          url: `${process.env.NEXT_PUBLIC_CLIENT_URL}/api/checkout/create-intent`,
          method: 'POST',
          body: {
            total,
          },
        });

        if (
          typeof result.data !== 'object' ||
          result.data === null ||
          !('clientSecret' in result.data) ||
          typeof result.data?.clientSecret !== 'string'
        ) {
          queryApi.dispatch(checkoutProccessingChanged(false));

          arg.card.update({
            disabled: false,
          });

          return {
            data: null,
          };
        }

        const payment = await arg.stripe.confirmCardPayment(
          result.data.clientSecret,
          {
            payment_method: {
              card: arg.card,
              billing_details: {
                name: cardHolder,
                email: session.user.email,
                address: {
                  country: 'US',
                  postal_code: session.profile.postalCode,
                  state: session.profile.state,
                  line1: session.profile.streetAddress,
                },
              },
            },
            receipt_email: session.user.email,
          },
        );

        queryApi.dispatch(checkoutProccessingChanged(false));

        arg.card.update({
          disabled: false,
        });

        if (payment.paymentIntent) {
          return {
            data: {
              id: payment.paymentIntent.id,
              amount: payment.paymentIntent.amount,
              created: payment.paymentIntent.created,
              items,
              type: 'card',
            },
          };
        }

        return {
          data: null,
        };
      },
    }),
  }),
});
