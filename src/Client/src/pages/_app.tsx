import AppProvider from '@features/app/AppProvider';
import AuthProvider from '@features/auth/AuthProvider';
import {storeWrapper} from '@lib/store';
import '@lib/styles/globals.css';
import type {AppPropsWithLayout} from '@lib/types/page';
import {SessionProvider} from 'next-auth/react';
import {FC, useMemo} from 'react';
import {Provider as StoreProvider} from 'react-redux';
import {persistStore} from 'redux-persist';
import {PersistGate} from 'redux-persist/integration/react';

const App: FC<AppPropsWithLayout> = ({Component, ...rest}) => {
  const {
    store,
    props: {
      pageProps: {session, ...pageProps},
    },
  } = storeWrapper.useWrappedStore(rest);

  const persistor = useMemo(() => persistStore(store), [store]);

  const getLayout = Component.getLayout ?? (page => page);

  return (
    <PersistGate persistor={persistor}>
      <StoreProvider store={store}>
        <SessionProvider session={session}>
          <AuthProvider>
            <AppProvider>{getLayout(<Component {...pageProps} />)}</AppProvider>
          </AuthProvider>
        </SessionProvider>
      </StoreProvider>
    </PersistGate>
  );
};

export default App;
