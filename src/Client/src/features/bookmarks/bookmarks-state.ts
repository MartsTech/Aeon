import {ProductsListModal} from '@features/products/products-types';
import type {RootState} from '@lib/store/store-types';
import {createAction, createReducer} from '@reduxjs/toolkit';
import {persistReducer} from 'redux-persist';
import storage from 'redux-persist/lib/storage';
import type {BookmarkModel, WishlistModal} from './bookmarks-types';

export interface BookmarksState {
  list: WishlistModal[] | null;
}

const initialState: BookmarksState = {
  list: null,
};

export const bookmarksHydrated =
  createAction<BookmarksState['list']>('bookmarks/hydrated');

export const bookmarksLoaded =
  createAction<BookmarksState['list']>('bookmarks/loaded');

export const bookmarksCreated =
  createAction<WishlistModal>('bookmarks/created');

export const bookmarksAdded = createAction<BookmarkModel>('bookmarks/added');

export const bookmarksRemoved = createAction<string>('bookmarks/removed');

const bookmarksReducer = createReducer(initialState, builder => {
  builder.addCase(bookmarksHydrated, (state, action) => {
    state.list = action.payload;
  });
  builder.addCase(bookmarksLoaded, (state, action) => {
    state.list = action.payload;
  });
  builder.addCase(bookmarksCreated, (state, action) => {
    state.list = [...(state.list || []), action.payload];
  });
  builder.addCase(bookmarksAdded, (state, action) => {
    if (!state.list) {
      return;
    }

    const wishlist = state.list[0];

    state.list = [
      {
        ...wishlist,
        bookmarks: [...(wishlist.bookmarks || []), action.payload],
      },
    ];
  });
  builder.addCase(bookmarksRemoved, (state, action) => {
    if (!state.list) {
      return;
    }

    const wishlist = state.list[0];

    state.list = [
      {
        ...wishlist,
        bookmarks: wishlist.bookmarks?.filter(x => x.id !== action.payload),
      },
    ];
  });
});

export const bookmarksPersistedReducer = persistReducer(
  {
    key: 'bookmarks',
    storage: storage,
    whitelist: ['list'],
  },
  bookmarksReducer,
);

export const bookmarksListSelector = (
  state: RootState,
): BookmarksState['list'] => state.bookmarks.list;

export const bookmarksEmptySelector = (state: RootState): boolean =>
  !state.bookmarks.list?.length ||
  !state.bookmarks.list[0] ||
  !state.bookmarks.list[0].bookmarks.length;

export const bookmarksItemsSelector = (
  state: RootState,
): ProductsListModal[] => {
  if (!state.bookmarks.list || !state.products.list) {
    return [];
  }

  const bookmarks = state.bookmarks.list[0].bookmarks;

  return state.products.list.filter(x =>
    bookmarks.find(y => x.id === y.productId),
  );
};

export const bookmarksCountSelector = (state: RootState): number =>
  state.bookmarks.list?.[0]?.bookmarks?.length || 0;

export const bookmarksCurrentSelector = (
  state: RootState,
  id: string,
): BookmarkModel | undefined => {
  if (!state.bookmarks.list) {
    return undefined;
  }

  const bookmarks = state.bookmarks.list[0].bookmarks;

  return bookmarks.find(x => x.productId === id);
};
