import type {RootState} from '@lib/store/store-types';
import {createAction, createReducer} from '@reduxjs/toolkit';
import {CategoriesListModal} from './categories-types';

export interface CategoriesState {
  hydrated: boolean;
  list: CategoriesListModal[];
}

const initialState: CategoriesState = {
  hydrated: false,
  list: [],
};

export const categoriesHydrated = createAction<{list: CategoriesState['list']}>(
  'categories/hydrated',
);

export const categoriesLoaded = createAction<{list: CategoriesState['list']}>(
  'categories/loaded',
);

export const categoriesReducer = createReducer(initialState, builder => {
  builder.addCase(categoriesHydrated, (state, action) => {
    state.hydrated = true;
    state.list = action.payload.list;
  });
  builder.addCase(categoriesLoaded, (state, action) => {
    state.list = action.payload.list;
  });
});

export const categoriesListSelector = (
  state: RootState,
): CategoriesState['list'] => state.categories.list;
