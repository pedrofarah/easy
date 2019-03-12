import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { ValidadorFormGroupClassComponent } from '../../validador-cadastro/validador-form-group-class/validador-form-group-class.component';

import { DispHorasService } from '../../services/disphoras/disphoras.service';
import { IDispHoras } from '../../dto/disphoras.interface';
import { DispHoras } from '../../dto/disphoras.model';


@Component({
  selector: 'app-disphoras-cadastro',
  templateUrl: './disphoras-cadastro.component.html',
  styleUrls: ['./disphoras-cadastro.component.css']
})
export class DispHorasCadastroComponent implements OnInit {

  disphoras: IDispHoras;

  frm : FormGroup;

  private NovoRegistro: boolean = true;

  @ViewChild('edit_dispHoras_nome') _editnome: ElementRef;

  constructor(
    private fb: FormBuilder,
    private dispHorasService: DispHorasService,
    private location: Location,
    private route: ActivatedRoute,
    private validadorFormGroup: ValidadorFormGroupClassComponent) {

    this.frm = fb.group({
      "id": [""],
      "descricao": ["", Validators.required]
    });
  }

  ngOnInit(): void {

    this.disphoras = new DispHoras(0, '');

    this.route.params.forEach((params: Params) => {
      let id: number = +params['id'];
      if (id) {
        this.NovoRegistro = false;
        this.dispHorasService.retornarDispHoras(id)
          .subscribe(result => {
            console.log(result);
            this.disphoras = result;

            if (this.disphoras == undefined) {
              alert("Falha ao localizar registro.");
              this.location.back();
              return;
            }
            else {
              this.frm.get("id").setValue(this.disphoras.id);
              this.frm.get("descricao").setValue(this.disphoras.descricao);
            }

          },
            err => {
              alert(err.error);
              console.log(err);
              this.location.back();
            }
          );
      }
      this._editnome.nativeElement.focus();
    });
  }

  onSubmit(): void {

    this.disphoras.id = (this.NovoRegistro) ? 0 : this.frm.controls["id"].value;
    this.disphoras.descricao = this.frm.controls["descricao"].value;

    if (this.NovoRegistro) {
      this.dispHorasService.incluirDispHoras(this.disphoras).subscribe(
        response => {
          this.location.back();
        },
        err => {
          console.log(err);
        });
    } else {
      this.dispHorasService.alterarDispHoras(this.disphoras).subscribe(
        response => {
          this.location.back();
        },
        err => {
          console.log(err);
        });
    }
  }


}
