import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { DispPeriodoService } from '../services/disp-periodo/disp-periodo.service';
import { IDispPeriodo } from '../dto/disp-periodo.interface';

@Component({
  selector: 'app-disp-periodo',
  templateUrl: './disp-periodo.component.html',
  styleUrls: ['./disp-periodo.component.css']
})
export class DispPeriodoComponent implements OnInit {

  Lst_dispperiodo: IDispPeriodo[] = [];

  constructor(
    private router: Router,
    private dispPeriodoService: DispPeriodoService
  ) { }

  private getDispPeriodo() {
    this.dispPeriodoService.getDispPeriodo().subscribe(
      result => { this.Lst_dispperiodo = result; },
      err => { alert(err.error); console.log(err); }
    );
  }

  private DispPeriodoPesquisarCodigo(texto: string) {
    this.dispPeriodoService.getDispPeriodo().subscribe(
      (result: IDispPeriodo[]) => {
        this.Lst_dispperiodo = (texto.trim().length > 0) ? result.filter(o => o.id == Number(texto)) : result;
        this.Lst_dispperiodo.sort((a, b) => { return (a.id > b.id) ? 1 : -1 });
      },
      error => console.log(error)
    );
  }

  private DispPeriodoPesquisarDescricao(texto: string) {
    this.dispPeriodoService.getDispPeriodo().subscribe(
      (result: IDispPeriodo[]) => {
        this.Lst_dispperiodo = result.filter(o => o.descricao.startsWith(texto));
        this.Lst_dispperiodo.sort((a, b) => { return (a.descricao > b.descricao) ? 1 : -1 });
      },
      err => { alert(err.error); console.log(err); }
    );
  }

  private excluir(obj: IDispPeriodo, idx: number) {

    if (window.confirm("Confirmar exclusão do registro?")) {

      this.dispPeriodoService.excluirDispPeriodo(obj).subscribe(
        result => { this.Lst_dispperiodo.splice(idx, 1); },
        err => { alert(err.error); console.log(err); }
      );
    }

  }

  private editar(obj: IDispPeriodo) {
    this.router.navigateByUrl('/dispperiodo/cadastro/' + obj.id);
  }

  ngOnInit() {
    this.getDispPeriodo();
  }

}
