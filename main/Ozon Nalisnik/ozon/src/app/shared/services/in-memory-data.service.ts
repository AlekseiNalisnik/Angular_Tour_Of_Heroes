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
        phoneNumber: '+7 911 111 1111',
        surname: 'Nalisnik',
        name: 'Alex',
        patronymic: 'Nikolaevich',
        sex: 'Man',
        birtdate: '25.06.2005'
      },
      {
        id: 702,
        email: '1@1',
        password: '1',
        phoneNumber: '+7 911 111 1111',
        surname: 'Cherevko',
        name: 'Nikita',
        patronymic: 'Aleksandrovich',
        sex: 'Man',
        birtdate: '15.15.1515'
      },
    ];
    const products = [
      {
        id: 11,  
        alt: 'Duck-pank', 
        price: 390, 
        description: 'Alex',
        weight: 150,
        name: 'Alex',
        images: [{imagePath: '../../assets/duck.jpg'}],
        isSelected: false,
        quantity: 0
      },
      { 
        id: 12, 
        alt: 'Duck-pank', 
        price: 310, 
        description: 'Nikita',
        weight: 50,
        name: 'Nikita',
        images: [{imagePath: '../../assets/duck.jpg'}],
        isSelected: false,
        quantity: 0
      },
      { 
        id: 13, 
        alt: 'Duck-pank', 
        price: 450, 
        description: 'Den',
        weight: 100,
        name: 'Den',
        images: [{imagePath: '../../assets/duck.jpg'}],
        isSelected: false,
        quantity: 0
      },
      { 
        id: 14, 
        alt: 'Duck-pank',
        price: 123, 
        description: 'Roman',
        weight: 100,
        name: 'Roman',
        images: [{imagePath: '../../assets/duck.jpg'}],
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