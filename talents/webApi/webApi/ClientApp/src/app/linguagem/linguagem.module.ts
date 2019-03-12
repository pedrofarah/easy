import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { ValidadorCadastroModule } from '../validador-cadastro/validador-cadastro.module';

import { LinguagemCadastroComponent } from './linguagem-cadastro/linguagem-cadastro.component';
import { LinguagemComponent } from './linguagem.component';
import { LinguagemService } from '../services/linguagem/linguagem.service';
import { LinguagemRoutingModule } from './linguagem-routing.module';

@NgModule({
  declarations: [
    LinguagemComponent,
    LinguagemCadastroComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    LinguagemRoutingModule,
    ValidadorCadastroModule
  ],
  providers: [LinguagemService],
  exports: [LinguagemCadastroComponent]
})
export class LinguagemModule { }
