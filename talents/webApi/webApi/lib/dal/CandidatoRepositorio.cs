using lib.dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace lib.dal
{
    public class CandidatoRepositorio: Repositorio<Candidato>
    {
        public CandidatoRepositorio(AppDbContext context) : base(context) { }

        public override void Atualizar(Candidato dto)
        {
            try
            {
                Candidato candidato_db = DBSet
                    .Include(h => h.lstCandidatoDisponibilidadeHoras)
                    .Include(p => p.lstCandidatoDisponibilidadePeriodo)
                    .Include(l => l.lstCandidatoLinguagem)
                    .FirstOrDefault(c => c.Id == dto.Id);

                candidato_db.lstCandidatoDisponibilidadePeriodo.RemoveAll(p => p.DisponibilidadePeriodoId > 0);

                candidato_db.lstCandidatoDisponibilidadeHoras.RemoveAll(p => p.DisponibilidadeHorasId > 0);

                candidato_db.lstCandidatoLinguagem.RemoveAll(p => p.LinguagemId > 0);

                candidato_db.Id = dto.Id;
                candidato_db.email = dto.email;
                candidato_db.nome = dto.nome;
                candidato_db.telefone = dto.telefone;
                candidato_db.skype = dto.skype;
                candidato_db.cidade = dto.cidade;
                candidato_db.uf = dto.uf;
                candidato_db.portifolio = dto.portifolio;
                candidato_db.pretencao_salarial_hora = dto.pretencao_salarial_hora;
                candidato_db.linkedin = dto.linkedin;
                candidato_db.nota_outros = dto.nota_outros;
                candidato_db.link_crud = dto.link_crud;

                candidato_db.lstCandidatoDisponibilidadePeriodo = dto.lstCandidatoDisponibilidadePeriodo.FindAll(p => p.DisponibilidadePeriodoId > 0);

                candidato_db.lstCandidatoDisponibilidadeHoras = dto.lstCandidatoDisponibilidadeHoras.FindAll(p => p.DisponibilidadeHorasId > 0);

                candidato_db.lstCandidatoLinguagem = dto.lstCandidatoLinguagem.FindAll(p => p.LinguagemId > 0);

                DBSet.Attach(candidato_db).State = EntityState.Modified;

            }
            catch (Exception ex)
            {
                throw new Exception(ex?.InnerException?.Message ?? ex?.Message);
            }
        }

        public override Candidato Recuperar(Expression<Func<Candidato, bool>> predicate) => DBSet
            .Include(h => h.lstCandidatoDisponibilidadeHoras)
            .Include(p => p.lstCandidatoDisponibilidadePeriodo)
            .Include(l => l.lstCandidatoLinguagem)
            .FirstOrDefault(predicate);
    }

}
