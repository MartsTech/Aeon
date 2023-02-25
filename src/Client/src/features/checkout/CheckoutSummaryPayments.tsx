import {cartCleared} from '@features/cart/cart-state';
import Button from '@lib/components/button/Button';
import {useStoreDispatch, useStoreSelector} from '@lib/store/store-hooks';
import {useStripe} from '@stripe/react-stripe-js';
import Image from 'next/image';
import {useCallback} from 'react';
import {checkoutApi} from './checkout-api';
import {
  checkoutAllowedSelector,
  checkoutPaymentMethodSelector,
  checkoutProcessingSelector,
  checkoutStatusSelector,
} from './checkout-state';

const CheckoutSummaryPayments = () => {
  const method = useStoreSelector(checkoutPaymentMethodSelector);
  const allowed = useStoreSelector(checkoutAllowedSelector);
  const status = useStoreSelector(checkoutStatusSelector);
  const processing = useStoreSelector(checkoutProcessingSelector);

  const stripe = useStripe();

  const dispatch = useStoreDispatch();

  const payViaStripeHandler = useCallback(async () => {
    try {
      const sessionId = await dispatch(
        checkoutApi.endpoints.createCheckoutSession.initiate(),
      ).unwrap();

      if (!sessionId) {
        return;
      }

      dispatch(cartCleared());

      stripe?.redirectToCheckout({
        sessionId,
        successUrl: process.env.NEXTAUTH_URL,
      });
    } catch (e) {}
  }, [stripe, dispatch]);

  return (
    <div className="mt-8 flex flex-col space-y-4">
      <Button
        disabled={method === 'card' && !allowed}
        variant="primary"
        className="!transform-none uppercase">
        {status}
      </Button>
      <Button
        onClick={payViaStripeHandler}
        disabled={processing}
        variant="outlined"
        className="flex items-center !border-[#635bff] !border-opacity-50
        text-center text-[#635bff] opacity-90"
        style={{boxShadow: '0 0.5rem 1rem rgba(99, 91, 255, 0.15)'}}>
        <span className="h-7 text-black">Pay via</span>
        <div className="relative h-6 w-12">
          <Image
            fill
            src="/images/stripe.svg"
            className="absolute h-full w-full object-contain"
            alt="Stripe"
          />
        </div>
      </Button>
    </div>
  );
};

export default CheckoutSummaryPayments;
