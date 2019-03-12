
export class Candidato {
  constructor(
    public id: Number,
    public email: string,
    public nome: string,
    public skype: string,
    public telefone: string,
    public linkedin: string,
    public cidade: string,
    public uf: string,
    public portifolio: string,
    public pretencao_salarial_hora: number,
    public nota_outros: string,
    public link_crud: string,
    public lstCandidatoLinguagem: CandidatoLinguagem[],
    public lstCandidatoDisponibilidadeHoras: CandidatoDisponibilidadeHoras[],
    public lstCandidatoDisponibilidadePeriodo: CandidatoDisponibilidadePeriodo[]
  ){ }
}

export class CandidatoLinguagem {
  constructor(
    public candidatoId: Number,
    public linguagemId: Number,
    public nota: Number,
    public linguagem: any
  ){ }
}

export class CandidatoDisponibilidadeHoras {
  constructor(
    public candidatoId: Number,
    public disponibilidadeHorasId: Number,
    public disponibilidadeHoras: any,
    public marcar: boolean
  ){ }
}

export class CandidatoDisponibilidadePeriodo {
  constructor(
    public candidatoId: Number,
    public disponibilidadePeriodoId: Number,
    public disponibilidadePeriodo: any,
    public marcar: boolean
  ){ }
}
