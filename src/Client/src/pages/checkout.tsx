import CheckoutModule from '@features/checkout/CheckoutModule';
import DefaultLayout from '@lib/layouts/DefaultLayout';
import {storeWrapper} from '@lib/store';
import StripeProvider from '@lib/stripe/StripeProvider';
import type {NextPageWithLayout} from '@lib/types/page';
import {GetServerSideProps} from 'next';
import {getSession} from 'next-auth/react';
import {ReactElement} from 'react';

const Checkout: NextPageWithLayout = () => {
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
