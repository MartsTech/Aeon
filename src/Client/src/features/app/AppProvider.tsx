import {useStoreDispatch} from '@lib/store/store-hooks';
import Head from 'next/head';
import {FC, ReactNode, useEffect} from 'react';
import appConstants from './app-constants';
import {appMounted} from './app-state';

interface Props {
  children: ReactNode;
}

const AppProvider: FC<Props> = ({children}) => {
  const dispatch = useStoreDispatch();

  useEffect(() => {
    dispatch(appMounted());
  }, [dispatch]);

  return (
    <>
      <Head>
        <title>{appConstants.APP_NAME}</title>
        <meta name="description" content={appConstants.APP_DESCRIPTION} />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link rel="icon" href="/favicon.ico" />
      </Head>
      {children}
    </>
  );
};

export default AppProvider;
