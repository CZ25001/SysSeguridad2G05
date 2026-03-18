using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using SysSeguridad2G05.EN;

namespace SysSeguridad2G05.DAL
{
    public class DBContexto : DbContext //Se virtualiza cada tabla de la base de datos
    {
        public DbSet<Rol>  Rol { get; set; } //Se pueden agregar mas DbSet para cada tabla que se tenga en la base de datos

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=HP-ENVY;Initial Catalog=DbSysSeguridad2G05;Integrated Security=True;Encrypt=False");
        }
    }
}
