import FormCheck from '@lib/components/form/FormCheck';
import {useStoreDispatch, useStoreSelector} from '@lib/store/store-hooks';
import {useCallback} from 'react';
import {
  checkoutErrorSelector,
  checkoutPaymentMethodChanged,
  checkoutPaymentMethodSelector,
} from './checkout-state';
import {CheckoutPaymentMethod} from './checkout-types';
import CheckoutPaymentCard from './CheckoutPaymentCard';
import CheckoutPaymentError from './CheckoutPaymentError';

const CheckoutPaymentMethod = () => {
  const method = useStoreSelector(checkoutPaymentMethodSelector);
  const error = useStoreSelector(checkoutErrorSelector);

  const dispatch = useStoreDispatch();

  const methodChangeHandler = useCallback(
    (method: CheckoutPaymentMethod) => {
      dispatch(checkoutPaymentMethodChanged(method));
    },
    [dispatch],
  );

  return (
    <div className="flex w-full flex-1 flex-col lg:mr-12 lg:flex-[60%]">
      <h5 className="mt-8 text-xl font-semibold">How would you like to pay?</h5>
      <p className="mb-8 max-w-[400px] font-normal">
        Choose a payment method and verify your details to successfully place
        the order.
      </p>
      {method === 'card' && <CheckoutPaymentCard />}
      <CheckoutPaymentError />
      <FormCheck
        name="method"
        label="Credit Card"
        type="radio"
        value={method === 'card'}
        onClick={() => methodChangeHandler('card')}
      />
      <FormCheck
        name="method"
        label="Cash on Delivery"
        type="radio"
        value={method === 'cash'}
        onClick={() => methodChangeHandler('cash')}
      />
    </div>
  );
};

export default CheckoutPaymentMethod;
