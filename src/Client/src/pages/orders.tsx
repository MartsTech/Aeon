import OrdersModule from '@features/orders/OrdersModule';
import DefaultLayout from '@lib/layouts/DefaultLayout';
import {storeWrapper} from '@lib/store';
import type {NextPageWithLayout} from '@lib/types/page';
import {getSession} from 'next-auth/react';
import type {ReactElement} from 'react';

const Orders: NextPageWithLayout = () => {
  return <OrdersModule />;
};

export default Orders;

Orders.getLayout = (page: ReactElement) => {
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
