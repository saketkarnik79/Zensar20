import { Directive, ElementRef, Renderer2, Input, HostListener, HostBinding, OnInit } from '@angular/core';

@Directive({
  selector: '[ttToggle]',
})
export class TtToggleDirective implements OnInit {
  private elementSelected: boolean=false;

  constructor(private el:ElementRef) {}

  ngOnInit(): void {
    
  }

  @HostListener('click')
  onClick(){
    this.elementSelected= !this.elementSelected;
    if(this.elementSelected){
      this.el.nativeElement.classList.add('toggle');
    } else {
      this.el.nativeElement.classList.remove('toggle');
    }
  }
}