
using EntityFrame.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrame.Data
{   

    //el db context nos sirve para poder generar un modelo de base de datos, este contiene dentro del
    //mismo las entidades (modelos) que se deben crear cuando pasamos la clase con el contexto a program. 
    //EntityFramework sabe cuales son nuestros modelos gracias a DbSet en donde pasamos cada entidad 
    //de nuestro programa
   
    public class APIContext:DbContext
    {   

        //El DbSet representa toda la data de una entidad
        public DbSet<Client> Clients { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transfer> Transfers { get; set; }  


        public APIContext(DbContextOptions<APIContext> options): base(options) { }



        //sobreescritura (override) del método OnModelCreating de EntityFramework (es el encargado de 
        //crear los modelos). Ya que EntityFramework tiene limitaciones con los atributos que podemos 
        //crear de nuestros modelos. Al realizar esta funcionalidad deberíamos obviar los atributos 
        //que hemos usado en nuestro (ver primer commit) y usar estos. En pocas palabras, aquí creamos 
        //nuestras tablas y sus atributos con sus constraints
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   

            //decimos que la entidad es el modelo Client
            modelBuilder.Entity<Client>(client => 
            {

                //convertimos el modelo cliente en una tabla con las funciones de FluentAPI
                client.ToTable("cliente");

                //decimos que queremos convertir cedula en PrimaryKey
                client.HasKey(c => c.cedula);

                client.Property(c => c.cedula).IsRequired();

                //agregamos propiedades (atributos o constraints) a columna tipo_doc
                client.Property(c => c.tipo_doc).IsRequired().HasMaxLength(10);

                //agregamos propiedades (atributos o constraints) a columna nombre_apellido
                client.Property(c => c.nombre_apellido).IsRequired().HasMaxLength(50);

                client.Ignore(c => c.cedula_ac);


                //insercion de datos
                //client.HasData(data);
            });

            //hacemos lo mismo que client pero con diferentes columnas ya que los modelos son diferentes
            modelBuilder.Entity<Bank>(bank =>
            {

                bank.ToTable("banco");

                bank.HasKey(b => b.codigo_banco);

                bank.Property(b => b.codigo_banco).HasMaxLength(8).IsRequired();

                bank.Property(b => b.nombre_banco).IsRequired().HasMaxLength(50);

                bank.Property(b => b.direccion).IsRequired().HasMaxLength(50);
            });


            modelBuilder.Entity<Account>(account =>
            {

                account.ToTable("cuenta");

                account.Property(a => a.id_cta).IsRequired();

                account.HasKey(a => a.num_cta);

                account.Property(a => a.moneda).IsRequired().HasMaxLength(50);

                account.Property(a => a.saldo).IsRequired();

                account.HasOne(a => a.cedula).WithMany(a =>  a.cedula_ac).HasForeignKey(a => a.cedula_cliente);

                account.HasOne(a => a.codigo_banco).WithMany(a => a.codigo_banco_ac).HasForeignKey(a => a.cod_banco);

            });

            modelBuilder.Entity<Transfer>(transfer =>
            {

                transfer.ToTable("transferencia");

                transfer.HasKey(t => t.id_transaccion);

                transfer.Property(t => t.fecha).IsRequired();

                transfer.Property(t => t.monto).IsRequired();

                transfer.Property(t => t.estado).IsRequired().HasMaxLength(9);

                transfer.HasOne(t => t.num_cta_origen).WithMany(a => a.numero_cta_origen).HasForeignKey(t => t.num_cta);
                
                transfer.HasOne(t => t.numero_cta_destino_ac).WithMany(a => a.numero_cta_destino).HasForeignKey(t => t.num_cta_destino);

                transfer.HasOne(t => t.codigo_banco_origen_bk).WithMany(b => b.codigo_banco_origen).HasForeignKey(t => t.cod_banco_origen);

                transfer.HasOne(t => t.codigo_banco_destino_bk).WithMany(b => b.codigo_banco_destino).HasForeignKey(t => t.cod_banco_destino);


            });






        }
    }
}
