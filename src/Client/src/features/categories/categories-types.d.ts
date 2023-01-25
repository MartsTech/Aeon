import type {ProductsListModal} from '@features/products/products-types';

export interface CategoriesListModal {
  id: string | null;
  name: string;
  products: ProductsListModal[];
}
