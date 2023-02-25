import 'next-auth';
import 'next-auth/jwt';

declare module 'next-auth' {
  interface Session {
    user: {
      id: string | undefined;
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
    accessToken: string | undefined;
  }

  interface Profile {
    given_name: string;
    family_name: string;
    name: string;
    country: string;
    postalCode: string;
    state: string;
    streetAddress: string;
    city: string;
  }
}

declare module 'next-auth/jwt' {
  interface JWT {
    id: string | undefined;
    accessToken: string | undefined;
    givenName: string;
    familyName: string;
    name: string;
    country: string;
    postalCode: string;
    state: string;
    streetAddress: string;
    city: string;
  }
}
