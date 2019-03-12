
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib.dto
{
    public class Candidato
    {
        public Int64 Id { get; set; }
        public string email { get; set; }
        public string nome { get; set; }
        public string skype { get; set; }
        public string telefone { get; set; }
        public string linkedin { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string portifolio { get; set; }
        public double pretencao_salarial_hora { get; set; }
        public string nota_outros { get; set; }
        public string link_crud { get; set; }
        public List<CandidatoLinguagem> lstCandidatoLinguagem { get; set; }
        public List<CandidatoDisponibilidadeHoras> lstCandidatoDisponibilidadeHoras { get; set; }
        public List<CandidatoDisponibilidadePeriodo> lstCandidatoDisponibilidadePeriodo { get; set; }
    }

    public class CandidatoLinguagem
    {
        public Int64 CandidatoId { get; set; }
        [JsonIgnore]
        public Candidato candidato { get; set; }
        public Int64 LinguagemId { get; set; }
        public Linguagem linguagem { get; set; }
        public int Nota { get; set; }
    }

    public class CandidatoDisponibilidadeHoras
    {
        public Int64 CandidatoId { get; set; }
        [JsonIgnore]
        public Candidato candidato { get; set; }
        public Int64 DisponibilidadeHorasId { get; set; }
        public DisponibilidadeHoras disponibilidadeHoras { get; set; }
    }

    public class CandidatoDisponibilidadePeriodo
    {
        public Int64 CandidatoId { get; set; }
        [JsonIgnore]
        public Candidato candidato { get; set; }
        public Int64 DisponibilidadePeriodoId { get; set; }
        public DisponibilidadePeriodo disponibilidadePeriodo { get; set; }
    }

    [NotMapped]
    public class ListasRelacionamentos
    {
        public List<DisponibilidadePeriodo> ListaDisponibilidadePeriodo { get; set; }
        public List<DisponibilidadeHoras> ListaDisponibilidadeHoras { get; set; }
        public List<Linguagem> ListaLinguagem { get; set; }
    }

}
