import { Component, ViewContainerRef, ComponentFactoryResolver, OnInit, ComponentFactory } from '@angular/core';
import { ItemComponent } from './item/item.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'screencast-app';

  constructor() {  }

    ngOnInit() {
    }
}
