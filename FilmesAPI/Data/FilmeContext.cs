﻿using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Sessao>().HasKey(sessao => new {sessao.FilmeId, sessao.CinemaId});
        builder.Entity<Sessao>().HasOne(sessao => sessao.Cinema).WithMany(cinema => cinema.Sessoes).HasForeignKey(sessao => sessao.CinemaId).OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Sessao>().HasOne(sessao => sessao.Filme).WithMany(filme => filme.Sessoes).HasForeignKey(sessao => sessao.FilmeId);
        builder.Entity<Endereco>().HasOne(endereco => endereco.Cinema).WithOne(cinema => cinema.Endereco).OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
}
