﻿namespace Sabv.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Services.Data;

    public class ModelsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Models.Any())
            {
                return;
            }

            var modelsService = serviceProvider.GetRequiredService<IModelsService>();
            var makesService = serviceProvider.GetRequiredService<IMakesService>();

            var models = new Dictionary<string, List<string>>()
            {
                {
                    "BMW", new List<string>()
                        {
                             "1",
                             "114",
                             "116",
                             "118",
                             "120",
                             "123",
                             "125",
                             "130",
                             "135",
                             "1500",
                             "1600",
                             "1602",
                             "1800",
                             "2",
                             "2 Active Tourer",
                             "2 Gran Tourer",
                             "2000",
                             "2002",
                             "220 d",
                             "225",
                             "228",
                             "230",
                             "235",
                             "240",
                             "2800",
                             "3",
                             "315",
                             "316",
                             "318",
                             "320",
                             "323",
                             "324",
                             "325",
                             "328",
                             "330",
                             "335",
                             "340",
                             "3gt",
                             "4",
                             "420",
                             "428",
                             "430",
                             "435",
                             "440",
                             "5",
                             "5 Gran Turismo",
                             "501",
                             "518",
                             "520",
                             "523",
                             "524",
                             "525",
                             "528",
                             "530",
                             "535",
                             "540",
                             "545",
                             "550",
                             "6",
                             "628",
                             "630",
                             "633",
                             "635",
                             "640",
                             "645",
                             "650",
                             "7",
                             "700",
                             "721",
                             "723",
                             "725",
                             "728",
                             "730",
                             "732",
                             "733",
                             "735",
                             "740",
                             "745",
                             "750",
                             "760",
                             "840",
                             "850",
                             "Izetta",
                             "M",
                             "M Coupe",
                             "M135",
                             "M2",
                             "M3",
                             "M4",
                             "M5",
                             "M6",
                             "X1",
                             "X2",
                             "X3",
                             "X4",
                             "X5",
                             "X6",
                             "X7",
                             "Z1",
                             "Z3",
                             "Z4",
                             "Z8",
                             "i3",
                             "i8",
                        }
                },
                {
                    "Audi", new List<string>()
                    {
                        "100",
                        "200",
                        "50",
                        "60",
                        "80",
                        "90",
                        "A1",
                        "A2",
                        "A3",
                        "A4",
                        "A4 Allroad",
                        "A5",
                        "A6",
                        "A6 Allroad",
                        "A7",
                        "A8",
                        "Allroad",
                        "Cabriolet",
                        "Coupe",
                        "E-Tron",
                        "Q2",
                        "Q3",
                        "Q5",
                        "Q7",
                        "Q8",
                        "Quattro",
                        "R8",
                        "RSQ8",
                        "Rs3",
                        "Rs4",
                        "Rs5",
                        "Rs6",
                        "Rs7",
                        "S2",
                        "S3",
                        "S4",
                        "S5",
                        "S6",
                        "S7",
                        "S8",
                        "SQ5",
                        "SQ7",
                        "SQ8",
                        "Tt",
                    }
                },
                {
                    "Mercedes-Benz", new List<string>()
                    {
                        "110",
                        "111",
                        "113",
                        "114",
                        "115",
                        "116",
                        "123",
                        "124",
                        "126",
                        "126-260",
                        "150",
                        "170",
                        "180",
                        "190",
                        "200",
                        "220",
                        "230",
                        "240",
                        "250",
                        "260",
                        "280",
                        "290",
                        "300",
                        "320",
                        "350",
                        "380",
                        "420",
                        "450",
                        "500",
                        "560",
                        "600",
                        "A",
                        "A 140",
                        "A 150",
                        "A 160",
                        "A 170",
                        "A 180",
                        "A 190",
                        "A 200",
                        "A 210",
                        "A 220",
                        "A 250",
                        "A45 AMG",
                        "AMG GT",
                        "AMG GT C",
                        "AMG GT R",
                        "AMG GT S",
                        "Adenauer",
                        "B",
                        "B 150",
                        "B 160",
                        "B 170",
                        "B 180",
                        "B 200",
                        "B 220",
                        "B 250",
                        "C",
                        "C 160",
                        "C 180",
                        "C 200",
                        "C 220",
                        "C 230",
                        "C 240",
                        "C 250",
                        "C 270",
                        "C 280",
                        "C 30 AMG",
                        "C 300",
                        "C 32 AMG",
                        "C 320",
                        "C 350",
                        "C 36 AMG",
                        "C 400",
                        "C 43 AMG",
                        "C 450 AMG",
                        "C 55 AMG",
                        "C 63 AMG",
                        "CL",
                        "CL 230",
                        "CL 320",
                        "CL 420",
                        "CL 500",
                        "CL 55 AMG",
                        "CL 600",
                        "CL 63 AMG",
                        "CL 65 AMG",
                        "CLA",
                        "CLA 180",
                        "CLA 200",
                        "CLA 220",
                        "CLA 250",
                        "CLA 45 AMG",
                        "CLC",
                        "CLC 160",
                        "CLC 180",
                        "CLC 200",
                        "CLC 220",
                        "CLC 230",
                        "CLC 250",
                        "CLC 350",
                        "CLK",
                        "CLK 55 AMG",
                        "CLK 63 AMG",
                        "CLS",
                        "CLS 250",
                        "CLS 300",
                        "CLS 320",
                        "CLS 350",
                        "CLS 400",
                        "CLS 450",
                        "CLS 500",
                        "CLS 53 AMG",
                        "CLS 55",
                        "CLS 55 AMG",
                        "CLS 63",
                        "CLS 63 AMG",
                        "Citan",
                        "E",
                        "E 200",
                        "E 220",
                        "E 230",
                        "E 240",
                        "E 250",
                        "E 260",
                        "E 270",
                        "E 280",
                        "E 290",
                        "E 300",
                        "E 320",
                        "E 350",
                        "E 36 AMG",
                        "E 400",
                        "E 420",
                        "E 43 AMG",
                        "E 430",
                        "E 450",
                        "E 50 AMG",
                        "E 500",
                        "E 53 AMG",
                        "E 55",
                        "E 55 AMG",
                        "E 60",
                        "E 60 AMG",
                        "E 63 AMG",
                        "EQC",
                        "G",
                        "G 230",
                        "G 240",
                        "G 250",
                        "G 270",
                        "G 280",
                        "G 290",
                        "G 300",
                        "G 320",
                        "G 350",
                        "G 36 AMG",
                        "G 400",
                        "G 500",
                        "G 55 AMG",
                        "G 63 AMG",
                        "G 65 AMG",
                        "GL",
                        "GL 320",
                        "GL 350",
                        "GL 420",
                        "GL 450",
                        "GL 500",
                        "GL 55 AMG",
                        "GL 63 AMG",
                        "GLA",
                        "GLA 180",
                        "GLA 200",
                        "GLA 220",
                        "GLA 250",
                        "GLA 45 AMG",
                        "GLB",
                        "GLC",
                        "GLC 220",
                        "GLC 250",
                        "GLC 300",
                        "GLC 350",
                        "GLC 43 AMG",
                        "GLC 63 AMG",
                        "GLE",
                        "GLE 250",
                        "GLE 350",
                        "GLE 400",
                        "GLE 43 AMG",
                        "GLE 450 AMG",
                        "GLE 53 4MATIC",
                        "GLE 63 AMG",
                        "GLE 63 S AMG",
                        "GLE Coupe",
                        "GLK",
                        "GLS",
                        "GLS 350",
                        "GLS 400",
                        "GLS 500",
                        "GLS 63 AMG",
                        "ML",
                        "ML 230",
                        "ML 250",
                        "ML 270",
                        "ML 280",
                        "ML 300",
                        "ML 320",
                        "ML 350",
                        "ML 400",
                        "ML 420",
                        "ML 430",
                        "ML 450",
                        "ML 500",
                        "ML 55 AMG",
                        "ML 63 AMG",
                        "R",
                        "R 280",
                        "R 300",
                        "R 320",
                        "R 350",
                        "R 500",
                        "R 63 AMG",
                        "S",
                        "S 250",
                        "S 280",
                        "S 300",
                        "S 320",
                        "S 350",
                        "S 400",
                        "S 420",
                        "S 430",
                        "S 450",
                        "S 500",
                        "S 55 AMG",
                        "S 550",
                        "S 560",
                        "S 600",
                        "S 63",
                        "S 63 AMG",
                        "S 65",
                        "S 65 AMG",
                        "SL",
                        "SL 400",
                        "SL 500",
                        "SL 55 AMG",
                        "SL 60 AMG",
                        "SL 63 AMG",
                        "SL 65 AMG",
                        "SLC",
                        "SLK",
                        "SLK 32 AMG",
                        "SLK 55 AMG",
                        "SLR",
                        "SLS",
                        "SLS AMG",
                        "Unimog",
                        "Vaneo",
                        "X-Klasse",
                    }
                },
            };

            foreach (var kvp in models)
            {
                var make = makesService.GetMakeByName(kvp.Key);
                var currentModels = kvp.Value;

                foreach (var modelName in currentModels)
                {
                    await modelsService.AddAsync(modelName, make);
                }
            }
        }
    }
}
