using HotelManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace HotelManager.Data
{
    public static class SeedData
    {
        public static WebApplication Seed(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<HotelManagerDbContext>();

                try
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    if (!context.RoomClasses.Any())
                    {
                        context.RoomClasses.AddRange(
                            new RoomClass { ClassName = "Single Room" ,
                                Description = "The room has a single bed, a desk that can serve as a work space," +
                            " a TV with all the most popular Bulgarian channels, heating in winter or a cool system for" +
                            " hot summer days. The room has a fully stocked mini bar for your needs. The bathrooms have hairdryers," +
                            " toiletries and everything you need for a stay.",
                                Capacity = 2,AllowsPet = true, TotalRooms = 5, BasePrice = 75m },
                            new RoomClass { ClassName = "Double Room",
                                Description = "Whether you are with your partner or a business colleague, the room offers you" +
                            " the best price-quality ratio. The room has a desk that can serve as a work space, a TV with all the most" +
                            " popular Bulgarian channels, heating in winter or a cool system for hot summer days. The room has a fully" +
                            " stocked mini bar for your needs. The bathrooms have hairdryers, toiletries and everything you need for a stay.",
                                Capacity = 4, AllowsPet = true,TotalRooms = 6, BasePrice = 100m },
                            new RoomClass {ClassName = "Studio",
                                Description = "The rooms are spacious, with two separate beds or one large bedroom. The rooms also have" +
                            " a sofa that can be made into a third, comfortable bed for your friends, a third adult or a child. The room has a desk" +
                            " that can serve as a work space, heating in winter or a cool system for hot summer days. The room has a fully stocked" +
                            " mini bar for your needs. The bathrooms have hairdryers, toiletries and everything you need for a vacation.",
                                Capacity = 5, AllowsPet = false,TotalRooms = 3, BasePrice = 120m },
                            new RoomClass {ClassName = "Deluxe Studio",
                                Description = "The room is the most spacious and luxurious room in our hotel. It has a hydro-massage bath," +
                            " a large round bedroom and a style that was known in the past only to the wealthiest Louis XVI. The room has a desk" +
                            " that can serve as a work space, heating in winter or a cool system for hot summer days. The room has a fully stocked" +
                            " mini bar for your needs. The bathrooms have hairdryers, toiletries and everything you need for a stay.",
                                Capacity = 6, AllowsPet = false,TotalRooms = 2,BasePrice = 160m });

                        context.SaveChanges();
                    }

                    if (!context.Features.Any())
                    {
                        context.AddRange(
                            new Feature { FeatureName = "TV" },
                            new Feature { FeatureName = "Mini Bar" },
                            new Feature { FeatureName = "Wi-Fi" },
                            new Feature { FeatureName = "Jacuzzi" },
                            new Feature { FeatureName = "Telephone" },
                            new Feature { FeatureName = "Air Conditioning" },
                            new Feature { FeatureName = "Hairdryer" },
                            new Feature { FeatureName = "Hot Tub" },
                            new Feature { FeatureName = "Desk" },
                            new Feature { FeatureName = "Sofa" });


                        context.SaveChanges();
                    }                  

                    if (!context.RoomClassFeatures.Any())
                    {
                        context.RoomClassFeatures.AddRange(
                        new RoomClassFeature { RoomClassId = 1, FeatureId = 1 },
                            new RoomClassFeature { RoomClassId = 1, FeatureId = 3 },
                            new RoomClassFeature { RoomClassId = 1, FeatureId = 5 },
                            new RoomClassFeature { RoomClassId = 1, FeatureId = 7 },
                            new RoomClassFeature { RoomClassId = 2, FeatureId = 1 },
                            new RoomClassFeature { RoomClassId = 2, FeatureId = 3 },
                            new RoomClassFeature { RoomClassId = 2, FeatureId = 6 },
                            new RoomClassFeature { RoomClassId = 2, FeatureId = 7 },
                            new RoomClassFeature { RoomClassId = 2, FeatureId = 8 },
                            new RoomClassFeature { RoomClassId = 2, FeatureId = 5 },
                            new RoomClassFeature { RoomClassId = 2, FeatureId = 9 },
                            new RoomClassFeature { RoomClassId = 3, FeatureId = 1 },
                            new RoomClassFeature { RoomClassId = 3, FeatureId = 2 },
                            new RoomClassFeature { RoomClassId = 3, FeatureId = 3 },
                            new RoomClassFeature { RoomClassId = 3, FeatureId = 6 },
                            new RoomClassFeature { RoomClassId = 3, FeatureId = 7 },
                            new RoomClassFeature { RoomClassId = 3, FeatureId = 8 },
                            new RoomClassFeature { RoomClassId = 3, FeatureId = 5 },
                            new RoomClassFeature { RoomClassId = 3, FeatureId = 9 },
                            new RoomClassFeature { RoomClassId = 3, FeatureId = 10 },
                            new RoomClassFeature { RoomClassId = 4, FeatureId = 1 },
                            new RoomClassFeature { RoomClassId = 4, FeatureId = 2 },
                            new RoomClassFeature { RoomClassId = 4, FeatureId = 3 },
                            new RoomClassFeature { RoomClassId = 4, FeatureId = 4 },
                            new RoomClassFeature { RoomClassId = 4, FeatureId = 5 },
                            new RoomClassFeature { RoomClassId = 4, FeatureId = 6 },
                            new RoomClassFeature { RoomClassId = 4, FeatureId = 7 },
                            new RoomClassFeature { RoomClassId = 4, FeatureId = 8 },
                            new RoomClassFeature { RoomClassId = 4, FeatureId = 9 },
                            new RoomClassFeature { RoomClassId = 4, FeatureId = 10 });

                        context.SaveChanges();
                    }

                    if (!context.RoomStatuses.Any())
                    {
                        context.RoomStatuses.AddRange(
                            new RoomStatus { StatusName = "Free" },
                            new RoomStatus { StatusName = "For Cleaning" },
                            new RoomStatus { StatusName = "Busy" });

                        context.SaveChanges();
                    }

                    if (!context.PaymentStatuses.Any())
                    {
                        context.PaymentStatuses.AddRange(
                            new PaymentStatus { StatusName = "With Debit/Credit card" },
                            new PaymentStatus { StatusName = "With Cash" });

                        context.SaveChanges();
                    }

                    if (!context.Rooms.Any())
                    {
                        context.Rooms.AddRange(
                            new Room {RoomFloor = 1, RoomClassId = 1, RoomStatusId = 1, RoomNumber = 101 },
                            new Room {RoomFloor = 1, RoomClassId = 1, RoomStatusId = 1, RoomNumber = 102 },
                            new Room {RoomFloor = 1, RoomClassId = 1, RoomStatusId = 1, RoomNumber = 103 },
                            new Room {RoomFloor = 1, RoomClassId = 1, RoomStatusId = 1, RoomNumber = 104 },
                            new Room {RoomFloor = 1, RoomClassId = 1, RoomStatusId = 1, RoomNumber = 105 },
                            new Room {RoomFloor = 2, RoomClassId = 2, RoomStatusId = 1, RoomNumber = 201 },
                            new Room {RoomFloor = 2, RoomClassId = 2, RoomStatusId = 1, RoomNumber = 202 },
                            new Room {RoomFloor = 2, RoomClassId = 2, RoomStatusId = 1, RoomNumber = 203 },
                            new Room {RoomFloor = 2, RoomClassId = 2, RoomStatusId = 1, RoomNumber = 204 },
                            new Room {RoomFloor = 2, RoomClassId = 2, RoomStatusId = 1, RoomNumber = 205 },
                            new Room {RoomFloor = 2, RoomClassId = 2, RoomStatusId = 1, RoomNumber = 206 },
                            new Room {RoomFloor = 3, RoomClassId = 3, RoomStatusId = 1, RoomNumber = 301 },
                            new Room {RoomFloor = 3, RoomClassId = 3, RoomStatusId = 1, RoomNumber = 302 },
                            new Room {RoomFloor = 3, RoomClassId = 3, RoomStatusId = 1, RoomNumber = 303 },
                            new Room {RoomFloor = 4, RoomClassId = 4, RoomStatusId = 1, RoomNumber = 401 },
                            new Room {RoomFloor = 4, RoomClassId = 4, RoomStatusId = 1, RoomNumber = 402 });

                        context.SaveChanges();
                    }
                }
                catch (Exception)
                {

                    throw;
                }

                return app;
            }
        }


        public static async Task SeedRolesAndGuestsAsync(IApplicationBuilder applicationBuilder)
        {
            using (var scoped = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = scoped.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(SeedRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(SeedRoles.Admin));
                if (!await roleManager.RoleExistsAsync(SeedRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(SeedRoles.User));

                //Users
                var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<Guest>>();
                string adminUserEmail = "mineset@abv.bg";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new Guest
                    {
                        FirstName = "Toskis",
                        LastName = "Zaranov",
                        PhoneNumber = "0882547459",
                        Email = adminUserEmail
                    };
                    newAdminUser.UserName = "Miogre";
                    newAdminUser.EmailConfirmed = true;


                    await userManager.CreateAsync(newAdminUser, "Coding@4321??");
                    await userManager.AddToRoleAsync(newAdminUser, SeedRoles.Admin);
                }

                string appUserEmail = "p.panushev@abv.bg";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new Guest 
                    {
                        FirstName = "David",
                        LastName = "Atanasov",
                        PhoneNumber = "0893544851",
                        Email = appUserEmail
                    };
                    newAppUser.UserName = "Test";
                    newAppUser.EmailConfirmed = true;

                    await userManager.CreateAsync(newAppUser, "Vaskata!23");
                    await userManager.AddToRoleAsync(newAppUser, SeedRoles.User);
                }

            }
        }
    }
}
