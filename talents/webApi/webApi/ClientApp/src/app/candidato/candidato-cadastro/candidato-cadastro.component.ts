import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { IDispHoras } from '../../dto/disphoras.interface';
import { IDispPeriodo } from '../../dto/disp-periodo.interface';
import { ILinguagem } from '../../dto/linguagem.interface';

import { ValidadorFormGroupClassComponent } from '../../validador-cadastro/validador-form-group-class/validador-form-group-class.component';

import { CandidatoService } from '../../services/candidato/candidato.service';
import { Candidato, CandidatoDisponibilidadeHoras, CandidatoLinguagem, CandidatoDisponibilidadePeriodo } from '../../dto/candidato.model';
import { ICandidato } from '../../dto/candidato.interface';
import { IListasRelacionamentos } from '../../dto/candidato.interface';

@Component({
  selector: 'app-candidato-cadastro',
  templateUrl: './candidato-cadastro.component.html',
  styleUrls: ['./candidato-cadastro.component.css']
})
export class CandidatoCadastroComponent implements OnInit {

  @ViewChild('edtemail') _editpadrao: ElementRef;

  Lst_disphoras: IDispHoras[];
  Lst_dispPeriodo: IDispPeriodo[];
  Lst_linguagem: ILinguagem[];
  
  frm: FormGroup;

  private NovoRegistro: boolean = true;
  private candidato: Candidato;
  private CarregandoDados: boolean = false;

  constructor(
    private fb: FormBuilder,
    private candidatoService: CandidatoService,
    private location: Location,
    private route: ActivatedRoute,
    private validadorFormGroup: ValidadorFormGroupClassComponent) {

    this.frm = this.fb.group({
      "id": [""],
      "email": ["", Validators.required],
      "nome": ["", Validators.required],
      "skype": ["", Validators.required],
      "telefone": ["", Validators.required],
      "linkedin": [""],
      "cidade": ["", Validators.required],
      "uf": ["", Validators.required],
      "portifolio": [""],
      "pretencao_salarial_hora": ["", Validators.required],
      "nota_outros": [""],
      "link_crud": [""]
    });

  }

  verificarCarregamentoDados() {
    this.CarregandoDados = (this.Lst_disphoras.length == 0) || (this.Lst_dispPeriodo.length == 0) || (this.Lst_linguagem.length == 0);
  }

  ngOnInit(): void {

    this.Lst_disphoras = new Array();

    this.Lst_dispPeriodo = new Array();

    this.Lst_linguagem = new Array();

    this.candidato = new Candidato(0, '', '', '', '', '', '', '', '', 0, '', '', new Array(), new Array(), new Array());

    this.NovoRegistro = true;

    this.CarregandoDados = true;

    this.candidatoService.getlistas().subscribe(
      (result: IListasRelacionamentos) => {

        var listasRelacionamentos = <IListasRelacionamentos>result;

        this.Lst_disphoras = <IDispHoras[]>listasRelacionamentos.listaDisponibilidadeHoras;

        if (this.Lst_disphoras.length > 0) {
          this.Lst_disphoras.forEach(obj => {
            this.candidato.lstCandidatoDisponibilidadeHoras.push(new CandidatoDisponibilidadeHoras(this.candidato.id, obj.id, obj, false));
          });
        }

        this.Lst_dispPeriodo = <IDispPeriodo[]>listasRelacionamentos.listaDisponibilidadePeriodo;

        if (this.Lst_dispPeriodo.length > 0) {
          this.Lst_dispPeriodo.forEach(obj => {
            this.candidato.lstCandidatoDisponibilidadePeriodo.push(new CandidatoDisponibilidadePeriodo(this.candidato.id, obj.id, obj, false));
          });
        }

        this.Lst_linguagem = <ILinguagem[]>listasRelacionamentos.listaLinguagem;

        this.verificarCarregamentoDados();

        if (this.Lst_linguagem.length > 0) {
          this.Lst_linguagem.forEach(obj => {

            this.candidato.lstCandidatoLinguagem.push(new CandidatoLinguagem(this.candidato.id, obj.id, 0, obj));

          });
        }

        this.verificarCarregamentoDados();

      });

    this.route.params.forEach(
      (params: Params) => {
        let id: number = +params['id'];

        if (id) {
          this.NovoRegistro = false;
          this.candidatoService.retornarCandidato(id)
            .subscribe(
              (result: ICandidato) => {

                console.log(result);

                this.candidato = <ICandidato>result;

                this.verificarCarregamentoDados();

                if (this.candidato.id == 0) {
                  alert("Falha ao localizar registro.");
                  this.location.back();
                  return;
                }
                else {

                  this.frm.get("id").setValue(this.candidato.id);
                  this.frm.get("email").setValue(this.candidato.email);
                  this.frm.get("nome").setValue(this.candidato.nome);
                  this.frm.get("skype").setValue(this.candidato.skype);
                  this.frm.get("telefone").setValue(this.candidato.telefone);
                  this.frm.get("linkedin").setValue(this.candidato.linkedin);
                  this.frm.get("cidade").setValue(this.candidato.cidade);
                  this.frm.get("uf").setValue(this.candidato.uf);
                  this.frm.get("portifolio").setValue(this.candidato.portifolio);
                  this.frm.get("pretencao_salarial_hora").setValue(this.candidato.pretencao_salarial_hora);
                  this.frm.get("nota_outros").setValue(this.candidato.nota_outros);
                  this.frm.get("link_crud").setValue(this.candidato.link_crud);

                  if (this.Lst_linguagem != undefined) {
                    this.Lst_linguagem.forEach(obj => {

                      var localizou = false;
                      this.candidato.lstCandidatoLinguagem.forEach(obj1 => {

                        if (obj.id == obj1.linguagemId) {
                          obj1.linguagem = obj;
                          localizou = true;
                        }

                      });

                      if (!localizou) {
                        this.candidato.lstCandidatoLinguagem.push(new CandidatoLinguagem(this.candidato.id, obj.id, 0, obj));
                      }

                    });

                    this.candidato.lstCandidatoLinguagem.sort((a, b) => { return (a.linguagemId > b.linguagemId) ? 1 : -1 });

                  }

                  if (this.Lst_disphoras != undefined) {


                    this.Lst_disphoras.forEach(obj => {

                      var localizou = false;
                      this.candidato.lstCandidatoDisponibilidadeHoras.forEach(obj1 => {

                        if (obj.id == obj1.disponibilidadeHorasId) {
                          localizou = true;
                          obj1.disponibilidadeHoras = obj;
                          obj1.marcar = true;
                        }

                      });

                      if (!localizou) {
                        this.candidato.lstCandidatoDisponibilidadeHoras.push(new CandidatoDisponibilidadeHoras(this.candidato.id, obj.id, obj, false));
                      }

                    });

                    this.candidato.lstCandidatoDisponibilidadeHoras.sort((a, b) => { return (a.disponibilidadeHorasId > b.disponibilidadeHorasId) ? 1 : -1 });

                  }

                  if (this.Lst_dispPeriodo != undefined) {
                    this.Lst_dispPeriodo.forEach(obj => {

                      var localizou = false;
                      this.candidato.lstCandidatoDisponibilidadePeriodo.forEach(obj1 => {

                        if (obj.id == obj1.disponibilidadePeriodoId) {
                          localizou = true;
                          obj1.marcar = true;
                          obj1.disponibilidadePeriodo = obj;
                        }

                      });

                      if (!localizou) {
                        this.candidato.lstCandidatoDisponibilidadePeriodo.push(new CandidatoDisponibilidadePeriodo(this.candidato.id, obj.id, obj, false));
                      }

                    });

                    this.candidato.lstCandidatoDisponibilidadePeriodo.sort((a, b) => { return (a.disponibilidadePeriodoId > b.disponibilidadePeriodoId) ? 1 : -1 });

                  }

                }

            },
            err => {
              alert(err.error);
              console.log(err);
              this.location.back();
            }

          );

        }

        this._editpadrao.nativeElement.focus();
    });

  }
  
  DefinirNotaLinguagem(valor_nota: number, objling: ILinguagem) {

    console.log("valor_nota: " + valor_nota);
    console.log("objling");
    console.log(objling);

    var localizou: boolean = false;
    this.candidato.lstCandidatoLinguagem.forEach((obj: CandidatoLinguagem) => {
      if (obj.linguagemId == objling.id) {
        localizou = true;
        obj.nota = valor_nota;
      }
    });

    if (!localizou) {
      var candidato_ling: CandidatoLinguagem = new CandidatoLinguagem(this.candidato.id, objling.id, valor_nota, objling);
      this.candidato.lstCandidatoLinguagem.push(candidato_ling);
      console.log("inc_cand_ling");
      console.log(candidato_ling);
    }

  }

  SelecionarDispHoras(valor: boolean, item: CandidatoDisponibilidadeHoras) {
    this.candidato.lstCandidatoDisponibilidadeHoras.find(p => p.disponibilidadeHorasId == item.disponibilidadeHorasId).marcar = valor;
  }

  SelecionarDispPeriodo(valor: boolean, item: CandidatoDisponibilidadePeriodo) {
    this.candidato.lstCandidatoDisponibilidadePeriodo.find(p => p.disponibilidadePeriodoId == item.disponibilidadePeriodoId).marcar = valor;
  }

  onSubmit(): void {

    this.candidato.id = (this.NovoRegistro) ? 0 : this.frm.controls["id"].value;
    this.candidato.email = this.frm.controls["email"].value;
    this.candidato.nome = this.frm.controls["nome"].value;
    this.candidato.skype = this.frm.controls["skype"].value;
    this.candidato.telefone = this.frm.controls["telefone"].value;
    this.candidato.linkedin = this.frm.controls["linkedin"].value;
    this.candidato.cidade = this.frm.controls["cidade"].value;
    this.candidato.uf = this.frm.controls["uf"].value;
    this.candidato.portifolio = this.frm.controls["portifolio"].value;
    this.candidato.pretencao_salarial_hora = this.frm.controls["pretencao_salarial_hora"].value;
    this.candidato.nota_outros = this.frm.controls["nota_outros"].value;
    this.candidato.link_crud = this.frm.controls["link_crud"].value;

    this.candidato.lstCandidatoDisponibilidadeHoras = this.candidato.lstCandidatoDisponibilidadeHoras.filter(p => p.marcar);

    this.candidato.lstCandidatoDisponibilidadePeriodo = this.candidato.lstCandidatoDisponibilidadePeriodo.filter(p => p.marcar);

    if (this.NovoRegistro) {
      this.candidatoService.incluirCandidato(this.candidato).subscribe(
        response => {
          this.location.back();
          console.log(this.candidato);
        },
        err => {
          alert(err.error);
          console.log(err);
        }
      );
    } else {
      this.candidatoService.alterarCandidato(this.candidato).subscribe(
        response => {
          this.location.back();
        },
        err => {
          alert(err.error);
          console.log(err);
        }
      );
    }
  }


}
