import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { ValidadorFormGroupClassComponent } from '../../validador-cadastro/validador-form-group-class/validador-form-group-class.component';

import { LinguagemService } from '../../services/linguagem/linguagem.service';
import { ILinguagem } from '../../dto/linguagem.interface';
import { Linguagem } from '../../dto/linguagem.model';

@Component({
  selector: 'linguagem-cadastro',
  templateUrl: './linguagem-cadastro.component.html',
  styleUrls: ['./linguagem-cadastro.component.css']
})
export class LinguagemCadastroComponent implements OnInit {

  linguagem: ILinguagem;

  frm: FormGroup;

  private NovoRegistro: boolean = true;

  @ViewChild('editnome') _editnome: ElementRef;

    constructor(
    private fb: FormBuilder,
      private linguagemService: LinguagemService,
      private location: Location,
      private route: ActivatedRoute,
      private validadorFormGroup: ValidadorFormGroupClassComponent) {
      this.frm = fb.group({
        "id": [""],
        "nome": ["", Validators.required]
      });
    }

  ngOnInit(): void {

    this.linguagem = new Linguagem(0, '');

    this.route.params.forEach((params: Params) => {
      let id: number = +params['id'];
      if (id) {
        this.NovoRegistro = false;
        this.linguagemService.retornarLinguagem(id)
          .subscribe(result => {
            console.log(result);
            this.linguagem = result;

            if (this.linguagem == undefined) {
              alert("Falha ao localizar registro.");
              this.location.back();
              return;
            }
            else {
              this.frm.get("id").setValue(this.linguagem.id);
              this.frm.get("nome").setValue(this.linguagem.nome);
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

    this.linguagem.id = (this.NovoRegistro) ? 0 : this.frm.controls["id"].value;
    this.linguagem.nome = this.frm.controls["nome"].value;

    if (this.NovoRegistro) {
      this.linguagemService.incluirLinguagem(this.linguagem).subscribe(
        response => {
          this.location.back();
      });
    } else {
      this.linguagemService.alterarLinguagem(this.linguagem).subscribe(
        response => {
          this.location.back();
        },
        err => {
          console.log(err);
        }
      );
    }
  }

}
