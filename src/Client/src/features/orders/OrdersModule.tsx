import {pageTransition, pageZoom} from '@lib/utils/animations';
import {motion} from 'framer-motion';
import OrdersEmpty from './OrdersEmpty';

const OrdersModule = () => {
  return (
    <motion.div
      initial="initial"
      animate="in"
      exit="out"
      variants={pageZoom}
      transition={pageTransition}
      className="py-12 px-6 sm:p-12 sm:pt-20">
      <h4 className="mb-12 text-2xl font-semibold">Your Orders</h4>
      <OrdersEmpty />
    </motion.div>
  );
};

export default OrdersModule;
