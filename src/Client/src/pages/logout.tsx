import {storeWrapper} from '@lib/store';
import {NextPage} from 'next';
import {getSession} from 'next-auth/react';

const Logout: NextPage = () => {
  return null;
};

export default Logout;

export const getServerSideProps = storeWrapper.getServerSideProps(store => {
  return async ({req}) => {
    const session = await getSession({req});

    if (!session) {
      return {
        redirect: {
          destination: '/',
          permanent: false,
        },
        props: {
          session,
        },
      };
    }

    return {
      redirect: {
        destination: '/api/auth/signout',
        permanent: false,
      },
      props: {
        session,
      },
    };
  };
});
