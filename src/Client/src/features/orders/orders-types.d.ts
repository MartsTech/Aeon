import type {ProductsListModal} from '@features/products/products-types';

export interface OrderModel {
  id: string;
  amount: number;
  created: number;
  items: ProductsListModal[];
  type: 'card' | 'cash';
}
