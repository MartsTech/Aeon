import AccountModule from '@features/account/AccountModule';
import DefaultLayout from '@lib/layouts/DefaultLayout';
import type {NextPageWithLayout} from '@lib/types/page';
import {GetServerSideProps} from 'next';
import {getSession} from 'next-auth/react';
import type {ReactElement} from 'react';

const Account: NextPageWithLayout = () => {
  return <AccountModule />;
};

export default Account;

Account.getLayout = (page: ReactElement) => {
  return <DefaultLayout>{page}</DefaultLayout>;
};

export const getServerSideProps: GetServerSideProps = async ({req}) => {
  const session = await getSession({req});

  if (!session) {
    return {
      redirect: {
        destination: '/',
        permanent: false,
      },
    };
  }

  return {
    props: {},
  };
};
