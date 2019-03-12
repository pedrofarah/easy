import { Injectable, Inject } from '@angular/core';
import 'rxjs/add/operator/map';
import { IDispPeriodo } from '../../dto/disp-periodo.interface';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DispPeriodoService {

  url_controller: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url_controller = baseUrl + 'api/disponibilidadeperiodo/';
  }

  getDispPeriodo() {
    return this.http.get<IDispPeriodo[]>(this.url_controller).map(data => <IDispPeriodo[]>data);
  }

  retornarDispPeriodo(id: number) {
    return this.http.get<IDispPeriodo>(this.url_controller + id).map(
      data => <IDispPeriodo>data
    );
  }

  incluirDispPeriodo(dispperiodo: IDispPeriodo) {
    return this.http.post(this.url_controller, dispperiodo);
  }

  alterarDispPeriodo(dispperiodo: IDispPeriodo) {
    return this.http.put(this.url_controller, dispperiodo);
  }

  excluirDispPeriodo(dispperiodo: IDispPeriodo) {
    return this.http.delete(this.url_controller + dispperiodo.id)
  }

}
