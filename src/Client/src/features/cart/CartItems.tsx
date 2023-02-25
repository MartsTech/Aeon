import {useStoreSelector} from '@lib/store/store-hooks';
import {cartProductsSelector} from './cart-state';
import CartItem from './CartItem';

const CartItems = () => {
  const items = useStoreSelector(cartProductsSelector);

  return (
    <div className="flex flex-[50%] flex-col">
      <div className="space-y-4">
        {items.map(item => (
          <CartItem key={item.id} item={item} />
        ))}
      </div>
    </div>
  );
};

export default CartItems;
