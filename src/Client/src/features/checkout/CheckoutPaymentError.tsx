import {useStoreSelector} from '@lib/store/store-hooks';
import {errorAnimation} from '@lib/utils/animations';
import {motion} from 'framer-motion';
import {checkoutErrorSelector} from './checkout-state';

const CheckoutPaymentError = () => {
  const error = useStoreSelector(checkoutErrorSelector);

  if (!error) {
    return null;
  }

  return (
    <motion.p
      initial="initial"
      animate="in"
      exit="out"
      variants={errorAnimation}
      className="mx-4 -mt-4 mb-12 rounded-lg 
      bg-[#ff0000] bg-opacity-5 py-2 px-4 text-sm text-[#dc143c]"
      style={{width: 'calc(100% - 2rem)'}}>
      {error}
    </motion.p>
  );
};

export default CheckoutPaymentError;
