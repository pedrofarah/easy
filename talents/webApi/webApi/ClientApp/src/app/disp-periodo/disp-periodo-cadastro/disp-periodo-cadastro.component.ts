import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { ValidadorFormGroupClassComponent } from '../../validador-cadastro/validador-form-group-class/validador-form-group-class.component';

import { DispPeriodoService } from '../../services/disp-periodo/disp-periodo.service';
import { IDispPeriodo } from '../../dto/disp-periodo.interface';
import { DispPeriodo } from '../../dto/disp-periodo.model';

@Component({
  selector: 'app-disp-periodo-cadastro',
  templateUrl: './disp-periodo-cadastro.component.html',
  styleUrls: ['./disp-periodo-cadastro.component.css']
})
export class DispPeriodoCadastroComponent implements OnInit {

  dispperiodo: IDispPeriodo;

  frm: FormGroup;

  private NovoRegistro: boolean = true;

  @ViewChild('edit_dispPeriodo_nome') _editnome: ElementRef;

  constructor(
    private fb: FormBuilder,
    private dispPeriodoService: DispPeriodoService,
    private location: Location,
    private route: ActivatedRoute,
    private validadorFormGroup: ValidadorFormGroupClassComponent) {
    this.frm = fb.group({
      "id": [""],
      "descricao": ["", Validators.required]
    });
  }

  ngOnInit(): void {

    this.dispperiodo = new DispPeriodo(0, '');

    this.route.params.forEach((params: Params) => {
      let id: number = +params['id'];
      if (id) {
        this.NovoRegistro = false;
        this.dispPeriodoService.retornarDispPeriodo(id)
          .subscribe(result => {
            console.log(result);
            this.dispperiodo = result;

            if (this.dispperiodo == undefined) {
              alert("Falha ao localizar registro.");
              this.location.back();
              return;
            }
            else {
              this.frm.get("id").setValue(this.dispperiodo.id);
              this.frm.get("descricao").setValue(this.dispperiodo.descricao);
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

    this.dispperiodo.id = (this.NovoRegistro) ? 0 : this.frm.controls["id"].value;
    this.dispperiodo.descricao = this.frm.controls["descricao"].value;

    if (this.NovoRegistro) {
      this.dispPeriodoService.incluirDispPeriodo(this.dispperiodo).subscribe(
        response => {
          this.location.back();
        },
        err => {
          alert(err.message);
          console.log(err);
        });
    } else {
      this.dispPeriodoService.alterarDispPeriodo(this.dispperiodo).subscribe(
        response => {
          this.location.back();
        },
        err => {
          alert(err.message);
          console.log(err);
        }
      );
    }
  }

}
