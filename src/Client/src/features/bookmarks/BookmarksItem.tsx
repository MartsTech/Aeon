import {ProductsListModal} from '@features/products/products-types';
import {StarIcon} from '@heroicons/react/24/solid';
import styles from '@lib/styles/product.module.css';
import {pageTransition, pageZoom} from '@lib/utils/animations';
import {motion} from 'framer-motion';
import Image from 'next/image';
import Link from 'next/link';
import type {FC} from 'react';

interface BookmarksItemProps {
  item: ProductsListModal;
}

const BookmarksItem: FC<BookmarksItemProps> = ({item}) => {
  return (
    <Link href={`product/${item.id}`}>
      <motion.div
        initial="initial"
        animate="in"
        exit="out"
        variants={pageZoom}
        transition={pageTransition}
        layout
        className="my-5 flex w-full transform cursor-pointer flex-col rounded-lg
      bg-white shadow-md transition-all duration-200 hover:scale-105
      hover:shadow-lg sm:w-3/4">
        <motion.div
          layoutId={item.id}
          className={`product__image relative block w-full 
      overflow-hidden rounded-t-lg pb-[75%] ${styles.productImage}`}>
          {true && (
            <span
              className="absolute top-12 right-8 z-10
          translate-x-1/2 -translate-y-full rotate-45 transform bg-[#f90] py-[0.33rem] px-12
          text-sm font-bold text-white shadow-md">
              Offer!
            </span>
          )}
          <Image
            src={item.image || '/images/default.jpg'}
            fill={true}
            alt={item.title}
            className="object-contain"
          />
        </motion.div>
        <div className="flex w-full flex-1 flex-col justify-between p-4">
          <span
            className="bg-[rgba(26, 26, 44, 0.05)] mb-3 
          rounded-2xl py-1 px-2 text-[0.5rem] uppercase tracking-[2px]
          text-[#1a1a2c]">
            {item.categoryId}
          </span>
          <h6 className="h-10 text-lg line-clamp-3">{item.title}</h6>
          <div className="mt-auto flex items-center justify-between pt-4">
            <p className="product__price">
              <b className="text-2xl font-black">${item.price}</b>{' '}
              {true && (
                <del className="text-red-600">
                  ${(item.price - item.discount).toFixed()}
                </del>
              )}
            </p>
            <div className="flex text-base">
              <StarIcon className="h-6 w-6 text-primary" />
              {0}
            </div>
          </div>
        </div>
      </motion.div>
    </Link>
  );
};

export default BookmarksItem;
