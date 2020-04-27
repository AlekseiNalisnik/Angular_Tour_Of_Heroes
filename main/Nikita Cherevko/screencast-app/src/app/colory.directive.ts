import { Directive, HostBinding, HostListener } from '@angular/core';

@Directive({
  selector: '[appColory]'
})

export class ColoryDirective {

  @HostBinding('style.color') myColor: string;

  @HostListener('click', ['$event']) changeColor() {
    this.myColor = '#' + Math.floor(Math.random() * 16234234).toString(16);
  }


  constructor() {
    this.myColor = 'red';
  }

}
