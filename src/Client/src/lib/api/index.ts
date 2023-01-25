import {createApi, fetchBaseQuery} from '@reduxjs/toolkit/query/react';
import {HYDRATE} from 'next-redux-wrapper';
import {setAuthorizationHeaders} from './api-auth';

export const api = createApi({
  reducerPath: 'api',
  baseQuery: fetchBaseQuery({
    baseUrl: process.env.NEXT_PUBLIC_API_URL,
    prepareHeaders: (headers, api) => {
      headers = setAuthorizationHeaders(headers, api);
      return headers;
    },
  }),
  extractRehydrationInfo(action, {reducerPath}) {
    if (action.type === HYDRATE) {
      return action.payload[reducerPath];
    }
  },
  endpoints: () => ({}),
});
