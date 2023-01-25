import {categoriesListSelector} from '@features/categories/categories-state';
import {useStoreSelector} from '@lib/store/store-hooks';
import type {FC} from 'react';
import CatalogCategoriesItem from './CatalogCategoriesItem';

const CatalogCategories: FC = () => {
  const categories = useStoreSelector(categoriesListSelector);

  return (
    <div
      className="relative m-6 flex overflow-scroll whitespace-nowrap
      scrollbar-hide sm:mx-12 sm:mt-4 sm:-mb-4">
      <CatalogCategoriesItem
        item={{id: null, name: 'All Categories', products: []}}
      />
      {categories.map(item => (
        <CatalogCategoriesItem key={item.id} item={item} />
      ))}
      <div className="absolute top-0 right-0 h-10 w-1/12 bg-gradient-to-l from-gray-50" />
    </div>
  );
};

export default CatalogCategories;
