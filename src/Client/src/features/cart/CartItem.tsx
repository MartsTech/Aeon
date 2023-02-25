import {ProductsListModal} from '@features/products/products-types';
import {ShoppingCartIcon} from '@heroicons/react/24/solid';
import {useStoreDispatch, useStoreSelector} from '@lib/store/store-hooks';
import {errorAnimation} from '@lib/utils/animations';
import {motion} from 'framer-motion';
import Image from 'next/image';
import Link from 'next/link';
import {useCallback} from 'react';
import {
  cartItemRemoved,
  cartProductQuantitySelector,
  cartQuantityChanged,
} from './cart-state';

interface Props {
  item: ProductsListModal;
}

const CartItem: React.FC<Props> = ({item}) => {
  const quantity = useStoreSelector(state =>
    cartProductQuantitySelector(state, item.id),
  );

  const dispatch = useStoreDispatch();

  const onIncreaseClick = useCallback(() => {
    dispatch(cartQuantityChanged({id: item.id, quantity: quantity + 1}));
  }, [item.id, quantity, dispatch]);

  const onDecreaseClick = useCallback(() => {
    dispatch(cartQuantityChanged({id: item.id, quantity: quantity - 1}));
  }, [item.id, quantity, dispatch]);

  const onRemoveClick = useCallback(() => {
    dispatch(cartItemRemoved(item.id));
  }, [item.id, dispatch]);

  return (
    <motion.div
      initial="initial"
      animate="in"
      exit="out"
      variants={errorAnimation}
      className="flex w-full transform cursor-pointer overflow-hidden
      rounded-lg bg-white shadow-md transition-all duration-200
      hover:scale-105 hover:shadow-lg">
      <motion.div
        layoutId={item.id}
        className="relative flex-1 pb-[10%]"
        style={{flex: '0 0 30%'}}>
        <Link href={`/product/${item.id}`}>
          <div className="h-full w-full flex-1">
            <Image
              src={item.image || '/images/default.jpg'}
              alt={item.title}
              className="absolute h-full w-full object-contain p-3 sm:p-4"
              fill
            />
          </div>
        </Link>
      </motion.div>
      <div className="flex w-full flex-col p-3 sm:p-4">
        <p className="line-clamp-2">{item.title}</p>
        <div className="mt-auto flex items-baseline pt-2">
          <div className="flex flex-col">
            <b className="mr-1 whitespace-pre-wrap">
              ${(item.price * quantity).toFixed(2)}
            </b>
            {true && (
              <del className="text-sm text-[#dc143c]">
                $
                {((item.price + item.price * 0.25) * quantity).toFixed() +
                  '.99'}
              </del>
            )}
          </div>
          <div className="ml-auto flex items-center">
            <div
              className="ml-auto overflow-hidden whitespace-nowrap
            rounded-md bg-[#fafafa] shadow-md">
              <button
                onClick={onDecreaseClick}
                className="h-6 w-6 border-none bg-[#eee]
                text-sm transition-all duration-200">
                -
              </button>
              <span className="p-2">{quantity}</span>
              <button
                onClick={onIncreaseClick}
                className="h-6 w-6 border-none bg-[#eee]
                text-sm transition-all duration-200">
                +
              </button>
            </div>
            <button
              onClick={onRemoveClick}
              data-for="removeTooltip"
              data-tip="Remove from Cart"
              className="ml-2 h-6 rounded-md border-none bg-[#dc143c] px-2 text-white">
              <ShoppingCartIcon className="h-4 w-4" />
            </button>
          </div>
        </div>
      </div>
    </motion.div>
  );
};

export default CartItem;
