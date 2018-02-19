using LmycDataLib.Models;
using LmycWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LmycDataLib.Data
{
    class DummyData
    {
        public static List<Boat> getBoats(ApplicationDbContext context)
        {
            List<Boat> boats = new List<Boat>()
            {
                new Boat()
                {
                    BoatName = "Sharqui",
                    Picture = { },
                    LengthInFeet = 27,
                    Make = "C&C",
                    Year = 1981,
                    RecordCreationDate = new DateTime(),
                    ApplicationUser = context.Users.FirstOrDefault(u => u.Email == "a@a.a")
                },
                new Boat()
                {
                    BoatName = "Pegasus",
                    Picture = { },
                    LengthInFeet = 27,
                    Make = "C&C",
                    Year = 1979,
                    RecordCreationDate = new DateTime(),
                    ApplicationUser = context.Users.FirstOrDefault(u => u.Email == "a@a.a")
                },
                new Boat()
                {
                    BoatName = "Frankie",
                    Picture = { },
                    LengthInFeet = 25,
                    Make = "Cal Mark 2",
                    Year = 1983,
                    RecordCreationDate = new DateTime(),
                    ApplicationUser = context.Users.FirstOrDefault(u => u.Email == "a@a.a")
                },
            };

            return boats;
        }
    }
}
