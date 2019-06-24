using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class EstabelecimentoContext : DbContext
    {
        public EstabelecimentoContext(DbContextOptions<EstabelecimentoContext> options) :base(options)
        {

        }

        public DbSet<estabelecimento> estabelecimentos  { get; set; }
    }
}
