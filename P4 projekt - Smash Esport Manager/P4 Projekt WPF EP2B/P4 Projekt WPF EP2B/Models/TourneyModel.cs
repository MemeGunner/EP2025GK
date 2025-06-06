using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_Projekt_WPF_EP2B.Models
{
    public class TourneyModel
    {
        [Key]
        public int tId {  get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nazwa Turnieju nie może być pusta!")]
        [StringLength(80)]
        public string tName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nazwa strony, na której jest turniej, nie może być pusta!")]
        [StringLength(25)]
        public string tWhichSite { get; set; }
        public string? tSiteLink { get; set; }
        public required DateOnly tStartDate { get; set; }
        public required DateOnly tEndDate { get; set; }
        public required bool tIsOnline { get; set; }
        [StringLength(60)]
        public string? tAdress { get; set; }
        [StringLength(15)]
        public string? tCity { get; set;}
        [StringLength(10)]
        public string? tZipCode { get; set;}
        [StringLength(56)]
        public string? tCountry { get; set;}
        public string? tNotes { get; set; }
        public ICollection<PlayerInTourneyModel> playerInTourneys { get; set; } = new List<PlayerInTourneyModel>();
    }
}
