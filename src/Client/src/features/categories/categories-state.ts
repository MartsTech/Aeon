import type {RootState} from '@lib/store/store-types';
import {createAction, createReducer} from '@reduxjs/toolkit';
import {persistReducer} from 'redux-persist';
import storage from 'redux-persist/lib/storage';
import {CategoriesListModal} from './categories-types';

export interface CategoriesState {
  hydrated: boolean;
  list: CategoriesListModal[];
  selectedId: CategoriesListModal['id'] | null;
}

const initialState: CategoriesState = {
  hydrated: false,
  list: [],
  selectedId: null,
};

export const categoriesHydrated = createAction<{list: CategoriesState['list']}>(
  'categories/hydrated',
);

export const categoriesLoaded = createAction<{list: CategoriesState['list']}>(
  'categories/loaded',
);

export const categoriesSelected = createAction<{
  id: CategoriesState['selectedId'];
}>('categories/selected');

const categoriesReducer = createReducer(initialState, builder => {
  builder.addCase(categoriesHydrated, (state, action) => {
    state.hydrated = true;
    state.list = action.payload.list;
    state.selectedId = null;
  });
  builder.addCase(categoriesLoaded, (state, action) => {
    state.list = action.payload.list;
  });
  builder.addCase(categoriesSelected, (state, action) => {
    state.selectedId = action.payload.id;
  });
});

export const categoriesPersistedReducer = persistReducer(
  {
    key: 'categories',
    storage: storage,
    whitelist: ['list'],
  },
  categoriesReducer,
);

export const categoriesListSelector = (
  state: RootState,
): CategoriesState['list'] => state.categories.list;

export const categoriesSelectedIdSelector = (
  state: RootState,
): CategoriesState['selectedId'] => state.categories.selectedId;

export const categoriesSelectedSelector = (
  state: RootState,
): CategoriesListModal | undefined => {
  const selectedId = categoriesSelectedIdSelector(state);
  const list = categoriesListSelector(state);
  return list.find(item => item.id === selectedId);
};
