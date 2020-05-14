import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Product } from '../interfaces/product';


@Injectable({
  providedIn: 'root'
})

export class EventBusService {

  private dataSource = new Subject<any>();
  currentData = this.dataSource.asObservable();

  constructor() {
  }

  changeData(data: any) {
    this.dataSource.next(data);
  }

}
