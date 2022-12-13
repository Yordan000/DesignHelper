using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignHelper.Infrastructure.Data.Configuration
{
    internal class ProjectsConfiguration : IEntityTypeConfiguration<ProjectEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectEntity> builder)
        {
            builder.HasData(CreateProjects());
        }

        private List<ProjectEntity> CreateProjects()
        {
            var projects = new List<ProjectEntity>()
            {
                new ProjectEntity()
                {
                     Id = 1,
                     Title = "Refining the Ordinary",
                     Location = "No. 181 Rui Hong Road, Hong Kou District, Shanghai, China",
                     Description = "Cultivating elegance in the everyday. Located in the North Bund of Hongkou District, Hall of the Sun is a 180,000 square meter commercial hub with an emphasis of nature in the design, including its curvilinear facade and a 3-storey-high biophilic food hall under Shanghai’s largest skylight roof canopy. Informed by the organic architecture, Lukstudio has extended the concept of nature and vitality into the public interior spaces.",
                     ImageUrl = "https://amazingarchitecture.com/storage/3335/responsive-images/1-refining_the_ordinary_lukstudio_shanghai___media_library_original_1343_755.jpg",
                     Area = 5900,
                     Rating = 7.9M,
                     CategoryId = 2,
                     AwardId = 2,
                     Author = "LUKSTUDIO",
                     IsActive = true,
                     AddedById = "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07"
                },
                new ProjectEntity()
                {
                     Id = 2,
                     Title = "Crestridge Residence",
                     Location = "Rancho Palos Verdes, California, USA",
                     Description = "This full gut remodel was realized for a design minded couple moving from New York back to LA. Making the transition back to sunny California, the couple had visions of keeping doors and windows open year-round. Self-proclaimed foodies, they were looking forward to weekend gatherings and being able to entertain inside and out. They purchased a home that had the square footage and lot size they wanted but lacked the aesthetics, flow and functions they sought. Modern, warm and uncluttered was their vision. Without adding a square foot, the existing house was transformed from a “drive by - don’t notice you” tired, tract home, into a custom, “that’s a remodel?” modern home that fully encompassed the warmth of family life with the modern aesthetic the couple was looking for.",
                     ImageUrl = "https://amazingarchitecture.com/storage/3427/responsive-images/crestridge_residence_colega_architects_california___media_library_original_1344_756.jpg",
                     Area = 2360,
                     Rating = 9.1M,
                     CategoryId = 1,
                     AwardId = 5,
                     Author = "Colega Architects",
                     IsActive = true,
                     AddedById = "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07"
                },
                new ProjectEntity()
                {
                     Id = 3,
                     Title = "Armitaj Hotel",
                     Location = "Kish Island, Iran",
                     Description = "The development of Kish in terms of tourism has led to the construction of new urban texture and buildings in the city to attract tourists and it can be noted that hotels are a potential platform that attracts tourists in the city texture according to their architectural-environmental factors.",
                     ImageUrl = "https://amazingarchitecture.com/storage/3369/responsive-images/1-armitaj_hotel_kish_island_ashariarchitects___media_library_original_1344_756.jpg",
                     Area = 6230,
                     Rating = 8.3M,
                     CategoryId = 3,
                     AwardId = 3,
                     Author = "AshariArchitects",
                     IsActive = true,
                     AddedById = "5faa7c98-430f-4036-928f-f5210e8fbeea"
                },
                new ProjectEntity()
                {
                     Id = 4,
                     Title = "Villa Lavante",
                     Location = "Antiparos, Greece",
                     Description = "Villa Lavante is a luxury holiday home whose construction was completed in July 2019. It is located within a complex consisting of two adjoining and fully equipped and furnished luxury villas (Villa Lavante with an independent guest house and Villa Rosmarina). Each has its own large pool. The two villas are separated by a long stone fence.",
                     ImageUrl = "https://amazingarchitecture.com/storage/2288/responsive-images/villa_lavante_antiparos_greece_maria_eirini_moschona-___media_library_original_1344_756.jpg",
                     Area = 385,
                     Rating = 7.9M,
                     CategoryId = 4,
                     AwardId = 5,
                     Author = "Maria Eirini Moschona",
                     IsActive = true,
                     AddedById = "5faa7c98-430f-4036-928f-f5210e8fbeea"
                },
                new ProjectEntity()
                {
                     Id = 5,
                     Title = "Furioso Vineyards",
                     Location = "Dundee, Oregon, USA",
                     Description = "The Furioso Vineyards project consists of the renovation and expansion of an existing winery, including the addition of a new tasting room and public amenity spaces. The original Furioso estate, located in the heart of Oregon’s wine country, was made up of a series of disconnected utilitarian structures scattered across its property, including a steel-shed winery, various storage facilities, outdoor crush pad, and an adjacent residence. Built in disparate styles and materials, the estate lacked a cohesive identity. In addition, although completely surrounded by vineyards, the buildings turned their backs on the landscape, instead focusing on internal production.",
                     ImageUrl = "https://amazingarchitecture.com/storage/3278/responsive-images/1-furioso_vineyards_waechter_architecture_dundee___media_library_original_1344_756.jpg",
                     Area = 9800,
                     Rating = 9.4M,
                     CategoryId = 1,
                     AwardId = 1,
                     Author = "Waechter Architecture",
                     IsActive = true,
                     AddedById = "5faa7c98-430f-4036-928f-f5210e8fbeea"
                },
                new ProjectEntity()
                {
                     Id = 6,
                     Title = "Zen Oasis",
                     Location = "The Pavilion Bay, New Territories, Hong Kong",
                     Description = "“Zen Oasis” - A home gateway infused with Japanese aesthetics designed by Minus Workshop. The founder of Minus Workshop, Kevin Yiu has long been inspired by Eastern philosophies. He has taken over this residential design project into a modified version of the spirit of zen in Japan for a family who loves Japanese culture and wants a respite from the hustle and bustle of city life. With the simple three worded design brief “Japanese, zen and calm” to request Kevin to design his 120 square metre apartment. As a result, Yiu also breaks through the paradox between how we imagine stereotypical Japanese minimalism.",
                     ImageUrl = "https://amazingarchitecture.com/storage/2613/responsive-images/zen_oasis_minus_workshop_hong_kong___media_library_original_1344_756.jpg",
                     Area = 120,
                     Rating = 5.9M,
                     CategoryId = 2,
                     AwardId = 5,
                     Author = "Minus Workshop",
                     IsActive = true,
                     AddedById = "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07"
                },
                new ProjectEntity()
                {
                     Id = 7,
                     Title = "Wenzhou Innovaland Start-Up Zone",
                     Location = "Wenzhou, China",
                     Description = "Wenzhou is planned to be one of the global high-tech cities by establishing Wenzhou Innovaland. The start-up zone integrates technology, financial, wellness and education, creating a mixed-use innovative hub in Wenzhou. Aedas Executive Director Yaochun Wen and Global Design Principal Dr. Andy Wen have jointly led the team to create a pioneering space in the zone.",
                     ImageUrl = "https://amazingarchitecture.com/storage/3212/responsive-images/wenzhou_innovaland_start_up_zone_aedas___media_library_original_1344_756.jpg",
                     Area = 119608,
                     Rating = 8.9M,
                     CategoryId = 3,
                     AwardId = 5,
                     Author = "Aedas",
                     IsActive = true,
                     AddedById = "5faa7c98-430f-4036-928f-f5210e8fbeea"
                },
                new ProjectEntity()
                {
                     Id = 8,
                     Title = "Plangrad Architects",
                     Location = "Bremen, Germany",
                     Description = "German hotel & architecture photographer Vivien Renziehausen portrayed the newly built company building of Plangrad Architects in Bremen, Germany. The building was designed and planned by the respective company itself. The concept of an open office whilst still having the privacy of your own office space has been greatly achieved through large glass fronts both on the outside and inside of the building. Symmetry and clear forms and structures dominate the interior and exterior design what made it technically challenging to photograph. Still, Vivien skillfully managed to capture and showcase the light and airy atmosphere within the straight architectural concept.",
                     ImageUrl = "https://amazingarchitecture.com/storage/3059/responsive-images/plangrad_architects_vivien_renziehausen_bremen_germany___media_library_original_1344_756.jpg",
                     Area = 289,
                     Rating = 6.8M,
                     CategoryId = 4,
                     AwardId = 5,
                     Author = "Vivien Renziehausen",
                     IsActive = true,
                     AddedById = "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07"
                }
            };

            return projects;
        }
    }
}
