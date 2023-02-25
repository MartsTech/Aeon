import {useStoreDispatch, useStoreSelector} from '@lib/store/store-hooks';
import styles from '@lib/styles/checkout.module.css';
import {errorAnimation} from '@lib/utils/animations';
import {CardElement} from '@stripe/react-stripe-js';
import {StripeCardElementChangeEvent} from '@stripe/stripe-js';
import {motion} from 'framer-motion';
import debounce from 'lodash.debounce';
import {useCallback, useState} from 'react';
import {
  checkoutCardChanged,
  checkoutCardHolderChanged,
  checkoutProcessingSelector,
  checkoutSuccessSelector,
} from './checkout-state';

const CheckoutPaymentCard = () => {
  const success = useStoreSelector(checkoutSuccessSelector);
  const processing = useStoreSelector(checkoutProcessingSelector);

  const [cardHolder, setCardHolder] = useState('');

  const dispatch = useStoreDispatch();

  const debouncedCardHolderDispatch = debounce(value => {
    dispatch(checkoutCardHolderChanged(value));
  }, 1000);

  const cardHolderChangeHandler = useCallback(
    (e: React.ChangeEvent<HTMLInputElement>) => {
      e.preventDefault();
      setCardHolder(e.target.value);
      debouncedCardHolderDispatch(e.target.value);
    },
    [],
  );

  const cardChangeHandler = useCallback((e: StripeCardElementChangeEvent) => {
    dispatch(
      checkoutCardChanged({
        disabled: e.empty,
        error: e.error ? e.error.message : null,
      }),
    );
  }, []);

  return (
    <motion.div
      initial="initial"
      animate="in"
      exit="out"
      variants={errorAnimation}
      className="flex max-w-md justify-center">
      <div
        className={`relative m-4 ml-0 mb-12 rounded-2xl
        border bg-cover ${
          success && 'transition-all duration-500 ease-in-out'
        }`}
        style={{
          width: 'calc(100% - 2.5rem)',
          paddingBottom: 'calc((100% - 2rem) * 0.6)',
          backgroundImage: 'url(/images/card.jpg)',
          boxShadow: '0 2rem 2rem -1rem rgba(255, 153, 0, 0.5)',
          filter: success ? 'hue-rotate(80deg)' : 'none',
        }}>
        <input
          disabled={success || processing}
          value={cardHolder}
          onChange={cardHolderChangeHandler}
          type="text"
          placeholder="Name (as appears in card)"
          className="absolute top-8 left-8 w-full
          border-none bg-transparent text-xl font-extrabold text-white
          placeholder-white placeholder-opacity-75 focus:outline-none"
          style={{
            width: 'calc(100% - 4rem)',
            textShadow:
              cardHolder != '' ? '1px 1px 2px rgba(26, 26, 44, 0.25)' : 'none',
          }}
        />
        <CardElement
          className={styles.StripeElement}
          onChange={cardChangeHandler}
          options={{
            style: {
              base: {
                fontSize: '20px',
                fontWeight: '800',
                fontFamily: 'Nunito Sans, sans-serif',
                iconColor: '#fff',
                color: '#fff',
                textShadow: '1px 1px 2px rgba(26,26,44,0.25)',
                '::placeholder': {
                  color: 'rgba(255,255,255,0.75)',
                  textShadow: 'none',
                },
                ':-webkit-autofill': {
                  color: '#fff',
                },
              },
              invalid: {
                color: '#fee',
                textShadow: '2px 2px 4px red',
              },
            },
          }}
        />
      </div>
    </motion.div>
  );
};

export default CheckoutPaymentCard;
