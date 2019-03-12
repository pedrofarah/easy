import { Injectable, Inject } from '@angular/core';
import 'rxjs/add/operator/map';
import { IDispHoras } from '../../dto/disphoras.interface';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DispHorasService {

  url_controller: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url_controller = baseUrl + 'api/disponibilidadehoras/';
  }

  getDispHoras() {
    return this.http.get<IDispHoras[]>(this.url_controller).map(data => <IDispHoras[]>data);
  }

  retornarDispHoras(id: number) {
    return this.http.get<IDispHoras>(this.url_controller + id).map(
      data => <IDispHoras>data
    );
  }

  incluirDispHoras(disphoras: IDispHoras) {
    return this.http.post(this.url_controller, disphoras);
  }

  alterarDispHoras(disphoras: IDispHoras) {
    return this.http.put(this.url_controller, disphoras);
  }

  excluirDispHoras(disphoras: IDispHoras) {
    return this.http.delete(this.url_controller + disphoras.id)
  }

}
