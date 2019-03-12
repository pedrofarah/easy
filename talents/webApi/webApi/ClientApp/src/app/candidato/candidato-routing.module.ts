import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CandidatoCadastroComponent } from './candidato-cadastro/candidato-cadastro.component';
import { CandidatoComponent } from './candidato.component';

const CandidatoRoutes: Routes = [
  {
    path: 'candidato',
    component: CandidatoComponent
  },
  {
    path: 'candidato/novo',
    component: CandidatoCadastroComponent
  },
  {
    path: 'candidato/cadastro/:id',
    component: CandidatoCadastroComponent
  }
]

@NgModule({
  imports: [
    RouterModule.forChild(CandidatoRoutes)
  ],
  exports: [RouterModule]
})
export class CandidatoRoutingModule { }
