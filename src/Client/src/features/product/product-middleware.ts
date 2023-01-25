import type {StoreMiddleware} from '@lib/store/store-types';
import type {AnyAction} from '@reduxjs/toolkit';
import {HYDRATE} from 'next-redux-wrapper';
import {productHydrated} from './product-state';

export const productMiddleware: StoreMiddleware = store => {
  return next => {
    return (action: AnyAction) => {
      const result = next(action);

      if (action.type === HYDRATE) {
        const state = store.getState();

        if (!action.payload.product.details) {
          return result;
        }

        if (state.product.details?.id === action.payload.product.details.id) {
          return result;
        }

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
