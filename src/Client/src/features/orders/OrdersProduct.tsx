import type {ProductsListModal} from '@features/products/products-types';
import Image from 'next/image';

interface Props {
  item: ProductsListModal;
}

const OrdersProduct: React.FC<Props> = ({item}) => {
  return (
    <div
      key={item.id}
      className="relative flex flex-1 flex-col overflow-hidden
      rounded-lg bg-black bg-opacity-[1%] p-4 shadow-inner"
      style={{scrollSnapAlign: 'start'}}>
      <div className=" relative h-96 w-full">
        <Image
          fill
          src={item.image ?? '/images/default.jpg'}
          alt="product image"
          className="absolute h-full w-full object-contain !p-2"
        />
      </div>
      <span className="w-full truncate">{item.title}</span>
      <small
        className="absolute left-auto right-2 bottom-auto 
        top-2 rounded-2xl bg-[#1a1a2c] bg-opacity-5 py-1
        px-2 text-xs font-bold text-[#1a1a2c]">
        x{item.quantity}
      </small>
    </div>
  );
};

export default OrdersProduct;
