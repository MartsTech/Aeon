import type {AuthProviders} from '@features/auth/auth-types';
import {api} from '@lib/api';
import {signIn, signOut} from 'next-auth/react';

export const authApi = api.injectEndpoints({
  endpoints: builder => ({
    authSignIn: builder.mutation<void, {providerId: keyof AuthProviders}>({
      queryFn: async ({providerId}) => {
        try {
          await signIn(providerId);
        } catch (error) {
          return {
            error: {
              status: 500,
              statusText: 'Internal Server Error',
              data: "Couldn't sign in",
            },
          };
        }
        return {
          data: undefined,
        };
      },
    }),
    authSignOut: builder.mutation<void, void>({
      queryFn: async () => {
        try {
          await signOut();
        } catch (error) {
          return {
            error: {
              status: 500,
              statusText: 'Internal Server Error',
              data: "Couldn't sign out",
            },
          };
        }
        return {
          data: undefined,
        };
      },
    }),
  }),
});
