import { Component, OnInit, Input } from '@angular/core';

import { Product } from '../../interfaces/product';

@Component({
  selector: 'app-basket-order-panel',
  templateUrl: './basket-order-panel.component.html',
  styleUrls: ['./basket-order-panel.component.css']
})
export class BasketOrderPanelComponent implements OnInit {
  @Input() basketProducts: Product[] = [];
  selectedProducts: Product[] = [];
  totalWeight: number = 0;
  totalCost: number = 0;
  finalCost: number = 0;
  percent: number = 15;

  constructor() { }

  ngOnInit(): void {

  }
  

  // Можно найти ХУК и получше...
  ngDoCheck(): void {
    // ПРОВЕРКА на наличие товара в корзине(Если его нет в корзине, он не может быть выбран)
    if(this.compareArraysStructure(this.basketProducts, this.selectedProducts) === false) {
      this.selectedProducts = [];
    }

    for(let i = 0; i < this.basketProducts.length; i++) {
      // Если продукт отмечен и его нет в "выбранных Продуктах", добавляем!
      if(this.basketProducts[i].isSelected === true && 
        !this.selectedProducts.includes(this.basketProducts[i])
      ) {
        this.selectedProducts.push(this.basketProducts[i]);
      }

      // Если продукт не отмечен и он есть в "выбранных Продуктах", удаляем!
      if(this.basketProducts[i].isSelected === false && 
        this.selectedProducts.includes(this.basketProducts[i])
      ) {
        let selectedIndex = this.selectedProducts.indexOf(this.basketProducts[i]);
        this.selectedProducts.splice(selectedIndex, 1);
      }
    }

    // Получаем изменившийся вес всех продуктов
    this.getTotalWeight();

    // Получаем изменившиеся цены всех продуктов и цены с учётом процента
    this.getTotalAndFinalCosts();
  }

  compareArraysStructure(arr, subarr): boolean {
    if(subarr.length > arr.length) {
      return false;
    }

    for(let i = 0; i < arr.length; i++) {
      if (arr.indexOf(subarr[i]) === -1) {
        return false;
      }
    }

    return true;
  }

  getTotalWeight() {
    this.totalWeight = 0;
    for(let i = 0; i < this.basketProducts.length; i++) {
      this.totalWeight += this.basketProducts[i].weight * this.basketProducts[i].quantity;
    }
  }

  getTotalAndFinalCosts() {
    this.totalCost = 0;
    this.finalCost = 0;
    for(let i = 0; i < this.selectedProducts.length; i++) {
      this.totalCost += this.selectedProducts[i].cost * this.selectedProducts[i].quantity;
    }
    this.finalCost = this.totalCost * (1 - this.percent / 100);
  }

}
