import { HostListener, Directive, ElementRef, Input } from '@angular/core';

@Directive({
    selector: '[round-image]'
})

export class RoundImageDirective {
    @Input('round-image') dirRoundIMage;

    constructor(private el: ElementRef) { }

    @HostListener('mouseenter') onMouseEnter () {
        this.changeImageBorder('10px')
    }

    @HostListener('mouseleave') onMouseLeave () {
        this.changeImageBorder(null);
    }

    private changeImageBorder(border: string) {
        this.el.nativeElement.style.borderRadius = border;
    }
}