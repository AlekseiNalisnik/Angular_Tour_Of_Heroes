import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { User } from '../interfaces/user';

@Injectable({
  providedIn: 'root',
})
export class InMemoryDataService implements InMemoryDbService {
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
        cost: 390, 
        description: 'Alex',
        weight: 150,
        isSelected: false,
        quantity: 0
      },
      { 
        id: 12, 
        path: '../../assets/duck.jpg', 
        alt: 'Duck-pank', 
        cost: 310, 
        description: 'Nikita',
        weight: 50,
        isSelected: false,
        quantity: 0
      },
      { 
        id: 13, 
        path: '../../assets/duck.jpg', 
        alt: 'Duck-pank', 
        cost: 450, 
        description: 'Den',
        weight: 100,
        isSelected: false,
        quantity: 0
      },
      { 
        id: 14, 
        path: '../../assets/duck.jpg', 
        alt: 'Duck-pank', 
        cost: 123, 
        description: 'Roman',
        weight: 100,
        isSelected: false,
        quantity: 0
      },
    ];
    const basket = [

    ]
    return { users, products, basket };
  }

  genId(users: User[]): number {
    return users.length > 0 ? Math.max(...users.map(hero => hero.id)) + 1 : 701;
  }
}