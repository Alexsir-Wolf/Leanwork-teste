using ApiRH.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiRH.Dominio;

public class ApiRHDbContext : DbContext
{
    public ApiRHDbContext(DbContextOptions options) : base(options)
    {        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Relacionamento EmpresaTecnologia
        modelBuilder.Entity<EmpresaTecnologia>()
            .HasKey(et => new { et.EmpresaId, et.TecnologiaId });

        modelBuilder.Entity<EmpresaTecnologia>()
            .HasOne(et => et.Empresa)
            .WithMany(e => e.EmpresaTecnologias)
            .HasForeignKey(et => et.EmpresaId);

        modelBuilder.Entity<EmpresaTecnologia>()
            .HasOne(et => et.Tecnologia)
            .WithMany(t => t.EmpresaTecnologias)
            .HasForeignKey(et => et.TecnologiaId);

        //Relacionamento CandidatoTecnologia
        modelBuilder.Entity<CandidatoTecnologia>()
            .HasKey(ct => new { ct.CandidatoId, ct.TecnologiaId });

        modelBuilder.Entity<CandidatoTecnologia>()
            .HasOne(ct => ct.Candidato)
            .WithMany(e => e.CandidatoTecnologias)
            .HasForeignKey(ct => ct.CandidatoId);

        modelBuilder.Entity<CandidatoTecnologia>()
            .HasOne(ct => ct.Tecnologia)
            .WithMany(t => t.CandidatoTecnologias)
            .HasForeignKey(ct => ct.TecnologiaId);

        //Relacionamento VagaTecnologia
        modelBuilder.Entity<VagaTecnologia>()
            .HasKey(ct => new { ct.VagaId, ct.TecnologiaId });

        modelBuilder.Entity<VagaTecnologia>()
            .HasOne(ct => ct.Vaga)
            .WithMany(e => e.VagaTecnologias)
            .HasForeignKey(ct => ct.VagaId);

        modelBuilder.Entity<VagaTecnologia>()
            .HasOne(ct => ct.Tecnologia)
            .WithMany(t => t.VagaTecnologias)
            .HasForeignKey(ct => ct.TecnologiaId);

        //Relacionamento VagaCandidato
        modelBuilder.Entity<VagaCandidato>()
            .HasKey(ct => new { ct.VagaId, ct.CandidatoId });

        modelBuilder.Entity<VagaCandidato>()
            .HasOne(ct => ct.Vaga)
            .WithMany(e => e.VagaCandidatos)
            .HasForeignKey(ct => ct.VagaId);

        modelBuilder.Entity<VagaCandidato>()
            .HasOne(ct => ct.Candidato)
            .WithMany(t => t.VagaCandidatos)
            .HasForeignKey(ct => ct.CandidatoId);
    }

    public DbSet<Candidato> Candidato { get; set; } 
    public DbSet<CandidatoTecnologia> CandidatoTecnologia { get; set; }
    public DbSet<Empresa> Empresa { get; set; }
    public DbSet<EmpresaTecnologia> EmpresaTecnologia { get; set; }
    public DbSet<Tecnologia> Tecnologia { get; set; }
    public DbSet<Vaga> Vaga { get; set; }
    public DbSet<VagaCandidato> VagaCandidato { get; set; }
    public DbSet<VagaTecnologia> VagaTecnologia { get; set; }
}
