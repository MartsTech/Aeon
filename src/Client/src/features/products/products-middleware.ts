import type {StoreMiddleware} from '@lib/store/store-types';
import type {AnyAction} from '@reduxjs/toolkit';
import {HYDRATE} from 'next-redux-wrapper';
import {productsHydrated} from './products-state';

export const productsMiddleware: StoreMiddleware = store => {
  return next => {
    return (action: AnyAction) => {
      const result = next(action);

      if (action.type === HYDRATE) {
        const state = store.getState();

        if (state.products.hydrated) {
          return result;
        }

        store.dispatch(
          productsHydrated({
            list: action.payload.products.list,
          }),
        );
      }

      return result;
    };
  };
};
