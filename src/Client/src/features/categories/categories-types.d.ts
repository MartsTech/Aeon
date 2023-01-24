import type {ProductsListModal} from '@features/products/products-types';

export interface CategoriesListModal {
  id: string;
  name: string;
  products: ProductsListModal[];
}
