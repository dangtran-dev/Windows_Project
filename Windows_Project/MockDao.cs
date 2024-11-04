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
    public List<IsExpanderExpaned> GetIsExpanderExpaned()
    {
        var result = new List<IsExpanderExpaned>()
        {
            new IsExpanderExpaned()
            {
                isExpanderExpanded = true,
                toggleText = "Thu gọn",
            },
            new IsExpanderExpaned()
            {
                isExpanderExpanded = true,
                toggleText = "Thu gọn",
            },
            new IsExpanderExpaned()
            {
                isExpanderExpanded = true,
                toggleText = "Thu gọn",
            },
        };
        return result;
    }

    public List<Location> GetLocations()
    {
        var result = new List<Location>()
        {
            new Location()
            {
                City = "Hà Nội",
                District = new List<string>()
                {
                    "Ba Đình",
                    "Hoàn Kiếm",
                    "Hai Bà Trưng",
                    "Đống Đa",
                    "Tây Hồ",
                    "Cầu Giấy",
                    "Thanh Xuân",
                    "Hoàng Mai",
                    "Long Biên",
                    "Bắc Từ Liêm",
                    "Nam Từ Liêm",
                    "Hà Đông",
                    "Sơn Tây",
                    "Ba Vì",
                    "Phúc Thọ",
                    "Thạch Thất",
                    "Quốc Oai",
                    "Chương Mỹ",
                    "Thanh Oai",
                    "Thường Tín",
                    "Phú Xuyên",
                    "Ứng Hòa",
                    "Mỹ Đức"
                }
            },
            new Location()
            {
                City = "Hồ Chí Minh",
                District = new List<string>()
                {
                    "Quận 1",
                    "Quận 2",
                    "Quận 3",
                    "Quận 4",
                    "Quận 5",
                    "Quận 6",
                    "Quận 7",
                    "Quận 8",
                    "Quận 9",
                    "Quận 10",
                    "Quận 11",
                    "Quận 12",
                    "Quận Bình Tân",
                    "Quận Bình Thạnh",
                    "Quận Gò Vấp",
                    "Quận Phú Nhuận",
                    "Quận Tân Bình",
                    "Quận Tân Phú",
                    "Quận Thủ Đức",
                    "Huyện Bình Chánh",
                    "Huyện Cần Giờ",
                    "Huyện Củ Chi",
                    "Huyện Hóc Môn",
                    "Huyện Nhà Bè"
                }
            },
            new Location()
            {
                City = "Đà Nẵng",
                District = new List<string>()
                {
                     "Quận Hải Châu", 
                    "Quận Thanh Khê", 
                    "Quận Sơn Trà", 
                    "Quận Ngũ Hành Sơn", 
                    "Quận Liên Chiểu", 
                    "Huyện Hoàng Sa"
                }
            },
        };
        return result;
    }
}
