import { Component, Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'validador-form-group-class',
  template: ''
})

@Injectable()
export class ValidadorFormGroupClassComponent {

  public getFormGroupClass(controle: FormControl): {} {
    return {
      'form-group': true,
      'has-error': (controle.dirty || controle.touched) && !controle.valid,
      'has-success': controle.valid
    };
  }

}
