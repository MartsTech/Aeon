import type {StoreMiddleware} from '@lib/store/store-types';
import type {AnyAction} from '@reduxjs/toolkit';
import {checkoutApi} from './checkout-api';
import {checkoutSucceded} from './checkout-state';

export const checkoutMiddleware: StoreMiddleware = store => {
  return next => {
    return (action: AnyAction) => {
      const result = next(action);

      if (checkoutApi.endpoints.checkoutPayWithCard.matchFulfilled(action)) {
        store.dispatch(checkoutSucceded());
      } else if (
        checkoutApi.endpoints.checkoutPayWithCash.matchFulfilled(action)
      ) {
        store.dispatch(checkoutSucceded());
      }

      return result;
    };
  };
};
