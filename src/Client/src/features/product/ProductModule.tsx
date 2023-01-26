import {ShoppingCartIcon} from '@heroicons/react/24/outline';
import {BookmarkIcon, TagIcon} from '@heroicons/react/24/solid';
import Button from '@lib/components/button/Button';
import {useStoreSelector} from '@lib/store/store-hooks';
import {pageTransition, pageZoom} from '@lib/utils/animations';
import {motion} from 'framer-motion';
import Image from 'next/image';
import {productDetailsSelector} from './product-state';

const ProductModule = () => {
  const product = useStoreSelector(productDetailsSelector);

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
              {false ? (
                <Button variant="primary">
                  <ShoppingCartIcon className="mr-2 h-5 w-5 fill-white" /> Added
                </Button>
              ) : (
                <Button variant="primary">
                  <ShoppingCartIcon className="mr-2 h-5 w-5" /> Add To Cart
                </Button>
              )}
              <Button variant="secondary">
                <BookmarkIcon
                  className={`${
                    false && '!fill-white'
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
