import {categoriesSelectedSelector} from '@features/categories/categories-state';
import {productsListSelector} from '@features/products/products-state';
import {useStoreSelector} from '@lib/store/store-hooks';
import type {FC} from 'react';
import CatalogProductsItem from './CatalogProductsItem';

const CatalogProducts: FC = () => {
  const category = useStoreSelector(categoriesSelectedSelector);
  const products = useStoreSelector(productsListSelector);

  return (
    <div
      className="m-8 flex flex-col items-center
      sm:grid sm:grid-cols-2 lg:grid-cols-3">
      {typeof category === 'undefined' ? (
        <>
          {products?.map(item => (
            <CatalogProductsItem key={item.id} item={item} />
          ))}
        </>
      ) : (
        <>
          {category.products.map(item => (
            <CatalogProductsItem key={item.id} item={item} />
          ))}
        </>
      )}
    </div>
  );
};

export default CatalogProducts;
