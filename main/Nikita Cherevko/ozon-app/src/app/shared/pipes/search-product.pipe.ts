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
        // console.log('pipe console log', search)
        return products.filter(product => {
            return product.name.toLowerCase().includes(search.toLowerCase());
        });
    }
}