import Button from '@lib/components/button/Button';
import {useStoreDispatch, useStoreSelector} from '@lib/store/store-hooks';
import {CardElement, useElements, useStripe} from '@stripe/react-stripe-js';
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
  const stripeElemets = useElements();

  const dispatch = useStoreDispatch();

  const payWithStripeHandler = useCallback(async () => {
    if (!stripe) {
      return;
    }

    try {
      await dispatch(
        checkoutApi.endpoints.createCheckoutSession.initiate(stripe),
      ).unwrap();
    } catch (e) {}
  }, [stripe, dispatch]);

  const payWithCardHandler = useCallback(async () => {
    if (!stripe || !stripeElemets) {
      return;
    }

    const card = stripeElemets.getElement(CardElement);

    if (!card) {
      return;
    }

    try {
      await dispatch(
        checkoutApi.endpoints.checkoutPayWithCard.initiate({stripe, card}),
      ).unwrap();
    } catch (e) {}
  }, [stripe, stripeElemets, dispatch]);

  const payNowHandler = useCallback(async () => {
    if (method === 'card') {
      payWithCardHandler();
    }
  }, [method, payWithCardHandler]);

  return (
    <div className="mt-8 flex flex-col space-y-4">
      <Button
        onClick={payNowHandler}
        disabled={method === 'card' && !allowed}
        variant="primary"
        className="!transform-none uppercase">
        {status}
      </Button>
      <Button
        onClick={payWithStripeHandler}
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
