using Fiap.Api.AspNet.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.AspNet.Repository.Context
{
    public class DataBaseContext : DbContext
    {
        // Propriedade que será responsável pelo acesso a tabela de Representantes
        public DbSet<RepresentanteModel> Representante { get; set; }

        // Propriedade que será responsável pelo acesso a tabela de Cliente
        public DbSet<ClienteModel> Cliente { get; set; }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DataBaseContext()
        {
        }

    }
}
