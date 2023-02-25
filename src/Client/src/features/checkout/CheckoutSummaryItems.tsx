import {
  cartListSelector,
  cartProductsSelector,
  cartTotalPriceSelector,
} from '@features/cart/cart-state';
import {useStoreSelector} from '@lib/store/store-hooks';
import CheckoutSummaryItem from './CheckoutSummaryItem';

const CheckoutSummaryItems = () => {
  const cart = useStoreSelector(cartListSelector);
  const products = useStoreSelector(cartProductsSelector);
  const cartTotalPrice = useStoreSelector(cartTotalPriceSelector);

  return (
    <div className="mt-6">
      {products.map(item => {
        const cartItem = cart.find(y => y.id === item.id);

        if (!cartItem) {
          return null;
        }

        return (
          <CheckoutSummaryItem
            key={item.id}
            title={item.title}
            price={(item.price * cartItem.quantity).toFixed(2)}
          />
        );
      })}
      <CheckoutSummaryItem title={'Delivery Charges'} price={4.99} />
      <hr className="my-4 bg-[#acacad]" />
      <CheckoutSummaryItem
        title={'Total'}
        price={(cartTotalPrice + 4.99).toFixed(2)}
      />
      <CheckoutSummaryItem
        title={'Tax'}
        quantity={'+5%'}
        price={(cartTotalPrice * 0.05).toFixed(2)}
      />
      <hr className="my-4 bg-[#acacad]" />
      <CheckoutSummaryItem
        title={'Grand Total'}
        price={(cartTotalPrice + cartTotalPrice * 0.05 + 4.99).toFixed(2)}
        total
      />
    </div>
  );
};

export default CheckoutSummaryItems;
