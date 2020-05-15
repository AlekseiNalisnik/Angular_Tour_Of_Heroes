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
        alt: 'Duck-punk',
        value: 100,
        description: 'Вутан, Один и многие другие',
        name: 'Уточка один.',
        weight: 100,
        cathegory: 'common',
        isSelected: false,
        quantity: 0
      },
      {
        id: 12,
        path: '../../assets/duck.jpg',
        alt: 'Duck-punk',
        value: 150,
        description: 'Нам будет хорошо.',
        name: 'Уточка два.',
        weight: 50,
        cathegory: 'common',
        isSelected: false,
        quantity: 0
      },
      {
        id: 13,
        path: '../../assets/duck.jpg',
        alt: 'Duck-punk',
        value: 2000,
        description: 'Уточка три. Набор игрушек для ванной.',
        name: 'Уточка три.',
        weight: 70,
        cathegory: 'common',
        isSelected: false,
        quantity: 0
      },
    ];

    const cart = [];

    return { users, products, cart};
  }

  getUserById(id: number) {
    const dataFromDb = this.createDb();
    return dataFromDb.users.find(post => post.id === id);
  }


}
