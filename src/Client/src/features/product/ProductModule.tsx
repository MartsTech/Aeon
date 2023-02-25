import {authSignedSelector} from '@features/auth/auth-state';
import {bookmarksApi} from '@features/bookmarks/bookmarks-api';
import {bookmarksCurrentSelector} from '@features/bookmarks/bookmarks-state';
import {
  cartIsAddedSelector,
  cartItemAdded,
  cartItemRemoved,
} from '@features/cart/cart-state';
import {ShoppingCartIcon} from '@heroicons/react/24/outline';
import {BookmarkIcon, TagIcon} from '@heroicons/react/24/solid';
import Button from '@lib/components/button/Button';
import {useStoreDispatch, useStoreSelector} from '@lib/store/store-hooks';
import {pageTransition, pageZoom} from '@lib/utils/animations';
import {motion} from 'framer-motion';
import Image from 'next/image';
import {useRouter} from 'next/router';
import {useCallback} from 'react';
import {productDetailsSelector} from './product-state';

const ProductModule = () => {
  const signed = useStoreSelector(authSignedSelector);
  const product = useStoreSelector(productDetailsSelector);

  const bookmark = useStoreSelector(state =>
    bookmarksCurrentSelector(state, product?.id || ''),
  );

  const inCart = useStoreSelector(state =>
    cartIsAddedSelector(state, product?.id || ''),
  );

  const dispatch = useStoreDispatch();

  const router = useRouter();

  const onBookmarkClick = useCallback(() => {
    if (!signed) {
      router.push('/login');
      return;
    }

    if (typeof product?.id !== 'string') {
      return;
    }

    if (!bookmark) {
      dispatch(bookmarksApi.endpoints.addBookmark.initiate(product.id));
    } else {
      dispatch(bookmarksApi.endpoints.deleteBookmark.initiate(bookmark.id));
    }
  }, [bookmark, product, signed, dispatch]);

  const onCartClick = useCallback(() => {
    if (typeof product?.id !== 'string') {
      return;
    }

    if (!inCart) {
      dispatch(cartItemAdded(product.id));
    } else {
      dispatch(cartItemRemoved(product.id));
    }
  }, [product, inCart, dispatch]);

  if (!product) {
    return null;
  }

  return (
    <motion.div
      initial="initial"
      animate="in"
      exit="out"
      variants={pageZoom}
      transition={pageTransition}
      className="p-6 pt-20 md:p-12">
      <div className="flex flex-col md:flex-row">
        <motion.div
          layoutId={product?.id}
          className="relative overflow-hidden rounded-2xl bg-white 
          pb-[50%] shadow-lg"
          style={{flex: '0 0 calc(100% / 2.5)'}}>
          <Image
            fill
            src={product?.image || '/images/default.jpg'}
            alt={product?.title || 'Product'}
            className="absolute object-contain p-4"
          />
        </motion.div>
        <div className="flex flex-col p-6 md:p-12 md:pr-4">
          <h5 className="text-xl font-bold line-clamp-3">{product?.title}</h5>
          <p className="relative my-4 text-justify text-base leading-7">
            {product?.description}
          </p>
          <div className="mt-auto">
            <div className="m-1 flex items-baseline space-x-1">
              <h4 className="text-2xl font-black">${product?.price}</h4>
              {true && (
                <del className="text-sm text-red-600">
                  ${(product?.price - product?.discount).toFixed()}
                </del>
              )}
            </div>
            {true && (
              <p className="mb-6 flex items-center text-[#2e8b57]">
                <TagIcon className="mr-2 h-5 w-5 !fill-[transparent] stroke-current stroke-1 text-xl" />
                Free Delivery Available
              </p>
            )}
            <div className="mt-6 flex space-x-4">
              {inCart ? (
                <Button variant="primary" onClick={onCartClick}>
                  <ShoppingCartIcon className="mr-2 h-5 w-5 fill-white" /> Added
                </Button>
              ) : (
                <Button variant="primary" onClick={onCartClick}>
                  <ShoppingCartIcon className="mr-2 h-5 w-5" /> Add To Cart
                </Button>
              )}
              <Button variant="secondary" onClick={onBookmarkClick}>
                <BookmarkIcon
                  className={`${
                    typeof bookmark !== 'undefined' && '!fill-white'
                  } h-5 w-5 fill-[transparent] stroke-[#fff] stroke-2 !text-xl`}
                />
              </Button>
            </div>
          </div>
        </div>
      </div>
    </motion.div>
  );
};

export default ProductModule;
