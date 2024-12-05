////using Microsoft.UI.Xaml;
////using System;
////using System.Collections.Generic;
////using System.IO;
////using System.Linq;
////using System.Reflection;
////using System.Text;
////using System.Text.Json;
////using System.Threading.Tasks;
////using Windows.Security.Cryptography.Core;
////using Windows.Storage;
////using Newtonsoft.Json;
////using System.Runtime.ConstrainedExecution;
////using System.Diagnostics;
////using Windows_Project.Model;

////namespace Windows_Project;

////public class MockDao : IDao
////{
////    public List<Manufacturers> GetManufacturers()
////    {
////        var result = new List<Manufacturers>()
////        {
////            new Manufacturers()
////            {
////                ManufacturerName = "Toyota",
////                ManufacturerPicture = "../../Assets/toyota_logo.jpg",
////                Cars = new List<Cars>()
////                {
////                    new Cars()
////                    {
////                        ID = 1,
////                        Model = "Toyota Vios",
////                        Manufacturer = "Toyota",
////                        Price = "458.000.000 VNĐ",
////                        Picture = "../../Assets/toyota_vios.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        City = "Hà Nội",
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 2,
////                        Model = "Toyota Raize",
////                        Manufacturer = "Toyota",
////                        Price = "498.000.000 VNĐ",
////                        Picture = "../../Assets/toyota_raize.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 3,
////                        Model = "Toyota Yaris Cross",
////                        Manufacturer = "Toyota",
////                        Price = "650.000.000 VNĐ",
////                        Picture = "../../Assets/toyota_yaris_cross.png",
////                        Condition = "Xe cũ"
////                    },
////                    new Cars()
////                    {
////                        ID = 4,
////                        Model = "Toyota Innova Cross",
////                        Manufacturer = "Toyota",
////                        Price = "810.000.000 VNĐ",
////                        Picture = "../../Assets/toyota_innova_cross.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 5,
////                        Model = "Toyota Innova",
////                        Manufacturer = "Toyota",
////                        Price = "755.000.000 VNĐ",
////                        Picture = "../../Assets/toyota_innova.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 6,
////                        Model = "Toyota Fortuner",
////                        Manufacturer = "Toyota",
////                        Price = "1.055.000.000 VNĐ",
////                        Picture = "../../Assets/toyota_fortuner.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 7,
////                        Model = "Toyota Veloz Cross",
////                        Manufacturer = "Toyota",
////                        Price = "638.000.000 VNĐ",
////                        Picture = "../../Assets/toyota_veloz_cross.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 8,
////                        Model = "Toyota Corolla Cross",
////                        Manufacturer = "Toyota",
////                        Price = "760.000.000 VNĐ",
////                        Picture = "../../Assets/toyota_corolla_cross.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                     new Cars()
////                    {
////                        ID = 9,
////                        Model = "Toyota Corolla Altis",
////                        Manufacturer = "Toyota",
////                        Price = "725.000.000 VNĐ",
////                        Picture = "../../Assets/toyota_corolla_altis.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 10,
////                        Model = "Toyota Wigo",
////                        Manufacturer = "Toyota",
////                        Price = "360.000.000 VNĐ",
////                        Picture = "../../Assets/toyota_wigo.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 11,
////                        Model = "Toyota Avanza​ Premio",
////                        Manufacturer = "Toyota",
////                        Price = "558.000.000 VNĐ",
////                        Picture = "../../Assets/toyota_avanza_premio.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 12,
////                        Model = "Toyota Camry",
////                        Manufacturer = "Toyota",
////                        Price = "1.105.000.000 VNĐ",
////                        Picture = "../../Assets/toyota_camry.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 13,
////                        Model = "Toyota Hilux",
////                        Manufacturer = "Toyota",
////                        Price = "668.000.000 VNĐ",
////                        Picture = "../../Assets/toyota_hilux.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 14,
////                        Model = "Toyota Land Cruiser",
////                        Manufacturer = "Toyota",
////                        Price = "4.286.000.000 VNĐ",
////                        Picture = "../../Assets/toyota_land_cruiser.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 15,
////                        Model = "Toyota Land Cruiser Prado",
////                        Manufacturer = "Toyota",
////                        Price = "3.460.000.000 VNĐ",
////                        Picture = "../../Assets/toyota_land_cruiser_prado.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    }
////                }
////            },
////            new Manufacturers()
////            {
////                ManufacturerName = "Wolkswagen",
////                ManufacturerPicture = "../../Assets/wolkswagen_logo.jpg",
////                Cars = new List<Cars>()
////                {
////                    new Cars()
////                    {
////                        ID = 16,
////                        Model = "Volkswagen Teramont",
////                        Manufacturer = "Wolkswagen",
////                        Price = "2.399.000.000 VNĐ",
////                        Picture = "../../Assets/volkswagen_teramont.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 17,
////                        Model = "Volkswagen Tiguan",
////                        Manufacturer = "Wolkswagen",
////                        Price = "1.688.000.000 VNĐ",
////                        Picture = "../../Assets/volkswagen_tiguan.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 18,
////                        Model = "Volkswagen Passat",
////                        Manufacturer = "Wolkswagen",
////                        Price = "1.399.000.000 VNĐ",
////                        Picture = "../../Assets/volkswagen_passat.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 19,
////                        Model = "Volkswagen Polo",
////                        Manufacturer = "Wolkswagen",
////                        Price = "699.000.000 VNĐ",
////                        Picture = "../../Assets/volkswagen_polo.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                }
////            },
////            new Manufacturers()
////            {
////                ManufacturerName = "Ford",
////                ManufacturerPicture = "../../../../Assets/ford_logo.jpg",
////                Cars = new List<Cars>()
////                {
////                    new Cars()
////                    {
////                        ID = 20,
////                        Model = "Ford Ranger",
////                        Manufacturer = "Ford",
////                        Price = "699.000.000 VNĐ",
////                        Picture = "../../Assets/ford_ranger.png",
////                        Condition = "Xe cũ"
////                    },
////                    new Cars()
////                    {
////                        ID = 21,
////                        Model = "Ford Ranger Raptor",
////                        Manufacturer = "Ford",
////                        Price = "1.299.000.000 VNĐ",
////                        Picture = "../../Assets/ford_ranger_raptor.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 22,
////                        Model = "Ford Everest",
////                        Manufacturer = "Ford",
////                        Price = "1.099.000.000 VNĐ",
////                        Picture = "../../Assets/ford_everest.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 23,
////                        Model = "Ford Territory",
////                        Manufacturer = "Ford",
////                        Price = "799.000.000 VNĐ",
////                        Picture = "../../Assets/ford_territory.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 24,
////                        Model = "Ford Explorer",
////                        Manufacturer = "Ford",
////                        Price = "2.099.000.000 VNĐ",
////                        Picture = "../../Assets/ford_explorer.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 25,
////                        Model = "Ford Transit",
////                        Manufacturer = "Ford",
////                        Price = "905.000.000 VNĐ",
////                        Picture = "../../Assets/ford_transit.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    }
////                }
////            },
////            new Manufacturers()
////            {
////                ManufacturerName = "Chevrolet",
////                ManufacturerPicture = "../../Assets/chevrolet_logo.jpg",
////                Cars = new List<Cars>
////                {
////                    new Cars()
////                    {
////                        ID = 26,
////                        Model = "Chevrolet Spark",
////                        Manufacturer = "Chevrolet",
////                        Price = "369.000.000 VNĐ",
////                        Picture = "../../Assets/chevrolet_spark.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    }
////                }
////            },
////            new Manufacturers()
////            {
////                ManufacturerName = "Nissan",
////                ManufacturerPicture = "../../Assets/nissan_logo.jpg",
////                Cars = new List<Cars>
////                {
////                    new Cars()
////                    {
////                        ID = 27,
////                        Model = "Nissan Kicks e-power",
////                        Manufacturer = "Nissan",
////                        Price = "789.000.000 VNĐ",
////                        Picture = "../../Assets/nissan_kicks_e_power.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 28,
////                        Model = "Nissan Almera",
////                        Manufacturer = "Nissan",
////                        Price = "539.000.000 VNĐ",
////                        Picture = "../../Assets/nissan_almera.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 29,
////                        Model = "Nissan Navara",
////                        Manufacturer = "Nissan",
////                        Price = "685.000.000 VNĐ",
////                        Picture = "../../Assets/nissan_navara.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "SUV",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 30,
////                        Model = "Nissan Terra",
////                        Manufacturer = "Nissan",
////                        Price = "848.000.000 VNĐ",
////                        Picture = "../../Assets/nissan_terra.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "SUV",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 31,
////                        Model = "Nissan X-Trail",
////                        Manufacturer = "Nissan",
////                        Price = "839.000.000 VNĐ",
////                        Picture = "../../Assets/nissan_x_trail.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "SUV",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    }
////                }
////            },
////            new Manufacturers()
////            {
////                ManufacturerName = "Hyundai",
////                ManufacturerPicture = "../../Assets/hyundai_logo.jpg",
////                Cars = new List<Cars>
////                {
////                    new Cars()
////                    {
////                        ID = 32,
////                        Model = "Hyundai Venue",
////                        Manufacturer = "Hyundai",
////                        Price = "499.000.000 VNĐ",
////                        Picture = "../../Assets/hyundai_venue.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "SUV",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 33,
////                        Model = "Hyundai Custin​​",
////                        Manufacturer = "Hyundai",
////                        Price = "820.000.000 VNĐ",
////                        Picture = "../../Assets/hyundai_custin.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 34,
////                        Model = "Hyundai Palisade",
////                        Manufacturer = "Hyundai",
////                        Price = "1.469.000.000 VNĐ",
////                        Picture = "../../Assets/hyundai_palisade.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 35,
////                        Model = "Hyundai Accent",
////                        Manufacturer = "Hyundai",
////                        Price = "439.000.000 VNĐ",
////                        Picture = "../../Assets/hyundai_accent.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 36,
////                        Model = "Hyundai SantaFe",
////                        Manufacturer = "Hyundai",
////                        Price = "1.069.000.000 VNĐ",
////                        Picture = "../../Assets/hyundai_santafe.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 37,
////                        Model = "Hyundai Creta",
////                        Manufacturer = "Hyundai",
////                        Price = "599.000.000 VNĐ",
////                        Picture = "../../Assets/hyundai_creta.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 38,
////                        Model = "Hyundai Stargazer",
////                        Manufacturer = "Hyundai",
////                        Price = "489.000.000 VNĐ",
////                        Picture = "../../Assets/hyundai_stargazer.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 39,
////                        Model = "Hyundai Kona",
////                        Manufacturer = "Hyundai",
////                        Price = "636.000.000 VNĐ",
////                        Picture = "../../Assets/hyundai_kona.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 40,
////                        Model = "Hyundai Grand i10",
////                        Manufacturer = "Hyundai",
////                        Price = "360.000.000 VNĐ",
////                        Picture = "../../Assets/hyundai_grand_i10.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 41,
////                        Model = "Hyundai Elantra",
////                        Manufacturer = "Hyundai",
////                        Price = "579.000.000 VNĐ",
////                        Picture = "../../Assets/hyundai_elantra.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 42,
////                        Model = "Hyundai Tucson",
////                        Manufacturer = "Hyundai",
////                        Price = "769.000.000 VNĐ",
////                        Picture = "../../Assets/hyundai_tucson.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 43,
////                        Model = "Hyundai IONIQ 5",
////                        Manufacturer = "Hyundai",
////                        Price = "1.300.000.000 VNĐ",
////                        Picture = "../../Assets/hyundai_ioniq_5.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 44,
////                        Model = "Hyundai Solati",
////                        Manufacturer = "Hyundai",
////                        Price = "1.080.000.000 VNĐ",
////                        Picture = "../../Assets/hyundai_solati.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    }
////                }
////            },
////            new Manufacturers()
////            {
////                ManufacturerName = "KIA",
////                ManufacturerPicture = "../../Assets/kia_logo.jpg",
////                Cars = new List<Cars>
////                {
////                    new Cars()
////                    {
////                        ID = 45,
////                        Model = "KIA Carens",
////                        Manufacturer = "Kia",
////                        Price = "589.000.000 VNĐ",
////                        Picture = "../../Assets/kia_carens.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 46,
////                        Model = "KIA Sportage",
////                        Manufacturer = "Kia",
////                        Price = "779.000.000 VNĐ",
////                        Picture = "../../Assets/kia_sportage.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 47,
////                        Model = "KIA Carnival",
////                        Manufacturer = "Kia",
////                        Price = "1.299.000.000 VNĐ",
////                        Picture = "../../Assets/kia_carnival.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 48,
////                        Model = "KIA Sonet",
////                        Manufacturer = "Kia",
////                        Price = "539.000.000 VNĐ",
////                        Picture = "../../Assets/kia_sonet.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 49,
////                        Model = "KIA K5",
////                        Manufacturer = "Kia",
////                        Price = "859.000.000 VNĐ",
////                        Picture = "../../Assets/kia_k5.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 50,
////                        Model = "KIA Morning",
////                        Manufacturer = "Kia",
////                        Price = "349.000.000 VNĐ",
////                        Picture = "../../Assets/kia_morning.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 51,
////                        Model = "KIA Seltos",
////                        Manufacturer = "Kia",
////                        Price = "599.000.000 VNĐ",
////                        Picture = "../../Assets/kia_seltos.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 52,
////                        Model = "KIA Soluto",
////                        Manufacturer = "Kia",
////                        Price = "386.000.000 VNĐ",
////                        Picture = "../../Assets/kia_soluto.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 53,
////                        Model = "KIA K3",
////                        Manufacturer = "Kia",
////                        Price = "549.000.000 VNĐ",
////                        Picture = "../../Assets/kia_k3.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 54,
////                        Model = "KIA Sorento",
////                        Manufacturer = "Kia",
////                        Price = "964.000.000 VNĐ",
////                        Picture = "../../Assets/kia_sorento.png",
////                        Condition = "Xe cũ",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    }
////                }
////            },
////            new Manufacturers()
////            {
////                ManufacturerName = "Subaru",
////                ManufacturerPicture = "../../Assets/subaru_logo.jpg",
////                Cars = new List<Cars>
////                {
////                    new Cars()
////                    {
////                        ID = 55,
////                        Model = "Forester 2.0i-L",
////                        Manufacturer = "Subaru",
////                        Price = "869.000.000 VNĐ",
////                        Picture = "../../Assets/subaru_forester_2.0i_l.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Sedan",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 56,
////                        Model = "Forester 2.0i-L EyeSight",
////                        Manufacturer = "Subaru",
////                        Price = "929.000.000 VNĐ",
////                        Picture = "../../Assets/subaru_forester_2.0i_l_eyesight.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 57,
////                        Model = "Forester 2.0i-S EyeSight",
////                        Manufacturer = "Subaru",
////                        Price = "969.000.000 VNĐ",
////                        Picture = "../../Assets/subaru_forester_2.0i_s_eyesight.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 58,
////                        Model = "Crosstrek 2.0i-S EyeSight",
////                        Manufacturer = "Subaru",
////                        Price = "999.000.000 VNĐ",
////                        Picture = "../../Assets/subaru_crosstrek_2.0i_s_eyesight.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 59,
////                        Model = "Outback 2.5i-T EyeSight",
////                        Manufacturer = "Subaru",
////                        Price = "1.696.000.000 VNĐ",
////                        Picture = "../../Assets/subaru_outback_2.5i_t_eyesight.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 60,
////                        Model = "BRZ 6AT EyeSight",
////                        Manufacturer = "Subaru",
////                        Price = "1.535.000.000 VNĐ",
////                        Picture = "../../Assets/subaru_brz_6at_eyesight.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 61,
////                        Model = "WRX 2.4 Sedan",
////                        Manufacturer = "Subaru",
////                        Price = "1.690.000.000 VNĐ",
////                        Picture = "../../Assets/subaru_wrx_2.4_sedan.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    }
////                }
////            },
////            new Manufacturers()
////            {
////                ManufacturerName = "Mercedes Benz",
////                ManufacturerPicture = "../../Assets/mercedes_benz_logo.jpg",
////                Cars = new List<Cars>
////                {
////                    new Cars()
////                    {
////                        ID = 62,
////                        Model = "Mercedes C-Class",
////                        Manufacturer = "Mercedes Benz",
////                        Price = "1.388.000.000 VNĐ",
////                        Picture = "../../Assets/mercedes_c_class.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 63,
////                        Model = "Mercedes E-Class",
////                        Manufacturer = "Mercedes Benz",
////                        Price = "1.888.000.000 VNĐ",
////                        Picture = "../../Assets/mercedes_e_class.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 64,
////                        Model = "Mercedes-Benz GLC-Class",
////                        Manufacturer = "Mercedes Benz",
////                        Price = "2.299.000.000 VNĐ",
////                        Picture = "../../Assets/mercedes_benz_glc_class.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 65,
////                        Model = "EQS 500 4Matic",
////                        Manufacturer = "Mercedes Benz",
////                        Price = "4.999.000.000 VNĐ",
////                        Picture = "../../Assets/mercedes_benz_eqs_500_4matic.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 66,
////                        Model = "EQE 500 4Matic",
////                        Manufacturer = "Mercedes Benz",
////                        Price = "3.999.000.000 VNĐ",
////                        Picture = "../../Assets/mercedes_benz_eqe_500_4matic.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 67,
////                        Model = "Mercedes-Benz EQB 250",
////                        Manufacturer = "Mercedes Benz",
////                        Price = "2.289.000.000 VNĐ",
////                        Picture = "../../Assets/mercedes_benz_eqb_250.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 68,
////                        Model = "Mercedes-Benz EQS",
////                        Manufacturer = "Mercedes Benz",
////                        Price = "4.839.000.000 VNĐ",
////                        Picture = "../../Assets/mercedes_benz_eqs.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 69,
////                        Model = "Mercedes S450",
////                        Manufacturer = "Mercedes Benz",
////                        Price = "5.039.000.000 VNĐ",
////                        Picture = "../../Assets/mercedes_s450.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 70,
////                        Model = "Mercedes GLB",
////                        Manufacturer = "Mercedes Benz",
////                        Price = "1.658.000.000 VNĐ",
////                        Picture = "../../Assets/mercedes_glb.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },

////                }
////            },
////            new Manufacturers()
////            {
////                ManufacturerName = "BMW",
////                ManufacturerPicture = "../../Assets/bmw_logo.jpg",
////                Cars = new List<Cars>
////                {
////                    new Cars()
////                    {
////                        ID = 71,
////                        Model = "BMW XM",
////                        Manufacturer = "BMW",
////                        Price = "10.099.000.000 VNĐ",
////                        Picture = "../../Assets/bmw_xm.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 72,
////                        Model = "BMW iX3",
////                        Manufacturer = "BMW",
////                        Price = "3.479.000.000 VNĐ",
////                        Picture = "../../Assets/bmw_ix3.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 73,
////                        Model = "BMW i4",
////                        Manufacturer = "BMW",
////                        Price = "3.739.000.000 VNĐ",
////                        Picture = "../../Assets/bmw_i4.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 74,
////                        Model = "BMW X7",
////                        Manufacturer = "BMW",
////                        Price = "5.149.000.000 VNĐ",
////                        Picture = "../../Assets/bmw_x7.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 75,
////                        Model = "BMW 7-Series",
////                        Manufacturer = "BMW",
////                        Price = "4.499.000.000 VNĐ",
////                        Picture = "../../Assets/bmw_7_series.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 76,
////                        Model = "BMW 5-Series",
////                        Manufacturer = "BMW",
////                        Price = "1.829.000.000 VNĐ",
////                        Picture = "../../Assets/bmw_5_series.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 77,
////                        Model = "BMW X4",
////                        Manufacturer = "BMW",
////                        Price = "2.899.000.000 VNĐ",
////                        Picture = "../../Assets/bmw_x4.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 78,
////                        Model = "BMW 3-Series",
////                        Manufacturer = "BMW",
////                        Price = "1.499.000.000 VNĐ",
////                        Picture = "../../Assets/bmw_3_series.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 79,
////                        Model = "BMW 4-Series",
////                        Manufacturer = "BMW",
////                        Price = "2.629.000.000 VNĐ",
////                        Picture = "../../Assets/bmw_4_series.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 80,
////                        Model = "BMW X3",
////                        Manufacturer = "BMW",
////                        Price = "1.855.000.000 VNĐ",
////                        Picture = "../../Assets/bmw_x3.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 81,
////                        Model = "BMW X5",
////                        Manufacturer = "BMW",
////                        Price = "3.909.000.000 VNĐ",
////                        Picture = "../../Assets/bmw_x5.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 82,
////                        Model = "BMW Z4 sDrive30i",
////                        Manufacturer = "BMW",
////                        Price = "3.139.000.000 VNĐ",
////                        Picture = "../../Assets/bmw_z4_sdrive30i.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    }

////                }
////            },
////            new Manufacturers()
////            {
////                ManufacturerName = "Lexus",
////                ManufacturerPicture = "../../Assets/lexus_logo.jpg",
////                Cars = new List<Cars>
////                {
////                    new Cars()
////                    {
////                        ID = 83,
////                        Model = "Lexus NX",
////                        Manufacturer = "Lexus",
////                        Price = "3.130.000.000 VNĐ",
////                        Picture = "../../Assets/lexus_nx.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 84,
////                        Model = "Lexus LM 500h",
////                        Manufacturer = "Lexus",
////                        Price = "7.290.000.000 VNĐ",
////                        Picture = "../../Assets/lexus_lm_500h.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 85,
////                        Model = "Lexus IS",
////                        Manufacturer = "Lexus",
////                        Price = "2.130.000.000 VNĐ",
////                        Picture = "../../Assets/lexus_is.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 86,
////                        Model = "Lexus RX",
////                        Manufacturer = "Lexus",
////                        Price = "3.430.000.000 VNĐ",
////                        Picture = "../../Assets/lexus_rx.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 87,
////                        Model = "Lexus LX",
////                        Manufacturer = "Lexus",
////                        Price = "8.500.000.000 VNĐ",
////                        Picture = "../../Assets/lexus_lx.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 88,
////                        Model = "Lexus GX",
////                        Manufacturer = "Lexus",
////                        Price = "6.200.000.000 VNĐ",
////                        Picture = "../../Assets/lexus_gx.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 89,
////                        Model = "Lexus LS",
////                        Manufacturer = "Lexus",
////                        Price = "7.650.000.000 VNĐ",
////                        Picture = "../../Assets/lexus_ls.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 90,
////                        Model = "Lexus ES",
////                        Manufacturer = "Lexus",
////                        Price = "2.620.000.000 VNĐ",
////                        Picture = "../../Assets/lexus_es.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 91,
////                        Model = "Lexus RC",
////                        Manufacturer = "Lexus",
////                        Price = "3.290.000.000 VNĐ",
////                        Picture = "../../Assets/lexus_rc.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    }
////                }
////            },
////            new Manufacturers()
////            {
////                ManufacturerName = "Porsche",
////                ManufacturerPicture = "../../Assets/porsche_logo.jpg",
////                Cars = new List<Cars>
////                {
////                    new Cars()
////                    {
////                        ID = 92,
////                        Model = "Porsche 718",
////                        Manufacturer = "Porsche",
////                        Price = "3.620.000.000 VNĐ",
////                        Picture = "../../Assets/porsche_718.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 93,
////                        Model = "Porsche 911",
////                        Manufacturer = "Porsche",
////                        Price = "7.130.000.000 VNĐ",
////                        Picture = "../../Assets/porsche_911.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Crossover",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 94,
////                        Model = "Porsche Taycan",
////                        Manufacturer = "Porsche",
////                        Price = "4.170.000.000 VNĐ",
////                        Picture = "../../Assets/porsche_taycan.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "MPV",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 95,
////                        Model = "Porsche Panamera",
////                        Manufacturer = "Porsche",
////                        Price = "6.420.000.000 VNĐ",
////                        Picture = "../../Assets/porsche_panamera.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "MPV",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 96,
////                        Model = "Porsche Macan",
////                        Manufacturer = "Porsche",
////                        Price = "3.150.000.000 VNĐ",
////                        Picture = "../../Assets/porsche_macan.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "MPV",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 97,
////                        Model = "Porsche Cayenne",
////                        Manufacturer = "Porsche",
////                        Price = "5.560.000.000 VNĐ",
////                        Picture = "../../Assets/porsche_cayenne.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "MPV",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    }
////                }
////            },
////            new Manufacturers()
////            {
////                ManufacturerName = "VinFast",
////                ManufacturerPicture = "../../Assets/vinfast_logo.jpg",
////                Cars = new List<Cars>
////                {
////                    new Cars()
////                    {
////                        ID = 98,
////                        Model = "VinFast VF 5",
////                        Manufacturer = "VinFast",
////                        Price = "460.000.000 VNĐ",
////                        Picture = "../../Assets/vinfast_vf_5.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "MPV",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 99,
////                        Model = "VinFast VF 6",
////                        Manufacturer = "VinFast",
////                        Price = "675.000.000 VNĐ",
////                        Picture = "../../Assets/vinfast_vf_6.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "MPV",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 100,
////                        Model = "VinFast VF 7",
////                        Manufacturer = "VinFast",
////                        Price = "850.000.000 VNĐ",
////                        Picture = "../../Assets/vinfast_vf_7.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "MPV",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 101,
////                        Model = "VinFast VF 8",
////                        Manufacturer = "VinFast",
////                        Price = "1.079.000.000 VNĐ",
////                        Picture = "../../Assets/vinfast_vf_8.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "MPV",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 102,
////                        Model = "VinFast VF 9",
////                        Manufacturer = "VinFast",
////                        Price = "1.531.000.000 VNĐ",
////                        Picture = "../../Assets/vinfast_vf_9.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "MPV",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 103,
////                        Model = "VinFast VF e34",
////                        Manufacturer = "VinFast",
////                        Price = "710.000.000 VNĐ",
////                        Picture = "../../Assets/vinfast_vf_e34.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "MPV",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 104,
////                        Model = "VinFast VF 3",
////                        Manufacturer = "VinFast",
////                        Price = "240.000.000 VNĐ",
////                        Picture = "../../Assets/vinfast_vf_3.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "MPV",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    }
////                }
////            },
////            new Manufacturers()
////            {
////                ManufacturerName = "Mazda",
////                ManufacturerPicture = "../../Assets/mazda_logo.jpg",
////                Cars = new List<Cars>
////                {
////                    new Cars()
////                    {
////                        ID = 105,
////                        Model = "Mazda CX-3",
////                        Manufacturer = "Mazda",
////                        Price = "512.000.000 VNĐ",
////                        Picture = "../../Assets/mazda_cx_3.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "MPV",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 106,
////                        Model = "Mazda CX-30",
////                        Manufacturer = "Mazda",
////                        Price = "699.000.000 VNĐ",
////                        Picture = "../../Assets/mazda_cx_30.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "MPV",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 107,
////                        Model = "Mazda 6",
////                        Manufacturer = "Mazda",
////                        Price = "769.000.000 VNĐ",
////                        Picture = "../../Assets/mazda_6.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 108,
////                        Model = "Mazda CX-5",
////                        Manufacturer = "Mazda",
////                        Price = "749.000.000 VNĐ",
////                        Picture = "../../Assets/mazda_cx_5.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 109,
////                        Model = "Mazda CX-8",
////                        Manufacturer = "Mazda",
////                        Price = "949.000.000 VNĐ",
////                        Picture = "../../Assets/mazda_cx_8.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 110,
////                        Model = "Mazda 2",
////                        Manufacturer = "Mazda",
////                        Price = "408.000.000 VNĐ",
////                        Picture = "../../Assets/mazda_2.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 111,
////                        Model = "Mazda 3",
////                        Manufacturer = "Mazda",
////                        Price = "579.000.000 VNĐ",
////                        Picture = "../../Assets/mazda_3.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 112,
////                        Model = "Mazda BT 50",
////                        Manufacturer = "Mazda",
////                        Price = "554.000.000 VNĐ",
////                        Picture = "../../Assets/mazda_bt_50.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    }
////                }
////            },
////            new Manufacturers()
////            {
////                ManufacturerName = "Honda",
////                ManufacturerPicture = "../../Assets/honda_logo.jpg",
////                Cars = new List<Cars>
////                {
////                    new Cars()
////                    {
////                        ID = 113,
////                        Model = "Honda City",
////                        Manufacturer = "Honda",
////                        Price = "499.000.000 VNĐ",
////                        Picture = "../../Assets/honda_city.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 114,
////                        Model = "Honda BR-V",
////                        Manufacturer = "Honda",
////                        Price = "661.000.000 VNĐ",
////                        Picture = "../../Assets/honda_br_v.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 115,
////                        Model = "Honda CR-V",
////                        Manufacturer = "Honda",
////                        Price = "1.029.000.000 VNĐ",
////                        Picture = "../../Assets/honda_cr_v.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 116,
////                        Model = "Honda Accord",
////                        Manufacturer = "Honda",
////                        Price = "1.319.000.000 VNĐ",
////                        Picture = "../../Assets/honda_accord.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 117,
////                        Model = "Honda Civic",
////                        Manufacturer = "Honda",
////                        Price = "730.000.000 VNĐ",
////                        Picture = "../../Assets/honda_civic.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 118,
////                        Model = "Honda Civic Type R",
////                        Manufacturer = "Honda",
////                        Price = "2.399.000.000 VNĐ",
////                        Picture = "../../Assets/honda_civic_type_r.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 119,
////                        Model = "Honda HR-V",
////                        Manufacturer = "Honda",
////                        Price = "699.000.000 VNĐ",
////                        Picture = "../../Assets/honda_hr_v.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 120,
////                        Model = "Honda Brio",
////                        Manufacturer = "Honda",
////                        Price = "418.000.000 VNĐ",
////                        Picture = "../../Assets/honda_brio.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 121,
////                        Model = "Honda Jazz",
////                        Manufacturer = "Honda",
////                        Price = "544.000.000 VNĐ",
////                        Picture = "../../Assets/honda_jazz.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Trong nước",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    }
////                }
////            },
////            new Manufacturers()
////            {
////                ManufacturerName = "Audi",
////                ManufacturerPicture = "../../Assets/audi_logo.jpg",
////                Cars = new List<Cars>
////                {
////                    new Cars()
////                    {
////                        ID = 122,
////                        Model = "Audi Q8 e-tron",
////                        Manufacturer = "Audi",
////                        Price = "3.800.000.000 VNĐ",
////                        Picture = "../../Assets/audi_q8_e_tron.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Hatchback",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 123,
////                        Model = "Audi e-tron GT",
////                        Manufacturer = "Audi",
////                        Price = "5.200.000.000 VNĐ",
////                        Picture = "../../Assets/audi_e_tron_gt.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Sport Car",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 124,
////                        Model = "Audi Q3",
////                        Manufacturer = "Audi",
////                        Price = "1.890.000.000 VNĐ",
////                        Picture = "../../Assets/audi_q3.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Sport Car",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 125,
////                        Model = "Audi Q5",
////                        Manufacturer = "Audi",
////                        Price = "2.390.000.000 VNĐ",
////                        Picture = "../../Assets/audi_q5.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Sport Car",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 126,
////                        Model = "Audi Q7",
////                        Manufacturer = "Audi",
////                        Price = "3.590.000.000 VNĐ",
////                        Picture = "../../Assets/audi_q7.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Sport Car",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 127,
////                        Model = "Audi A6",
////                        Manufacturer = "Audi",
////                        Price = "2.500.000.000 VNĐ",
////                        Picture = "../../Assets/audi_a6.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Sport Car",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    },
////                    new Cars()
////                    {
////                        ID = 128,
////                        Model = "Audi Q2",
////                        Manufacturer = "Audi",
////                        Price = "1.590.000.000 VNĐ",
////                        Picture = "../../Assets/audi_q2.png",
////                        Condition = "Xe mới",
////                        Year = 2022,
////                        Style = "Sport Car",
////                        Origin = "Nhập khẩu",
////                        Mileage = 75000,
////                        Gear = "Số tự động",
////                        FuelType = "Máy xăng"
////                    }
////                }
////            },
////        };
////        LoadDataCarFromJson(result);
////        return result;
////    }
////    public void LoadDataCarFromJson(List<Manufacturers> manufacturersList)
////    {
////        try
////        {
////            string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
////            string filePath = Path.Combine(assemblyLocation, "Cars.json");
////            string json = File.ReadAllText(filePath);

////            // Deserialize dữ liệu từ JSON thành List<Cars>
////            var carsFromJson = JsonConvert.DeserializeObject<List<Cars>>(json);

////            // Lặp qua danh sách các xe và phân loại vào đúng nhà sản xuất
////            foreach (var car in carsFromJson)
////            {
////                // Tìm nhà sản xuất trong danh sách Manufacturers
////                var existingManufacturer = manufacturersList.FirstOrDefault(m => m.ManufacturerName == car.Manufacturer);
////                existingManufacturer.Cars.Add(car);
////            }
////        }
////        catch (Exception ex)
////        {
////            // Xử lý lỗi nếu có vấn đề trong việc đọc file hoặc xử lý dữ liệu
////            Console.WriteLine("Error loading data from JSON: " + ex.Message);
////        }
////    }

////    public List<Cars> GetCars()
////    {
////        // Tạo danh sách chứa tất cả các xe
////        var allCars = new List<Cars>();

////        // Duyệt qua từng nhà sản xuất và lấy xe
////        foreach (var manufacturer in GetManufacturers())
////        {
////            allCars.AddRange(manufacturer.Cars);
////        }

////        // Trả về danh sách tất cả các xe
////        return allCars;
////    }


////    public List<Users> GetUsers()
////    {
////        var users = new List<Users>()
////        {
////            new Users() { Username = "admin", Password = "123", FullName="Tuấn Khanh", Address="75A Linh Xuân", Phone="232237", Email="tk@exam.com" },
////            new Users() { Username = "lebao", Password = "hihi", FullName="Lê Bảo", Address="561B Linh Xuân", Phone="1234567", Email="lb@exam.com" }
////        };
////        return users;
////    }

////    public List<Listings> GetListings()
////    {
////        var result = new List<Listings>()
////        {
////            new Listings() { CarID = 1, UserID = 1, Status = "Bài Đăng 1", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 2, UserID = 2, Status = "Bài Đăng 2", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 3, UserID = 1, Status = "Bài Đăng 3", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 4, UserID = 2, Status = "Bài Đăng 4", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 5, UserID = 1, Status = "Bài Đăng 5", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 6, UserID = 2, Status = "Bài Đăng 6", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 7, UserID = 1, Status = "Bài Đăng 7", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 8, UserID = 2, Status = "Bài Đăng 8", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 9, UserID = 1, Status = "Bài Đăng 9", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 10, UserID = 2, Status = "Bài Đăng 10", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 11, UserID = 1, Status = "Bài Đăng 11", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 12, UserID = 2, Status = "Bài Đăng 12", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 13, UserID = 1, Status = "Bài Đăng 13", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 14, UserID = 2, Status = "Bài Đăng 14", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 15, UserID = 1, Status = "Bài Đăng 15", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 16, UserID = 2, Status = "Bài Đăng 16", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 17, UserID = 1, Status = "Bài Đăng 17", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 18, UserID = 2, Status = "Bài Đăng 18", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 19, UserID = 1, Status = "Bài Đăng 19", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 20, UserID = 2, Status = "Bài Đăng 20", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 21, UserID = 1, Status = "Bài Đăng 21", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 22, UserID = 2, Status = "Bài Đăng 22", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 23, UserID = 1, Status = "Bài Đăng 23", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 24, UserID = 2, Status = "Bài Đăng 24", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 25, UserID = 1, Status = "Bài Đăng 25", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 26, UserID = 2, Status = "Bài Đăng 26", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 27, UserID = 1, Status = "Bài Đăng 27", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 28, UserID = 2, Status = "Bài Đăng 28", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 29, UserID = 1, Status = "Bài Đăng 29", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 30, UserID = 2, Status = "Bài Đăng 30", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 31, UserID = 1, Status = "Bài Đăng 31", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 32, UserID = 2, Status = "Bài Đăng 32", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 33, UserID = 1, Status = "Bài Đăng 33", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 34, UserID = 2, Status = "Bài Đăng 34", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 35, UserID = 1, Status = "Bài Đăng 35", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 36, UserID = 2, Status = "Bài Đăng 36", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 37, UserID = 1, Status = "Bài Đăng 37", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 38, UserID = 2, Status = "Bài Đăng 38", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 39, UserID = 1, Status = "Bài Đăng 39", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 40, UserID = 2, Status = "Bài Đăng 40", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 41, UserID = 1, Status = "Bài Đăng 41", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 42, UserID = 2, Status = "Bài Đăng 42", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 43, UserID = 1, Status = "Bài Đăng 43", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 44, UserID = 2, Status = "Bài Đăng 44", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 45, UserID = 1, Status = "Bài Đăng 45", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 46, UserID = 2, Status = "Bài Đăng 46", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 47, UserID = 1, Status = "Bài Đăng 47", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 48, UserID = 2, Status = "Bài Đăng 48", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 49, UserID = 1, Status = "Bài Đăng 49", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 50, UserID = 2, Status = "Bài Đăng 50", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 51, UserID = 1, Status = "Bài Đăng 51", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 52, UserID = 2, Status = "Bài Đăng 52", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 53, UserID = 1, Status = "Bài Đăng 53", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 54, UserID = 2, Status = "Bài Đăng 54", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 55, UserID = 1, Status = "Bài Đăng 55", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 56, UserID = 2, Status = "Bài Đăng 56", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 57, UserID = 1, Status = "Bài Đăng 57", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 58, UserID = 2, Status = "Bài Đăng 58", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 59, UserID = 1, Status = "Bài Đăng 59", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 60, UserID = 2, Status = "Bài Đăng 60", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 61, UserID = 1, Status = "Bài Đăng 61", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 62, UserID = 2, Status = "Bài Đăng 62", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 63, UserID = 1, Status = "Bài Đăng 63", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 64, UserID = 2, Status = "Bài Đăng 64", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 65, UserID = 1, Status = "Bài Đăng 65", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 66, UserID = 2, Status = "Bài Đăng 66", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 67, UserID = 1, Status = "Bài Đăng 67", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 68, UserID = 2, Status = "Bài Đăng 68", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 69, UserID = 1, Status = "Bài Đăng 69", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 70, UserID = 2, Status = "Bài Đăng 70", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 71, UserID = 1, Status = "Bài Đăng 71", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 72, UserID = 2, Status = "Bài Đăng 72", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 73, UserID = 1, Status = "Bài Đăng 73", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 74, UserID = 2, Status = "Bài Đăng 74", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 75, UserID = 1, Status = "Bài Đăng 75", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 76, UserID = 2, Status = "Bài Đăng 76", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 77, UserID = 1, Status = "Bài Đăng 77", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 78, UserID = 2, Status = "Bài Đăng 78", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 79, UserID = 1, Status = "Bài Đăng 79", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 80, UserID = 2, Status = "Bài Đăng 80", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 81, UserID = 1, Status = "Bài Đăng 81", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 82, UserID = 2, Status = "Bài Đăng 82", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 83, UserID = 1, Status = "Bài Đăng 83", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 84, UserID = 2, Status = "Bài Đăng 84", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 85, UserID = 1, Status = "Bài Đăng 85", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 86, UserID = 2, Status = "Bài Đăng 86", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 87, UserID = 1, Status = "Bài Đăng 87", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 88, UserID = 2, Status = "Bài Đăng 88", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 89, UserID = 1, Status = "Bài Đăng 89", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 90, UserID = 2, Status = "Bài Đăng 90", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 91, UserID = 1, Status = "Bài Đăng 91", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 92, UserID = 2, Status = "Bài Đăng 92", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 93, UserID = 1, Status = "Bài Đăng 93", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 94, UserID = 2, Status = "Bài Đăng 94", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 95, UserID = 1, Status = "Bài Đăng 95", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 96, UserID = 2, Status = "Bài Đăng 96", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 97, UserID = 1, Status = "Bài Đăng 97", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 98, UserID = 2, Status = "Bài Đăng 98", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 99, UserID = 1, Status = "Bài Đăng 99", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 100, UserID = 2, Status = "Bài Đăng 100", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 101, UserID = 1, Status = "Bài Đăng 101", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 102, UserID = 2, Status = "Bài Đăng 102", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 103, UserID = 1, Status = "Bài Đăng 103", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 104, UserID = 2, Status = "Bài Đăng 104", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 105, UserID = 1, Status = "Bài Đăng 105", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 106, UserID = 2, Status = "Bài Đăng 106", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 107, UserID = 1, Status = "Bài Đăng 107", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 108, UserID = 2, Status = "Bài Đăng 108", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 109, UserID = 1, Status = "Bài Đăng 109", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 110, UserID = 2, Status = "Bài Đăng 110", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 111, UserID = 1, Status = "Bài Đăng 111", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 112, UserID = 2, Status = "Bài Đăng 112", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 113, UserID = 1, Status = "Bài Đăng 113", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 114, UserID = 2, Status = "Bài Đăng 114", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 115, UserID = 1, Status = "Bài Đăng 115", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 116, UserID = 2, Status = "Bài Đăng 116", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 117, UserID = 1, Status = "Bài Đăng 117", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 118, UserID = 2, Status = "Bài Đăng 118", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 119, UserID = 1, Status = "Bài Đăng 119", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 120, UserID = 2, Status = "Bài Đăng 120", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 121, UserID = 1, Status = "Bài Đăng 121", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 122, UserID = 2, Status = "Bài Đăng 122", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 123, UserID = 1, Status = "Bài Đăng 123", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 124, UserID = 2, Status = "Bài Đăng 124", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 125, UserID = 1, Status = "Bài Đăng 125", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 126, UserID = 2, Status = "Bài Đăng 126", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 127, UserID = 1, Status = "Bài Đăng 127", Description = "Bán xe", CreateAt = "" },
////            new Listings() { CarID = 128, UserID = 2, Status = "Bài Đăng 128", Description = "Bán xe", CreateAt = "" }
////        };
////        LoadDataListingFromJson(result);
////        return result;
////    }

////    public void LoadDataListingFromJson(List<Listings> listings)
////    {
////        try
////        {
////            string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
////            string filePath = Path.Combine(assemblyLocation, "Listings.json");
////            string json = File.ReadAllText(filePath);

////            // Deserialize dữ liệu từ JSON thành List<Listings>
////            var listingsFromJson = JsonConvert.DeserializeObject<List<Listings>>(json);

////            foreach (var listing in listingsFromJson)
////            {
////                listings.Add(listing);
////            }
////        }
////        catch (Exception ex)
////        {
////            // Xử lý lỗi nếu có vấn đề trong việc đọc file hoặc xử lý dữ liệu
////            Console.WriteLine("Error loading data from JSON: " + ex.Message);
////        }
////    }

////    public List<IsExpanderExpaned> GetIsExpanderExpaned()
////    {
////        var result = new List<IsExpanderExpaned>()
////        {
////            new IsExpanderExpaned()
////            {
////                isExpanderExpanded = true,
////                toggleText = "Thu gọn",
////            },
////            new IsExpanderExpaned()
////            {
////                isExpanderExpanded = true,
////                toggleText = "Thu gọn",
////            },
////            new IsExpanderExpaned()
////            {
////                isExpanderExpanded = true,
////                toggleText = "Thu gọn",
////            },
////        };
////        return result;
////    }

//public List<Location> GetLocations()
//{
//    var result = new List<Location>()
//        {
//            new Location()
//            {
//                City = "Hà Nội",
//                District = new List<string>()
//                {
//                    "Ba Đình",
//                    "Hoàn Kiếm",
//                    "Hai Bà Trưng",
//                    "Đống Đa",
//                    "Tây Hồ",
//                    "Cầu Giấy",
//                    "Thanh Xuân",
//                    "Hoàng Mai",
//                    "Long Biên",
//                    "Bắc Từ Liêm",
//                    "Nam Từ Liêm",
//                    "Hà Đông",
//                    "Sơn Tây",
//                    "Ba Vì",
//                    "Phúc Thọ",
//                    "Thạch Thất",
//                    "Quốc Oai",
//                    "Chương Mỹ",
//                    "Thanh Oai",
//                    "Thường Tín",
//                    "Phú Xuyên",
//                    "Ứng Hòa",
//                    "Mỹ Đức"
//                }
//            },
//            new Location()
//            {
//                City = "Hồ Chí Minh",
//                District = new List<string>()
//                {
//                    "Quận 1",
//                    "Quận 2",
//                    "Quận 3",
//                    "Quận 4",
//                    "Quận 5",
//                    "Quận 6",
//                    "Quận 7",
//                    "Quận 8",
//                    "Quận 9",
//                    "Quận 10",
//                    "Quận 11",
//                    "Quận 12",
//                    "Quận Bình Tân",
//                    "Quận Bình Thạnh",
//                    "Quận Gò Vấp",
//                    "Quận Phú Nhuận",
//                    "Quận Tân Bình",
//                    "Quận Tân Phú",
//                    "Quận Thủ Đức",
//                    "Huyện Bình Chánh",
//                    "Huyện Cần Giờ",
//                    "Huyện Củ Chi",
//                    "Huyện Hóc Môn",
//                    "Huyện Nhà Bè"
//                }
//            },
//            new Location()
//            {
//                City = "Đà Nẵng",
//                District = new List<string>()
//                {
//                    "Quận Hải Châu",
//                    "Quận Thanh Khê",
//                    "Quận Sơn Trà",
//                    "Quận Ngũ Hành Sơn",
//                    "Quận Liên Chiểu",
//                    "Huyện Hoàng Sa"
//                }
//            },
//        };
//    return result;
//}
////}
