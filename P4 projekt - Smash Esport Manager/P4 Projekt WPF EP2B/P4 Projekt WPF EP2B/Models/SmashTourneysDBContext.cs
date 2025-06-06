using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_Projekt_WPF_EP2B.Models
{
    public class SmashTourneysDBContext : DbContext
    {
        public DbSet<TourneyModel> Tourneys { get; set;}
        public DbSet<PlayerInTourneyModel> PlayersInTourneys { get; set; }
        public DbSet<PlayerModel> Players { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { // funkcja przy konfiguracji tworzenia bazy danych
            var connectionString = "Server=DESKTOP-QAFVCTU;Database=SmashTourneysDb;Trusted_Connection=True;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionString);
            // użyj bazy danych podanej w connectionString
            base.OnConfiguring(optionsBuilder);
        }
    }
}
