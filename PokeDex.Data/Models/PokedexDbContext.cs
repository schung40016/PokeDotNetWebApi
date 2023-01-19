using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PokeDex.Data.Models;

public partial class PokedexDbContext : DbContext
{
    public PokedexDbContext()
    {
    }

    public PokedexDbContext(DbContextOptions<PokedexDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ability> Abilities { get; set; }

    public virtual DbSet<Move> Moves { get; set; }

    public virtual DbSet<Pokemon> Pokemons { get; set; }

    public virtual DbSet<PokemonMove> PokemonMoves { get; set; }

    public virtual DbSet<PokemonType> PokemonTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=PokedexDB;Integrated Security=SSPI;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ability>(entity =>
        {
            entity.ToTable("Ability");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Move>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Move_1");

            entity.ToTable("Move");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Pp).HasColumnName("PP");

            entity.HasOne(d => d.Type).WithMany(p => p.Moves)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Move-Type");
        });

        modelBuilder.Entity<Pokemon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Pokemon_1");

            entity.ToTable("Pokemon");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Region).HasMaxLength(50);

            entity.HasOne(d => d.Ability).WithMany(p => p.Pokemons)
                .HasForeignKey(d => d.AbilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Poke Ability");

            entity.HasOne(d => d.PokemonType).WithMany(p => p.Pokemons)
                .HasForeignKey(d => d.PokemonTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Poke Type");
        });

        modelBuilder.Entity<PokemonMove>(entity =>
        {
            entity.ToTable("PokemonMove");

            entity.HasOne(d => d.Move).WithMany(p => p.PokemonMoves)
                .HasForeignKey(d => d.MoveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Move-Move");

            entity.HasOne(d => d.Pokemon).WithMany(p => p.PokemonMoves)
                .HasForeignKey(d => d.PokemonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Poke PokemonMove");
        });

        modelBuilder.Entity<PokemonType>(entity =>
        {
            entity.ToTable("PokemonType");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
