import { Pipe, PipeTransform } from "@angular/core";
import { Product } from '../interfaces/product';

@Pipe({
    name: 'SearchProduct'
})
export class SearchProductPipe implements PipeTransform {
    transform(products: Product[], search = ''): Product[] {
        if(!search.trim()) {
            return products;
        }

        return products.filter(product => {
            return product.description.toLowerCase().includes(search.toLowerCase());
        });
    }
}