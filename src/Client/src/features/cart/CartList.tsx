import CartCheckout from './CartCheckout';
import CartItems from './CartItems';

const CartList = () => {
  return (
    <div className="flex flex-col-reverse md:flex-row md:space-x-8">
      <CartItems />
      <CartCheckout />
    </div>
  );
};

export default CartList;
