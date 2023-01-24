import AppProvider from '@features/app/AppProvider';
import {storeWrapper} from '@lib/store';
import '@lib/styles/globals.css';
import type {AppProps} from 'next/app';
import type {FC} from 'react';
import {Provider as StoreProvider} from 'react-redux';
import {persistStore} from 'redux-persist';

const App: FC<AppProps> = ({Component, ...rest}) => {
  const {store, props} = storeWrapper.useWrappedStore(rest);

  persistStore(store);

  return (
    <StoreProvider store={store}>
      <AppProvider>
        <Component {...props.pageProps} />
      </AppProvider>
    </StoreProvider>
  );
};

export default App;
