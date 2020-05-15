import { Product } from './product';

export interface BasketProduct extends Product {
    isSelected: boolean;
    quantity: number;
}