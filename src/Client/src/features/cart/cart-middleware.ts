import {checkoutApi} from '@features/checkout/checkout-api';
import type {StoreMiddleware} from '@lib/store/store-types';
import type {AnyAction} from '@reduxjs/toolkit';
import {cartCleared} from './cart-state';

export const cartMiddleware: StoreMiddleware = store => {
  return next => {
    return (action: AnyAction) => {
      const result = next(action);

      if (checkoutApi.endpoints.checkoutPayWithCard.matchFulfilled(action)) {
        store.dispatch(cartCleared());
      }

      return result;
    };
  };
};
