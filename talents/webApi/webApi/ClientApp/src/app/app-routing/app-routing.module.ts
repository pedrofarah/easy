import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from '../app.component';
import { LinguagemCadastroComponent } from '../linguagem/linguagem-cadastro/linguagem-cadastro.component';
import { LinguagemComponent } from '../linguagem/linguagem.component';


@NgModule({
  declarations: [AppComponent, LinguagemCadastroComponent, LinguagemComponent],
  imports: [
    CommonModule,
    LinguagemCadastroComponent,
    LinguagemComponent,
    RouterModule.forRoot([
      { path: '', component: AppComponent, pathMatch: 'full' },
      { path: 'linguagem', component: LinguagemComponent },
      { path: 'linguagemcadastro', component: LinguagemCadastroComponent }
    ])
  ],
  exports: [RouterModule]
  
})
export class AppRoutingModule { }
