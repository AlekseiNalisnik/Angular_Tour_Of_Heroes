import { Directive, HostBinding, HostListener } from '@angular/core';

@Directive({
  selector: '[appColory]',
  exportAs: 'colory'
})

export class ColoryDirective {

  @HostBinding('style.color') myColor: string;

  @HostListener('click', ['$event']) changeColor() {
    this.setRandomColor();
  }


  constructor() {
    this.myColor = 'red';
  }

  setRandomColor() {
    this.myColor = '#' + Math.floor(Math.random() * 16234234).toString(16);

  }

}
