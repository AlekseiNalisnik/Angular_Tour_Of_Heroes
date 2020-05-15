import { Injectable } from '@angular/core';
import { Subject, Subscription, Observable, BehaviorSubject } from 'rxjs';
import { filter, map } from 'rxjs/operators';

import { EventData } from './event-data';

// export const enum EventType {
//   EVENT_1 = 'event_1',
//   EVENT_2 = 'event_2',
//   EVENT_3 = 'event_3',
// }

// export interface BusEvent {
//   type: EventType;
//   payload: any;
// }

// @Injectable({
//   providedIn: 'root',
// })
// export class EventbusService {
//   private _eventSubject = new Subject<BusEvent>();

//   public on<T = any>(type: EventType): Observable<T> {
//     return this._eventSubject.pipe(
//       filter(event => event.type === type),
//       map(event => event.payload)
//     );
//   }

//   public next(event: BusEvent): void {
//     this._eventSubject.next(event);
//   }
// }
// export class EventBusService {
//   public subject = new Subject();

//   constructor() {}

//   emit(event: EventData, data: any) {
//     this.subject.next({event, data});
//   }

//   on(eventName: string, action: any): Subscription {
//     return this.subject.pipe(
//       filter((e: EventData) => e.name === eventName),
//       map((e: EventData) => e.value)  // e['value']
//     )
//     .subscribe(action);
//   }
// }


@Injectable({
  providedIn: 'root',
})
export class EventBusService {
  private dataSource = new Subject<any>();
  currentData = this.dataSource.asObservable();

  constructor() {}

  changeData(data: any) {
    this.dataSource.next(data);
  }
}