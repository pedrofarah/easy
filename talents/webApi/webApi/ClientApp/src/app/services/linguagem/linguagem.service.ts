import { Injectable, Inject } from '@angular/core';
import 'rxjs/add/operator/map';
import { ILinguagem } from '../../dto/linguagem.interface';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class LinguagemService {

  str_base_url: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.str_base_url = baseUrl;
  }

  getLinguagens() {
    return this.http.get<ILinguagem[]>(this.str_base_url + 'api/linguagem').map(data => <ILinguagem[]>data);
  }

  retornarLinguagem(id: number) {
    return this.http.get<ILinguagem>(this.str_base_url + 'api/linguagem/' + id).map(
      data => <ILinguagem>data
    );
  }

  incluirLinguagem(linguagem: ILinguagem) {
    return this.http.post(this.str_base_url + 'api/linguagem', linguagem);
  }

  alterarLinguagem(linguagem: ILinguagem) {
    return this.http.put(this.str_base_url + 'api/linguagem/', linguagem);
  }

  excluirLinguagem(linguagem: ILinguagem) {
    return this.http.delete(this.str_base_url + 'api/linguagem/' + linguagem.id)
  }

}
