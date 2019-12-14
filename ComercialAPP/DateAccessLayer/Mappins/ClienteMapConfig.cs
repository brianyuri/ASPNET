using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccessLayer.Mappins
{
    class ClienteMapConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteMapConfig()
        {
            this.ToTable("CLIENTES");
            this.Property(c => c.Nome).IsRequired().HasMaxLength(50).IsUnicode(false);
            this.Property(c => c.Email).IsRequired().HasMaxLength(50).IsUnicode(false);
            this.Property(c => c.CPF).IsRequired().IsFixedLength().HasMaxLength(11).IsUnicode(false);
        }
    }
}
