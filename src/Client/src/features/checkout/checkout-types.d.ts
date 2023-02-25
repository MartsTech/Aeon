export type CheckoutPaymentMethod = 'card' | 'cash';

export interface CheckoutProduct {
  quantity: number;
  price_data: CheckoutProductPriceData;
}

export interface CheckoutProductPriceData {
  currency: string;
  unit_amount: number;
  product_data: CheckoutProductData;
}

export interface CheckoutProductData {
  name: string;
  description: string;
  images: string[];
}
