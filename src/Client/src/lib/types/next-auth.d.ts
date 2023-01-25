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
    accessToken: string | undefined;
  }
}

declare module 'next-auth/jwt' {
  interface JWT {
    id: string | undefined;
    accessToken: string | undefined;
  }
}
