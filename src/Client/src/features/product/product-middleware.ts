import type {StoreMiddleware} from '@lib/store/store-types';
import type {AnyAction} from '@reduxjs/toolkit';
import {HYDRATE} from 'next-redux-wrapper';
import {productHydrated} from './product-state';

export const productMiddleware: StoreMiddleware = store => {
  return next => {
    return (action: AnyAction) => {
      const result = next(action);

      if (action.type === HYDRATE && action.payload.product.details) {
        store.dispatch(
          productHydrated({
            details: action.payload.product.details,
          }),
        );
      }

      return result;
    };
  };
};
