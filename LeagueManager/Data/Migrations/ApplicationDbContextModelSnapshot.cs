using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LeagueManager.Data;

namespace LeagueManager.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LeagueManager.Data.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("LeagueManager.Data.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Dates");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("LeagueManager.Data.TournamentGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool?>("ParticipantAGameIsWinner");

                    b.Property<int?>("ParticipantATournamentGameId");

                    b.Property<int?>("ParticipantATournamentTeamId");

                    b.Property<bool?>("ParticipantBGameIsWinner");

                    b.Property<int?>("ParticipantBTournamentGameId");

                    b.Property<int?>("ParticipantBTournamentTeamId");

                    b.Property<string>("Result");

                    b.Property<string>("Tag");

                    b.Property<int>("TournamentId");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantATournamentGameId");

                    b.HasIndex("ParticipantATournamentTeamId");

                    b.HasIndex("ParticipantBTournamentGameId");

                    b.HasIndex("ParticipantBTournamentTeamId");

                    b.HasIndex("TournamentId");

                    b.ToTable("TournamentGames");
                });

            modelBuilder.Entity("LeagueManager.Data.TournamentGameTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Score");

                    b.Property<int>("TournamentGameId");

                    b.Property<int>("TournamentTeamId");

                    b.HasKey("Id");

                    b.HasIndex("TournamentGameId");

                    b.HasIndex("TournamentTeamId");

                    b.ToTable("TournamentGameTeams");
                });

            modelBuilder.Entity("LeagueManager.Data.TournamentTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Seed");

                    b.Property<int>("TeamId");

                    b.Property<string>("TeamNameOverride");

                    b.Property<int>("TournamentId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("TournamentId");

                    b.ToTable("TournamentTeams");
                });

            modelBuilder.Entity("LeagueManager.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LeagueManager.Data.TournamentGame", b =>
                {
                    b.HasOne("LeagueManager.Data.TournamentGame", "ParticipantATournamentGame")
                        .WithMany("ParticipantATournamentGames")
                        .HasForeignKey("ParticipantATournamentGameId");

                    b.HasOne("LeagueManager.Data.TournamentTeam", "ParticipantATournamentTeam")
                        .WithMany("ParticipantATournamentGames")
                        .HasForeignKey("ParticipantATournamentTeamId");

                    b.HasOne("LeagueManager.Data.TournamentGame", "ParticipantBTournamentGame")
                        .WithMany("ParticipantBTournamentGames")
                        .HasForeignKey("ParticipantBTournamentGameId");

                    b.HasOne("LeagueManager.Data.TournamentTeam", "ParticipantBTournamentTeam")
                        .WithMany("ParticipantBTournamentGames")
                        .HasForeignKey("ParticipantBTournamentTeamId");

                    b.HasOne("LeagueManager.Data.Tournament", "Tournament")
                        .WithMany("TournamentGames")
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("LeagueManager.Data.TournamentGameTeam", b =>
                {
                    b.HasOne("LeagueManager.Data.TournamentGame", "TournamentGame")
                        .WithMany("TournamentGameTeams")
                        .HasForeignKey("TournamentGameId");

                    b.HasOne("LeagueManager.Data.TournamentTeam", "TournamentTeam")
                        .WithMany("TournamentGameTeams")
                        .HasForeignKey("TournamentTeamId");
                });

            modelBuilder.Entity("LeagueManager.Data.TournamentTeam", b =>
                {
                    b.HasOne("LeagueManager.Data.Team", "Team")
                        .WithMany("TournamentTeams")
                        .HasForeignKey("TeamId");

                    b.HasOne("LeagueManager.Data.Tournament", "Tournament")
                        .WithMany("TournamentTeams")
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LeagueManager.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LeagueManager.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LeagueManager.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
