using lib.dto;

namespace lib.interfaces
{

    public interface INucleoDados
    {
        IRepositorio<Candidato> CandidatoRepositorio { get; }
        IRepositorio<Linguagem> LinguagemRepositorio { get; }
        IRepositorio<DisponibilidadePeriodo> DisponibilidadePeriodoRepositorio { get; }
        IRepositorio<DisponibilidadeHoras> DisponibilidadeHorasRepositorio { get; }
        void Gravar();
    }

}
