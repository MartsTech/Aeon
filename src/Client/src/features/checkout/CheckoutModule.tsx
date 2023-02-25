import {authUserSelector} from '@features/auth/auth-state';
import {useStoreSelector} from '@lib/store/store-hooks';
import {pageSlide, pageTransition} from '@lib/utils/animations';
import {motion} from 'framer-motion';
import {checkoutSuccessSelector} from './checkout-state';
import CheckoutPaymentMethod from './CheckoutPaymentMethod';
import CheckoutSuccessSummary from './CheckoutSuccessSummary';
import CheckoutSummary from './CheckoutSummary';

const CheckoutModule = () => {
  const user = useStoreSelector(authUserSelector);
  const success = useStoreSelector(checkoutSuccessSelector);

  if (!user) {
    return null;
  }

  return (
    <motion.div
      initial="initial"
      animate="in"
      exit="out"
      variants={pageSlide}
      transition={pageTransition}
      className="mx-auto w-full p-4 pt-20 lg:max-w-screen-lg lg:p-12">
      <h4 className="mb-12 text-2xl font-semibold">
        Complete your Order, {user.name.split(' ', 1)}
      </h4>

      <div className="flex flex-col space-y-4 lg:flex-row">
        <CheckoutPaymentMethod />
        {!success ? <CheckoutSummary /> : <CheckoutSuccessSummary />}
      </div>
    </motion.div>
  );
};

export default CheckoutModule;
