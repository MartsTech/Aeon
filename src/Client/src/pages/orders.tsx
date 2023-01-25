import OrdersModule from '@features/orders/OrdersModule';
import DefaultLayout from '@lib/layouts/DefaultLayout';
import type {NextPageWithLayout} from '@lib/types/page';
import type {ReactElement} from 'react';

const Orders: NextPageWithLayout = () => {
  return <OrdersModule />;
};

export default Orders;

Orders.getLayout = (page: ReactElement) => {
  return <DefaultLayout>{page}</DefaultLayout>;
};
