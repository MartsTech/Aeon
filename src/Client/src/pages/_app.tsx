import AppProvider from '@features/app/AppProvider';
import {storeWrapper} from '@lib/store';
import '@lib/styles/globals.css';
import type {AppPropsWithLayout} from '@lib/types/page';
import type {FC} from 'react';
import {Provider as StoreProvider} from 'react-redux';
import {persistStore} from 'redux-persist';

const App: FC<AppPropsWithLayout> = ({Component, ...rest}) => {
  const {store, props} = storeWrapper.useWrappedStore(rest);

  persistStore(store);

  const getLayout = Component.getLayout ?? (page => page);

  return (
    <StoreProvider store={store}>
      <AppProvider>{getLayout(<Component {...props.pageProps} />)}</AppProvider>
    </StoreProvider>
  );
};

export default App;
