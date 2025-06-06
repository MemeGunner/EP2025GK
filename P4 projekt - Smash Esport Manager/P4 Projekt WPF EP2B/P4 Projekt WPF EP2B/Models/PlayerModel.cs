using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_Projekt_WPF_EP2B.Models
{
    public class PlayerModel
    {
        [Key]
        public int pId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nazwa Gracza nie może być pusta!")]
        [StringLength(25)]
        public string pName { get; set; }
        [StringLength(15)]
        public string? pPrefix { get; set; }
        [StringLength(50)]
        public string? pPronouns { get; set; }
        [StringLength(18)]
        public string? pMainName { get; set; }
        public int? pDifficulty { get; set; }
        [StringLength(56)]
        public string? pCountry { get; set; }
        public DateOnly? pJoinDate { get; set; }
        public string? pLink { get; set; }
        public required bool pIsAccountless { get; set; }
        public string? pNotes { get; set; }
        public ICollection<PlayerInTourneyModel> playerInTourneys { get; set; } = new List<PlayerInTourneyModel>();
    }
}
