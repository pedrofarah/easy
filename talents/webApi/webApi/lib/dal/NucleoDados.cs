using System;
using lib.dto;
using lib.interfaces;

namespace lib.dal
{

    public class NucleoDados : INucleoDados, IDisposable
    {
        private AppDbContext _bdcontexto;

        public NucleoDados(AppDbContext context)
        {
            _bdcontexto = context;
        }

        public void Gravar()
        {
            _bdcontexto.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _bdcontexto.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private CandidatoRepositorio candidatoRepositorio = null;
        public IRepositorio<Candidato> CandidatoRepositorio
        {
            get
            {
                candidatoRepositorio = candidatoRepositorio ?? new CandidatoRepositorio(_bdcontexto);
                return candidatoRepositorio;
            }
        }

        private Repositorio<Linguagem> linguagemRepositorio = null;
        public IRepositorio<Linguagem> LinguagemRepositorio
        {
            get
            {
                linguagemRepositorio = linguagemRepositorio ?? new Repositorio<Linguagem>(_bdcontexto);
                return linguagemRepositorio;
            }
        }

        private Repositorio<DisponibilidadePeriodo> disponibilidadePeriodoRepositorio = null;
        public IRepositorio<DisponibilidadePeriodo> DisponibilidadePeriodoRepositorio
        {
            get
            {
                disponibilidadePeriodoRepositorio = disponibilidadePeriodoRepositorio ?? new Repositorio<DisponibilidadePeriodo>(_bdcontexto);
                return disponibilidadePeriodoRepositorio;
            }
        }

        private Repositorio<DisponibilidadeHoras> disponibilidadeHorasRepositorio = null;
        public IRepositorio<DisponibilidadeHoras> DisponibilidadeHorasRepositorio
        {
            get
            {
                disponibilidadeHorasRepositorio = disponibilidadeHorasRepositorio ?? new Repositorio<DisponibilidadeHoras>(_bdcontexto);
                return disponibilidadeHorasRepositorio;
            }

        }

    }

}
