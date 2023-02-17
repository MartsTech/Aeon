import type {RootState} from '@lib/store/store-types';
import type {ApiHeaders} from './api-types';

export const setAuthorizationHeaders = (
  headers: Headers,
  api: ApiHeaders,
): Headers => {
  const state = api.getState() as RootState;

  const token = state.auth.session?.accessToken;

  if (typeof token === 'string') {
    headers.set('Authorization', `Bearer ${token}`);
  }
  return headers;
};
