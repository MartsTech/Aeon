import {pageTransition, pageZoom} from '@lib/utils/animations';
import {motion} from 'framer-motion';
import CartEmpty from './CartEmpty';

const CartModule = () => {
  return (
    <motion.div
      initial="initial"
      animate="in"
      exit="out"
      variants={pageZoom}
      transition={pageTransition}
      className="py-12 px-6 sm:p-12 sm:pt-20">
      <h4 className="mb-12 text-2xl font-semibold">Your Cart</h4>
      <CartEmpty />
    </motion.div>
  );
};

export default CartModule;
