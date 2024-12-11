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
using Windows_Project.Model;
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

                        // Đọc dữ liệu và ánh xạ vào đối tượng Manufacturers
                        manufacturers.Add(new Manufacturers
                        {
                            ManufacturerId = manufacturerId,
                            ManufacturerName = manufacturerName,
                            ManufacturerPicture = manufacturerPicture, // hoặc lấy từ cơ sở dữ liệu nếu cần
                            Cars = cars // Gán danh sách Cars
                        });
                    }
                }
            }
            return manufacturers;
        }

        public List<CarModels> GetCarModels()
        {
            var carModels = new List<CarModels>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT ModelID, ManufacturerID, ModelName FROM CarModels";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        carModels.Add(new CarModels
                        {
                            ModelID = reader.GetInt32(0),
                            ManufacturerID = reader.GetInt32(1),
                            ModelName = reader.GetString(2),
                        });
                    }
                }
            }

            return carModels;
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
                                Price = reader.GetDecimal(10).ToString(), // Chuyển đổi Decimal thành String
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
                string query = "SELECT CarID, ModelID, CarName, Year, Style, Condition, Origin, Mileage, Gear, FuelType, Price, City, District FROM Cars";

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
                            Price = reader.GetDecimal(10).ToString(),
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


        //public List<Listings> GetListings()
        //{
        //    var listings = new List<Listings>();
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();
        //        string query = "SELECT ListingID, UserID, CarID, Status, Description, DatePosted FROM Listings";
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                listings.Add(new Listings
        //                {
        //                    ListingID = reader.GetInt32(0),
        //                    UserID = reader.GetInt32(1),
        //                    CarID = reader.GetInt32(2),
        //                    Status = reader.GetString(3),
        //                    Description = reader.GetString(4),
        //                    DatePosted = reader.GetDateTime(5).ToString(),
        //                });
        //            }
        //        }
        //    }
        //    return listings;
        //}

        public List<Listings> GetListings()
        {
            var result = new List<Listings>()
        {
            new Listings() { CarID = 1, UserID = 1, Status = "Bài Đăng 1", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 2, UserID = 2, Status = "Bài Đăng 2", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 3, UserID = 1, Status = "Bài Đăng 3", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 4, UserID = 2, Status = "Bài Đăng 4", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 5, UserID = 1, Status = "Bài Đăng 5", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 6, UserID = 2, Status = "Bài Đăng 6", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 7, UserID = 1, Status = "Bài Đăng 7", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 8, UserID = 2, Status = "Bài Đăng 8", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 9, UserID = 1, Status = "Bài Đăng 9", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 10, UserID = 2, Status = "Bài Đăng 10", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 11, UserID = 1, Status = "Bài Đăng 11", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 12, UserID = 2, Status = "Bài Đăng 12", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 13, UserID = 1, Status = "Bài Đăng 13", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 14, UserID = 2, Status = "Bài Đăng 14", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 15, UserID = 1, Status = "Bài Đăng 15", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 16, UserID = 2, Status = "Bài Đăng 16", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 17, UserID = 1, Status = "Bài Đăng 17", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 18, UserID = 2, Status = "Bài Đăng 18", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 19, UserID = 1, Status = "Bài Đăng 19", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 20, UserID = 2, Status = "Bài Đăng 20", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 21, UserID = 1, Status = "Bài Đăng 21", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 22, UserID = 2, Status = "Bài Đăng 22", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 23, UserID = 1, Status = "Bài Đăng 23", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 24, UserID = 2, Status = "Bài Đăng 24", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 25, UserID = 1, Status = "Bài Đăng 25", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 26, UserID = 2, Status = "Bài Đăng 26", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 27, UserID = 1, Status = "Bài Đăng 27", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 28, UserID = 2, Status = "Bài Đăng 28", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 29, UserID = 1, Status = "Bài Đăng 29", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 30, UserID = 2, Status = "Bài Đăng 30", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 31, UserID = 1, Status = "Bài Đăng 31", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 32, UserID = 2, Status = "Bài Đăng 32", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 33, UserID = 1, Status = "Bài Đăng 33", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 34, UserID = 2, Status = "Bài Đăng 34", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 35, UserID = 1, Status = "Bài Đăng 35", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 36, UserID = 2, Status = "Bài Đăng 36", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 37, UserID = 1, Status = "Bài Đăng 37", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 38, UserID = 2, Status = "Bài Đăng 38", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 39, UserID = 1, Status = "Bài Đăng 39", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 40, UserID = 2, Status = "Bài Đăng 40", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 41, UserID = 1, Status = "Bài Đăng 41", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 42, UserID = 2, Status = "Bài Đăng 42", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 43, UserID = 1, Status = "Bài Đăng 43", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 44, UserID = 2, Status = "Bài Đăng 44", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 45, UserID = 1, Status = "Bài Đăng 45", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 46, UserID = 2, Status = "Bài Đăng 46", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 47, UserID = 1, Status = "Bài Đăng 47", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 48, UserID = 2, Status = "Bài Đăng 48", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 49, UserID = 1, Status = "Bài Đăng 49", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 50, UserID = 2, Status = "Bài Đăng 50", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 51, UserID = 1, Status = "Bài Đăng 51", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 52, UserID = 2, Status = "Bài Đăng 52", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 53, UserID = 1, Status = "Bài Đăng 53", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 54, UserID = 2, Status = "Bài Đăng 54", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 55, UserID = 1, Status = "Bài Đăng 55", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 56, UserID = 2, Status = "Bài Đăng 56", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 57, UserID = 1, Status = "Bài Đăng 57", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 58, UserID = 2, Status = "Bài Đăng 58", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 59, UserID = 1, Status = "Bài Đăng 59", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 60, UserID = 2, Status = "Bài Đăng 60", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 61, UserID = 1, Status = "Bài Đăng 61", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 62, UserID = 2, Status = "Bài Đăng 62", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 63, UserID = 1, Status = "Bài Đăng 63", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 64, UserID = 2, Status = "Bài Đăng 64", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 65, UserID = 1, Status = "Bài Đăng 65", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 66, UserID = 2, Status = "Bài Đăng 66", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 67, UserID = 1, Status = "Bài Đăng 67", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 68, UserID = 2, Status = "Bài Đăng 68", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 69, UserID = 1, Status = "Bài Đăng 69", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 70, UserID = 2, Status = "Bài Đăng 70", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 71, UserID = 1, Status = "Bài Đăng 71", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 72, UserID = 2, Status = "Bài Đăng 72", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 73, UserID = 1, Status = "Bài Đăng 73", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 74, UserID = 2, Status = "Bài Đăng 74", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 75, UserID = 1, Status = "Bài Đăng 75", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 76, UserID = 2, Status = "Bài Đăng 76", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 77, UserID = 1, Status = "Bài Đăng 77", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 78, UserID = 2, Status = "Bài Đăng 78", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 79, UserID = 1, Status = "Bài Đăng 79", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 80, UserID = 2, Status = "Bài Đăng 80", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 81, UserID = 1, Status = "Bài Đăng 81", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 82, UserID = 2, Status = "Bài Đăng 82", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 83, UserID = 1, Status = "Bài Đăng 83", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 84, UserID = 2, Status = "Bài Đăng 84", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 85, UserID = 1, Status = "Bài Đăng 85", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 86, UserID = 2, Status = "Bài Đăng 86", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 87, UserID = 1, Status = "Bài Đăng 87", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 88, UserID = 2, Status = "Bài Đăng 88", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 89, UserID = 1, Status = "Bài Đăng 89", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 90, UserID = 2, Status = "Bài Đăng 90", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 91, UserID = 1, Status = "Bài Đăng 91", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 92, UserID = 2, Status = "Bài Đăng 92", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 93, UserID = 1, Status = "Bài Đăng 93", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 94, UserID = 2, Status = "Bài Đăng 94", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 95, UserID = 1, Status = "Bài Đăng 95", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 96, UserID = 2, Status = "Bài Đăng 96", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 97, UserID = 1, Status = "Bài Đăng 97", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 98, UserID = 2, Status = "Bài Đăng 98", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 99, UserID = 1, Status = "Bài Đăng 99", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 100, UserID = 2, Status = "Bài Đăng 100", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 101, UserID = 1, Status = "Bài Đăng 101", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 102, UserID = 2, Status = "Bài Đăng 102", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 103, UserID = 1, Status = "Bài Đăng 103", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 104, UserID = 2, Status = "Bài Đăng 104", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 105, UserID = 1, Status = "Bài Đăng 105", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 106, UserID = 2, Status = "Bài Đăng 106", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 107, UserID = 1, Status = "Bài Đăng 107", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 108, UserID = 2, Status = "Bài Đăng 108", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 109, UserID = 1, Status = "Bài Đăng 109", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 110, UserID = 2, Status = "Bài Đăng 110", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 111, UserID = 1, Status = "Bài Đăng 111", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 112, UserID = 2, Status = "Bài Đăng 112", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 113, UserID = 1, Status = "Bài Đăng 113", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 114, UserID = 2, Status = "Bài Đăng 114", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 115, UserID = 1, Status = "Bài Đăng 115", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 116, UserID = 2, Status = "Bài Đăng 116", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 117, UserID = 1, Status = "Bài Đăng 117", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 118, UserID = 2, Status = "Bài Đăng 118", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 119, UserID = 1, Status = "Bài Đăng 119", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 120, UserID = 2, Status = "Bài Đăng 120", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 121, UserID = 1, Status = "Bài Đăng 121", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 122, UserID = 2, Status = "Bài Đăng 122", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 123, UserID = 1, Status = "Bài Đăng 123", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 124, UserID = 2, Status = "Bài Đăng 124", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 125, UserID = 1, Status = "Bài Đăng 125", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 126, UserID = 2, Status = "Bài Đăng 126", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 127, UserID = 1, Status = "Bài Đăng 127", Description = "Bán xe", DatePosted = "" },
            new Listings() { CarID = 128, UserID = 2, Status = "Bài Đăng 128", Description = "Bán xe", DatePosted = "" }
        };
            LoadDataListingFromJson(result);
            return result;
        }

        public void LoadDataListingFromJson(List<Listings> listings)
        {
            try
            {
                string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string filePath = Path.Combine(assemblyLocation, "Listings.json");
                string json = File.ReadAllText(filePath);

                // Deserialize dữ liệu từ JSON thành List<Listings>
                var listingsFromJson = JsonConvert.DeserializeObject<List<Listings>>(json);

                foreach (var listing in listingsFromJson)
                {
                    listings.Add(listing);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có vấn đề trong việc đọc file hoặc xử lý dữ liệu
                Console.WriteLine("Error loading data from JSON: " + ex.Message);
            }
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
}
