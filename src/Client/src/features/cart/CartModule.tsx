import {useStoreSelector} from '@lib/store/store-hooks';
import {pageTransition, pageZoom} from '@lib/utils/animations';
import {motion} from 'framer-motion';
import {cartIsEmptySelector} from './cart-state';
import CartEmpty from './CartEmpty';
import CartList from './CartList';

const CartModule = () => {
  const isEmpty = useStoreSelector(cartIsEmptySelector);

  return (
    <motion.div
      initial="initial"
      animate="in"
      exit="out"
      variants={pageZoom}
      transition={pageTransition}
      className="py-12 px-6 sm:p-12 sm:pt-20">
      <h4 className="mb-12 text-2xl font-semibold">Your Cart</h4>
      {!isEmpty ? <CartList /> : <CartEmpty />}
    </motion.div>
  );
};

export default CartModule;
