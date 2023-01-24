using Fiap.Api.AspNet.Models;
using Fiap.Api.AspNet.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.AspNet.Repository
{
    public class RepresentanteRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public RepresentanteRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IList<RepresentanteModel> Listar()
        {
            var lista = new List<RepresentanteModel>();
            lista = dataBaseContext.Representante.ToList<RepresentanteModel>();
            return lista;
        }

        public IList<RepresentanteModel> ListarRepresentantesComClientes()
        {

            var lista = new List<RepresentanteModel>();

            lista = dataBaseContext.Representante
                    .Include(r => r.Clientes)
                        .ToList<RepresentanteModel>();

            return lista;
        }


        public IList<RepresentanteModel> ListarOrdenadoPorNome()
        {
            var lista = new List<RepresentanteModel>();

            lista = dataBaseContext
                .Representante
                .OrderBy(r => r.NomeRepresentante).ToList<RepresentanteModel>();

            return lista;
        }

        public IList<RepresentanteModel> ListarOrdenadoPorNomeDescendente()
        {
            var lista = new List<RepresentanteModel>();

            lista = dataBaseContext
                .Representante
                .OrderByDescending(r => r.NomeRepresentante).ToList<RepresentanteModel>();

            return lista;
        }


        public RepresentanteModel ConsultarPorCpf(String cpf)
        {
            var representante = dataBaseContext.Representante.
                    Where(r => r.Cpf == cpf).
                        FirstOrDefault<RepresentanteModel>();

            return representante;
        }

        public RepresentanteModel ConsultarPorParteNome(String nomeParcial)
        {
            var representante = dataBaseContext.Representante.
                    Where(r => r.NomeRepresentante.Contains(nomeParcial)).AsNoTracking().
                        FirstOrDefault<RepresentanteModel>();

            return representante;
        }

        public RepresentanteModel Consultar(int id)
        {
            var representante = dataBaseContext.Representante.AsNoTracking()
                    .FirstOrDefault( r => r.RepresentanteId == id);

            return representante;
        }

        public void Inserir(RepresentanteModel representante)
        {
            dataBaseContext.Representante.Add(representante);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(RepresentanteModel representante)
        {
            dataBaseContext.Representante.Update(representante);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            try
            {
                var representante = new RepresentanteModel(id, "");

                dataBaseContext.Representante.Remove(representante);
                dataBaseContext.SaveChanges();
            } catch (Exception e)
            {
                throw e;
            }
        }

    }
}
