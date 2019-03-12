import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';


import { ValidadorCampoComponent } from './validador-campo.component';
import { ValidadorFormGroupClassComponent } from './validador-form-group-class/validador-form-group-class.component';

@NgModule({
  declarations: [
    ValidadorCampoComponent,
    ValidadorFormGroupClassComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  providers: [ValidadorFormGroupClassComponent],
  exports: [
    ValidadorCampoComponent
  ]
})
export class ValidadorCadastroModule { }
