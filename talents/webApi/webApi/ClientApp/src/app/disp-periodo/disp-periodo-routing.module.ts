import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DispPeriodoCadastroComponent } from './disp-periodo-cadastro/disp-periodo-cadastro.component';
import { DispPeriodoComponent } from './disp-periodo.component';

const DispPeriodoRoutes: Routes = [
  {
    path: 'dispperiodo',
    component: DispPeriodoComponent
  },
  {
    path: 'dispperiodo/novo',
    component: DispPeriodoCadastroComponent
  },
  {
    path: 'dispperiodo/cadastro/:id',
    component: DispPeriodoCadastroComponent
  }
]

@NgModule({
  imports: [
    RouterModule.forChild(DispPeriodoRoutes)
  ],
  exports: [RouterModule]
})
export class DispPeriodoRoutingModule { }
