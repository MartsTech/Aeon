import {useStoreDispatch, useStoreSelector} from '@lib/store/store-hooks';
import {useSession} from 'next-auth/react';
import {FC, ReactNode, useEffect} from 'react';
import {authLoggedIn, authLogggedOut, authSignedSelector} from './auth-state';

interface Props {
  children: ReactNode;
}

const AuthProvider: FC<Props> = ({children}) => {
  const signed = useStoreSelector(authSignedSelector);

  const {data, status} = useSession();

  const dispatch = useStoreDispatch();

  useEffect(() => {
    if (status === 'authenticated' && !signed) {
      dispatch(
        authLoggedIn({
          session: {
            user: {
              id: data.user.id ?? '',
              name: data.user.name,
              email: data.user.email,
              image: data.user.image,
            },
            profile: {
              givenName: data.profile?.givenName ?? '',
              familyName: data.profile?.familyName ?? '',
              name: data.profile?.name ?? '',
              country: data.profile?.country ?? '',
              city: data.profile?.city ?? '',
              postalCode: data.profile?.postalCode ?? '',
              state: data.profile?.state ?? '',
              streetAddress: data.profile?.streetAddress ?? '',
            },
            expires: data.expires,
            accessToken: data.accessToken ?? '',
          },
        }),
      );
    } else if (status === 'unauthenticated' && signed) {
      dispatch(authLogggedOut());
    }
  }, [status, data, signed, dispatch]);

  return <>{children}</>;
};

export default AuthProvider;
