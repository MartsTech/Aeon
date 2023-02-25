import Button from '@lib/components/button/Button';
import {useStoreSelector} from '@lib/store/store-hooks';
import {errorAnimation} from '@lib/utils/animations';
import {motion} from 'framer-motion';
import Link from 'next/link';
import {cartTotalCountSelector, cartTotalPriceSelector} from './cart-state';

const CartCheckout = () => {
  const cartTotalPrice = useStoreSelector(cartTotalPriceSelector);
  const cartTotalCount = useStoreSelector(cartTotalCountSelector);

  return (
    <div className="flex-[50%] items-start">
      <div className="mb-12 rounded-lg bg-white p-6 shadow-md md:mt-0 md:p-8">
        <h5 className="text-xl font-semibold">Checkout</h5>
        {cartTotalPrice > 25 && (
          <motion.p
            initial="initial"
            animate="in"
            exit="out"
            variants={errorAnimation}
            className="my-4 flex items-center
          rounded-md bg-[#00c800] bg-opacity-25 py-1 px-2 text-[#2e8b57]">
            Your order is eligible for Free Delivery
          </motion.p>
        )}
        <p className="mt-8 mb-1 text-2xl font-black">
          Sub-Total: ${cartTotalPrice.toFixed(2)}
        </p>
        <p>Number of items: {cartTotalCount}</p>
        <p style={{opacity: 0.5}}>
          This price is exclusive of taxes. GST will be added during checkout.
        </p>
        <div className="mt-4">
          <Link href="/checkout">
            <Button variant="primary">Proceed to Payment</Button>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default CartCheckout;
