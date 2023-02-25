import type {DefaultSession} from 'next-auth';
import type {BuiltInProviderType} from 'next-auth/providers';
import type {ClientSafeProvider, LiteralUnion} from 'next-auth/react';

export interface AuthSession extends DefaultSession {
  user: {
    id: string;
    name: string;
    email: string;
    image: string;
  };
  profile: {
    givenName: string;
    familyName: string;
    name: string;
    country: string;
    postalCode: string;
    state: string;
    streetAddress: string;
    city: string;
  };
  expires: string;
  accessToken: string;
}

export type AuthProviders = Record<
  LiteralUnion<BuiltInProviderType, string>,
  ClientSafeProvider
>;
