import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { DispHorasService } from '../services/disphoras/disphoras.service';
import { IDispHoras } from '../dto/disphoras.interface';

@Component({
  selector: 'app-disphoras',
  templateUrl: './disphoras.component.html',
  styleUrls: ['./disphoras.component.css']
})
export class DispHorasComponent implements OnInit {

  Lst_disphoras: IDispHoras[] = [];

  constructor(
    private router: Router,
    private disphorasService: DispHorasService
  ) { }

  private getDispHoras() {
    this.disphorasService.getDispHoras().subscribe(
      result => { this.Lst_disphoras = result; },
      err => { alert(err.error); console.log(err); }
    );
  }

  private DispHorasPesquisarCodigo(texto: string) {
    this.disphorasService.getDispHoras().subscribe(
      (result: IDispHoras[]) => {
        this.Lst_disphoras = (texto.trim().length > 0) ? result.filter(o => o.id == Number(texto)) : result;
        this.Lst_disphoras.sort((a, b) => { return (a.id > b.id) ? 1 : -1 });
      },
      error => console.log(error)
    );
  }

  private DispHorasPesquisarDescricao(texto: string) {
    this.disphorasService.getDispHoras().subscribe(
      (result: IDispHoras[]) => {
        this.Lst_disphoras = result.filter(o => o.descricao.startsWith(texto));
        this.Lst_disphoras.sort((a, b) => { return (a.descricao > b.descricao) ? 1 : -1 });
      },
      err => { alert(err.error); console.log(err); }
    );
  }

  private excluir(obj: IDispHoras, idx: number) {

    if (window.confirm("Confirmar exclusão do registro?")) {

      this.disphorasService.excluirDispHoras(obj).subscribe(
        result => { this.Lst_disphoras.splice(idx, 1); },
        err => { alert(err.error); console.log(err); }
      );
    }

  }

  private editar(obj: IDispHoras) {
    this.router.navigateByUrl('/disphoras/cadastro/' + obj.id);
  }

  ngOnInit() {
    this.getDispHoras();
  }

}
