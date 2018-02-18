using LmycWebSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LmycDataLib.Models
{
    public class Boat
    {
        [Key]
        public int BoatId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string BoatName { get; set; }
        [Required]
        [Display(Name = "Picture")]
        public string Picture { get; set; }
        [Required]
        [Display(Name = "Length (In Feet)")]
        public int LengthInFeet { get; set; }
        [Required]
        [Display(Name = "Make")]
        public string Make { get; set; }
        [Required]
        [Display(Name = "Year")]
        public int Year { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Created At")]
        public DateTime RecordCreationDate { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        [Column("Id")]
        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public Boat()
        {
            RecordCreationDate = DateTime.Now;
        }

    }
}
