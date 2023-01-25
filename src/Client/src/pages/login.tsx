import {storeWrapper} from '@lib/store';
import {NextPage} from 'next';
import {getSession} from 'next-auth/react';

const Login: NextPage = () => {
  return null;
};

export default Login;

export const getServerSideProps = storeWrapper.getServerSideProps(store => {
  return async ({req}) => {
    const session = await getSession({req});

    if (session) {
      return {
        redirect: {
          destination: '/',
          permanent: false,
        },
      };
    }

    return {
      redirect: {
        destination: '/api/auth/signin',
        permanent: false,
      },
    };
  };
});
