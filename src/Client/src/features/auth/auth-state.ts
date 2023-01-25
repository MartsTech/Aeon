import type {RootState} from '@lib/store/store-types';
import {createAction, createReducer} from '@reduxjs/toolkit';
import {persistReducer} from 'redux-persist';
import storage from 'redux-persist/lib/storage';
import type {AuthSession} from './auth-types';

export interface AuthState {
  session: AuthSession | null;
}

const initialState: AuthState = {
  session: null,
};

export const authLoggedIn = createAction<{session: AuthState['session']}>(
  'auth/loggedIn',
);

export const authLogggedOut = createAction('auth/loggedOut');

const authReducer = createReducer(initialState, builder => {
  builder.addCase(authLoggedIn, (state, action) => {
    state.session = action.payload.session;
  });
  builder.addCase(authLogggedOut, state => {
    state.session = null;
  });
});

export const authPersistedReducer = persistReducer(
  {
    key: 'auth',
    storage: storage,
    whitelist: ['session'],
  },
  authReducer,
);

export const authSignedSelector = (state: RootState): boolean =>
  state.auth.session !== null;

export const authUserSelecter = (
  state: RootState,
): AuthSession['user'] | undefined => state.auth.session?.user;
