using EchoHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Data.Context
{
    public class EchoHotelContext: DbContext
    {

        public EchoHotelContext(): base(ConfigurationManager.ConnectionStrings["EchoHotel"].ConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());

            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Entity<Cliente>().HasRequired(c => c.Endereco).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Hotel>().HasRequired(c => c.Endereco).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<Hotel>().HasMany<Adicional>(h => h.Adicionais).WithMany(a => a.Hoteis)
            //    .Map(ha => {
            //        ha.MapLeftKey("HotelId");
            //        ha.MapRightKey("AdicionalId");
            //        ha.ToTable("AdicionalHotel");
            //    });

            //modelBuilder.Entity<Acomodacao>().HasMany<Adicional>(h => h.Adicionais).WithMany(a => a.Acomodacoes)
            //    .Map(ha => {
            //        ha.MapLeftKey("AcomodacaoId");
            //        ha.MapRightKey("AdicionaoId");
            //        ha.ToTable("AdicionalAcomodacao");
            //    });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Adicional> Adicional { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Acomodacao> Acomodacao { get; set; }
        public DbSet<Endereco> Endereco { get; set; }


    }
}
