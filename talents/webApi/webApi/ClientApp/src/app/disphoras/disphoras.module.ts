import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { ValidadorCadastroModule } from '../validador-cadastro/validador-cadastro.module';

import { DispHorasCadastroComponent } from './disphoras-cadastro/disphoras-cadastro.component';
import { DispHorasComponent } from './disphoras.component';
import { DispHorasService } from '../services/disphoras/disphoras.service';
import { DispHorasRoutingModule } from './disphoras-routing.module';

@NgModule({
  declarations: [
    DispHorasComponent,
    DispHorasCadastroComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    DispHorasRoutingModule,
    ValidadorCadastroModule
  ],
  providers: [DispHorasService],
  exports: [DispHorasRoutingModule]
})
export class DispHorasModule { }
