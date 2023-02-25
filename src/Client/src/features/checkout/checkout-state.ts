import {cartProductsSelector} from '@features/cart/cart-state';
import {RootState} from '@lib/store/store-types';
import {createAction, createReducer} from '@reduxjs/toolkit';
import {persistReducer} from 'redux-persist';
import storage from 'redux-persist/lib/storage';
import type {CheckoutPaymentMethod, CheckoutProduct} from './checkout-types';

export interface CheckoutState {
  success: boolean;
  processing: boolean;
  cardHolder: string;
  error: string | null;
  disabled: boolean;
  paymentMethod: CheckoutPaymentMethod;
}

const initialState: CheckoutState = {
  success: false,
  processing: false,
  cardHolder: '',
  error: null,
  disabled: false,
  paymentMethod: 'card',
};

export const checkoutCardHolderChanged = createAction<string>(
  'checkout/cardHolderChanged',
);

export const checkoutCardChanged = createAction<{
  disabled: boolean;
  error: string | null;
}>('checkout/errorChanged');

export const checkoutPaymentMethodChanged = createAction<CheckoutPaymentMethod>(
  'checkout/paymentMethodChanged',
);

export const checkoutProccessingChanged = createAction<boolean>(
  `checkout/processingChanged`,
);

const checkoutReducer = createReducer(initialState, builder => {
  builder.addCase(checkoutCardHolderChanged, (state, action) => {
    state.cardHolder = action.payload;
  });
  builder.addCase(checkoutCardChanged, (state, action) => {
    state.disabled = action.payload.disabled;
    state.error = action.payload.error;
  });
  builder.addCase(checkoutPaymentMethodChanged, (state, action) => {
    state.paymentMethod = action.payload;
  });
  builder.addCase(checkoutProccessingChanged, (state, action) => {
    state.processing = action.payload;
  });
});

export const checkoutPersistedReducer = persistReducer(
  {
    key: 'checkout',
    storage: storage,
    whitelist: [''],
  },
  checkoutReducer,
);

export const checkoutSuccessSelector = (state: RootState) =>
  state.checkout.success;

export const checkoutProcessingSelector = (state: RootState) =>
  state.checkout.processing;

export const checkoutCardHolderSelector = (state: RootState) =>
  state.checkout.cardHolder;

export const checkoutPaymentMethodSelector = (state: RootState) =>
  state.checkout.paymentMethod;

export const checkoutErrorSelector = (state: RootState) => state.checkout.error;

export const checkoutDisabledSelector = (state: RootState) =>
  state.checkout.disabled;

export const checkoutAllowedSelector = (state: RootState) => {
  const {cardHolder, disabled, error, processing} = state.checkout;

  return !disabled && !processing && !error && cardHolder.length > 0;
};

export const checkoutStatusSelector = (state: RootState) => {
  const {processing, success, paymentMethod} = state.checkout;

  if (processing) {
    return 'Processing...';
  }

  if (success) {
    return 'Success!';
  }

  if (paymentMethod === 'cash') {
    return 'Confirm Order';
  }

  return 'Pay Now';
};

export const checkoutProductsSelector = (
  state: RootState,
): CheckoutProduct[] => {
  const list = state.cart.list;
  const products = cartProductsSelector(state);

  return products.map(item => {
    const cart = list.find(cartItem => cartItem.id === item.id);

    if (!cart) {
      return [];
    }

    return {
      quantity: cart.quantity,
      price_data: {
        currency: 'USD',
        unit_amount: item.price * 100,
        product_data: {
          name: item.title,
          description: item.description,
          images: [
            item.image.length
              ? item.image
              : 'https://aeon.martstech.com/images/placeholder.png',
          ],
        },
      },
    };
  }) as CheckoutProduct[];
};
