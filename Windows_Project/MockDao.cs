using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Project;

public class MockDao : IDao
{
    public List<Manufacturers> GetManufacturers()
    {
        var result = new List<Manufacturers>()
        {
            new Manufacturers()
            {
                ManufacturerName = "TOYOTA",
                ManufacturerPicture = "Assets/toyota_logo.jpg",
                Cars = new List<Cars>()
                {
                    new Cars()
                    {
                        Model = "Corolla",
                        Manufacturer = "Toyota",
                        Year = "2021",
                        Price = "20,000",
                        Picture = "Assets/toyota_corolla.jpg"
                    },
                    new Cars()
                    {
                        Model = "Camry",
                        Manufacturer = "Toyota",
                        Year = "2021",
                        Price = "25,000",
                        Picture = "Assets/toyota_camry.jpg"
                    },
                    new Cars()
                    {
                        Model = "RAV4",
                        Manufacturer = "Toyota",
                        Year = "2021",
                        Price = "30,000",
                        Picture = "Assets/toyota_rav4.jpg"
                    },
                    new Cars()
                    {
                        Model = "Highlander",
                        Manufacturer = "Toyota",
                        Year = "2021",
                        Price = "35,000",
                        Picture = "Assets/toyota_highlander.jpg"
                    },
                    new Cars()
                    {
                        Model = "Sienna",
                        Manufacturer = "Toyota",
                        Year = "2021",
                        Price = "40,000",
                        Picture = "Assets/toyota_sienna.jpg"
                    },
                    new Cars()
                    {
                        Model = "Tacoma",
                        Manufacturer = "Toyota",
                        Year = "2021",
                        Price = "45,000",
                        Picture = "Assets/toyota_tacoma.jpg"
                    },
                    new Cars()
                    {
                        Model = "Tundra",
                        Manufacturer = "Toyota",
                        Year = "2021",
                        Price = "50,000",
                        Picture = "Assets/toyota_tundra.jpg"
                    },
                }
            },
            new Manufacturers()
            {
                ManufacturerName = "WOLKSWAGEN",
                ManufacturerPicture = "Assets/wolkswagen_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "FORD",
                ManufacturerPicture = "Assets/ford_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "CHEVROLET",
                ManufacturerPicture = "Assets/chevrolet_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "NISSAN",
                ManufacturerPicture = "Assets/nissan_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "HYUNDAI",
                ManufacturerPicture = "Assets/hyundai_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "KIA",
                ManufacturerPicture = "Assets/kia_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "SUBARU",
                ManufacturerPicture = "Assets/subaru_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "MERCEDES-BENZ",
                ManufacturerPicture = "Assets/mercedes_benz_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "BMW",
                ManufacturerPicture = "Assets/bmw_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "LEXUS",
                ManufacturerPicture = "Assets/lexus_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "PORSCHE",
                ManufacturerPicture = "Assets/porsche_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "TESLA",
                ManufacturerPicture = "Assets/tesla_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "MAZDA",
                ManufacturerPicture = "Assets/mazda_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "HONDA",
                ManufacturerPicture = "Assets/honda_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "AUDI",
                ManufacturerPicture = "Assets/audi_logo.jpg"
            },
        };
        return result;
    }
}
