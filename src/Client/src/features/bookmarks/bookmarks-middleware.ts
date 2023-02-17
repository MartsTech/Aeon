import type {StoreMiddleware} from '@lib/store/store-types';
import type {AnyAction} from '@reduxjs/toolkit';
import {HYDRATE} from 'next-redux-wrapper';
import {bookmarksHydrated} from './bookmarks-state';

export const bookmarksMiddleware: StoreMiddleware = store => {
  return next => {
    return (action: AnyAction) => {
      const result = next(action);

      if (action.type === HYDRATE && action.payload.bookmarks.list) {
        store.dispatch(bookmarksHydrated(action.payload.bookmarks.list));
      }

      return result;
    };
  };
};
