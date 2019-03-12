import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LinguagemCadastroComponent } from './linguagem-cadastro/linguagem-cadastro.component';
import { LinguagemComponent } from './linguagem.component';

const LinguagemRoutes: Routes = [
  {
    path: 'linguagem',
    component: LinguagemComponent
  },
  {
    path: 'linguagem/novo',
    component: LinguagemCadastroComponent
  },
  {
    path: 'linguagem/cadastro/:id',
    component: LinguagemCadastroComponent
  }
]

@NgModule({
  imports: [
    RouterModule.forChild(LinguagemRoutes)
  ],
  exports: [RouterModule]
})
export class LinguagemRoutingModule { }
