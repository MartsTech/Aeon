import CartModule from '@features/cart/CartModule';
import DefaultLayout from '@lib/layouts/DefaultLayout';
import type {NextPageWithLayout} from '@lib/types/page';
import type {ReactElement} from 'react';

const Cart: NextPageWithLayout = () => {
  return <CartModule />;
};

export default Cart;

Cart.getLayout = (page: ReactElement) => {
  return <DefaultLayout>{page}</DefaultLayout>;
};
