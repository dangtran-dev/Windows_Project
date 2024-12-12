using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.UI.Xaml;
using Newtonsoft.Json;
using Windows.System;
using Windows_Project;
using System.IO;
using System.Diagnostics;

namespace Windows_Project.Service.DataAccess
{
    public class SqlDao : IDao
    {
        private readonly string _connectionString;

        public SqlDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Manufacturers> GetManufacturers()
        {
            var manufacturers = new List<Manufacturers>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT ManufacturerID, ManufacturerName, ManufacturerPicture FROM Manufacturers";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int manufacturerId = reader.GetInt32(0);  // ManufacturerID
                        string manufacturerName = reader.GetString(1);  // ManufacturerName
                        string manufacturerPicture = reader.GetString(2);  // ManufacturerPicture

                        // Tạo một kết nối mới cho mỗi truy vấn Cars
                        List<Cars> cars = GetCarsByManufacturer(manufacturerId);
                        // Tạo một kết nối cho mỗi truy vấn CarModel
                        List<CarModels> carmodels = GetModelsByManufacturer(manufacturerId);
                        // Đọc dữ liệu và ánh xạ vào đối tượng Manufacturers
                        manufacturers.Add(new Manufacturers
                        {
                            ManufacturerId = manufacturerId,
                            ManufacturerName = manufacturerName,
                            ManufacturerPicture = manufacturerPicture, // hoặc lấy từ cơ sở dữ liệu nếu cần
                            Cars = cars,     // Gán danh sách Cars
                            CarsModels = carmodels // gán danh sách CarModels
                        });
                    }
                }
            }
            return manufacturers;
        }
        // Phương thức lấy danh sách Models cho mỗi nhà sản xuất
        private List<CarModels> GetModelsByManufacturer(int manufacturerId)
        {
            var models = new List<CarModels>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT ModelID, ModelName FROM CarModels WHERE ManufacturerID = @ManufacturerId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ManufacturerId", manufacturerId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            models.Add(new CarModels
                            {
                                ModelID = reader.GetInt32(0),
                                ModelName = reader.GetString(1),
                            });
                        }
                    }
                }
            }
            return models;
        }
        // Phương thức lấy danh sách Cars cho mỗi nhà sản xuất
        private List<Cars> GetCarsByManufacturer(int manufacturerId)
        {
            var cars = new List<Cars>();

            // Tạo một kết nối mới cho truy vấn Cars
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Truy vấn kết hợp giữa Cars, CarModels và Manufacturers
                string query = @"
            SELECT 
                Cars.CarID, 
                Cars.ModelID, 
                Cars.CarName, 
                Cars.Year, 
                Cars.Style, 
                Cars.Condition, 
                Cars.Origin, 
                Cars.Mileage, 
                Cars.Gear, 
                Cars.FuelType, 
                Cars.Price,
                Cars.City,
                Cars.District,
                CarModels.ModelName,
                CarModels.ManufacturerID,
                Manufacturers.ManufacturerName
            FROM Cars
            JOIN CarModels ON Cars.ModelID = CarModels.ModelID
            JOIN Manufacturers ON CarModels.ManufacturerID = Manufacturers.ManufacturerID
            WHERE Manufacturers.ManufacturerID = @ManufacturerId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ManufacturerId", manufacturerId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cars.Add(new Cars
                            {
                                ID = reader.GetInt32(0),
                                ModelID = reader.GetInt32(1),
                                CarName = reader.GetString(2),
                                Year = reader.GetInt32(3),
                                Style = reader.GetString(4),
                                Condition = reader.GetString(5),
                                Origin = reader.GetString(6),
                                Mileage = reader.GetDecimal(7), // Đảm bảo rằng kiểu dữ liệu phù hợp
                                Gear = reader.GetString(8),
                                FuelType = reader.GetString(9),
                                Price = reader.GetDecimal(10),
                                City = reader.GetString(11).ToString(),
                                District = reader.GetString(12).ToString(),
                                CarImages = GetCarImages(reader.GetInt32(0))
                            });
                        }
                    }
                }
            }
            return cars;
        }



        public List<Cars> GetCars()
        {
            var cars = new List<Cars>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT CarID, ModelID, CarName, Year, Style, Condition, Origin, Mileage, Gear, FuelType, Price, City, District FROM Cars ORDER BY CarID DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {  
                        cars.Add(new Cars
                        {
                            ID = reader.GetInt32(0),
                            ModelID = reader.GetInt32(1),
                            CarName = reader.GetString(2),
                            Year = reader.GetInt32(3),
                            Style = reader.GetString(4),
                            Condition = reader.GetString(5),
                            Origin = reader.GetString(6),
                            Mileage = reader.GetDecimal(7),
                            Gear = reader.GetString(8),
                            FuelType = reader.GetString(9),
                            Price = reader.GetDecimal(10),
                            City = reader.GetString(11).ToString(),
                            District = reader.GetString(12).ToString(),
                            CarImages = GetCarImages(reader.GetInt32(0))
                        });
                    }
                }
            }
            return cars;
        }

        // Phương thức lấy danh sách hình ảnh cho mỗi xe
        public List<CarImages> GetCarImages(int carId)
        {
            var carImages = new List<CarImages>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT ImageID, CarID, ImageURL FROM CarImages WHERE CarID = @CarId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarId", carId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            carImages.Add(new CarImages
                            {
                                ImageID = reader.GetInt32(0),
                                CarID = reader.GetInt32(1),
                                ImageURL = reader.GetString(2),
                            });
                        }
                    }
                }
            }

            return carImages;
        }
        // phương lưu danh sách ảnh cho mỗi xe xuống cơ sở dữ liệu
        public async Task<bool> SaveCarImagesAsync(CarImages carImages)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"
                    INSERT INTO CarImages (CarID, ImageURL)
                    VALUES (@CarID, @ImageURL)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CarID", carImages.CarID);
                        cmd.Parameters.AddWithValue("@ImageURL", carImages.ImageURL);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Debug.WriteLine($"Error saving car images: {ex.Message}");
                return false;
            }
        }
        public List<Users> GetUsers()
        {
            var users = new List<Users>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT UserID, UserName, Password, FullName, Phone, Email, Address FROM Users";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new Users
                        {
                            UserID = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Password = reader.GetString(2),
                            FullName = reader.IsDBNull(3) ? null : reader.GetString(3),
                            Phone = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Email = reader.IsDBNull(5) ? null : reader.GetString(5),
                            Address = reader.IsDBNull(6) ? null : reader.GetString(6),
                        });
                    }
                }
            }
            return users;
        }

        public async Task<bool> SaveUserAsync(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username))
                {
                    // Return false if the username is invalid (null or empty)
                    Debug.WriteLine("Username cannot be null or empty.");
                    return false;
                }

                // Check if the username already exists in the database
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        int count = (int)await checkCmd.ExecuteScalarAsync();

                        if (count > 0)
                        {
                            // Return false if the username already exists
                            Debug.WriteLine("Username already exists.");
                            return false;
                        }
                    }
                }

                // If the username is valid and does not exist, insert the new user
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Debug.WriteLine($"Error saving user: {ex.Message}");
                return false;
            }
        }

        // phương thức lưu thông tin xe xuống cơ sở dữ liệu
        public async Task<bool> SaveCarAsync(Cars car)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"
                    INSERT INTO Cars (ModelID, CarName, Year, Style, Condition, Origin, Mileage, Gear, FuelType, Price, City, District)
                    VALUES (@ModelID, @CarName, @Year, @Style, @Condition, @Origin, @Mileage, @Gear, @FuelType, @Price, @City, @District)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ModelID", car.ModelID);
                        cmd.Parameters.AddWithValue("@CarName", car.CarName);
                        cmd.Parameters.AddWithValue("@Year", car.Year);
                        cmd.Parameters.AddWithValue("@Style", car.Style);
                        cmd.Parameters.AddWithValue("@Condition", car.Condition);
                        cmd.Parameters.AddWithValue("@Origin", car.Origin);
                        cmd.Parameters.AddWithValue("@Mileage", car.Mileage);
                        cmd.Parameters.AddWithValue("@Gear", car.Gear);
                        cmd.Parameters.AddWithValue("@FuelType", car.FuelType);
                        cmd.Parameters.AddWithValue("@Price", car.Price);
                        cmd.Parameters.AddWithValue("@City", car.City);
                        cmd.Parameters.AddWithValue("@District", car.District);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Debug.WriteLine($"Error saving car: {ex.Message}");
                return false;
            }
        }
        // phương thức lưu bài đăng xuống cơ sở dữ liệu
        public async Task<bool> SaveListingAsync(Listings listing)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"
                    INSERT INTO Listings (UserID, CarID, Status, Description, DatePosted)
                    VALUES (@UserID, @CarID, @Status, @Description, @DatePosted)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", listing.UserID);
                        cmd.Parameters.AddWithValue("@CarID", listing.CarID);
                        cmd.Parameters.AddWithValue("@Status", listing.Status);
                        cmd.Parameters.AddWithValue("@Description", listing.Description);
                        cmd.Parameters.AddWithValue("@DatePosted", listing.DatePosted);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Debug.WriteLine($"Error saving listing: {ex.Message}");
                return false;
            }
        }
        // phương thức lấy danh sách bài đăng
        public List<Listings> GetListings()
        {
            var listings = new List<Listings>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT ListingID, UserID, CarID, Status, Description, DatePosted FROM Listings ORDER BY DatePosted DESC";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listings.Add(new Listings
                        {
                            ListingID = reader.GetInt32(0),
                            UserID = reader.GetInt32(1),
                            CarID = reader.GetInt32(2),
                            Status = reader.GetString(3),
                            Description = reader.GetString(4),
                            DatePosted = reader.GetDateTime(5),
                        });
                    }
                }
            }
            return listings;
        }

        // Các phương thức khác (GetIsExpanderExpaned, GetLocations, GetUsers, GetListings) có thể triển khai tương tự.
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
                    "Bình Tân",
                    "Bình Thạnh",
                    "Gò Vấp",
                    "Phú Nhuận",
                    "Tân Bình",
                    "Tân Phú",
                    "Thủ Đức",
                    "Bình Chánh",
                    "Cần Giờ",
                    "Củ Chi",
                    "Hóc Môn",
                    "Nhà Bè"
                }
            },
            new Location()
            {
                City = "Đà Nẵng",
                District = new List<string>()
                {
                    "Hải Châu",
                    "Thanh Khê",
                    "Sơn Trà",
                    "Ngũ Hành Sơn",
                    "Liên Chiểu",
                    "Hoàng Sa"
                }
            },
        };
            return result;
        }

        
    }
}
