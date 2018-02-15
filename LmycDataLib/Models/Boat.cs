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
        public int BoatId { get; set; }
        public string BoatName { get; set; }
        public string Picture { get; set; }
        public int LengthInFeet { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RecordCreationDate { get; set; }
        
        [ScaffoldColumn(false)]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
