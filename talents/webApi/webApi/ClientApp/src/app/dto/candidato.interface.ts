
export interface ICandidato {
  id: Number;
  email: string;
  nome: string;
  skype: string;
  telefone: string;
  linkedin: string;
  cidade: string;
  uf: string;
  portifolio: string;
  pretencao_salarial_hora: number;
  nota_outros: string;
  link_crud: string;
  lstCandidatoLinguagem: ICandidatoLinguagem[];
  lstCandidatoDisponibilidadeHoras: ICandidatoDisponibilidadeHoras[];
  lstCandidatoDisponibilidadePeriodo: ICandidatoDisponibilidadePeriodo[];
}

export interface ICandidatoLinguagem {
  candidatoId: Number;
  linguagemId: Number;
  nota: Number;
  linguagem: any;
}

export interface ICandidatoDisponibilidadeHoras {
  candidatoId: Number;
  disponibilidadeHorasId: Number;
  disponibilidadeHoras: any;
  marcar: boolean;
}

export interface ICandidatoDisponibilidadePeriodo {
  candidatoId: Number;
  disponibilidadePeriodoId: Number;
  disponibilidadePeriodo: any;
  marcar: boolean;
}

export interface IListasRelacionamentos {
  listaDisponibilidadePeriodo: any;
  listaDisponibilidadeHoras: any;
  listaLinguagem: any;
}


