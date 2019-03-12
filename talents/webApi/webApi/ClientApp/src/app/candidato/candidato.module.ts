import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { ValidadorCadastroModule } from '../validador-cadastro/validador-cadastro.module';

import { CandidatoCadastroComponent } from './candidato-cadastro/candidato-cadastro.component';
import { CandidatoComponent } from './candidato.component';
import { CandidatoService } from '../services/candidato/candidato.service';
import { CandidatoRoutingModule } from './candidato-routing.module';

@NgModule({
  declarations: [
    CandidatoComponent,
    CandidatoCadastroComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CandidatoRoutingModule,
    ValidadorCadastroModule,
  ],
  providers: [CandidatoService],
  exports: [CandidatoRoutingModule]
})
export class CandidatoModule { }
