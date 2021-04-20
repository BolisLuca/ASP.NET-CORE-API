using Microsoft.EntityFrameworkCore;

namespace API_Chess.Entities
{
    public partial class dbchessgamesContext : DbContext
    {
        public dbchessgamesContext()
        {
        }

        public dbchessgamesContext(DbContextOptions<dbchessgamesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Moves> Moves { get; set; }
        public virtual DbSet<Opening> Opening { get; set; }
        public virtual DbSet<Players> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=root;password=;database=dbchessgames");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.Pkid)
                    .HasName("PRIMARY");

                entity.ToTable("games");

                entity.HasIndex(e => e.FkblackId)
                    .HasName("fkblack_id");

                entity.HasIndex(e => e.FkwhiteId)
                    .HasName("fkwhite_id");

                entity.HasIndex(e => e.OpeningEco)
                    .HasName("opening_eco");

                entity.Property(e => e.Pkid)
                    .HasColumnName("pkid")
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkblackId)
                    .IsRequired()
                    .HasColumnName("fkblack_id")
                    .HasMaxLength(30);

                entity.Property(e => e.FkwhiteId)
                    .IsRequired()
                    .HasColumnName("fkwhite_id")
                    .HasMaxLength(30);

                entity.Property(e => e.IncrementCode)
                    .IsRequired()
                    .HasColumnName("increment_code")
                    .HasMaxLength(5);

                entity.Property(e => e.LastMoveAt)
                    .HasColumnName("last_move_at")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OpeningEco)
                    .IsRequired()
                    .HasColumnName("opening_eco")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.Rated)
                    .HasColumnName("rated")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Turns)
                    .HasColumnName("turns")
                    .HasColumnType("int(3)");

                entity.Property(e => e.VictoryStatus)
                    .IsRequired()
                    .HasColumnName("victory_status")
                    .HasMaxLength(9);

                entity.Property(e => e.Winner)
                    .IsRequired()
                    .HasColumnName("winner")
                    .HasMaxLength(5);

                entity.HasOne(d => d.Fkblack)
                    .WithMany(p => p.GamesFkblack)
                    .HasForeignKey(d => d.FkblackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("games_ibfk_2");

                entity.HasOne(d => d.Fkwhite)
                    .WithMany(p => p.GamesFkwhite)
                    .HasForeignKey(d => d.FkwhiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("games_ibfk_1");

                entity.HasOne(d => d.OpeningEcoNavigation)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.OpeningEco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("games_ibfk_3");
            });

            modelBuilder.Entity<Moves>(entity =>
            {
                entity.HasKey(e => new { e.Ppkid, e.PpkfkGameId })
                    .HasName("PRIMARY");

                entity.ToTable("moves");

                entity.HasIndex(e => e.PpkfkGameId)
                    .HasName("ppkfkGameId");

                entity.Property(e => e.Ppkid)
                    .HasColumnName("ppkid")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PpkfkGameId)
                    .HasColumnName("ppkfkGameId")
                    .HasMaxLength(10);

                entity.Property(e => e.Move)
                    .IsRequired()
                    .HasColumnName("move")
                    .HasMaxLength(8);

                entity.HasOne(d => d.PpkfkGame)
                    .WithMany(p => p.Moves)
                    .HasForeignKey(d => d.PpkfkGameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("moves_ibfk_1");
            });

            modelBuilder.Entity<Opening>(entity =>
            {
                entity.HasKey(e => e.OpeningEco)
                    .HasName("PRIMARY");

                entity.ToTable("opening");

                entity.Property(e => e.OpeningEco)
                    .HasColumnName("opening_eco")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.OpeningName)
                    .IsRequired()
                    .HasColumnName("opening_name")
                    .HasMaxLength(30);

                entity.Property(e => e.OpeningPly)
                    .HasColumnName("opening_ply")
                    .HasColumnType("int(1)");
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasKey(e => e.Pkid)
                    .HasName("PRIMARY");

                entity.ToTable("players");

                entity.Property(e => e.Pkid)
                    .HasColumnName("pkid")
                    .HasMaxLength(30);

                entity.Property(e => e.PlayerRating)
                    .HasColumnName("player_rating")
                    .HasColumnType("int(4)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
