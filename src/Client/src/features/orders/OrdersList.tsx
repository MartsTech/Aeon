import {useStoreSelector} from '@lib/store/store-hooks';
import {ordersListSelector} from './orders-state';
import OrdersItem from './OrdersItem';

const OrdersList = () => {
  const orders = useStoreSelector(ordersListSelector);

  return (
    <div className="-ml-4 flex w-full flex-col gap-4 lg:grid lg:grid-cols-2 xl:grid-cols-3">
      {orders.map(order => (
        <OrdersItem key={order.id} order={order} />
      ))}
    </div>
  );
};

export default OrdersList;
