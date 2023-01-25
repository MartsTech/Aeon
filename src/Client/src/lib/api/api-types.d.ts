import type {BaseQueryApi} from '@reduxjs/toolkit/dist/query';

type ApiHeaders = Pick<
  BaseQueryApi,
  'getState' | 'extra' | 'endpoint' | 'type' | 'forced'
>;
