using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context) {
            if(context.Activities.Any()) return;

            var activities = new List<CarActivity> {
                new CarActivity {
                    Title = "Tommorow activity",
                    Date = DateTime.Now.AddDays(1),
                    Description = "Activity for tommorow",
                    Category = "LongTruck",
                    City = "Novi Sad",
                    Venue = "NS",
                    CarModel = "Kamion",
                    CarName = "Sleper"
                },
                new CarActivity {
                    Title = "Yesterdays activity",
                    Date = DateTime.Now.AddDays(-1),
                    Description = "Yesterdaysss activity!",
                    Category = "Truck",
                    City = "Beograd",
                    Venue = "BG",
                    CarModel = "Kamion",
                    CarName = "Kamionce"
                },
                new CarActivity {
                    Title = "Super activity",
                    Date = DateTime.Now.AddMonths(2),
                    Description = "Maybe it will be nice activity",
                    Category = "Plane",
                    City = "Zrenjanin",
                    Venue = "ZR",
                    CarModel = "Plane",
                    CarName = "Redbull"
                },
                new CarActivity {
                    Title = "Extra good activity",
                    Date = DateTime.Now.AddMonths(1),
                    Description = "Maybe it won't be so nice activity",
                    Category = "Car",
                    City = "Ruski Krstur",
                    Venue = "RK",
                    CarModel = "M3",
                    CarName = "BMW"
                },
                new CarActivity {
                    Title = "Just some activity",
                    Date = DateTime.Now.AddMonths(4),
                    Description = "Boring activity",
                    Category = "Junk",
                    City = "Veternik",
                    Venue = "VET",
                    CarModel = "Pinto",
                    CarName = "Ford"
                },
                new CarActivity {
                    Title = "Another activity",
                    Date = DateTime.Now.AddMonths(5),
                    Description = "Also boring activity",
                    Category = "Junk2",
                    City = "Zmajevo",
                    Venue = "ZM",
                    CarModel = "Punto",
                    CarName = "Fiat"
                }
            };

            await context.Activities.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }
    }
}