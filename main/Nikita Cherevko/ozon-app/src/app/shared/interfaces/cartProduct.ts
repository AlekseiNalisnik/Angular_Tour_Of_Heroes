import { Product } from './product';

export class CartProduct extends Product{
    isSelected: boolean;
    quantity: number;
}
