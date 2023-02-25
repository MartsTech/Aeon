import {RootState} from '@lib/store/store-types';
import {createAction, createReducer} from '@reduxjs/toolkit';
import {persistReducer} from 'redux-persist';
import storage from 'redux-persist/lib/storage';
import type {OrderModel} from './orders-types';

export interface OrdersState {
  list: OrderModel[];
}

const initialState: OrdersState = {
  list: [],
};

export const ordersAdded = createAction<OrderModel>('orders/added');

const ordersReducer = createReducer(initialState, builder => {
  builder.addCase(ordersAdded, (state, action) => {
    state.list = [...state.list, action.payload];
  });
});

export const ordersPersistedReducer = persistReducer(
  {
    key: 'orders',
    storage: storage,
    whitelist: ['list'],
  },
  ordersReducer,
);

export const ordersEmptySelector = (state: RootState) =>
  state.orders.list.length === 0;

export const ordersListSelector = (state: RootState) => state.orders.list;
