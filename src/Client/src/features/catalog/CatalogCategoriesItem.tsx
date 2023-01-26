import {
  categoriesSelected,
  categoriesSelectedIdSelector,
} from '@features/categories/categories-state';
import type {CategoriesListModal} from '@features/categories/categories-types';
import {useStoreDispatch, useStoreSelector} from '@lib/store/store-hooks';
import {FC, useMemo} from 'react';

interface Props {
  item: CategoriesListModal;
}

const CatalogCategoriesItem: FC<Props> = ({item}) => {
  const selectedId = useStoreSelector(categoriesSelectedIdSelector);

  const dispatch = useStoreDispatch();

  const selected = useMemo(() => {
    return selectedId === item.id;
  }, [selectedId, item.id]);

  return (
    <span
      onClick={() => dispatch(categoriesSelected({id: item.id}))}
      className={`relative cursor-pointer p-4 text-lg capitalize
      opacity-50 transition-opacity duration-200 before:underline
      hover:opacity-100 hover:before:w-1/3 sm:ml-4 ${
        selected && 'font-bold opacity-100 before:left-8 before:w-almost'
      }`}
      style={{flex: '0 0 auto'}}>
      {item.name}
    </span>
  );
};

export default CatalogCategoriesItem;
