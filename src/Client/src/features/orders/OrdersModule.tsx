import {useStoreSelector} from '@lib/store/store-hooks';
import {pageTransition, pageZoom} from '@lib/utils/animations';
import {motion} from 'framer-motion';
import {ordersEmptySelector} from './orders-state';
import OrdersEmpty from './OrdersEmpty';
import OrdersList from './OrdersList';

const OrdersModule = () => {
  const empty = useStoreSelector(ordersEmptySelector);

  return (
    <motion.div
      initial="initial"
      animate="in"
      exit="out"
      variants={pageZoom}
      transition={pageTransition}
      className="py-12 px-6 sm:p-12 sm:pt-20">
      <h4 className="mb-12 text-2xl font-semibold">Your Orders</h4>
      {!empty ? <OrdersList /> : <OrdersEmpty />}
    </motion.div>
  );
};

export default OrdersModule;
