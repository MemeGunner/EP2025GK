using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_Projekt_WPF_EP2B.Models
{
    public class PlayerInTourneyModel
    {
        [Key]
        public int pitId {  get; set; }
        public TourneyModel tourney { get; set; }
        public PlayerModel player { get; set; }
        public required bool pitIsPlaying { get; set; }
        public required bool pitIsTO {  get; set; }
        public int? pitSeeding { get; set; }
    }
}
