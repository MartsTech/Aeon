import {ProductsListModal} from '@features/products/products-types';
import type {RootState} from '@lib/store/store-types';
import {createAction, createReducer} from '@reduxjs/toolkit';
import {persistReducer} from 'redux-persist';
import storage from 'redux-persist/lib/storage';
import {CartItem} from './cart-types';

export interface CartState {
  list: CartItem[];
}

const initialState: CartState = {
  list: [],
};

export const cartItemAdded = createAction<string>('cart/itemAdded');

export const cartItemRemoved = createAction<string>('cart/itemRemoved');

export const cartQuantityChanged = createAction<{id: string; quantity: number}>(
  'cart/quantityChanged',
);

export const cartCleared = createAction('cart/cleared');

const cartReducer = createReducer(initialState, builder => {
  builder.addCase(cartItemAdded, (state, action) => {
    const item: CartItem = {
      id: action.payload,
      quantity: 1,
    };
    state.list = [...state.list, item];
  });
  builder.addCase(cartItemRemoved, (state, action) => {
    state.list = state.list.filter(item => item.id !== action.payload);
  });
  builder.addCase(cartQuantityChanged, (state, action) => {
    const {id, quantity} = action.payload;

    if (quantity === 0) {
      state.list = state.list.filter(item => item.id !== id);
      return;
    }

    state.list = state.list.map(item => {
      if (item.id === id) {
        return {
          ...item,
          quantity,
        };
      }
      return item;
    });
  });
  builder.addCase(cartCleared, state => {
    state.list = [];
  });
});

export const cartPersistedReducer = persistReducer(
  {
    key: 'cart',
    storage: storage,
    whitelist: ['list'],
  },
  cartReducer,
);

export const cartListSelector = (state: RootState): CartState['list'] =>
  state.cart.list;

export const cartIsEmptySelector = (state: RootState): boolean =>
  state.cart.list.length === 0;

export const cartIsAddedSelector = (state: RootState, id: string): boolean =>
  state.cart.list.some(item => item.id === id);

export const cartProductQuantitySelector = (
  state: RootState,
  id: string,
): number => state.cart.list.find(item => item.id === id)?.quantity || 0;

export const cartTotalCountSelector = (state: RootState): number =>
  state.cart.list.reduce((acc, item) => acc + item.quantity, 0);

export const cartProductsSelector = (state: RootState): ProductsListModal[] =>
  state.products.list?.filter(product =>
    cartIsAddedSelector(state, product.id),
  ) || [];

export const cartTotalPriceSelector = (state: RootState): number => {
  const products = cartProductsSelector(state);
  return products.reduce(
    (acc, product) =>
      acc + product.price * cartProductQuantitySelector(state, product.id),
    0,
  );
};
