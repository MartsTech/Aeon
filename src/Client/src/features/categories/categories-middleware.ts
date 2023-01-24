import type {StoreMiddleware} from '@lib/store/store-types';
import type {AnyAction} from '@reduxjs/toolkit';
import {HYDRATE} from 'next-redux-wrapper';
import {categoriesHydrated} from './categories-state';

export const cateogoriesMiddleware: StoreMiddleware = store => {
  return next => {
    return (action: AnyAction) => {
      const result = next(action);

      if (action.type === HYDRATE) {
        const state = store.getState();

        if (state.categories.hydrated) {
          return result;
        }

        store.dispatch(
          categoriesHydrated({
            list: action.payload.categories.list,
          }),
        );
      }

      return result;
    };
  };
};
