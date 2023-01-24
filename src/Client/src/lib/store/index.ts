import {appReducer} from '@features/app/app-state';
import {cateogoriesMiddleware} from '@features/categories/categories-middleware';
import {categoriesReducer} from '@features/categories/categories-state';
import {productsMiddleware} from '@features/products/products-middleware';
import {productsReducer} from '@features/products/products-state';
import {api} from '@lib/api';
import {combineReducers, configureStore, Middleware} from '@reduxjs/toolkit';
import {createWrapper} from 'next-redux-wrapper';
import {createLogger} from 'redux-logger';
import {FLUSH, PAUSE, PERSIST, PURGE, REGISTER, REHYDRATE} from 'redux-persist';

const middlewares: Middleware[] = [];

if (process.env.NODE_ENV === `development`) {
  const logger = createLogger({
    diff: true,
    collapsed: true,
  });

  middlewares.push(logger);
}

export const rootReducer = combineReducers({
  [api.reducerPath]: api.reducer,
  app: appReducer,
  products: productsReducer,
  categories: categoriesReducer,
});

const makeStore = () =>
  configureStore({
    reducer: rootReducer,
    middleware: getDefaultMiddleware =>
      getDefaultMiddleware({
        serializableCheck: {
          ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER],
        },
      }).concat(
        api.middleware,
        productsMiddleware,
        cateogoriesMiddleware,
        ...middlewares,
      ),
  });

export const storeWrapper = createWrapper(makeStore);
