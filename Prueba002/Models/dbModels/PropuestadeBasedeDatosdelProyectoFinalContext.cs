using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Prueba002.Models.dbModels
{
    public partial class PropuestadeBasedeDatosdelProyectoFinalContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public PropuestadeBasedeDatosdelProyectoFinalContext()
        {
        }

        public PropuestadeBasedeDatosdelProyectoFinalContext(DbContextOptions<PropuestadeBasedeDatosdelProyectoFinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<Artistum> Artista { get; set; } = null!;
        public virtual DbSet<ComentaioAlbum> ComentaioAlbums { get; set; } = null!;
        public virtual DbSet<Favorito> Favoritos { get; set; } = null!;
        public virtual DbSet<Genero> Generos { get; set; } = null!;
        public virtual DbSet<ListaAlbum> ListaAlbums { get; set; } = null!;
        public virtual DbSet<Listum> Lista { get; set; } = null!;
        public virtual DbSet<OpcionRespuestum> OpcionRespuesta { get; set; } = null!;
        public virtual DbSet<PreguntaTest> PreguntaTests { get; set; } = null!;
        public virtual DbSet<RespuestaPreguntaTest> RespuestaPreguntaTests { get; set; } = null!;
        public virtual DbSet<Sugerencium> Sugerencia { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasOne(d => d.IdArtistaNavigation)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.IdArtista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Album_Artista");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Album_Genero");
            });

            modelBuilder.Entity<ComentaioAlbum>(entity =>
            {
                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithMany(p => p.ComentaioAlbums)
                    .HasForeignKey(d => d.IdAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComentaioAlbum_Album");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ComentaioAlbums)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComentaioAlbum_Usuario");
            });

            modelBuilder.Entity<Favorito>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdAlbum })
                    .HasName("PK_Favorito_1");

                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.IdAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favorito_Album");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favorito_Usuario");
            });

            modelBuilder.Entity<ListaAlbum>(entity =>
            {
                entity.HasKey(e => new { e.IdLista, e.IdAlbum });

                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithMany(p => p.ListaAlbums)
                    .HasForeignKey(d => d.IdAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lista-Album_Album");

                entity.HasOne(d => d.IdListaNavigation)
                    .WithMany(p => p.ListaAlbums)
                    .HasForeignKey(d => d.IdLista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lista-Album_Lista");
            });

            modelBuilder.Entity<Listum>(entity =>
            {
                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Lista)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lista_Usuario");
            });

            modelBuilder.Entity<OpcionRespuestum>(entity =>
            {
                entity.HasOne(d => d.IdPreguntaNavigation)
                    .WithMany(p => p.OpcionRespuesta)
                    .HasForeignKey(d => d.IdPregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpcionRespuesta_PreguntaTest");
            });

            modelBuilder.Entity<PreguntaTest>(entity =>
            {
                entity.HasKey(e => e.IdPregunta)
                    .HasName("PK_PreguntasTest");

                entity.HasOne(d => d.IdTestNavigation)
                    .WithMany(p => p.PreguntaTests)
                    .HasForeignKey(d => d.IdTest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreguntasTest_Test");
            });

            modelBuilder.Entity<RespuestaPreguntaTest>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdOpcionRespuesta });

                entity.HasOne(d => d.IdOpcionRespuestaNavigation)
                    .WithMany(p => p.RespuestaPreguntaTests)
                    .HasForeignKey(d => d.IdOpcionRespuesta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RespuestaPreguntaTest_OpcionRespuesta");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.RespuestaPreguntaTests)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RespuestasPreguntasTest_Usuario");
            });

            modelBuilder.Entity<Sugerencium>(entity =>
            {
                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Sugerencia)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sugerencia_Usuario");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
