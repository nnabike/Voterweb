using System.ComponentModel.DataAnnotations;

namespace VoterWeb.Models
{
    public class VoterViewModel
    {
        [Required]
        public string Name { get; set; } 
        public int VoterId { get; set; } 
        
        public string Message { get; set; }
        
    }
}