import type {OrderModel} from './orders-types';
import OrdersProduct from './OrdersProduct';

interface Props {
  order: OrderModel;
}

const OrdersItem: React.FC<Props> = ({order}) => {
  return (
    <div className="m-4 flex max-h-96 w-full flex-1 flex-col p-4 shadow-lg">
      <h5 className="text-xl font-semibold">Order ID: {order.id}</h5>
      <p>
        Payment Method: {order.type === 'cash' && 'Cash'}
        {order.type === 'card' && 'Card'}
      </p>
      <div
        className="my-4 flex flex-1 overflow-scroll scrollbar-hide"
        style={{scrollSnapType: 'x mandatory'}}>
        {order.items.slice(0, 3).map(item => (
          <OrdersProduct key={item.id} item={item} />
        ))}
      </div>
      <div
        className="relative flex flex-col overflow-hidden rounded-lg 
        bg-black bg-opacity-[1%] p-4"
        style={{scrollSnapAlign: 'start'}}>
        <span className="flex items-center justify-between rounded-2xl bg-[#1a1a2c] bg-opacity-5 py-1 px-2 ">
          <span className="truncate">Amount</span>
          <span className="text-xs font-bold text-[#1a1a2c]">
            <strong className="text-xl font-black">
              <small>$</small>
              {(order.amount / 100).toFixed(2)}
            </strong>
          </span>
        </span>
      </div>
    </div>
  );
};

export default OrdersItem;
