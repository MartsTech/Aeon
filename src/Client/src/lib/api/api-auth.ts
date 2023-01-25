import type {RootState} from '@lib/store/store-types';
import type {ApiHeaders} from './api-types';

export const setAuthorizationHeaders = (
  headers: Headers,
  api: ApiHeaders,
): Headers => {
  const state = api.getState() as RootState;
  const {session} = state.auth;

  if (session !== null) {
    headers.set('Authorization', `Bearer ${session.accessToken}`);
  }
  return headers;
};
