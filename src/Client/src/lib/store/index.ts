import {appReducer} from '@features/app/app-state';
import {authPersistedReducer} from '@features/auth/auth-state';
import {bookmarksMiddleware} from '@features/bookmarks/bookmarks-middleware';
import {bookmarksPersistedReducer} from '@features/bookmarks/bookmarks-state';
import {cartMiddleware} from '@features/cart/cart-middleware';
import {cartPersistedReducer} from '@features/cart/cart-state';
import {cateogoriesMiddleware} from '@features/categories/categories-middleware';
import {categoriesPersistedReducer} from '@features/categories/categories-state';
import {checkoutMiddleware} from '@features/checkout/checkout-middleware';
import {checkoutPersistedReducer} from '@features/checkout/checkout-state';
import {ordersMiddleware} from '@features/orders/orders-middleware';
import {ordersPersistedReducer} from '@features/orders/orders-state';
import {productMiddleware} from '@features/product/product-middleware';
import {productPersistedReducer} from '@features/product/product-state';
import {productsMiddleware} from '@features/products/products-middleware';
import {productsPersistedReducer} from '@features/products/products-state';
import {api} from '@lib/api';
import {combineReducers, configureStore} from '@reduxjs/toolkit';
import {createWrapper} from 'next-redux-wrapper';
import {FLUSH, PAUSE, PERSIST, PURGE, REGISTER, REHYDRATE} from 'redux-persist';

export const rootReducer = combineReducers({
  [api.reducerPath]: api.reducer,
  app: appReducer,
  auth: authPersistedReducer,
  categories: categoriesPersistedReducer,
  products: productsPersistedReducer,
  product: productPersistedReducer,
  bookmarks: bookmarksPersistedReducer,
  cart: cartPersistedReducer,
  checkout: checkoutPersistedReducer,
  orders: ordersPersistedReducer,
});

export const makeStore = () =>
  configureStore({
    reducer: rootReducer,
    middleware: getDefaultMiddleware =>
      getDefaultMiddleware({
        serializableCheck: {
          ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER],
        },
      }).concat(
        api.middleware,
        cateogoriesMiddleware,
        productsMiddleware,
        productMiddleware,
        bookmarksMiddleware,
        cartMiddleware,
        checkoutMiddleware,
        ordersMiddleware,
      ),
  });

export const storeWrapper = createWrapper(makeStore);
