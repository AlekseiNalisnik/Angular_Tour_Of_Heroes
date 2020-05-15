import { Directive, ElementRef, Output, EventEmitter, HostListener } from '@angular/core';

@Directive({
    selector: '[clickOutside]',
})
export class ClickOutsideDirective {
    @Output() clickOutside = new EventEmitter();
    constructor(private elementRef: ElementRef) { }

    @HostListener('document:click', ['$event.target'])
    onClick(targetElement) {
        if(targetElement['className'].includes('header__search__line')) return;
        const isClickedInside = this.elementRef.nativeElement.contains(targetElement);
        if (!isClickedInside) {
            this.clickOutside.emit(null);
        }
    }
}