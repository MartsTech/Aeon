import type {RootState} from '@lib/store/store-types';
import {createAction, createReducer} from '@reduxjs/toolkit';
import type {ProductsListModal} from './products-types';
import {persistReducer} from 'redux-persist';
import storage from 'redux-persist/lib/storage';

export interface ProductsState {
  hydrated: boolean;
  list: ProductsListModal[];
}

const initialState: ProductsState = {
  hydrated: false,
  list: [],
};

export const productsHydrated = createAction<{list: ProductsState['list']}>(
  'products/hydrated',
);

export const productsLoaded = createAction<{list: ProductsState['list']}>(
  'products/loaded',
);

const productsReducer = createReducer(initialState, builder => {
  builder.addCase(productsHydrated, (state, action) => {
    state.hydrated = true;
    state.list = action.payload.list;
  });
  builder.addCase(productsLoaded, (state, action) => {
    state.list = action.payload.list;
  });
});

export const productsPersistedReducer = persistReducer(
  {
    key: 'products',
    storage: storage,
    whitelist: ['list'],
  },
  productsReducer,
);

export const productsListSelector = (state: RootState): ProductsState['list'] =>
  state.products.list;
