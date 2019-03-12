import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { LinguagemService } from '../services/linguagem/linguagem.service';
import { ILinguagem } from '../dto/linguagem.interface';

@Component({
  selector: 'app-linguagem',
  templateUrl: './linguagem.component.html',
  styleUrls: ['./linguagem.component.css']
})
export class LinguagemComponent implements OnInit {

  linguagens: ILinguagem[] = [];

  constructor(
    private router: Router,
    private linguagemService: LinguagemService
  ) { }

  private getLinguagens() {
    this.linguagemService.getLinguagens().subscribe(
      result => { this.linguagens = result },
      err => { alert(err.error); console.log(err); }
    );
  }

  private LinguagemPesquisarCodigo(texto: string) {
    this.linguagemService.getLinguagens().subscribe(
      (result: ILinguagem[]) => {
        this.linguagens = (texto.trim().length > 0) ? result.filter(o => o.id == Number(texto)) : result;
        this.linguagens.sort((a, b) => { return (a.id > b.id) ? 1 : -1 });
      },
      err => { alert(err.error); console.log(err); }
    );
  }

  private LinguagemPesquisarDescricao(texto: string) {
    this.linguagemService.getLinguagens().subscribe(
      (result: ILinguagem[]) => {
        this.linguagens = result.filter(o => o.nome.startsWith(texto))
        this.linguagens.sort((a, b) => { return (a.nome > b.nome) ? 1 : -1 });
      },
      err => { alert(err.error); console.log(err); }
    );
  }

  private excluir(obj: ILinguagem, idx: number) {
    if (window.confirm("Confirmar exclusão do registro?")) {
      this.linguagemService.excluirLinguagem(obj).subscribe(
        result => { this.linguagens.splice(idx, 1); },
        err => { alert(err.error); console.log(err); }
      );
    }
  }

  private editar(obj: ILinguagem) {
    this.router.navigateByUrl('/linguagem/cadastro/' + obj.id);
  }

  ngOnInit() {
    this.getLinguagens();
  }

}
