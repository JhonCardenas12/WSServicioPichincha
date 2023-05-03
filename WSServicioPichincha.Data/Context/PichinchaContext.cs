using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSServicioPichincha.Domain.Entities;

namespace WSServicioPichincha.Data.Context
{
    public class PichinchaContext : DbContext
    {
        public PichinchaContext(DbContextOptions<PichinchaContext> options) : base(options) { }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }
    }
}
