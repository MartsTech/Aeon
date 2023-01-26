import AppProvider from '@features/app/AppProvider';
import AuthProvider from '@features/auth/AuthProvider';
import {storeWrapper} from '@lib/store';
import '@lib/styles/globals.css';
import type {AppPropsWithLayout} from '@lib/types/page';
import {SessionProvider} from 'next-auth/react';
import type {FC} from 'react';
import {Provider as StoreProvider} from 'react-redux';
import {persistStore} from 'redux-persist';

const App: FC<AppPropsWithLayout> = ({Component, ...rest}) => {
  const {
    store,
    props: {
      pageProps: {session, ...pageProps},
    },
  } = storeWrapper.useWrappedStore(rest);

  persistStore(store);

  const getLayout = Component.getLayout ?? (page => page);

  return (
    <SessionProvider session={session}>
      <StoreProvider store={store}>
        <AuthProvider>
          <AppProvider>{getLayout(<Component {...pageProps} />)}</AppProvider>
        </AuthProvider>
      </StoreProvider>
    </SessionProvider>
  );
};

export default App;
