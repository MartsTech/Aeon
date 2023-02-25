import {checkoutApi} from '@features/checkout/checkout-api';
import type {StoreMiddleware} from '@lib/store/store-types';
import type {AnyAction} from '@reduxjs/toolkit';
import {ordersAdded} from './orders-state';

export const ordersMiddleware: StoreMiddleware = store => {
  return next => {
    return (action: AnyAction) => {
      const result = next(action);

      if (checkoutApi.endpoints.checkoutPayWithCard.matchFulfilled(action)) {
        const order = action.payload;

        if (order) {
          store.dispatch(ordersAdded(order));
        }
      }

      return result;
    };
  };
};
