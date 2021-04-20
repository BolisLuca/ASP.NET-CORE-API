using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ArticlesAPI.Entities
{
    public partial class dbarticoliContext : DbContext
    {
        public dbarticoliContext()
        {
        }

        public dbarticoliContext(DbContextOptions<dbarticoliContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articoli> Articolis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=dbarticoli;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articoli>(entity =>
            {
                entity.ToTable("articoli");

                entity.HasIndex(e => e.Titolo, "Titolo")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID").ValueGeneratedOnAdd()
                   ;

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(90)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Prezzo)
                    .HasColumnType("decimal(7,2)")
                    .HasDefaultValueSql("'5.99'");

                entity.Property(e => e.Titolo)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
