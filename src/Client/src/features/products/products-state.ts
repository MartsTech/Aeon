import type {RootState} from '@lib/store/store-types';
import {createAction, createReducer} from '@reduxjs/toolkit';
import type {ProductsListModal} from './products-types';

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

export const productsReducer = createReducer(initialState, builder => {
  builder.addCase(productsHydrated, (state, action) => {
    state.hydrated = true;
    state.list = action.payload.list;
  });
  builder.addCase(productsLoaded, (state, action) => {
    state.list = action.payload.list;
  });
});

export const productsListSelector = (state: RootState): ProductsState['list'] =>
  state.products.list;
