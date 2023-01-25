import type {RootState} from '@lib/store/store-types';
import {createAction, createReducer} from '@reduxjs/toolkit';
import {persistReducer} from 'redux-persist';
import storage from 'redux-persist/lib/storage';
import type {ProductDetailsModal} from './product-types';

export interface ProductState {
  details: ProductDetailsModal | null;
}

const initialState: ProductState = {
  details: null,
};

export const productHydrated = createAction<{details: ProductState['details']}>(
  'product/hydrated',
);

export const productLoaded = createAction<{details: ProductState['details']}>(
  'product/loaded',
);

const productReducer = createReducer(initialState, builder => {
  builder.addCase(productHydrated, (state, action) => {
    state.details = action.payload.details;
  });
  builder.addCase(productLoaded, (state, action) => {
    state.details = action.payload.details;
  });
});

export const productPersistedReducer = persistReducer(
  {
    key: 'product',
    storage: storage,
    whitelist: ['details'],
  },
  productReducer,
);

export const productDetailsSelector = (
  state: RootState,
): ProductState['details'] => state.product.details;
