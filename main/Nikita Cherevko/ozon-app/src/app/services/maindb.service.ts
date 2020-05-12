import { Injectable } from '@angular/core';
import {InMemoryWebApiModule } from 'angular-in-memory-web-api';


@Injectable({
  providedIn: 'root'
})
export class MaindbService implements InMemoryWebApiModule{

  constructor() { }

  createDb() {
    const users = [
      {
        id: 701,
        email: '2@2',
        password: 'password',
        phone: '+7 911 111 1111',
        name: 'Ivan Ivanov',
        sex: 'Man',
        birtdate: '25.06.2005'
      },
      {
        id: 702,
        email: '1@1',
        password: '1',
        phone: '+7 911 111 1111',
        name: 'John Smith',
        sex: 'Man',
        birtdate: '15.15.1515'
      },
    ];
    const products = [
      {
        id: 11,
        path: '../../assets/duck.jpg',
        alt: 'Duck-pank',
        value: 3930,
        description: 'Панки. Набор игрушек для ванной. Уточка панк и анархия.',
        name: 'Duck',
        weight: 1032,
        cathegory: 'common',
        isSelected: false,
        quantity: 0
      },
      {
        id: 12,
        path: '../../assets/duck.jpg',
        alt: 'Duck-pank',
        value: 39,
        description: 'Панки. Набор игрушек для ванной. Уточка панк и анархия.',
        name: 'Duck',
        weight: 1032,
        cathegory: 'common',
        isSelected: false,
        quantity: 0
      },
      {
        id: 13,
        path: '../../assets/duck.jpg',
        alt: 'Duck-pank',
        value: 39134,
        description: 'Панки. Набор игрушек для ванной. Уточка панк и анархия.',
        name: 'Duck',
        weight: 1032,
        cathegory: 'common',
        isSelected: false,
        quantity: 0
      },
    ];

    const cart = [];

    return { users, products, cart};
  }

  getProductById(id: number) {
    const dataFromDb = this.createDb();
    return dataFromDb.products.find(post => post.id === id);
  }

  getUserById(id: number) {
    const dataFromDb = this.createDb();
    return dataFromDb.users.find(post => post.id === id);
  }


}
