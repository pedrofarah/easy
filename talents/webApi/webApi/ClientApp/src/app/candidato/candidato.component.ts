import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { CandidatoService } from '../services/candidato/candidato.service';
import { ICandidato } from '../dto/candidato.interface';

@Component({
  selector: 'app-candidato',
  templateUrl: './candidato.component.html',
  styleUrls: ['./candidato.component.css']
})
export class CandidatoComponent implements OnInit {

  Lst_candidatos: ICandidato[] = [];

  constructor(
    private router: Router,
    private candidatoService: CandidatoService
  ) { }

  private getCandidatos() {
    this.candidatoService.getCandidato().subscribe(
      result => { this.Lst_candidatos = result; },
      err => { alert(err.error); console.log(err); }
    );
  }

  private PesquisarNome(texto: string) {
    this.candidatoService.getCandidato().subscribe(
      (result: ICandidato[]) => {
        this.Lst_candidatos = (texto.trim().length > 0) ? result.filter(o => o.nome.startsWith(texto)) : result;
        this.Lst_candidatos.sort((a, b) => { return (a.nome > b.nome) ? 1 : -1 });
      },
      error => console.log(error)
    );
  }

  private PesquisarEmail(texto: string) {
    this.candidatoService.getCandidato().subscribe(
      (result: ICandidato[]) => {
        this.Lst_candidatos = (texto.trim().length > 0) ? result.filter(o => o.email.startsWith(texto)) : result;
        this.Lst_candidatos.sort((a, b) => { return (a.email > b.email) ? 1 : -1 });
      },
      error => console.log(error)
    );
  }

  private PesquisarTelefone(texto: string) {
    this.candidatoService.getCandidato().subscribe(
      (result: ICandidato[]) => {
        this.Lst_candidatos = (texto.trim().length > 0) ? result.filter(o => o.telefone.startsWith(texto)) : result;
        this.Lst_candidatos.sort((a, b) => { return (a.telefone > b.telefone) ? 1 : -1 });
      },
      error => console.log(error)
    );
  }

  private excluir(id: number, idx: number) {
    
    if (window.confirm("Confirmar exclusão do registro?")) {

      this.candidatoService.excluirCandidato(id).subscribe(
        result => { this.Lst_candidatos.splice(idx, 1); },
        err => { alert(err.error); console.log(err); }
      );
    }

  }

  private editar(id: number) {
    this.router.navigateByUrl('/candidato/cadastro/' + id);
  }

  ngOnInit() {
    this.getCandidatos();
  }

}
