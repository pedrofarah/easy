import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'validador-campo',
  template: '<div *ngIf="monstrarMsg()" class="invalid-feedback"><small class="form-text text-muted">Preenchimento obrigatório.</small></div>',
  styles: ['']
})
export class ValidadorCampoComponent {

  @Input() controle: FormControl;

  monstrarMsg() {
    return ((this.controle.touched || this.controle.dirty) && !this.controle.valid);
  }

}
