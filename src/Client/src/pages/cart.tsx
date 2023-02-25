import CartModule from '@features/cart/CartModule';
import DefaultLayout from '@lib/layouts/DefaultLayout';
import {storeWrapper} from '@lib/store';
import type {NextPageWithLayout} from '@lib/types/page';
import {getSession} from 'next-auth/react';
import type {ReactElement} from 'react';

const Cart: NextPageWithLayout = () => {
  return <CartModule />;
};

export default Cart;

Cart.getLayout = (page: ReactElement) => {
  return <DefaultLayout>{page}</DefaultLayout>;
};

export const getServerSideProps = storeWrapper.getServerSideProps(store => {
  return async ({req}) => {
    const session = await getSession({req});

    return {
      props: {
        session,
      },
    };
  };
});
