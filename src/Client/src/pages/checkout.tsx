import {cartIsEmptySelector} from '@features/cart/cart-state';
import CheckoutModule from '@features/checkout/CheckoutModule';
import DefaultLayout from '@lib/layouts/DefaultLayout';
import {storeWrapper} from '@lib/store';
import {useStoreSelector} from '@lib/store/store-hooks';
import StripeProvider from '@lib/stripe/StripeProvider';
import type {NextPageWithLayout} from '@lib/types/page';
import {useStripe} from '@stripe/react-stripe-js';
import {GetServerSideProps} from 'next';
import {getSession} from 'next-auth/react';
import {useRouter} from 'next/router';
import {ReactElement, useEffect} from 'react';

const Checkout: NextPageWithLayout = () => {
  const cartIsEmpty = useStoreSelector(cartIsEmptySelector);

  const stripe = useStripe();

  const router = useRouter();

  useEffect(() => {
    if (cartIsEmpty) {
      router.push('/');
    }
  }, [cartIsEmpty]);

  return <CheckoutModule />;
};

export default Checkout;

Checkout.getLayout = (page: ReactElement) => {
  return (
    <DefaultLayout>
      <StripeProvider>{page}</StripeProvider>
    </DefaultLayout>
  );
};

export const getServerSideProps: GetServerSideProps =
  storeWrapper.getServerSideProps(() => async ({req, res}) => {
    const session = await getSession({req});

    if (!session || !session.accessToken) {
      return {
        redirect: {
          destination: '/login',
          permanent: false,
        },
        props: {
          session,
        },
      };
    }

    return {
      props: {
        session,
      },
    };
  });
