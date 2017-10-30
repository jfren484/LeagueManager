using LeagueManager.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        public ApplicationDbContext() {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Team>().Property(f => f.Id).ValueGeneratedNever();

            builder.Entity<TournamentGame>()
                .HasOne(tg => tg.Tournament)
                .WithMany(t => t.TournamentGames)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<TournamentGame>()
                .HasOne(tg => tg.ParticipantATournamentTeam)
                .WithMany(tt => tt.ParticipantATournamentGames)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<TournamentGame>()
                .HasOne(tg => tg.ParticipantBTournamentTeam)
                .WithMany(tt => tt.ParticipantBTournamentGames)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<TournamentGame>()
                .HasOne(tg => tg.ParticipantATournamentGame)
                .WithMany(tg => tg.ParticipantATournamentGames)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<TournamentGame>()
                .HasOne(tg => tg.ParticipantBTournamentGame)
                .WithMany(tg => tg.ParticipantBTournamentGames)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TournamentGameTeam>()
                .HasOne(tgt => tgt.TournamentGame)
                .WithMany(tg => tg.TournamentGameTeams)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<TournamentGameTeam>()
                .HasOne(tgt => tgt.TournamentTeam)
                .WithMany(tt => tt.TournamentGameTeams)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TournamentTeam>()
                .HasOne(tt => tt.Tournament)
                .WithMany(t => t.TournamentTeams)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<TournamentTeam>()
                .HasOne(tt => tt.Team)
                .WithMany(t => t.TournamentTeams)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentGame> TournamentGames { get; set; }
        public DbSet<TournamentGameTeam> TournamentGameTeams { get; set; }
        public DbSet<TournamentTeam> TournamentTeams { get; set; }
    }
}