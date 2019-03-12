import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DispHorasCadastroComponent } from './disphoras-cadastro/disphoras-cadastro.component';
import { DispHorasComponent } from './disphoras.component';

const DispHorasRoutes: Routes = [
  {
    path: 'disphoras',
    component: DispHorasComponent
  },
  {
    path: 'disphoras/novo',
    component: DispHorasCadastroComponent
  },
  {
    path: 'disphoras/cadastro/:id',
    component: DispHorasCadastroComponent
  }
]

@NgModule({
  imports: [
    RouterModule.forChild(DispHorasRoutes)
  ],
  exports: [RouterModule]
})
export class DispHorasRoutingModule { }
