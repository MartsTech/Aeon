import type {RootState} from '@lib/store/store-types';
import {createAction, createReducer} from '@reduxjs/toolkit';

export interface AppState {
  mounted: boolean;
}

const initialState: AppState = {
  mounted: false,
};

export const appMounted = createAction('app/mounted');

export const appReducer = createReducer(initialState, builder => {
  builder.addCase(appMounted, state => {
    state.mounted = true;
  });
});

export const appMountedSelector = (state: RootState): AppState['mounted'] =>
  state.app.mounted;
