import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { ValidadorCadastroModule } from '../validador-cadastro/validador-cadastro.module';

import { DispPeriodoCadastroComponent } from './disp-periodo-cadastro/disp-periodo-cadastro.component';
import { DispPeriodoComponent } from './disp-periodo.component';
import { DispPeriodoService } from '../services/disp-periodo/disp-periodo.service';
import { DispPeriodoRoutingModule } from './disp-periodo-routing.module';

@NgModule({
  declarations: [
    DispPeriodoComponent,
    DispPeriodoCadastroComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    DispPeriodoRoutingModule,
    ValidadorCadastroModule
  ],
  providers: [DispPeriodoService],
  exports: [DispPeriodoRoutingModule]
})
export class DispPeriodoModule { }
