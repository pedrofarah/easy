import { Injectable, Inject } from '@angular/core';
import 'rxjs/add/operator/map';
import { ICandidato } from '../../dto/candidato.interface';
import { IListasRelacionamentos } from '../../dto/candidato.interface';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CandidatoService {

  url_controller: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url_controller = baseUrl + 'api/candidato/';
  }

  getlistas() {
    return this.http.get<IListasRelacionamentos>(this.url_controller + 'listas').map(
      data => <IListasRelacionamentos>data
    );
  }
  
  getCandidato() {
    return this.http.get<ICandidato[]>(this.url_controller).map(data => <ICandidato[]>data);
  }

  retornarCandidato(id: number) {
    return this.http.get<ICandidato>(this.url_controller + id).map(
      data => <ICandidato>data
    );
  }

  incluirCandidato(candidato: ICandidato) {
    return this.http.post(this.url_controller, candidato);
  }

  alterarCandidato(candidato: ICandidato) {
    return this.http.put(this.url_controller, candidato);
  }

  excluirCandidato(id: number) {
    return this.http.delete(this.url_controller + id)
  }


}
