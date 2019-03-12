export class Candidato {
    constructor(id, email, nome, skype, telefone, linkedin, cidade, uf, portifolio, pretencao_salarial_hora, nota_outros, link_crud, lstCandidatoLinguagem, lstCandidatoDisponibilidadeHoras, lstCandidatoDisponibilidadePeriodo) {
        this.id = id;
        this.email = email;
        this.nome = nome;
        this.skype = skype;
        this.telefone = telefone;
        this.linkedin = linkedin;
        this.cidade = cidade;
        this.uf = uf;
        this.portifolio = portifolio;
        this.pretencao_salarial_hora = pretencao_salarial_hora;
        this.nota_outros = nota_outros;
        this.link_crud = link_crud;
        this.lstCandidatoLinguagem = lstCandidatoLinguagem;
        this.lstCandidatoDisponibilidadeHoras = lstCandidatoDisponibilidadeHoras;
        this.lstCandidatoDisponibilidadePeriodo = lstCandidatoDisponibilidadePeriodo;
    }
}
export class CandidatoLinguagem {
    constructor(candidatoId, linguagemId, nota, linguagem) {
        this.candidatoId = candidatoId;
        this.linguagemId = linguagemId;
        this.nota = nota;
        this.linguagem = linguagem;
    }
}
export class CandidatoDisponibilidadeHoras {
    constructor(candidatoId, disponibilidadeHorasId, disponibilidadeHoras, marcar) {
        this.candidatoId = candidatoId;
        this.disponibilidadeHorasId = disponibilidadeHorasId;
        this.disponibilidadeHoras = disponibilidadeHoras;
        this.marcar = marcar;
    }
}
export class CandidatoDisponibilidadePeriodo {
    constructor(candidatoId, disponibilidadePeriodoId, disponibilidadePeriodo, marcar) {
        this.candidatoId = candidatoId;
        this.disponibilidadePeriodoId = disponibilidadePeriodoId;
        this.disponibilidadePeriodo = disponibilidadePeriodo;
        this.marcar = marcar;
    }
}
//# sourceMappingURL=candidato.model.js.map