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
                ManufacturerName = "Toyota",
                ManufacturerPicture = "Assets/toyota_logo.jpg",
                Cars = new List<Cars>()
                {
                    new Cars()
                    {
                        Model = "Toyota Vios",
                        Manufacturer = "Toyota",
                        Price = "458.000.000 VNĐ",
                        Picture = "Assets/toyota_vios.png"
                    },
                    new Cars()
                    {
                        Model = "Toyota Yaris Cross",
                        Manufacturer = "Toyota",
                        Price = "650.000.000 VNĐ",
                        Picture = "Assets/toyota_yaris_corolla.png"
                    },
                    new Cars()
                    {
                        Model = "Toyota Camry",
                        Manufacturer = "Toyota",
                        Price = "1.220.000.000 VNĐ",
                        Picture = "Assets/toyota_camry.png"
                    },
                    new Cars()
                    {
                        Model = "Toyota Innova",
                        Manufacturer = "Toyota",
                        Price = "810.000.000 VNĐ",
                        Picture = "Assets/toyota_innova.png"
                    },
                    new Cars()
                    {
                        Model = "Toyota Fortuner",
                        Manufacturer = "Toyota",
                        Price = "1.055.000.000 VNĐ",
                        Picture = "Assets/toyota_fortuner.png"
                    },
                    new Cars()
                    {
                        Model = "Toyota Land Cruiser Prado",
                        Manufacturer = "Toyota",
                        Price = "3.480.000.000 VNĐ",
                        Picture = "Assets/toyota_land_cruiser_prado.png"
                    },
                    new Cars()
                    {
                        Model = "Toyota Land Cruiser",
                        Manufacturer = "Toyota",
                        Price = "4.286.000.000 VNĐ",
                        Picture = "Assets/toyota_land_cruiser.png"
                    },
                    new Cars()
                    {
                        Model = "Toyota Corolla Altis",
                        Manufacturer = "Toyota",
                        Price = "725.000.000 VNĐ",
                        Picture = "Assets/toyota_corolla_altis.png"
                    }

                }
            },
            new Manufacturers()
            {
                ManufacturerName = "Wolkswagen",
                ManufacturerPicture = "Assets/wolkswagen_logo.jpg",
                Cars = new List<Cars>()
                {
                    new Cars()
                    {
                        Model = "Volkswagen Teramont",
                        Manufacturer = "Wolkswagen",
                        Price = "2.399.000.000 VNĐ",
                        Picture = "Assets/volkswagen_teramont.png"
                    },
                    new Cars()
                    {
                        Model = "Volkswagen Tiguan",
                        Manufacturer = "Wolkswagen",
                        Price = "1.688.000.000 VNĐ",
                        Picture = "Assets/volkswagen_tiguan.png"
                    },
                    new Cars()
                    {
                        Model = "Volkswagen Passat",
                        Manufacturer = "Wolkswagen",
                        Price = "1.399.000.000 VNĐ",
                        Picture = "Assets/volkswagen_passat.png"
                    },
                    new Cars()
                    {
                        Model = "Volkswagen Polo",
                        Manufacturer = "Wolkswagen",
                        Price = "699.000.000 VNĐ",
                        Picture = "Assets/volkswagen_polo.png"
                    },
                }
            },
            new Manufacturers()
            {
                ManufacturerName = "Ford",
                ManufacturerPicture = "Assets/ford_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "Chevrolet",
                ManufacturerPicture = "Assets/chevrolet_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "Nissan",
                ManufacturerPicture = "Assets/nissan_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "Hyundai",
                ManufacturerPicture = "Assets/hyundai_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "Kia",
                ManufacturerPicture = "Assets/kia_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "Subaru",
                ManufacturerPicture = "Assets/subaru_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "Mercedes Benz",
                ManufacturerPicture = "Assets/mercedes_benz_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "BMW",
                ManufacturerPicture = "Assets/bmw_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "Lexus",
                ManufacturerPicture = "Assets/lexus_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "Porsche",
                ManufacturerPicture = "Assets/porsche_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "Tesla",
                ManufacturerPicture = "Assets/tesla_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "Mazda",
                ManufacturerPicture = "Assets/mazda_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "Honda",
                ManufacturerPicture = "Assets/honda_logo.jpg"
            },
            new Manufacturers()
            {
                ManufacturerName = "Audi",
                ManufacturerPicture = "Assets/audi_logo.jpg"
            },
        };
        return result;
    }
}
