/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.seed = async function (knex) {
  // Deletes ALL existing entries
  await knex("table_name").del();
  await knex("table_name").insert([
    { id: 1, colName: "rowValue1" },
    { id: 2, colName: "rowValue2" },
    { id: 3, colName: "rowValue3" },
  ]);
};
/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.seed = async function (knex) {
  // Xóa dữ liệu cũ trước khi thêm mới
  await knex("Favorites").del();
  await knex("Listings").del();
  await knex("CarImages").del();
  await knex("Cars").del();
  await knex("CarModels").del();
  await knex("Manufacturers").del();
  await knex("Users").del();
  await knex("Reviews").del();

  // Thêm dữ liệu vào bảng Users
  await knex("Users").insert([
    {
      Username: "lebao",
      Password: "123",
      FullName: "Lê Bảo",
      Phone: "1234567890",
      Email: "bao@example.com",
      Address: "123 Elm Street",
    },
    {
      Username: "hihi",
      Password: "2004",
      FullName: "Jane Doe",
      Phone: "0987654321",
      Email: "jane@example.com",
      Address: "456 Oak Street",
    },
  ]);

  // Thêm dữ liệu vào bảng Manufacturers
  await knex("Manufacturers").insert([
    {
      ManufacturerName: "Toyota",
      ManufacturerPicture:
        "https://latarfaitdjumzdjmqxd.supabase.co/storage/v1/object/public/windows_project/toyota_logo.jpg",
    },
    {
      ManufacturerName: "Volkswagen",
      ManufacturerPicture:
        "https://latarfaitdjumzdjmqxd.supabase.co/storage/v1/object/public/windows_project/wolkswagen_logo.jpg",
    },
    {
      ManufacturerName: "Ford",
      ManufacturerPicture:
        "https://latarfaitdjumzdjmqxd.supabase.co/storage/v1/object/public/windows_project/ford_logo.jpg",
    },
    {
      ManufacturerName: "Chevrolet",
      ManufacturerPicture:
        "https://latarfaitdjumzdjmqxd.supabase.co/storage/v1/object/public/windows_project/chevrolet_logo.jpg",
    },
    {
      ManufacturerName: "Nissan",
      ManufacturerPicture:
        "https://latarfaitdjumzdjmqxd.supabase.co/storage/v1/object/public/windows_project/nissan_logo.jpg",
    },
    {
      ManufacturerName: "Hyundai",
      ManufacturerPicture:
        "https://latarfaitdjumzdjmqxd.supabase.co/storage/v1/object/public/windows_project/hyundai_logo.jpg",
    },
    {
      ManufacturerName: "KIA",
      ManufacturerPicture:
        "https://latarfaitdjumzdjmqxd.supabase.co/storage/v1/object/public/windows_project/kia_logo.jpg",
    },
    {
      ManufacturerName: "Subaru",
      ManufacturerPicture:
        "https://latarfaitdjumzdjmqxd.supabase.co/storage/v1/object/public/windows_project/subaru_logo.jpg",
    },
    {
      ManufacturerName: "Mercedes",
      ManufacturerPicture:
        "https://latarfaitdjumzdjmqxd.supabase.co/storage/v1/object/public/windows_project/mercedes_benz_logo.jpg",
    },
    {
      ManufacturerName: "BMW",
      ManufacturerPicture:
        "https://latarfaitdjumzdjmqxd.supabase.co/storage/v1/object/public/windows_project/bmw_logo.jpg",
    },
    {
      ManufacturerName: "Lexus",
      ManufacturerPicture:
        "https://latarfaitdjumzdjmqxd.supabase.co/storage/v1/object/public/windows_project/lexus_logo.jpg",
    },
    {
      ManufacturerName: "Porsche",
      ManufacturerPicture:
        "https://latarfaitdjumzdjmqxd.supabase.co/storage/v1/object/public/windows_project/porsche_logo.jpg",
    },
    {
      ManufacturerName: "VinFast",
      ManufacturerPicture:
        "https://latarfaitdjumzdjmqxd.supabase.co/storage/v1/object/public/windows_project/vinfast_logo.jpg",
    },
    {
      ManufacturerName: "Mazda",
      ManufacturerPicture:
        "https://latarfaitdjumzdjmqxd.supabase.co/storage/v1/object/public/windows_project/mazda_logo.jpg",
    },
    {
      ManufacturerName: "Honda",
      ManufacturerPicture:
        "https://latarfaitdjumzdjmqxd.supabase.co/storage/v1/object/public/windows_project/honda_logo.jpg",
    },
    {
      ManufacturerName: "Audi",
      ManufacturerPicture:
        "https://latarfaitdjumzdjmqxd.supabase.co/storage/v1/object/public/windows_project/audi_logo.jpg",
    },
  ]);

  // Thêm dữ liệu vào bảng CarModels
  await knex("CarModels").insert([
    { ManufacturerID: 1, ModelName: "Vios" },
    { ManufacturerID: 1, ModelName: "Innova" },
    { ManufacturerID: 1, ModelName: "Fortuner" },
    { ManufacturerID: 1, ModelName: "Camry" },
    { ManufacturerID: 1, ModelName: "Corolla Altis" },
    { ManufacturerID: 1, ModelName: "Corolla Cross" },
    { ManufacturerID: 1, ModelName: "Yaris" },
    { ManufacturerID: 1, ModelName: "Wigo" },
    { ManufacturerID: 2, ModelName: "Tiguan" },
    { ManufacturerID: 2, ModelName: "Polo" },
    { ManufacturerID: 2, ModelName: "Teramont" },
    { ManufacturerID: 2, ModelName: "Touareg" },
    { ManufacturerID: 2, ModelName: "T-Cross" },
    { ManufacturerID: 2, ModelName: "Beetle" },
    { ManufacturerID: 2, ModelName: "Amarok" },
    { ManufacturerID: 2, ModelName: "Atlas" },
    { ManufacturerID: 3, ModelName: "Ranger" },
    { ManufacturerID: 3, ModelName: "Everest" },
    { ManufacturerID: 3, ModelName: "EcoSport" },
    { ManufacturerID: 3, ModelName: "Territory" },
    { ManufacturerID: 3, ModelName: "Explorer" },
    { ManufacturerID: 3, ModelName: "F-150" },
    { ManufacturerID: 3, ModelName: "Transit" },
    { ManufacturerID: 3, ModelName: "Focus" },
    { ManufacturerID: 4, ModelName: "Alero" },
    { ManufacturerID: 4, ModelName: "Astro" },
    { ManufacturerID: 4, ModelName: "Avanlanche" },
    { ManufacturerID: 4, ModelName: "Aveo" },
    { ManufacturerID: 4, ModelName: "Beretta" },
    { ManufacturerID: 4, ModelName: "Blazer" },
    { ManufacturerID: 4, ModelName: "Bolt" },
    { ManufacturerID: 4, ModelName: "Camaro" },
    { ManufacturerID: 5, ModelName: "Navara" },
    { ManufacturerID: 5, ModelName: "Sunny" },
    { ManufacturerID: 5, ModelName: "Almera" },
    { ManufacturerID: 5, ModelName: "X trail" },
    { ManufacturerID: 5, ModelName: "Terra" },
    { ManufacturerID: 5, ModelName: "Teana" },
    { ManufacturerID: 5, ModelName: "100NX" },
    { ManufacturerID: 5, ModelName: "200SX" },
    { ManufacturerID: 6, ModelName: "Accent" },
    { ManufacturerID: 6, ModelName: "Avante" },
    { ManufacturerID: 6, ModelName: "Creta" },
    { ManufacturerID: 6, ModelName: "Elantra" },
    { ManufacturerID: 6, ModelName: "Getz" },
    { ManufacturerID: 6, ModelName: "Grand i10" },
    { ManufacturerID: 6, ModelName: "i20" },
    { ManufacturerID: 6, ModelName: "Kona" },
    { ManufacturerID: 7, ModelName: "Morning" },
    { ManufacturerID: 7, ModelName: "Cerato" },
    { ManufacturerID: 7, ModelName: "Sorento" },
    { ManufacturerID: 7, ModelName: "K3" },
    { ManufacturerID: 7, ModelName: "Sendona" },
    { ManufacturerID: 7, ModelName: "Seltos" },
    { ManufacturerID: 7, ModelName: "Carnival" },
    { ManufacturerID: 7, ModelName: "Soluto" },
    { ManufacturerID: 8, ModelName: "Ascent" },
    { ManufacturerID: 8, ModelName: "BRZ" },
    { ManufacturerID: 8, ModelName: "Crosstrek" },
    { ManufacturerID: 8, ModelName: "Forester" },
    { ManufacturerID: 8, ModelName: "Impreza" },
    { ManufacturerID: 8, ModelName: "Legacy" },
    { ManufacturerID: 8, ModelName: "Levorg" },
    { ManufacturerID: 8, ModelName: "Outback" },
    { ManufacturerID: 9, ModelName: "C-class" },
    { ManufacturerID: 9, ModelName: "E-class" },
    { ManufacturerID: 9, ModelName: "S-class" },
    { ManufacturerID: 9, ModelName: "V-class" },
    { ManufacturerID: 9, ModelName: "GLA" },
    { ManufacturerID: 9, ModelName: "GLB" },
    { ManufacturerID: 9, ModelName: "GLC" },
    { ManufacturerID: 9, ModelName: "GLE" },
    { ManufacturerID: 10, ModelName: "3-Series" },
    { ManufacturerID: 10, ModelName: "4-Series" },
    { ManufacturerID: 10, ModelName: "5-Series" },
    { ManufacturerID: 10, ModelName: "7-Series" },
    { ManufacturerID: 10, ModelName: "X3" },
    { ManufacturerID: 10, ModelName: "X5" },
    { ManufacturerID: 10, ModelName: "X7" },
    { ManufacturerID: 10, ModelName: "X6" },
    { ManufacturerID: 11, ModelName: "RX" },
    { ManufacturerID: 11, ModelName: "LX" },
    { ManufacturerID: 11, ModelName: "GX" },
    { ManufacturerID: 11, ModelName: "FordCT 200" },
    { ManufacturerID: 11, ModelName: "ES" },
    { ManufacturerID: 11, ModelName: "ES 250" },
    { ManufacturerID: 11, ModelName: "ES 300h" },
    { ManufacturerID: 11, ModelName: "ES 350" },
    { ManufacturerID: 12, ModelName: "718" },
    { ManufacturerID: 12, ModelName: "Macan" },
    { ManufacturerID: 12, ModelName: "Panamera" },
    { ManufacturerID: 12, ModelName: "911" },
    { ManufacturerID: 12, ModelName: "Cayenne" },
    { ManufacturerID: 12, ModelName: "Taycan" },
    { ManufacturerID: 12, ModelName: "930" },
    { ManufacturerID: 12, ModelName: "Boxster" },
    { ManufacturerID: 13, ModelName: "LUX A2.0" },
    { ManufacturerID: 13, ModelName: "LUX SA2.0" },
    { ManufacturerID: 13, ModelName: "Fadil" },
    { ManufacturerID: 13, ModelName: "VF e34" },
    { ManufacturerID: 13, ModelName: "VF8" },
    { ManufacturerID: 13, ModelName: "VF9" },
    { ManufacturerID: 13, ModelName: "SA" },
    { ManufacturerID: 13, ModelName: "VF 3" },
    { ManufacturerID: 14, ModelName: "3" },
    { ManufacturerID: 14, ModelName: "CX-5" },
    { ManufacturerID: 14, ModelName: "6" },
    { ManufacturerID: 14, ModelName: "2" },
    { ManufacturerID: 14, ModelName: "BT-50" },
    { ManufacturerID: 14, ModelName: "CX-8" },
    { ManufacturerID: 14, ModelName: "CX-3" },
    { ManufacturerID: 14, ModelName: "CX-30" },
    { ManufacturerID: 15, ModelName: "City" },
    { ManufacturerID: 15, ModelName: "Civic" },
    { ManufacturerID: 15, ModelName: "CR-V" },
    { ManufacturerID: 15, ModelName: "Accord" },
    { ManufacturerID: 15, ModelName: "Brio" },
    { ManufacturerID: 15, ModelName: "HR-V" },
    { ManufacturerID: 15, ModelName: "Jazz" },
    { ManufacturerID: 15, ModelName: "Odyssey" },
    { ManufacturerID: 16, ModelName: "A4" },
    { ManufacturerID: 16, ModelName: "A5" },
    { ManufacturerID: 16, ModelName: "Q5" },
    { ManufacturerID: 16, ModelName: "A6" },
    { ManufacturerID: 16, ModelName: "A8" },
    { ManufacturerID: 16, ModelName: "Q7" },
    { ManufacturerID: 16, ModelName: "100" },
    { ManufacturerID: 16, ModelName: "200" },
  ]);

  // Thêm dữ liệu vào bảng Cars
  await knex("Cars").insert([
    {
      ModelID: 1,
      CarName: "Toyota Vios 1.5G AT 2022",
      Year: 2022,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 75000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 450000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 2,
      CarName: "Toyota Innova 2.0V 2019",
      Year: 2019,
      Style: "MPV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 25000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 699000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 3,
      CarName: "Toyota Fortuner 2015",
      Year: 2015,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 107000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 488000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 4,
      CarName: "Toyota Camry 2.5Q 2018",
      Year: 2018,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 38000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 695000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 5,
      CarName: "Toyota Corolla Altis 1.8 G 2012",
      Year: 2012,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 120,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 335000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 6,
      CarName: "Toyota Corolla Cross 1.8 V 2020",
      Year: 2020,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 64000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 695000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 7,
      CarName: "Toyota Yaris 1.5G 2017",
      Year: 2017,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 60000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 414000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 8,
      CarName: "Toyota Wigo 1.2 G MT 2020",
      Year: 2020,
      Style: "Hatchback",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 70000,
      Gear: "Số sàn",
      FuelType: "Máy xăng",
      Price: 235000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 9,
      CarName: "Volkswagen Tiguan 2.0L TSI 2014",
      Year: 2014,
      Style: "Crossover",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 131313,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 475000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 10,
      CarName: "Volkswagen Polo 1.6AT 2021",
      Year: 2021,
      Style: "Hatchback",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 19900,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 539000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 11,
      CarName: "Volkswagen Teramont 2022",
      Year: 2022,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 22000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1750000000,
      City: "Hồ Chí Minh",
      District: "Quận 1",
    },
    {
      ModelID: 12,
      CarName: "Volkswagen Touareg 2008",
      Year: 2008,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 150000,
      Gear: "Số tự động",
      FuelType: "Máy dầu",
      Price: 388000000,
      City: "Hồ Chí Minh",
      District: "Quận 1",
    },
    {
      ModelID: 13,
      CarName: "Volkswagen T-Cross 2024",
      Year: 2024,
      Style: "SUV",
      Condition: "Xe mới",
      Origin: "Nhập khẩu",
      Mileage: 0,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 879000000,
      City: "Hồ Chí Minh",
      District: "Quận 1",
    },
    {
      ModelID: 14,
      CarName: "Volkswagen Beetle 2018",
      Year: 2018,
      Style: "Coupe",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 50000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1100000000,
      City: "Hồ Chí Minh",
      District: "Quận 1",
    },
    {
      ModelID: 17,
      CarName: "Ford Ranger Wildtrak 4x4 AT 2023",
      Year: 2023,
      Style: "Bán Tải",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 80000,
      Gear: "Số tự động",
      FuelType: "Máy dầu",
      Price: 870000000,
      City: "Hồ Chí Minh",
      District: "Quận 1",
    },
    {
      ModelID: 18,
      CarName: "Ford Everest Titanium 2.0 AT 4x2 2020",
      Year: 2020,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 45000,
      Gear: "Số tự động",
      FuelType: "Máy dầu",
      Price: 870000000,
      City: "Hồ Chí Minh",
      District: "Quận 1",
    },
    {
      ModelID: 19,
      CarName: "Ford EcoSport Ambiente 1.5L MT 2019",
      Year: 2019,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 65000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 398000000,
      City: "Hồ Chí Minh",
      District: "Quận 1",
    },
    {
      ModelID: 20,
      CarName: "Ford Territory Titanium X 2023",
      Year: 2023,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 45000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 840000000,
      City: "Hồ Chí Minh",
      District: "Quận 1",
    },
    {
      ModelID: 21,
      CarName: "Ford Explorer 2021",
      Year: 2021,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 85000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1730000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 22,
      CarName: "Ford F-150 Harley Davidson 2019",
      Year: 2019,
      Style: "Bán tải",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 40000,
      Gear: "Số tự động",
      FuelType: "Máy dầu",
      Price: 466000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 23,
      CarName: "Ford Transit 2013",
      Year: 2013,
      Style: "Van",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 100000,
      Gear: "Số sàn",
      FuelType: "Máy dầu",
      Price: 300000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 24,
      CarName: "Ford Focus Titanium 2014",
      Year: 2014,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 100000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 295000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 28,
      CarName: "Chevrolet Aveo 2018",
      Year: 2018,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 58000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 249000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 32,
      CarName: "Chevrolet Camaro RS 2012",
      Year: 2012,
      Style: "Convertible",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 88950,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 980000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 33,
      CarName: "Nissan Navara PRO4X 2022",
      Year: 2022,
      Style: "Bán tải",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 50000,
      Gear: "Số tự động",
      FuelType: "Máy dầu",
      Price: 825000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 34,
      CarName: "Nissan Sunny XV Premium 1.5 AT 2018",
      Year: 2018,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 40000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 365000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 35,
      CarName: "Nissan Almera CVT Cao cấp 2021",
      Year: 2021,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 69000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 435000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 36,
      CarName: "Nissan X trail 2.5 SV 4WD Premium 2019",
      Year: 2019,
      Style: "Crossover",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 70000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 715000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 37,
      CarName: "Nissan Terra 2018",
      Year: 2018,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 92000,
      Gear: "Số sàn",
      FuelType: "Máy dầu",
      Price: 599000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 38,
      CarName: "Nissan Teana SL 2.5 AT 2013",
      Year: 2013,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 110000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 390000000,
      City: "Hồ Chí Minh",
      District: "Thủ Đức",
    },
    {
      ModelID: 41,
      CarName: "Hyundai Accent 1.4 AT Đặc biệt 2021",
      Year: 2021,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 60000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 440000000,
      City: "Hồ Chí Minh",
      District: "Thủ Đức",
    },
    {
      ModelID: 42,
      CarName: "Hyundai Avante 1.6 MT 2011",
      Year: 2011,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 130000,
      Gear: "Số sàn",
      FuelType: "Máy xăng",
      Price: 209000000,
      City: "Hồ Chí Minh",
      District: "Thủ Đức",
    },
    {
      ModelID: 43,
      CarName: "Hyundai Creta 1.5L Đặc biệt 2022",
      Year: 2022,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 40000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 565000000,
      City: "Hồ Chí Minh",
      District: "Thủ Đức",
    },
    {
      ModelID: 44,
      CarName: "Hyundai Elantra 2.0 AT Cao cấp 2020",
      Year: 2020,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 80000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 415000000,
      City: "Hồ Chí Minh",
      District: "Thủ Đức",
    },
    {
      ModelID: 45,
      CarName: "Hyundai Getz 1.1 MT 2009",
      Year: 2009,
      Style: "Hatchback",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 145000,
      Gear: "Số sàn",
      FuelType: "Máy xăng",
      Price: 139000000,
      City: "Hồ Chí Minh",
      District: "Thủ Đức",
    },
    {
      ModelID: 46,
      CarName: "Hyundai Grand i10 Sedan 1.2 MT 2019",
      Year: 2019,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 65000,
      Gear: "Số sàn",
      FuelType: "Máy xăng",
      Price: 245000000,
      City: "Hồ Chí Minh",
      District: "Thủ Đức",
    },
    {
      ModelID: 47,
      CarName: "Hyundai i20 Active 1.4 AT 2015",
      Year: 2015,
      Style: "Coupe",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 8000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 345000000,
      City: "Hồ Chí Minh",
      District: "Thủ Đức",
    },
    {
      ModelID: 48,
      CarName: "Hyundai Kona 2.0 AT Đặc biệt 2020",
      Year: 2020,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 50000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 540000000,
      City: "Hồ Chí Minh",
      District: "Thủ Đức",
    },
    {
      ModelID: 49,
      CarName: "Kia Morning Si 1.25 AT 2017",
      Year: 2017,
      Style: "Hatchback",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 65000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 265000000,
      City: "Hồ Chí Minh",
      District: "Thủ Đức",
    },
    {
      ModelID: 50,
      CarName: "Kia Cerato 1.6 AT Luxury 2021",
      Year: 2021,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 60000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 750000000,
      City: "Hồ Chí Minh",
      District: "Thủ Đức",
    },
    {
      ModelID: 51,
      CarName: "Kia Sorento 2.2D Premium AWD 2022",
      Year: 2022,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 70000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 509000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 52,
      CarName: "Kia K3 1.6 Premium 2022",
      Year: 2022,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 28000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 566000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 53,
      CarName: "Kia Sedona 2.2 DATH 2018",
      Year: 2018,
      Style: "MPV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 66000,
      Gear: "Số tự động",
      FuelType: "Máy dầu",
      Price: 775000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 54,
      CarName: "Kia Seltos 1.4 Premium 2022",
      Year: 2022,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 41000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 655000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 55,
      CarName: "Kia Carnival 2.2D Signature 2022",
      Year: 2022,
      Style: "MPV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 20000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1399000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 56,
      CarName: "Kia Soluto MT Deluxe 2021",
      Year: 2021,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 20000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 400000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 58,
      CarName: "Subaru BRZ 2023",
      Year: 2023,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 800,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1390000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 60,
      CarName: "Subaru Forester 2.0i-S EyeSight 2021",
      Year: 2021,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 63000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 820000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 64,
      CarName: "Subaru Outback 2016",
      Year: 2016,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 70000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 650000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 65,
      CarName: "Mercedes-Benz C200 Exclusive 2021",
      Year: 2021,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 31700,
      Gear: "Số tự động",
      FuelType: "Hybrid",
      Price: 1659000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 66,
      CarName: "Mercedes-Benz E250 E250 2018",
      Year: 2018,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 64000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1130000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 67,
      CarName: "Mercedes-Benz S450L 4Matic 2019",
      Year: 2019,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 59000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 2699000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 68,
      CarName: "Mercedes-Benz V250 2018",
      Year: 2018,
      Style: "MPV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 83000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1380000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 69,
      CarName: "Mercedes-Benz GLA 45 2015",
      Year: 2015,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 136000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 759000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 70,
      CarName: "Mercedes-Benz GLB 35 2022",
      Year: 2022,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 20000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1990000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 71,
      CarName: "Mercedes-Benz GLC 300 4Matic 2022",
      Year: 2022,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 68000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1179000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 72,
      CarName: "Mercedes-Benz GLE 450 4Matic 2021",
      Year: 2021,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 55000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 3199000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 73,
      CarName: "BMW 320i 2015",
      Year: 2015,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 75000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 569000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 74,
      CarName: "BMW 420i 2018",
      Year: 2018,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 40000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1150000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 75,
      CarName: "BMW 520i 2018",
      Year: 2018,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 22000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1599000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 76,
      CarName: "BMW 740Li Pure Excellence 2018",
      Year: 2018,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 63000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 2280000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 77,
      CarName: "BMW X3 xDrive20i 2021",
      Year: 2021,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 61000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1460000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 78,
      CarName: "BMW X5 xDrive40i 2022",
      Year: 2022,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 10000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 3099000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 79,
      CarName: "BMW X7 xDrive40i 2020",
      Year: 2020,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 30000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 4099000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 80,
      CarName: "BMW X6 xDrive40i Msport 2022",
      Year: 2022,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 24000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 3799000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 81,
      CarName: "Lexus RX 300 2020",
      Year: 2020,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 23000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 2999000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 82,
      CarName: "Lexus LX 570 2016",
      Year: 2016,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 56789,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 4699000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 83,
      CarName: "Lexus GX 470 2008",
      Year: 2008,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 90000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 770000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 85,
      CarName: "Lexus ES 250 2019",
      Year: 2019,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 46000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1719000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 86,
      CarName: "Lexus ES 250 2021",
      Year: 2021,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 60000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 2230000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 87,
      CarName: "Lexus ES 300h 2021",
      Year: 2021,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 16000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 2630000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 88,
      CarName: "Lexus ES 350 2015",
      Year: 2015,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 70000,
      Gear: "Số sàn",
      FuelType: "Máy xăng",
      Price: 1150000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 89,
      CarName: "Porsche 718 CaymanT 2022",
      Year: 2022,
      Style: "Sport Car",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 8000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 4479000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 90,
      CarName: "Porsche Macan 2017",
      Year: 2017,
      Style: "Hatchback",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 38000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1720000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 91,
      CarName: "Porsche Panamera 3.0 V6 2017",
      Year: 2017,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 71000,
      Gear: "Số hỗn hợp",
      FuelType: "Máy xăng",
      Price: 3599000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 92,
      CarName: "Porsche 911 Carrera GTS 2022",
      Year: 2022,
      Style: "Sport Car",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 8000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 9499000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 93,
      CarName: "Porsche Cayenne V6 3.0 2019",
      Year: 2019,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 48000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 3699000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 94,
      CarName: "Porsche Taycan 4S 2021",
      Year: 2021,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 27000,
      Gear: "Số tự động",
      FuelType: "Điện",
      Price: 5000000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 96,
      CarName: "Porsche Boxster 2009",
      Year: 2009,
      Style: "Covertible",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 70000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1200000000,
      City: "Hà Nội",
      District: "Ba Đình",
    },
    {
      ModelID: 97,
      CarName: "VinFast LUX A2.0 Tiêu chuẩn 2020",
      Year: 2020,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 60000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 560000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 98,
      CarName: "VinFast LUX SA2.0 Tiêu chuẩn 2020",
      Year: 2020,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 50000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 718000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 99,
      CarName: "VinFast Fadil Nâng Cao 2019",
      Year: 2019,
      Style: "Hatchback",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 30000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 319000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 100,
      CarName: "VinFast VF e34 2022",
      Year: 2022,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 79000,
      Gear: "Số tự động",
      FuelType: "Điện",
      Price: 480000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 101,
      CarName: "VinFast VF8 Plus 2022",
      Year: 2022,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 20000,
      Gear: "Số tự động",
      FuelType: "Điện",
      Price: 850000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 102,
      CarName: "VinFast VF9 2023",
      Year: 2023,
      Style: "MPV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 19000,
      Gear: "Số tự động",
      FuelType: "Điện",
      Price: 1140000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 104,
      CarName: "VinFast VF 3 2024",
      Year: 2024,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 700,
      Gear: "Số tự động",
      FuelType: "Điện",
      Price: 255000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 105,
      CarName: "Mazda 3 1.5 Hatchback 2018",
      Year: 2018,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 46000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 475000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 106,
      CarName: "Mazda CX-5 2.5 2WD 2018",
      Year: 2018,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 110000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 625000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 107,
      CarName: "Mazda 6 2.0 Premium 2020",
      Year: 2020,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 9000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 760000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 108,
      CarName: "Mazda 2 1.5AT 2015",
      Year: 2015,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 90000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 328000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 109,
      CarName: "Mazda BT-50 2015",
      Year: 2015,
      Style: "Bán tải",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 110000,
      Gear: "Số tự động",
      FuelType: "Máy dầu",
      Price: 345000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 110,
      CarName: "Mazda CX-8 Premium 2024",
      Year: 2024,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 20000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1075000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 111,
      CarName: "Mazda CX-3 1.5L Deluxe 2022",
      Year: 2022,
      Style: "Crossover",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 18000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 525000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 112,
      CarName: "Mazda CX-30 2.0L Premium 2022",
      Year: 2022,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 1,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 690000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 113,
      CarName: "Honda City RS 2021",
      Year: 2021,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 13,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 470000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 114,
      CarName: "Honda Civic 1.5 G 2020",
      Year: 2020,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 78000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 655000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 115,
      CarName: "Honda CR-V 2.0 2014",
      Year: 2014,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 120000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 470000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 116,
      CarName: "Honda Accord 2008",
      Year: 2008,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 102000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 375000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 117,
      CarName: "Honda Brio RS 2019",
      Year: 2019,
      Style: "Hatchback",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 48000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 345000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 118,
      CarName: "Honda HR-V G 2023",
      Year: 2023,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Trong nước",
      Mileage: 31000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 675000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 119,
      CarName: "Honda Jazz 2019",
      Year: 2019,
      Style: "Hatchback",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 147000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 380000000,
      City: "Đà Nẵng",
      District: "Hải Châu",
    },
    {
      ModelID: 120,
      CarName: "Honda Odyssey 2.4 CVT 2016",
      Year: 2016,
      Style: "MPV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 98000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 790000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 121,
      CarName: "Audi A4 1.8L TFSI 2013",
      Year: 2013,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 78000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 450000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 122,
      CarName: "Audi A5 Sportback 2.0 TFSI 2013",
      Year: 2013,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 100000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 550000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 123,
      CarName: "Audi Q5 45 TFSI Quattro 2018",
      Year: 2018,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 89000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1179000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 124,
      CarName: "Audi A6 45 TFSI 2022",
      Year: 2022,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 22000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 1699000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 125,
      CarName: "Audi A8 4.2 2011",
      Year: 2011,
      Style: "Sedan",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 55000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 999000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
    {
      ModelID: 126,
      CarName: "Audi Q7 2013",
      Year: 2013,
      Style: "SUV",
      Condition: "Xe cũ",
      Origin: "Nhập khẩu",
      Mileage: 79000,
      Gear: "Số tự động",
      FuelType: "Máy xăng",
      Price: 748000000,
      City: "Hồ Chí Minh",
      District: "Gò Vấp",
    },
  ]);

  // Thêm dữ liệu vào bảng CarImages: chua lam
  await knex("CarImages").insert([
    {
      CarID: 1,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Toyota%20Vios%201.5G%20AT%202022.jpg?t=2024-11-21T09%3A49%3A10.336Z",
    },
    {
      CarID: 2,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Toyota%20Innova%202.0V%202019.jpg?t=2024-11-21T09%3A50%3A23.024Z",
    },
    {
      CarID: 3,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Toyota%20Fortuner%202015.jpg?t=2024-11-21T09%3A54%3A37.679Z",
    },
    {
      CarID: 4,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Toyota%20Camry%202.5Q%202018.jpg?t=2024-11-21T09%3A54%3A53.869Z",
    },
    {
      CarID: 5,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Toyota%20Corolla%20Altis%201.8%20G%202012.jpg?t=2024-11-21T09%3A55%3A06.149Z",
    },
    {
      CarID: 6,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Toyota%20Corolla%20Cross%201.8%20V%202020.jpg?t=2024-11-21T09%3A55%3A23.965Z",
    },
    {
      CarID: 7,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Toyota%20Yaris%201.5G%202017.jpg?t=2024-11-21T09%3A56%3A21.843Z",
    },
    {
      CarID: 8,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Toyota%20Wigo%201.2%20G%20MT%202020.jpg?t=2024-11-21T09%3A56%3A42.879Z",
    },
    {
      CarID: 9,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Volkswagen%20Tiguan%202.0L%20TSI%202014.jpg?t=2024-11-21T09%3A57%3A01.447Z",
    },
    {
      CarID: 10,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Volkswagen%20Polo%201.6AT%202021.jpg?t=2024-11-21T09%3A57%3A15.885Z",
    },
    {
      CarID: 11,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Volkswagen%20Teramont%202022.jpg?t=2024-11-21T09%3A57%3A28.046Z",
    },
    {
      CarID: 12,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Volkswagen%20Touareg%202008.jpg",
    },
    {
      CarID: 13,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Volkswagen%20T-Cross%202024.jpg",
    },
    {
      CarID: 14,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Volkswagen%20Beetle%202018.jpg?t=2024-11-21T09%3A58%3A26.540Z",
    },
    {
      CarID: 15,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Ford%20Ranger%20Wildtrak%204x4%20AT%202023.jpg?t=2024-11-21T09%3A58%3A48.748Z",
    },
    {
      CarID: 16,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Ford%20Everest%20Titanium%202.0%20AT%204x2%202020.jpg?t=2024-11-21T09%3A59%3A06.713Z",
    },
    {
      CarID: 17,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Ford%20EcoSport%20Ambiente%201.5L%20MT%202019.jpg?t=2024-11-21T09%3A59%3A20.268Z",
    },
    {
      CarID: 18,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Ford%20Territory%20Titanium%20X%202023.jpg?t=2024-11-21T09%3A59%3A33.976Z",
    },
    {
      CarID: 19,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Ford%20Explorer%202021.jpg?t=2024-11-21T09%3A59%3A50.726Z",
    },
    {
      CarID: 20,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Ford%20F-150%20Harley%20Davidson%202019.jpg?t=2024-11-21T10%3A00%3A04.331Z",
    },
    {
      CarID: 21,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Ford%20Transit%202013.jpg?t=2024-11-21T10%3A00%3A16.454Z",
    },
    {
      CarID: 22,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Ford%20Focus%20Titanium%202014.jpg",
    },
    {
      CarID: 23,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Chevrolet%20Aveo%202018.jpg",
    },
    {
      CarID: 24,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Chevrolet%20Camaro%20RS%202012.jpg?t=2024-11-21T10%3A01%3A22.847Z",
    },
    {
      CarID: 25,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Nissan%20Navara%20PRO4X%202022.jpg?t=2024-11-21T10%3A01%3A41.816Z",
    },
    {
      CarID: 26,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Nissan%20Sunny%20XV%20Premium%201.5%20AT%202018.jpg?t=2024-11-21T10%3A01%3A55.930Z",
    },
    {
      CarID: 27,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Nissan%20Almera%20CVT%20Cao%20cap%202021.jpg?t=2024-11-21T10%3A02%3A21.956Z",
    },
    {
      CarID: 28,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Nissan%20X%20trail%202.5%20SV%204WD%20Premium%202019.jpg?t=2024-11-21T10%3A02%3A32.912Z",
    },
    {
      CarID: 29,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Nissan%20Terra%202018.jpg?t=2024-11-21T10%3A02%3A48.370Z",
    },
    {
      CarID: 30,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Nissan%20Teana%20SL%202.5%20AT%202013.jpg",
    },
    {
      CarID: 31,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Hyundai%20Accent%201.4%20AT%20Dac%20biet%202021.jpg",
    },
    {
      CarID: 32,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Hyundai%20Avante%201.6%20MT%202011.jpg",
    },
    {
      CarID: 33,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Hyundai%20Creta%201.5L%20Dac%20biet%202022.jpg",
    },
    {
      CarID: 34,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Hyundai%20Elantra%202.0%20AT%20Cao%20cap%202020.jpg",
    },
    {
      CarID: 35,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Hyundai%20Getz%201.1%20MT%202009.jpg",
    },
    {
      CarID: 36,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Hyundai%20Grand%20i10%20Sedan%201.2%20MT%202019.jpg",
    },
    {
      CarID: 37,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Hyundai%20i20%20Active%201.4%20AT%202015.jpg",
    },
    {
      CarID: 38,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Hyundai%20Kona%202.0%20AT%20Dac%20biet%202020.jpg?t=2024-11-21T10%3A05%3A37.025Z",
    },
    {
      CarID: 39,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Kia%20Morning%20Si%201.25%20AT%202017.jpg",
    },
    {
      CarID: 40,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Kia%20Cerato%201.6%20AT%20Luxury%202021.jpg?t=2024-11-21T10%3A06%3A02.668Z",
    },
    {
      CarID: 41,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Kia%20Sorento%202.2D%20Premium%20AWD%202022.jpg?t=2024-11-21T10%3A06%3A15.591Z",
    },
    {
      CarID: 42,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Kia%20K3%201.6%20Premium%202022.jpg?t=2024-11-21T10%3A06%3A56.896Z",
    },
    {
      CarID: 43,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Kia%20Sedona%202.2%20DATH%202018.jpg?t=2024-11-21T10%3A07%3A11.647Z",
    },
    {
      CarID: 44,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Kia%20Seltos%201.4%20Premium%202022.jpg?t=2024-11-21T10%3A07%3A25.473Z",
    },
    {
      CarID: 45,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Kia%20Carnival%202.2D%20Signature%202022.jpg?t=2024-11-21T10%3A07%3A39.065Z",
    },
    {
      CarID: 46,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Kia%20Soluto%20MT%20Deluxe%202021.jpg?t=2024-11-21T10%3A07%3A51.132Z",
    },
    {
      CarID: 47,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Subaru%20BRZ%202023.jpg?t=2024-11-21T10%3A08%3A04.069Z",
    },
    {
      CarID: 48,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Subaru%20Forester%202.0i-S%20EyeSight%202021.jpg?t=2024-11-21T10%3A08%3A15.761Z",
    },
    {
      CarID: 49,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Subaru%20Outback%202016.jpg",
    },
    {
      CarID: 50,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mercedes-Benz%20C200%20Exclusive%202021.jpg?t=2024-11-21T10%3A08%3A43.225Z",
    },
    {
      CarID: 51,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mercedes-Benz%20E250%20E250%202018.jpg?t=2024-11-21T10%3A08%3A55.685Z",
    },
    {
      CarID: 52,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mercedes-Benz%20S450L%204Matic%202019.jpg?t=2024-11-21T10%3A09%3A11.862Z",
    },
    {
      CarID: 53,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mercedes-Benz%20V250%202018.jpg?t=2024-11-21T10%3A09%3A23.942Z",
    },
    {
      CarID: 54,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mercedes-Benz%20GLA%2045%202015.jpg?t=2024-11-21T10%3A09%3A35.609Z",
    },
    {
      CarID: 55,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mercedes-Benz%20GLB%2035%202022.jpg?t=2024-11-21T10%3A09%3A48.095Z",
    },
    {
      CarID: 56,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mercedes-Benz%20GLC%20300%204Matic%202022.jpg?t=2024-11-21T10%3A10%3A16.586Z",
    },
    {
      CarID: 57,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mercedes-Benz%20GLE%20450%204Matic%202021.jpg?t=2024-11-21T10%3A10%3A28.206Z",
    },
    {
      CarID: 58,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/BMW%20320i%202015.jpg?t=2024-11-21T10%3A10%3A40.781Z",
    },
    {
      CarID: 59,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/BMW%20420i%202018.jpg?t=2024-11-21T10%3A10%3A53.306Z",
    },
    {
      CarID: 60,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/BMW%20520i%202018.jpg?t=2024-11-21T10%3A11%3A05.911Z",
    },
    {
      CarID: 61,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/BMW%20740Li%20Pure%20Excellence%202018.jpg?t=2024-11-21T10%3A11%3A18.412Z",
    },
    {
      CarID: 62,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/BMW%20X3%20xDrive20i%202021.jpg",
    },
    {
      CarID: 63,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/BMW%20X5%20xDrive40i%202022.jpg?t=2024-11-21T10%3A11%3A44.955Z",
    },
    {
      CarID: 64,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/BMW%20X7%20xDrive40i%202020.jpg?t=2024-11-21T10%3A11%3A57.414Z",
    },
    {
      CarID: 65,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/BMW%20X6%20xDrive40i%20Msport%202022.jpg?t=2024-11-21T10%3A12%3A11.343Z",
    },
    {
      CarID: 66,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Lexus%20RX%20300%202020.jpg?t=2024-11-21T10%3A12%3A23.735Z",
    },
    {
      CarID: 67,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Lexus%20LX%20570%202016.jpg?t=2024-11-21T10%3A12%3A41.403Z",
    },
    {
      CarID: 68,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Lexus%20GX%20470%202008.jpg?t=2024-11-21T10%3A12%3A51.280Z",
    },
    {
      CarID: 69,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Lexus%20ES%20250%202019.jpg?t=2024-11-21T10%3A13%3A03.646Z",
    },
    {
      CarID: 70,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Lexus%20ES%20250%202021.jpg",
    },
    {
      CarID: 71,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Lexus%20ES%20300h%202021.jpg?t=2024-11-21T10%3A13%3A32.923Z",
    },
    {
      CarID: 72,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Lexus%20ES%20350%202015.jpg?t=2024-11-21T10%3A13%3A53.363Z",
    },
    {
      CarID: 73,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Porsche%20718%20CaymanT%202022.jpg?t=2024-11-21T10%3A14%3A04.123Z",
    },
    {
      CarID: 74,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Porsche%20Macan%202017.jpg?t=2024-11-21T10%3A14%3A15.481Z",
    },
    {
      CarID: 75,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Porsche%20Panamera%203.0%20V6%202017.jpg?t=2024-11-21T10%3A14%3A28.795Z",
    },
    {
      CarID: 76,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Porsche%20911%20Carrera%20GTS%202022.jpg?t=2024-11-21T10%3A14%3A38.898Z",
    },
    {
      CarID: 77,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Porsche%20Cayenne%20V6%203.0%202019.jpg?t=2024-11-21T10%3A14%3A49.419Z",
    },
    {
      CarID: 78,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Porsche%20Taycan%204S%202021.jpg?t=2024-11-21T10%3A15%3A04.802Z",
    },
    {
      CarID: 79,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Porsche%20Boxster%202009.jpg?t=2024-11-21T10%3A15%3A16.031Z",
    },
    {
      CarID: 80,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/VinFast%20LUX%20A2.0%20Tieu%20chuan%202020.jpg?t=2024-11-21T10%3A15%3A32.063Z",
    },
    {
      CarID: 81,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/VinFast%20LUX%20SA2.0%20Tieu%20chuan%202020.jpg?t=2024-11-21T10%3A15%3A47.363Z",
    },
    {
      CarID: 82,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/VinFast%20Fadil%20Nang%20Cao%202019.jpg?t=2024-11-21T10%3A16%3A00.531Z",
    },
    {
      CarID: 83,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/VinFast%20VF%20e34%202022.jpg?t=2024-11-21T10%3A16%3A14.299Z",
    },
    {
      CarID: 84,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/VinFast%20VF8%20Plus%202022.jpg?t=2024-11-21T10%3A16%3A25.349Z",
    },
    {
      CarID: 85,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/VinFast%20VF9%202023.jpg?t=2024-11-21T10%3A16%3A36.481Z",
    },
    {
      CarID: 86,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/VinFast%20VF%203%202024.jpg?t=2024-11-21T10%3A16%3A48.092Z",
    },
    {
      CarID: 87,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mazda%203%201.5%20Hatchback%202018.jpg?t=2024-11-21T10%3A17%3A00.076Z",
    },
    {
      CarID: 88,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mazda%20CX-5%202.5%202WD%202018.jpg?t=2024-11-21T10%3A17%3A14.360Z",
    },
    {
      CarID: 89,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mazda%206%202.0%20Premium%202020.jpg?t=2024-11-21T10%3A17%3A27.237Z",
    },
    {
      CarID: 90,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mazda%202%201.5AT%202015.jpg?t=2024-11-21T10%3A17%3A38.117Z",
    },
    {
      CarID: 91,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mazda%20BT-50%202015.jpg?t=2024-11-21T10%3A17%3A51.101Z",
    },
    {
      CarID: 92,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mazda%20CX-8%20Premium%202024.jpg?t=2024-11-21T10%3A18%3A01.646Z",
    },
    {
      CarID: 93,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mazda%20CX-3%201.5L%20Deluxe%202022.jpg?t=2024-11-21T10%3A18%3A13.277Z",
    },
    {
      CarID: 94,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mazda%20CX-30%202.0L%20Premium%202022.jpg?t=2024-11-21T10%3A18%3A26.171Z",
    },
    {
      CarID: 95,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Honda%20City%20RS%202021.jpg?t=2024-11-21T10%3A18%3A39.565Z",
    },
    {
      CarID: 96,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Honda%20Civic%201.5%20G%202020.jpg?t=2024-11-21T10%3A18%3A51.127Z",
    },
    {
      CarID: 97,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Honda%20CR-V%202.0%202014.jpg?t=2024-11-21T10%3A19%3A04.061Z",
    },
    {
      CarID: 98,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Honda%20Accord%202008.jpg?t=2024-11-21T10%3A19%3A16.671Z",
    },
    {
      CarID: 99,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Honda%20Brio%20RS%202019.jpg?t=2024-11-21T10%3A19%3A27.836Z",
    },
    {
      CarID: 100,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Honda%20HR-V%20G%202023.jpg?t=2024-11-21T10%3A19%3A38.956Z",
    },
    {
      CarID: 101,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Honda%20Jazz%202019.jpg?t=2024-11-21T10%3A19%3A49.081Z",
    },
    {
      CarID: 102,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Honda%20Odyssey%202.4%20CVT%202016.jpg?t=2024-11-21T10%3A20%3A01.439Z",
    },
    {
      CarID: 103,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Audi%20A4%201.8L%20TFSI%202013.jpg?t=2024-11-21T10%3A20%3A12.843Z",
    },
    {
      CarID: 104,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Audi%20A5%20Sportback%202.0%20TFSI%202013.jpg?t=2024-11-21T10%3A20%3A23.563Z",
    },
    {
      CarID: 105,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Audi%20Q5%2045%20TFSI%20Quattro%202018.jpg",
    },
    {
      CarID: 106,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Audi%20A6%2045%20TFSI%202022.jpg?t=2024-11-21T10%3A20%3A49.480Z",
    },
    {
      CarID: 107,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Audi%20A8%204.2%202011.jpg?t=2024-11-21T10%3A21%3A00.228Z",
    },
    {
      CarID: 108,
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Audi%20Q7%202013.jpg?t=2024-11-21T10%3A21%3A11.005Z",
    },
  ]);

  // Thêm dữ liệu vào bảng Reviews
  await knex("Reviews").insert([
    {
      Title: "Đánh giá Toyota Vios 1.5G AT 2022",
      Advantages: "Thiết kế đẹp, tiết kiệm nhiên liệu, giá bán hợp lý",
      Disadvantages:
        "Không gian nội thất hạn chế, khả năng tăng tốc chưa ấn tượng",
      Content:
        "Toyota Vios 1.5G AT 2022 là một trong những mẫu sedan được ưa chuộng nhất tại Việt Nam nhờ sự bền bỉ, tiết kiệm nhiên liệu và giá trị bán lại cao. Tuy nhiên, mẫu xe này có không gian nội thất khá hạn chế và động cơ không mạnh mẽ.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Toyota%20Vios%201.5G%20AT%202022.jpg",
    },
    {
      Title: "Đánh giá Toyota Innova 2.0V 2019",
      Advantages: "Không gian rộng rãi, vận hành bền bỉ, phù hợp gia đình",
      Disadvantages: "Thiết kế ngoại thất chưa nổi bật, giá bán cao",
      Content:
        "Toyota Innova 2.0V 2019 là mẫu MPV rất được yêu thích tại Việt Nam, nhờ sự rộng rãi và vận hành ổn định. Tuy nhiên, thiết kế ngoại thất của xe không thực sự ấn tượng và giá bán tương đối cao.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Toyota%20Innova%202.0V%202019.jpg",
    },
    {
      Title: "Đánh giá Toyota Fortuner 2015",
      Advantages:
        "Khả năng vận hành mạnh mẽ, thiết kế cứng cáp, phù hợp off-road",
      Disadvantages: "Trang bị nội thất đơn giản, giá bán cao",
      Content:
        "Toyota Fortuner 2015 là mẫu SUV rất phổ biến nhờ khả năng off-road tốt và thiết kế bền bỉ. Tuy nhiên, nội thất đơn giản và mức giá cao khiến mẫu xe này phù hợp hơn với những ai yêu cầu độ bền và tính năng vận hành.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Toyota%20Fortuner%202015.jpg",
    },
    {
      Title: "Đánh giá Toyota Camry 2.5Q 2018",
      Advantages: "Thiết kế sang trọng, vận hành êm ái, trang bị hiện đại",
      Disadvantages: "Giá bán cao, bảo dưỡng tốn kém",
      Content:
        "Toyota Camry 2.5Q 2018 là dòng sedan cao cấp với thiết kế sang trọng, khả năng vận hành êm ái và nội thất tiện nghi. Tuy nhiên, mức giá cao và chi phí bảo dưỡng lớn là những điểm cần cân nhắc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Toyota%20Camry%202.5Q%202018.jpg",
    },
    {
      Title: "Đánh giá Toyota Corolla Altis 1.8 G 2012",
      Advantages: "Độ bền cao, vận hành ổn định, tiết kiệm nhiên liệu",
      Disadvantages: "Thiết kế cũ, trang bị không hiện đại",
      Content:
        "Toyota Corolla Altis 1.8 G 2012 là mẫu xe sedan có độ bền vượt trội, phù hợp với những ai yêu thích sự ổn định và tiết kiệm. Tuy nhiên, thiết kế đã lỗi thời và thiếu nhiều công nghệ hiện đại.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Toyota%20Corolla%20Altis%201.8%20G%202012.jpg",
    },
    {
      Title: "Đánh giá Toyota Corolla Cross 1.8 V 2020",
      Advantages:
        "Thiết kế hiện đại, tiết kiệm nhiên liệu, trang bị an toàn cao",
      Disadvantages: "Không gian nội thất chưa rộng rãi, giá bán cao",
      Content:
        "Toyota Corolla Cross 1.8 V 2020 là một mẫu crossover hiện đại với nhiều công nghệ an toàn và thiết kế hấp dẫn. Tuy nhiên, không gian nội thất hơi hạn chế và giá bán tương đối cao.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Toyota%20Corolla%20Cross%201.8%20V%202020.jpg",
    },
    {
      Title: "Đánh giá Toyota Yaris 1.5G 2017",
      Advantages:
        "Kích thước nhỏ gọn, tiết kiệm nhiên liệu, vận hành linh hoạt",
      Disadvantages: "Thiết kế không nổi bật, trang bị đơn giản",
      Content:
        "Toyota Yaris 1.5G 2017 là một mẫu hatchback nhỏ gọn, phù hợp cho việc di chuyển trong đô thị. Xe có khả năng tiết kiệm nhiên liệu tốt nhưng thiết kế không nổi bật và trang bị còn đơn giản.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Toyota%20Yaris%201.5G%202017.jpg",
    },
    {
      Title: "Đánh giá Toyota Wigo 1.2 G MT 2020",
      Advantages: "Giá bán rẻ, tiết kiệm nhiên liệu, vận hành ổn định",
      Disadvantages: "Khả năng cách âm kém, không gian hạn chế",
      Content:
        "Toyota Wigo 1.2 G MT 2020 là mẫu xe hatchback giá rẻ, phù hợp cho những ai tìm kiếm một chiếc xe tiết kiệm nhiên liệu và vận hành ổn định. Tuy nhiên, xe có khả năng cách âm chưa tốt và không gian nội thất hạn chế.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Toyota%20Wigo%201.2%20G%20MT%202020.jpg",
    },
    {
      Title: "Đánh giá Volkswagen Tiguan 2.0L TSI 2014",
      Advantages:
        "Khả năng vận hành mạnh mẽ, thiết kế sang trọng, trang bị đầy đủ",
      Disadvantages: "Tiêu thụ nhiên liệu cao, giá bán cao",
      Content:
        "Volkswagen Tiguan 2.0L TSI 2014 là một mẫu SUV sang trọng, với khả năng vận hành mạnh mẽ và thiết kế thể thao. Tuy nhiên, mức tiêu thụ nhiên liệu của xe khá cao và giá bán cũng không hề rẻ.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Volkswagen%20Tiguan%202.0L%20TSI%202014.jpg",
    },
    {
      Title: "Đánh giá Volkswagen Polo 1.6AT 2021",
      Advantages: "Tiết kiệm nhiên liệu, thiết kế nhỏ gọn, vận hành ổn định",
      Disadvantages: "Không gian nội thất hạn chế, động cơ không mạnh mẽ",
      Content:
        "Volkswagen Polo 1.6AT 2021 là mẫu xe nhỏ gọn, tiết kiệm nhiên liệu và vận hành ổn định. Tuy nhiên, không gian nội thất hạn chế và động cơ không thật sự mạnh mẽ, không phù hợp với những ai yêu cầu sức mạnh.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Volkswagen%20Polo%201.6AT%202021.jpg",
    },
    {
      Title: "Đánh giá Volkswagen Teramont 2022",
      Advantages: "Không gian rộng rãi, trang bị tiện nghi, vận hành mạnh mẽ",
      Disadvantages: "Kích thước lớn, tiêu thụ nhiên liệu cao",
      Content:
        "Volkswagen Teramont 2022 là mẫu SUV cỡ lớn với không gian rộng rãi, trang bị tiện nghi và khả năng vận hành mạnh mẽ. Tuy nhiên, xe có kích thước lớn, khó khăn trong việc di chuyển ở đô thị và tiêu thụ nhiên liệu tương đối cao.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Volkswagen%20Teramont%202022.jpg",
    },
    {
      Title: "Đánh giá Volkswagen Touareg 2008",
      Advantages: "Khả năng off-road tuyệt vời, thiết kế mạnh mẽ, bền bỉ",
      Disadvantages: "Giá bán cao, tiêu thụ nhiên liệu lớn",
      Content:
        "Volkswagen Touareg 2008 là một chiếc SUV mạnh mẽ, với khả năng off-road ấn tượng và thiết kế cứng cáp. Tuy nhiên, mức giá của xe khá cao và xe tiêu thụ nhiên liệu không ít.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Volkswagen%20Touareg%202008.jpg",
    },
    {
      Title: "Đánh giá Volkswagen T-Cross 2024",
      Advantages: "Thiết kế hiện đại, tiết kiệm nhiên liệu, vận hành linh hoạt",
      Disadvantages:
        "Không gian nội thất chưa rộng rãi, thiếu tính năng cao cấp",
      Content:
        "Volkswagen T-Cross 2024 là mẫu SUV cỡ nhỏ với thiết kế hiện đại, khả năng tiết kiệm nhiên liệu tốt và vận hành linh hoạt. Tuy nhiên, không gian nội thất của xe không quá rộng và thiếu một số tính năng cao cấp.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Volkswagen%20T-Cross%202024.jpg",
    },
    {
      Title: "Đánh giá Volkswagen Beetle 2018",
      Advantages: "Thiết kế độc đáo, cảm giác lái thú vị, vận hành ổn định",
      Disadvantages: "Không gian nội thất hạn chế, giá bán cao",
      Content:
        "Volkswagen Beetle 2018 là mẫu xe có thiết kế đặc trưng và cảm giác lái thú vị. Tuy nhiên, không gian nội thất hạn chế và giá bán tương đối cao so với những mẫu xe khác trong phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Volkswagen%20Beetle%202018.jpg",
    },
    {
      Title: "Đánh giá Ford Ranger Wildtrak 4x4 AT 2023",
      Advantages:
        "Khả năng off-road xuất sắc, thiết kế mạnh mẽ, công nghệ tiên tiến",
      Disadvantages: "Giá bán cao, tiêu thụ nhiên liệu lớn",
      Content:
        "Ford Ranger Wildtrak 4x4 AT 2023 là một mẫu xe bán tải mạnh mẽ với khả năng off-road ấn tượng và thiết kế thể thao, nổi bật với công nghệ tiên tiến. Tuy nhiên, xe có giá bán cao và mức tiêu thụ nhiên liệu tương đối lớn.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Ford%20Ranger%20Wildtrak%204x4%20AT%202023.jpg",
    },
    {
      Title: "Đánh giá Ford Everest Titanium 2.0 AT 4x2 2020",
      Advantages:
        "Không gian rộng rãi, tiện nghi cao cấp, khả năng vận hành mượt mà",
      Disadvantages: "Kích thước lớn, khả năng off-road hạn chế",
      Content:
        "Ford Everest Titanium 2.0 AT 4x2 2020 mang đến không gian rộng rãi và tiện nghi cao cấp. Tuy nhiên, xe có kích thước lớn, điều này có thể gây khó khăn trong việc di chuyển tại các khu vực đô thị, và khả năng off-road không mạnh mẽ như các mẫu xe SUV 4x4.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Ford%20Everest%20Titanium%202.0%20AT%204x2%202020.jpg",
    },
    {
      Title: "Đánh giá Ford EcoSport Ambiente 1.5L MT 2019",
      Advantages:
        "Tiết kiệm nhiên liệu, thiết kế nhỏ gọn, phù hợp di chuyển đô thị",
      Disadvantages: "Không gian nội thất hạn chế, động cơ không mạnh mẽ",
      Content:
        "Ford EcoSport Ambiente 1.5L MT 2019 là một mẫu SUV nhỏ gọn, phù hợp cho các chuyến đi trong đô thị. Tuy nhiên, không gian nội thất của xe khá hạn chế và động cơ không đủ mạnh mẽ đối với những ai muốn một chiếc xe có sức mạnh vượt trội.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Ford%20EcoSport%20Ambiente%201.5L%20MT%202019.jpg",
    },
    {
      Title: "Đánh giá Ford Territory Titanium X 2023",
      Advantages: "Thiết kế hiện đại, tiện nghi cao cấp, vận hành mạnh mẽ",
      Disadvantages: "Giá bán cao, không gian chưa thực sự rộng rãi",
      Content:
        "Ford Territory Titanium X 2023 là một mẫu SUV hiện đại với thiết kế nổi bật và tiện nghi cao cấp. Tuy nhiên, giá bán khá cao và không gian nội thất vẫn chưa thực sự rộng rãi so với các đối thủ trong phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Ford%20Territory%20Titanium%20X%202023.jpg",
    },
    {
      Title: "Đánh giá Ford Explorer 2021",
      Advantages:
        "Không gian rộng rãi, khả năng off-road mạnh mẽ, công nghệ tiên tiến",
      Disadvantages: "Giá bán cao, tiêu thụ nhiên liệu lớn",
      Content:
        "Ford Explorer 2021 là một mẫu SUV cỡ lớn, với không gian rộng rãi và khả năng off-road ấn tượng. Tuy nhiên, xe có giá bán cao và tiêu thụ nhiên liệu lớn, đặc biệt khi di chuyển trong các chuyến đi dài.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Ford%20Explorer%202021.jpg",
    },
    {
      Title: "Đánh giá Ford F-150 Harley Davidson 2019",
      Advantages: "Thiết kế mạnh mẽ, động cơ mạnh mẽ, trang bị đẳng cấp",
      Disadvantages: "Kích thước lớn, tiêu thụ nhiên liệu cao",
      Content:
        "Ford F-150 Harley Davidson 2019 là một mẫu bán tải hạng nặng với động cơ mạnh mẽ và thiết kế ấn tượng. Tuy nhiên, kích thước lớn và mức tiêu thụ nhiên liệu cao có thể làm cho xe không phải là sự lựa chọn tối ưu cho việc di chuyển trong đô thị.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Ford%20F-150%20Harley%20Davidson%202019.jpg",
    },
    {
      Title: "Đánh giá Ford Transit 2013",
      Advantages:
        "Không gian rộng rãi, khả năng vận hành bền bỉ, phù hợp với kinh doanh",
      Disadvantages: "Ngoại thất không nổi bật, tiêu thụ nhiên liệu lớn",
      Content:
        "Ford Transit 2013 là một mẫu xe van rất phù hợp cho mục đích kinh doanh nhờ không gian rộng rãi và khả năng vận hành bền bỉ. Tuy nhiên, ngoại thất của xe không có gì đặc biệt và mức tiêu thụ nhiên liệu khá lớn.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Ford%20Transit%202013.jpg",
    },
    {
      Title: "Đánh giá Ford Focus Titanium 2014",
      Advantages: "Thiết kế hiện đại, vận hành ổn định, tiết kiệm nhiên liệu",
      Disadvantages: "Không gian nội thất hơi chật, động cơ chưa mạnh mẽ",
      Content:
        "Ford Focus Titanium 2014 là một chiếc sedan với thiết kế hiện đại và khả năng vận hành ổn định, tiết kiệm nhiên liệu. Tuy nhiên, không gian nội thất có thể hơi chật đối với những ai cần một chiếc xe rộng rãi hơn.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Ford%20Focus%20Titanium%202014.jpg",
    },
    {
      Title: "Đánh giá Chevrolet Aveo 2018",
      Advantages: "Thiết kế hiện đại, giá bán hợp lý, tiết kiệm nhiên liệu",
      Disadvantages: "Không gian nội thất hạn chế, động cơ không mạnh mẽ",
      Content:
        "Chevrolet Aveo 2018 là một chiếc sedan cỡ nhỏ có thiết kế hiện đại và giá bán hợp lý. Tuy nhiên, không gian nội thất của xe khá hạn chế và động cơ không đủ mạnh mẽ cho những ai muốn một chiếc xe có hiệu suất cao.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Chevrolet%20Aveo%202018.jpg",
    },
    {
      Title: "Đánh giá Chevrolet Camaro RS 2012",
      Advantages:
        "Thiết kế thể thao, động cơ mạnh mẽ, khả năng vận hành ấn tượng",
      Disadvantages: "Giá bán cao, không gian nội thất hạn chế",
      Content:
        "Chevrolet Camaro RS 2012 là một mẫu xe thể thao với động cơ mạnh mẽ và thiết kế nổi bật. Tuy nhiên, xe có giá bán khá cao và không gian nội thất hạn chế, điều này có thể không phù hợp với những ai tìm kiếm sự thoải mái trong một chiếc xe thể thao.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Chevrolet%20Camaro%20RS%202012.jpg",
    },
    {
      Title: "Đánh giá Nissan Navara PRO4X 2022",
      Advantages:
        "Khả năng off-road ấn tượng, thiết kế mạnh mẽ, trang bị cao cấp",
      Disadvantages:
        "Tiêu thụ nhiên liệu cao, không gian nội thất chưa thực sự rộng rãi",
      Content:
        "Nissan Navara PRO4X 2022 là một mẫu xe bán tải mạnh mẽ, thích hợp cho những chuyến đi off-road. Với thiết kế hầm hố và trang bị cao cấp, chiếc xe này vẫn có một nhược điểm là tiêu thụ nhiên liệu khá cao và không gian nội thất không quá rộng rãi.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Nissan%20Navara%20PRO4X%202022.jpg",
    },
    {
      Title: "Đánh giá Nissan Sunny XV Premium 1.5 AT 2018",
      Advantages: "Giá bán hợp lý, tiết kiệm nhiên liệu, không gian rộng rãi",
      Disadvantages:
        "Thiết kế chưa bắt mắt, khả năng vận hành không quá mạnh mẽ",
      Content:
        "Nissan Sunny XV Premium 1.5 AT 2018 là một chiếc sedan với giá bán hợp lý và tiết kiệm nhiên liệu. Mặc dù không có thiết kế quá nổi bật, nhưng xe lại sở hữu không gian rộng rãi và khả năng vận hành ổn định, thích hợp cho nhu cầu di chuyển hàng ngày.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Nissan%20Sunny%20XV%20Premium%201.5%20AT%202018.jpg",
    },
    {
      Title: "Đánh giá Nissan Almera CVT Cao cấp 2021",
      Advantages: "Tiết kiệm nhiên liệu, trang bị hiện đại, giá bán hợp lý",
      Disadvantages:
        "Động cơ không mạnh mẽ, không gian nội thất chưa thực sự sang trọng",
      Content:
        "Nissan Almera CVT Cao cấp 2021 là một mẫu sedan tiết kiệm nhiên liệu với trang bị hiện đại và giá bán hợp lý. Tuy nhiên, động cơ của xe không mạnh mẽ và không gian nội thất chưa thực sự sang trọng như các đối thủ cùng phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Nissan%20Almera%20CVT%20Cao%20cap%202021.jpg",
    },
    {
      Title: "Đánh giá Nissan X trail 2.5 SV 4WD Premium 2019",
      Advantages:
        "Khả năng vận hành mạnh mẽ, trang bị hiện đại, khả năng off-road tốt",
      Disadvantages: "Giá bán cao, không gian hàng ghế sau chưa rộng rãi",
      Content:
        "Nissan X trail 2.5 SV 4WD Premium 2019 là một chiếc SUV với khả năng vận hành mạnh mẽ và trang bị hiện đại. Với khả năng off-road tuyệt vời, xe này lại có một nhược điểm là giá bán khá cao và không gian hàng ghế sau chưa đủ rộng rãi.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Nissan%20X%20trail%202.5%20SV%204WD%20Premium%202019.jpg",
    },
    {
      Title: "Đánh giá Nissan Terra 2018",
      Advantages:
        "Khả năng vận hành mạnh mẽ, không gian rộng rãi, tiện nghi đầy đủ",
      Disadvantages: "Thiết kế chưa thực sự nổi bật, giá bán cao",
      Content:
        "Nissan Terra 2018 là một mẫu SUV với khả năng vận hành mạnh mẽ, không gian rộng rãi và tiện nghi đầy đủ. Tuy nhiên, thiết kế của xe chưa thực sự nổi bật và giá bán có phần cao so với một số đối thủ trong cùng phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Nissan%20Terra%202018.jpg",
    },
    {
      Title: "Đánh giá Nissan Teana SL 2.5 AT 2013",
      Advantages: "Thiết kế sang trọng, trang bị cao cấp, vận hành êm ái",
      Disadvantages: "Tiêu thụ nhiên liệu cao, giá bán cao",
      Content:
        "Nissan Teana SL 2.5 AT 2013 là một mẫu sedan sang trọng với trang bị cao cấp và khả năng vận hành êm ái. Tuy nhiên, xe có nhược điểm là tiêu thụ nhiên liệu khá cao và giá bán cũng khá cao so với các mẫu xe cùng phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Nissan%20Teana%20SL%202.5%20AT%202013.jpg",
    },
    {
      Title: "Đánh giá Hyundai Accent 1.4 AT Đặc biệt 2021",
      Advantages: "Thiết kế trẻ trung, tiết kiệm nhiên liệu, giá bán hợp lý",
      Disadvantages:
        "Không gian nội thất hạn chế, khả năng vận hành chưa mạnh mẽ",
      Content:
        "Hyundai Accent 1.4 AT Đặc biệt 2021 nổi bật với thiết kế trẻ trung, tiết kiệm nhiên liệu và giá bán hợp lý. Tuy nhiên, mẫu xe này có không gian nội thất khá hạn chế và khả năng vận hành chưa thật sự mạnh mẽ.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Hyundai%20Accent%201.4%20AT%20Dac%20biet%202021.jpg",
    },
    {
      Title: "Đánh giá Hyundai Avante 1.6 MT 2011",
      Advantages:
        "Vận hành ổn định, giá bán phải chăng, không gian nội thất vừa đủ",
      Disadvantages: "Thiết kế đã cũ, tính năng tiện nghi không quá nổi bật",
      Content:
        "Hyundai Avante 1.6 MT 2011 là một chiếc sedan với giá bán phải chăng và khả năng vận hành ổn định. Tuy nhiên, thiết kế của xe đã có phần cũ và tính năng tiện nghi không thực sự nổi bật so với các mẫu xe mới.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Hyundai%20Avante%201.6%20MT%202011.jpg",
    },
    {
      Title: "Đánh giá Hyundai Creta 1.5L Đặc biệt 2022",
      Advantages:
        "Thiết kế hiện đại, trang bị tiện nghi đầy đủ, khả năng vận hành mạnh mẽ",
      Disadvantages: "Giá bán khá cao, không gian hàng ghế sau hơi chật",
      Content:
        "Hyundai Creta 1.5L Đặc biệt 2022 là một chiếc SUV hiện đại với trang bị tiện nghi đầy đủ và khả năng vận hành mạnh mẽ. Tuy nhiên, giá bán của xe khá cao và không gian hàng ghế sau hơi chật.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Hyundai%20Creta%201.5L%20Dac%20biet%202022.jpg",
    },
    {
      Title: "Đánh giá Hyundai Elantra 2.0 AT Cao cấp 2020",
      Advantages:
        "Thiết kế sang trọng, trang bị cao cấp, khả năng vận hành êm ái",
      Disadvantages: "Tiêu thụ nhiên liệu cao, giá bán cao",
      Content:
        "Hyundai Elantra 2.0 AT Cao cấp 2020 là một mẫu sedan sang trọng với trang bị cao cấp và khả năng vận hành êm ái. Tuy nhiên, mẫu xe này có nhược điểm là tiêu thụ nhiên liệu cao và giá bán cũng khá cao so với một số đối thủ trong cùng phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Hyundai%20Elantra%202.0%20AT%20Cao%20cap%202020.jpg",
    },
    {
      Title: "Đánh giá Hyundai Getz 1.1 MT 2009",
      Advantages:
        "Giá bán rẻ, tiết kiệm nhiên liệu, phù hợp cho di chuyển trong thành phố",
      Disadvantages: "Không gian nội thất chật, khả năng vận hành chưa mạnh mẽ",
      Content:
        "Hyundai Getz 1.1 MT 2009 là một chiếc hatchback nhỏ gọn với giá bán rẻ và tiết kiệm nhiên liệu. Mặc dù nó phù hợp cho di chuyển trong thành phố, nhưng không gian nội thất khá chật và khả năng vận hành chưa mạnh mẽ.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Hyundai%20Getz%201.1%20MT%202009.jpg",
    },
    {
      Title: "Đánh giá Hyundai Grand i10 Sedan 1.2 MT 2019",
      Advantages: "Thiết kế hiện đại, tiết kiệm nhiên liệu, giá bán hợp lý",
      Disadvantages:
        "Không gian hàng ghế sau không rộng, khả năng vận hành không mạnh mẽ",
      Content:
        "Hyundai Grand i10 Sedan 1.2 MT 2019 là một mẫu sedan nhỏ gọn với thiết kế hiện đại và tiết kiệm nhiên liệu. Tuy nhiên, không gian hàng ghế sau không rộng và khả năng vận hành của xe không thật sự mạnh mẽ.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Hyundai%20Grand%20i10%20Sedan%201.2%20MT%202019.jpg",
    },
    {
      Title: "Đánh giá Hyundai i20 Active 1.4 AT 2015",
      Advantages: "Thiết kế thể thao, vận hành linh hoạt, tiết kiệm nhiên liệu",
      Disadvantages:
        "Không gian nội thất hạn chế, không có nhiều tính năng tiện nghi",
      Content:
        "Hyundai i20 Active 1.4 AT 2015 là một mẫu hatchback thể thao với khả năng vận hành linh hoạt và tiết kiệm nhiên liệu. Tuy nhiên, không gian nội thất của xe hơi hạn chế và xe không có nhiều tính năng tiện nghi so với các mẫu xe mới.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Hyundai%20i20%20Active%201.4%20AT%202015.jpg",
    },
    {
      Title: "Đánh giá Hyundai Kona 2.0 AT Đặc biệt 2020",
      Advantages:
        "Thiết kế hiện đại, trang bị cao cấp, khả năng vận hành mạnh mẽ",
      Disadvantages: "Giá bán khá cao, không gian hàng ghế sau không rộng",
      Content:
        "Hyundai Kona 2.0 AT Đặc biệt 2020 là một chiếc SUV với thiết kế hiện đại, trang bị cao cấp và khả năng vận hành mạnh mẽ. Tuy nhiên, giá bán của xe khá cao và không gian hàng ghế sau không thật sự rộng rãi.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Hyundai%20Kona%202.0%20AT%20Dac%20biet%202020.jpg",
    },
    {
      Title: "Đánh giá Kia Morning Si 1.25 AT 2017",
      Advantages:
        "Thiết kế nhỏ gọn, tiết kiệm nhiên liệu, dễ dàng di chuyển trong thành phố",
      Disadvantages:
        "Không gian nội thất chật, khả năng vận hành không mạnh mẽ",
      Content:
        "Kia Morning Si 1.25 AT 2017 là một chiếc hatchback nhỏ gọn với thiết kế dễ thương và tiết kiệm nhiên liệu. Tuy nhiên, không gian nội thất hơi chật và khả năng vận hành chưa thật sự mạnh mẽ.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Kia%20Morning%20Si%201.25%20AT%202017.jpg",
    },
    {
      Title: "Đánh giá Kia Cerato 1.6 AT Luxury 2021",
      Advantages:
        "Thiết kế sang trọng, trang bị tiện nghi đầy đủ, khả năng vận hành ổn định",
      Disadvantages: "Giá bán cao, không gian hàng ghế sau hơi chật",
      Content:
        "Kia Cerato 1.6 AT Luxury 2021 nổi bật với thiết kế sang trọng và trang bị tiện nghi đầy đủ. Tuy nhiên, giá bán của xe khá cao và không gian hàng ghế sau không rộng rãi.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Kia%20Cerato%201.6%20AT%20Luxury%202021.jpg",
    },
    {
      Title: "Đánh giá Kia Sorento 2.2D Premium AWD 2022",
      Advantages:
        "Thiết kế mạnh mẽ, không gian rộng rãi, khả năng vận hành vượt trội",
      Disadvantages: "Giá bán cao, mức tiêu thụ nhiên liệu lớn",
      Content:
        "Kia Sorento 2.2D Premium AWD 2022 là một mẫu SUV mạnh mẽ với không gian nội thất rộng rãi và khả năng vận hành vượt trội. Tuy nhiên, giá bán của xe khá cao và mức tiêu thụ nhiên liệu cũng không phải là thấp.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Kia%20Sorento%202.2D%20Premium%20AWD%202022.jpg",
    },
    {
      Title: "Đánh giá Kia K3 1.6 Premium 2022",
      Advantages:
        "Thiết kế trẻ trung, khả năng vận hành êm ái, trang bị tiện nghi đầy đủ",
      Disadvantages: "Giá bán cao, không gian nội thất chưa rộng rãi",
      Content:
        "Kia K3 1.6 Premium 2022 mang đến một thiết kế trẻ trung và khả năng vận hành êm ái. Mẫu xe này có trang bị tiện nghi đầy đủ nhưng giá bán lại cao và không gian nội thất chưa thật sự rộng rãi.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Kia%20K3%201.6%20Premium%202022.jpg",
    },
    {
      Title: "Đánh giá Kia Sedona 2.2 DATH 2018",
      Advantages: "Không gian rộng rãi, tiện nghi cao cấp, vận hành mạnh mẽ",
      Disadvantages: "Khó di chuyển trong thành phố, tiêu thụ nhiên liệu cao",
      Content:
        "Kia Sedona 2.2 DATH 2018 là một mẫu MPV với không gian rộng rãi và tiện nghi cao cấp. Tuy nhiên, mẫu xe này có nhược điểm là khó di chuyển trong thành phố và mức tiêu thụ nhiên liệu khá cao.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Kia%20Sedona%202.2%20DATH%202018.jpg",
    },
    {
      Title: "Đánh giá Kia Seltos 1.4 Premium 2022",
      Advantages:
        "Thiết kế hiện đại, trang bị cao cấp, khả năng vận hành ổn định",
      Disadvantages: "Giá bán khá cao, không gian hàng ghế sau hơi chật",
      Content:
        "Kia Seltos 1.4 Premium 2022 là một chiếc SUV với thiết kế hiện đại và trang bị cao cấp. Tuy nhiên, giá bán của xe khá cao và không gian hàng ghế sau không thật sự rộng rãi.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Kia%20Seltos%201.4%20Premium%202022.jpg",
    },
    {
      Title: "Đánh giá Kia Carnival 2.2D Signature 2022",
      Advantages: "Không gian rộng rãi, tiện nghi cao cấp, vận hành êm ái",
      Disadvantages:
        "Giá bán cao, kích thước lớn gây khó khăn trong việc di chuyển",
      Content:
        "Kia Carnival 2.2D Signature 2022 là một mẫu MPV cao cấp với không gian rộng rãi và tiện nghi cao cấp. Tuy nhiên, kích thước lớn của xe có thể gây khó khăn trong việc di chuyển, đặc biệt là trong khu vực thành phố.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Kia%20Carnival%202.2D%20Signature%202022.jpg",
    },
    {
      Title: "Đánh giá Kia Soluto MT Deluxe 2021",
      Advantages:
        "Giá bán hợp lý, tiết kiệm nhiên liệu, dễ dàng di chuyển trong thành phố",
      Disadvantages:
        "Không gian nội thất không rộng rãi, khả năng vận hành chưa mạnh mẽ",
      Content:
        "Kia Soluto MT Deluxe 2021 là một mẫu sedan nhỏ gọn với giá bán hợp lý và khả năng tiết kiệm nhiên liệu. Tuy nhiên, không gian nội thất của xe không thật sự rộng rãi và khả năng vận hành cũng chưa mạnh mẽ.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Kia%20Soluto%20MT%20Deluxe%202021.jpg",
    },
    {
      Title: "Đánh giá Subaru BRZ 2023",
      Advantages:
        "Thiết kế thể thao, khả năng vận hành mạnh mẽ, cảm giác lái tuyệt vời",
      Disadvantages: "Không gian nội thất hạn chế, giá bán cao",
      Content:
        "Subaru BRZ 2023 là một mẫu xe thể thao mạnh mẽ với khả năng vận hành tuyệt vời. Tuy nhiên, không gian nội thất khá hạn chế và giá bán cũng khá cao so với các đối thủ cùng phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Subaru%20BRZ%202023.jpg",
    },
    {
      Title: "Đánh giá Subaru Forester 2.0i-S EyeSight 2021",
      Advantages:
        "Khả năng vận hành ổn định, công nghệ an toàn EyeSight, không gian rộng rãi",
      Disadvantages: "Mức tiêu thụ nhiên liệu tương đối cao, giá bán khá cao",
      Content:
        "Subaru Forester 2.0i-S EyeSight 2021 mang đến khả năng vận hành ổn định, công nghệ an toàn EyeSight và không gian nội thất rộng rãi. Tuy nhiên, mức tiêu thụ nhiên liệu khá cao và giá bán của xe cũng tương đối đắt.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Subaru%20Forester%202.0i-S%20EyeSight%202021.jpg",
    },
    {
      Title: "Đánh giá Subaru Outback 2016",
      Advantages:
        "Không gian rộng rãi, khả năng vận hành ổn định, hệ thống dẫn động 4 bánh toàn thời gian",
      Disadvantages:
        "Thiết kế chưa thật sự nổi bật, không gian hành lý hạn chế",
      Content:
        "Subaru Outback 2016 là một chiếc SUV với không gian nội thất rộng rãi và khả năng vận hành ổn định. Xe được trang bị hệ thống dẫn động 4 bánh toàn thời gian, tuy nhiên thiết kế của xe không thật sự nổi bật và không gian hành lý có phần hạn chế.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Subaru%20Outback%202016.jpg",
    },
    {
      Title: "Đánh giá Mercedes-Benz C200 Exclusive 2021",
      Advantages:
        "Thiết kế sang trọng, khả năng vận hành êm ái, công nghệ tiên tiến",
      Disadvantages: "Không gian nội thất khá chật, giá bán cao",
      Content:
        "Mercedes-Benz C200 Exclusive 2021 mang đến một thiết kế sang trọng và khả năng vận hành êm ái. Tuy nhiên, không gian nội thất hơi hạn chế và giá bán khá cao so với các đối thủ trong phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mercedes-Benz%20C200%20Exclusive%202021.jpg",
    },
    {
      Title: "Đánh giá Mercedes-Benz E250 E250 2018",
      Advantages:
        "Khả năng vận hành mạnh mẽ, không gian rộng rãi, thiết kế thanh lịch",
      Disadvantages: "Tiêu thụ nhiên liệu cao, giá bán khá đắt",
      Content:
        "Mercedes-Benz E250 2018 nổi bật với khả năng vận hành mạnh mẽ và không gian rộng rãi, cùng thiết kế thanh lịch đặc trưng của thương hiệu. Tuy nhiên, mức tiêu thụ nhiên liệu của xe khá cao và giá bán của nó cũng khá đắt.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mercedes-Benz%20E250%20E250%202018.jpg",
    },
    {
      Title: "Đánh giá Mercedes-Benz S450L 4Matic 2019",
      Advantages:
        "Tiện nghi cao cấp, khả năng vận hành vượt trội, hệ thống an toàn tiên tiến",
      Disadvantages: "Kích thước lớn, giá bán rất cao",
      Content:
        "Mercedes-Benz S450L 4Matic 2019 mang lại sự thoải mái tuyệt đối với các tiện nghi cao cấp và khả năng vận hành vượt trội. Hệ thống an toàn của xe cũng rất tiên tiến, nhưng với kích thước lớn và giá bán rất cao, xe chỉ phù hợp với những khách hàng đẳng cấp.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mercedes-Benz%20S450L%204Matic%202019.jpg",
    },
    {
      Title: "Đánh giá Mercedes-Benz V250 2018",
      Advantages: "Không gian rộng rãi, tiện nghi cao cấp, động cơ mạnh mẽ",
      Disadvantages: "Khả năng tiết kiệm nhiên liệu chưa tốt, giá cao",
      Content:
        "Mercedes-Benz V250 2018 là lựa chọn tuyệt vời cho những ai cần một chiếc MPV với không gian rộng rãi và tiện nghi cao cấp. Tuy nhiên, khả năng tiết kiệm nhiên liệu chưa thực sự ấn tượng và giá bán khá cao.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mercedes-Benz%20V250%202018.jpg",
    },
    {
      Title: "Đánh giá Mercedes-Benz GLA 45 2015",
      Advantages:
        "Thiết kế thể thao, khả năng vận hành mạnh mẽ, trang bị đầy đủ",
      Disadvantages: "Không gian nội thất hạn chế, giá cao",
      Content:
        "Mercedes-Benz GLA 45 2015 mang đến một thiết kế thể thao và khả năng vận hành mạnh mẽ. Tuy nhiên, không gian nội thất của xe khá hạn chế và giá bán của nó cũng khá cao trong phân khúc SUV hạng sang.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mercedes-Benz%20GLA%2045%202015.jpg",
    },
    {
      Title: "Đánh giá Mercedes-Benz GLB 35 2022",
      Advantages:
        "Thiết kế hiện đại, không gian rộng rãi, khả năng vận hành mạnh mẽ",
      Disadvantages: "Giá bán cao, mức tiêu thụ nhiên liệu lớn",
      Content:
        "Mercedes-Benz GLB 35 2022 nổi bật với thiết kế hiện đại và không gian rộng rãi. Xe có khả năng vận hành mạnh mẽ và các trang bị cao cấp, tuy nhiên mức tiêu thụ nhiên liệu khá lớn và giá bán cũng không hề rẻ.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mercedes-Benz%20GLB%2035%202022.jpg",
    },
    {
      Title: "Đánh giá Mercedes-Benz GLC 300 4Matic 2022",
      Advantages:
        "Khả năng vận hành ổn định, công nghệ hiện đại, không gian thoải mái",
      Disadvantages: "Giá bán khá cao, nội thất không có nhiều điểm mới",
      Content:
        "Mercedes-Benz GLC 300 4Matic 2022 là một chiếc SUV sang trọng với khả năng vận hành ổn định, công nghệ hiện đại và không gian thoải mái. Tuy nhiên, giá bán của xe khá cao và nội thất không có nhiều cải tiến đáng chú ý.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mercedes-Benz%20GLC%20300%204Matic%202022.jpg",
    },
    {
      Title: "Đánh giá Mercedes-Benz GLE 450 4Matic 2021",
      Advantages:
        "Tiện nghi sang trọng, khả năng vận hành mạnh mẽ, hệ thống an toàn tốt",
      Disadvantages: "Kích thước lớn, mức tiêu thụ nhiên liệu cao",
      Content:
        "Mercedes-Benz GLE 450 4Matic 2021 mang lại trải nghiệm lái tuyệt vời với hệ thống an toàn hiện đại, tiện nghi sang trọng và khả năng vận hành mạnh mẽ. Tuy nhiên, với kích thước lớn và mức tiêu thụ nhiên liệu cao, xe có thể không phù hợp với mọi khách hàng.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mercedes-Benz%20GLE%20450%204Matic%202021.jpg",
    },
    {
      Title: "Đánh giá BMW 320i 2015",
      Advantages:
        "Thiết kế thể thao, khả năng vận hành mượt mà, tiết kiệm nhiên liệu",
      Disadvantages: "Không gian nội thất hơi chật, giá khá cao",
      Content:
        "BMW 320i 2015 mang đến một thiết kế thể thao, khả năng vận hành mượt mà và tiết kiệm nhiên liệu. Tuy nhiên, không gian nội thất hơi chật và giá bán của xe khá cao so với các đối thủ cùng phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/BMW%20320i%202015.jpg",
    },
    {
      Title: "Đánh giá BMW 420i 2018",
      Advantages:
        "Thiết kế sang trọng, khả năng vận hành mạnh mẽ, cảm giác lái tuyệt vời",
      Disadvantages: "Không gian trong xe không rộng rãi, giá cao",
      Content:
        "BMW 420i 2018 nổi bật với thiết kế sang trọng và khả năng vận hành mạnh mẽ. Cảm giác lái của xe rất tuyệt vời, nhưng không gian trong xe không quá rộng rãi và giá của nó khá cao.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/BMW%20420i%202018.jpg",
    },
    {
      Title: "Đánh giá BMW 520i 2018",
      Advantages:
        "Thiết kế lịch lãm, khả năng vận hành tuyệt vời, nội thất sang trọng",
      Disadvantages: "Giá khá cao, không gian khoang hành lý hạn chế",
      Content:
        "BMW 520i 2018 là một chiếc sedan sang trọng với thiết kế lịch lãm và khả năng vận hành tuyệt vời. Nội thất sang trọng và các tính năng cao cấp mang đến trải nghiệm tuyệt vời, nhưng giá bán khá cao và không gian khoang hành lý hơi hạn chế.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/BMW%20520i%202018.jpg",
    },
    {
      Title: "Đánh giá BMW 740Li Pure Excellence 2018",
      Advantages:
        "Tiện nghi đẳng cấp, khả năng vận hành mượt mà, hệ thống an toàn tiên tiến",
      Disadvantages: "Giá rất cao, chi phí bảo dưỡng đắt",
      Content:
        "BMW 740Li Pure Excellence 2018 mang đến tiện nghi đẳng cấp và khả năng vận hành mượt mà. Hệ thống an toàn tiên tiến giúp xe trở nên an toàn hơn, nhưng giá bán rất cao và chi phí bảo dưỡng cũng không hề rẻ.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/BMW%20740Li%20Pure%20Excellence%202018.jpg",
    },
    {
      Title: "Đánh giá BMW X3 xDrive20i 2021",
      Advantages:
        "Thiết kế thể thao, khả năng vận hành mạnh mẽ, công nghệ tiên tiến",
      Disadvantages: "Giá bán khá cao, không gian nội thất nhỏ",
      Content:
        "BMW X3 xDrive20i 2021 là một chiếc SUV thể thao với khả năng vận hành mạnh mẽ và công nghệ tiên tiến. Tuy nhiên, giá bán của xe khá cao và không gian nội thất hơi nhỏ đối với một chiếc SUV.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/BMW%20X3%20xDrive20i%202021.jpg",
    },
    {
      Title: "Đánh giá BMW X5 xDrive40i 2022",
      Advantages:
        "Khả năng vận hành ấn tượng, thiết kế sang trọng, không gian rộng rãi",
      Disadvantages: "Giá cao, mức tiêu thụ nhiên liệu lớn",
      Content:
        "BMW X5 xDrive40i 2022 là một chiếc SUV sang trọng với khả năng vận hành ấn tượng. Xe có không gian rộng rãi và các trang bị cao cấp, tuy nhiên giá bán khá cao và mức tiêu thụ nhiên liệu cũng lớn.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/BMW%20X5%20xDrive40i%202022.jpg",
    },
    {
      Title: "Đánh giá BMW X7 xDrive40i 2020",
      Advantages:
        "Tiện nghi cao cấp, khả năng vận hành mạnh mẽ, không gian rộng rãi",
      Disadvantages: "Giá bán rất cao, khó di chuyển trong thành phố",
      Content:
        "BMW X7 xDrive40i 2020 mang đến tiện nghi cao cấp, khả năng vận hành mạnh mẽ và không gian rộng rãi. Tuy nhiên, với kích thước lớn và giá bán rất cao, xe có thể không phù hợp cho những người sử dụng trong thành phố.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/BMW%20X7%20xDrive40i%202020.jpg",
    },
    {
      Title: "Đánh giá BMW X6 xDrive40i Msport 2022",
      Advantages:
        "Thiết kế thể thao, khả năng vận hành mạnh mẽ, trang bị cao cấp",
      Disadvantages:
        "Tiêu thụ nhiên liệu khá cao, không gian hàng ghế sau hơi hạn chế",
      Content:
        "BMW X6 xDrive40i Msport 2022 nổi bật với thiết kế thể thao và khả năng vận hành mạnh mẽ. Xe được trang bị nhiều tính năng cao cấp, nhưng mức tiêu thụ nhiên liệu khá cao và không gian hàng ghế sau hơi hạn chế.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/BMW%20X6%20xDrive40i%20Msport%202022.jpg",
    },
    {
      Title: "Đánh giá Lexus RX 300 2020",
      Advantages:
        "Thiết kế sang trọng, khả năng vận hành mạnh mẽ, không gian nội thất rộng rãi",
      Disadvantages: "Giá cao, mức tiêu thụ nhiên liệu lớn",
      Content:
        "Lexus RX 300 2020 mang đến một thiết kế sang trọng, khả năng vận hành mạnh mẽ và không gian nội thất rộng rãi. Tuy nhiên, giá bán cao và mức tiêu thụ nhiên liệu cũng là điểm cần lưu ý.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Lexus%20RX%20300%202020.jpg",
    },
    {
      Title: "Đánh giá Lexus LX 570 2016",
      Advantages:
        "Khả năng off-road tuyệt vời, nội thất sang trọng, sức mạnh động cơ mạnh mẽ",
      Disadvantages: "Kích thước lớn, tiêu thụ nhiên liệu cao",
      Content:
        "Lexus LX 570 2016 là một chiếc SUV cao cấp với khả năng off-road tuyệt vời, nội thất sang trọng và động cơ mạnh mẽ. Tuy nhiên, với kích thước lớn và mức tiêu thụ nhiên liệu cao, xe có thể không phù hợp với những người sử dụng trong thành phố.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Lexus%20LX%20570%202016.jpg",
    },
    {
      Title: "Đánh giá Lexus GX 470 2008",
      Advantages:
        "Khả năng off-road xuất sắc, nội thất bền bỉ, động cơ mạnh mẽ",
      Disadvantages:
        "Kích thước lớn, tiêu thụ nhiên liệu cao, công nghệ lạc hậu",
      Content:
        "Lexus GX 470 2008 nổi bật với khả năng off-road xuất sắc, nội thất bền bỉ và động cơ mạnh mẽ. Tuy nhiên, kích thước lớn và tiêu thụ nhiên liệu cao cùng công nghệ lạc hậu khiến chiếc xe này không còn phù hợp với xu hướng hiện đại.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Lexus%20GX%20470%202008.jpg",
    },
    {
      Title: "Đánh giá Lexus ES 250 2019",
      Advantages:
        "Thiết kế thanh lịch, không gian nội thất rộng rãi, khả năng vận hành mượt mà",
      Disadvantages: "Khả năng tăng tốc không mạnh mẽ, giá cao",
      Content:
        "Lexus ES 250 2019 mang đến một thiết kế thanh lịch và không gian nội thất rộng rãi, cùng khả năng vận hành mượt mà. Tuy nhiên, khả năng tăng tốc không quá mạnh mẽ và giá bán cao có thể là yếu tố cần cân nhắc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Lexus%20ES%20250%202019.jpg",
    },
    {
      Title: "Đánh giá Lexus ES 250 2021",
      Advantages: "Thiết kế hiện đại, tính năng cao cấp, vận hành êm ái",
      Disadvantages: "Giá cao, không gian hàng ghế sau hạn chế",
      Content:
        "Lexus ES 250 2021 mang đến thiết kế hiện đại và các tính năng cao cấp. Xe vận hành êm ái và mang lại sự thoải mái cho người lái, tuy nhiên giá bán khá cao và không gian hàng ghế sau có phần hạn chế.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Lexus%20ES%20250%202021.jpg",
    },
    {
      Title: "Đánh giá Lexus ES 300h 2021",
      Advantages: "Tiết kiệm nhiên liệu, thiết kế sang trọng, vận hành mượt mà",
      Disadvantages: "Giá cao, không gian khoang hành lý hạn chế",
      Content:
        "Lexus ES 300h 2021 là mẫu xe hybrid với khả năng tiết kiệm nhiên liệu vượt trội. Thiết kế sang trọng và vận hành mượt mà giúp chiếc xe này nổi bật trong phân khúc, nhưng giá bán khá cao và không gian khoang hành lý hơi hạn chế.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Lexus%20ES%20300h%202021.jpg",
    },
    {
      Title: "Đánh giá Lexus ES 350 2015",
      Advantages:
        "Nội thất sang trọng, khả năng vận hành mạnh mẽ, công nghệ cao cấp",
      Disadvantages: "Giá khá cao, khả năng tiết kiệm nhiên liệu chưa ấn tượng",
      Content:
        "Lexus ES 350 2015 mang đến nội thất sang trọng, khả năng vận hành mạnh mẽ và các công nghệ tiên tiến. Tuy nhiên, giá bán khá cao và khả năng tiết kiệm nhiên liệu chưa thực sự ấn tượng.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Lexus%20ES%20350%202015.jpg",
    },
    {
      Title: "Đánh giá Porsche 718 CaymanT 2022",
      Advantages:
        "Thiết kế thể thao, vận hành tuyệt vời, cảm giác lái chính xác",
      Disadvantages: "Giá cao, không gian trong xe hạn chế",
      Content:
        "Porsche 718 CaymanT 2022 mang đến thiết kế thể thao với động cơ mạnh mẽ, cảm giác lái chính xác và tinh tế. Tuy nhiên, giá bán cao và không gian trong xe khá hạn chế, có thể không phù hợp với những ai cần không gian rộng rãi.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Porsche%20718%20CaymanT%202022.jpg",
    },
    {
      Title: "Đánh giá Porsche Macan 2017",
      Advantages: "Vận hành mạnh mẽ, thiết kế đẹp, nội thất sang trọng",
      Disadvantages: "Tiêu thụ nhiên liệu cao, giá bán đắt đỏ",
      Content:
        "Porsche Macan 2017 mang đến một cảm giác lái mạnh mẽ và linh hoạt, thiết kế đẹp mắt và nội thất sang trọng. Tuy nhiên, mức tiêu thụ nhiên liệu khá cao và giá bán của xe cũng không hề rẻ.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Porsche%20Macan%202017.jpg",
    },
    {
      Title: "Đánh giá Porsche Panamera 3.0 V6 2017",
      Advantages:
        "Khả năng vận hành tuyệt vời, không gian nội thất rộng rãi, công nghệ cao cấp",
      Disadvantages:
        "Giá rất cao, không phù hợp với những ai cần tiết kiệm nhiên liệu",
      Content:
        "Porsche Panamera 3.0 V6 2017 là mẫu xe sedan thể thao mang lại khả năng vận hành tuyệt vời, không gian nội thất rộng rãi và các tính năng công nghệ cao cấp. Tuy nhiên, mức giá của xe rất cao và khả năng tiết kiệm nhiên liệu không ấn tượng.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Porsche%20Panamera%203.0%20V6%202017.jpg",
    },
    {
      Title: "Đánh giá Porsche 911 Carrera GTS 2022",
      Advantages:
        "Thiết kế biểu tượng, hiệu suất mạnh mẽ, cảm giác lái đỉnh cao",
      Disadvantages: "Giá quá cao, không gian trong xe hạn chế",
      Content:
        "Porsche 911 Carrera GTS 2022 là một trong những chiếc xe thể thao đỉnh cao với thiết kế biểu tượng và hiệu suất mạnh mẽ. Cảm giác lái tuyệt vời khiến chiếc xe này trở thành một lựa chọn lý tưởng cho những tín đồ yêu thích tốc độ. Tuy nhiên, mức giá cao và không gian trong xe khá hạn chế là điểm cần lưu ý.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Porsche%20911%20Carrera%20GTS%202022.jpg",
    },
    {
      Title: "Đánh giá Porsche Cayenne V6 3.0 2019",
      Advantages:
        "Khả năng vận hành mạnh mẽ, công nghệ tiên tiến, nội thất cao cấp",
      Disadvantages: "Giá đắt đỏ, tiêu thụ nhiên liệu cao",
      Content:
        "Porsche Cayenne V6 3.0 2019 là một chiếc SUV sang trọng với khả năng vận hành mạnh mẽ, công nghệ tiên tiến và nội thất cao cấp. Tuy nhiên, giá bán của xe khá cao và mức tiêu thụ nhiên liệu không thực sự tiết kiệm.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Porsche%20Cayenne%20V6%203.0%202019.jpg",
    },
    {
      Title: "Đánh giá Porsche Taycan 4S 2021",
      Advantages: "Hiệu suất vượt trội, công nghệ tiên tiến, vận hành êm ái",
      Disadvantages:
        "Giá bán cực kỳ cao, khả năng di chuyển bị hạn chế bởi phạm vi pin",
      Content:
        "Porsche Taycan 4S 2021 là mẫu xe điện thể thao với hiệu suất vượt trội, công nghệ tiên tiến và khả năng vận hành êm ái. Tuy nhiên, giá bán rất cao và phạm vi di chuyển của xe còn hạn chế so với các mẫu xe điện khác.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Porsche%20Taycan%204S%202021.jpg",
    },
    {
      Title: "Đánh giá Porsche Boxster 2009",
      Advantages: "Thiết kế thể thao, cảm giác lái tuyệt vời, động cơ mạnh mẽ",
      Disadvantages: "Không gian trong xe hạn chế, giá khá cao",
      Content:
        "Porsche Boxster 2009 mang đến thiết kế thể thao và cảm giác lái tuyệt vời. Động cơ mạnh mẽ và khả năng vận hành linh hoạt là những điểm nổi bật của mẫu xe này. Tuy nhiên, không gian trong xe khá hạn chế và giá bán cũng không hề rẻ.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Porsche%20Boxster%202009.jpg",
    },
    {
      Title: "Đánh giá VinFast LUX A2.0 Tiêu chuẩn 2020",
      Advantages: "Thiết kế sang trọng, vận hành mạnh mẽ, cảm giác lái êm ái",
      Disadvantages: "Mức tiêu thụ nhiên liệu khá cao, giá bán cao",
      Content:
        "VinFast LUX A2.0 Tiêu chuẩn 2020 là một chiếc sedan sang trọng với động cơ mạnh mẽ và thiết kế đẳng cấp. Cảm giác lái êm ái cùng với trang bị tiện nghi hiện đại giúp xe trở thành một lựa chọn hấp dẫn. Tuy nhiên, mức tiêu thụ nhiên liệu có phần cao và giá bán khá đắt đỏ.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/VinFast%20LUX%20A2.0%20Tieu%20chuan%202020.jpg",
    },
    {
      Title: "Đánh giá VinFast LUX SA2.0 Tiêu chuẩn 2020",
      Advantages: "Thiết kế thể thao, công nghệ tiên tiến, không gian rộng rãi",
      Disadvantages: "Giá bán cao, tiêu thụ nhiên liệu lớn",
      Content:
        "VinFast LUX SA2.0 Tiêu chuẩn 2020 là một chiếc SUV sang trọng với thiết kế thể thao, không gian nội thất rộng rãi và công nghệ tiên tiến. Tuy nhiên, giá bán của xe cao và mức tiêu thụ nhiên liệu cũng không phải là điểm mạnh của chiếc xe này.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/VinFast%20LUX%20SA2.0%20Tieu%20chuan%202020.jpg",
    },
    {
      Title: "Đánh giá VinFast Fadil Nâng Cao 2019",
      Advantages:
        "Tiết kiệm nhiên liệu, giá bán hợp lý, dễ dàng di chuyển trong thành phố",
      Disadvantages: "Không gian nội thất hạn chế, tính năng không quá nổi bật",
      Content:
        "VinFast Fadil Nâng Cao 2019 là một chiếc xe đô thị với mức tiêu thụ nhiên liệu thấp và giá bán hợp lý. Xe dễ dàng di chuyển trong thành phố và phù hợp với những người tìm kiếm một phương tiện nhỏ gọn. Tuy nhiên, không gian nội thất khá hạn chế và tính năng không quá nổi bật.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/VinFast%20Fadil%20Nang%20Cao%202019.jpg",
    },
    {
      Title: "Đánh giá VinFast VF e34 2022",
      Advantages:
        "Xe điện tiết kiệm nhiên liệu, công nghệ tiên tiến, không gian rộng rãi",
      Disadvantages: "Giá bán cao, phạm vi di chuyển còn hạn chế",
      Content:
        "VinFast VF e34 2022 là một chiếc xe điện với khả năng tiết kiệm nhiên liệu vượt trội và công nghệ tiên tiến. Không gian nội thất rộng rãi và các tính năng hiện đại là điểm mạnh của xe. Tuy nhiên, giá bán của xe còn khá cao và phạm vi di chuyển còn hạn chế đối với những ai cần di chuyển quãng đường dài.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/VinFast%20VF%20e34%202022.jpg",
    },
    {
      Title: "Đánh giá VinFast VF8 Plus 2022",
      Advantages: "Thiết kế sang trọng, vận hành mạnh mẽ, công nghệ hiện đại",
      Disadvantages: "Giá bán cao, không gian khoang hành lý hạn chế",
      Content:
        "VinFast VF8 Plus 2022 là mẫu SUV điện mang đến thiết kế sang trọng, khả năng vận hành mạnh mẽ và công nghệ hiện đại. Xe được trang bị nhiều tính năng tiện nghi, nhưng giá bán khá cao và không gian khoang hành lý hạn chế.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/VinFast%20VF8%20Plus%202022.jpg",
    },
    {
      Title: "Đánh giá VinFast VF9 2023",
      Advantages:
        "Thiết kế mạnh mẽ, không gian rộng rãi, tính năng công nghệ cao",
      Disadvantages: "Giá khá cao, tiêu thụ năng lượng lớn",
      Content:
        "VinFast VF9 2023 là một chiếc SUV điện với thiết kế mạnh mẽ và không gian nội thất rộng rãi, có thể chứa nhiều hành khách và đồ đạc. Xe cũng được trang bị nhiều tính năng công nghệ cao, nhưng giá bán cao và mức tiêu thụ năng lượng không phải là điểm mạnh.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/VinFast%20VF9%202023.jpg",
    },
    {
      Title: "Đánh giá VinFast VF 3 2024",
      Advantages: "Tiết kiệm năng lượng, thiết kế hiện đại, giá bán hợp lý",
      Disadvantages: "Phạm vi di chuyển hạn chế, không gian nội thất nhỏ",
      Content:
        "VinFast VF 3 2024 là mẫu xe điện mới của VinFast với thiết kế hiện đại và tiết kiệm năng lượng. Tuy nhiên, phạm vi di chuyển của xe còn hạn chế và không gian nội thất khá nhỏ, phù hợp với những ai tìm kiếm một chiếc xe nhỏ gọn và tiết kiệm.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/VinFast%20VF%203%202024.jpg",
    },
    {
      Title: "Đánh giá Mazda 3 1.5 Hatchback 2018",
      Advantages: "Thiết kế thể thao, vận hành ổn định, cảm giác lái tốt",
      Disadvantages:
        "Không gian nội thất hơi chật, mức giá cao so với các đối thủ",
      Content:
        "Mazda 3 1.5 Hatchback 2018 mang đến một thiết kế thể thao cuốn hút cùng khả năng vận hành ổn định và cảm giác lái tuyệt vời. Tuy nhiên, không gian nội thất hơi chật và giá bán cao hơn so với một số đối thủ cùng phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mazda%203%201.5%20Hatchback%202018.jpg",
    },
    {
      Title: "Đánh giá Mazda CX-5 2.5 2WD 2018",
      Advantages: "Thiết kế đẹp, nội thất sang trọng, hệ thống giải trí tốt",
      Disadvantages: "Tiêu thụ nhiên liệu khá cao, giá bán đắt",
      Content:
        "Mazda CX-5 2.5 2WD 2018 là một mẫu crossover với thiết kế đẹp và nội thất sang trọng. Xe được trang bị hệ thống giải trí hiện đại, tuy nhiên mức tiêu thụ nhiên liệu khá cao và giá bán cũng đắt hơn so với một số đối thủ.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mazda%20CX-5%202.5%202WD%202018.jpg",
    },
    {
      Title: "Đánh giá Mazda 6 2.0 Premium 2020",
      Advantages:
        "Thiết kế sang trọng, khả năng vận hành mượt mà, nội thất tiện nghi",
      Disadvantages: "Không gian phía sau hơi chật, giá bán khá cao",
      Content:
        "Mazda 6 2.0 Premium 2020 là một chiếc sedan sang trọng với khả năng vận hành mượt mà và nội thất tiện nghi. Tuy nhiên, không gian ở hàng ghế sau hơi chật và giá bán cũng cao so với các đối thủ trong cùng phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mazda%206%202.0%20Premium%202020.jpg",
    },
    {
      Title: "Đánh giá Mazda 2 1.5AT 2015",
      Advantages:
        "Tiết kiệm nhiên liệu, dễ dàng di chuyển trong thành phố, giá bán hợp lý",
      Disadvantages:
        "Không gian nội thất hạn chế, cảm giác lái chưa thật sự ấn tượng",
      Content:
        "Mazda 2 1.5AT 2015 là một chiếc xe nhỏ gọn với mức tiêu thụ nhiên liệu thấp và giá bán hợp lý. Xe rất phù hợp cho việc di chuyển trong thành phố, nhưng không gian nội thất hạn chế và cảm giác lái chưa thật sự ấn tượng.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mazda%202%201.5AT%202015.jpg",
    },
    {
      Title: "Đánh giá Mazda BT-50 2015",
      Advantages:
        "Động cơ mạnh mẽ, khả năng vận hành vượt trội, không gian chứa đồ rộng rãi",
      Disadvantages:
        "Khả năng tiêu thụ nhiên liệu cao, không gian nội thất không thoải mái",
      Content:
        "Mazda BT-50 2015 là một chiếc bán tải mạnh mẽ với khả năng vận hành vượt trội và không gian chứa đồ rộng rãi. Tuy nhiên, khả năng tiêu thụ nhiên liệu khá cao và không gian nội thất không được thoải mái cho những chuyến đi dài.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mazda%20BT-50%202015.jpg",
    },
    {
      Title: "Đánh giá Mazda CX-8 Premium 2024",
      Advantages:
        "Thiết kế hiện đại, không gian nội thất rộng rãi, công nghệ tiên tiến",
      Disadvantages: "Giá bán cao, khả năng tiết kiệm nhiên liệu chưa tối ưu",
      Content:
        "Mazda CX-8 Premium 2024 là một mẫu SUV 7 chỗ với thiết kế hiện đại và không gian nội thất rộng rãi. Xe được trang bị nhiều công nghệ tiên tiến, nhưng giá bán khá cao và khả năng tiết kiệm nhiên liệu chưa tối ưu.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mazda%20CX-8%20Premium%202024.jpg",
    },
    {
      Title: "Đánh giá Mazda CX-3 1.5L Deluxe 2022",
      Advantages:
        "Thiết kế nhỏ gọn, tiết kiệm nhiên liệu, tính năng an toàn cao",
      Disadvantages:
        "Không gian nội thất hạn chế, khả năng vận hành chưa mạnh mẽ",
      Content:
        "Mazda CX-3 1.5L Deluxe 2022 là mẫu crossover nhỏ gọn với khả năng tiết kiệm nhiên liệu tốt và các tính năng an toàn cao. Tuy nhiên, không gian nội thất hạn chế và khả năng vận hành chưa thật sự mạnh mẽ.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mazda%20CX-3%201.5L%20Deluxe%202022.jpg",
    },
    {
      Title: "Đánh giá Mazda CX-30 2.0L Premium 2022",
      Advantages: "Thiết kế hiện đại, vận hành mượt mà, nội thất cao cấp",
      Disadvantages: "Giá bán cao, không gian hành lý hạn chế",
      Content:
        "Mazda CX-30 2.0L Premium 2022 là một chiếc crossover với thiết kế hiện đại, khả năng vận hành mượt mà và nội thất cao cấp. Tuy nhiên, giá bán cao và không gian hành lý hạn chế.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Mazda%20CX-30%202.0L%20Premium%202022.jpg",
    },
    {
      Title: "Đánh giá Honda City RS 2021",
      Advantages: "Thiết kế thể thao, tiện nghi cao, tiết kiệm nhiên liệu",
      Disadvantages:
        "Không gian nội thất hạn chế, cảm giác lái chưa thực sự ấn tượng",
      Content:
        "Honda City RS 2021 mang đến thiết kế thể thao, các tiện nghi hiện đại và khả năng tiết kiệm nhiên liệu tốt. Tuy nhiên, không gian nội thất còn hạn chế và cảm giác lái chưa thật sự ấn tượng so với các đối thủ trong cùng phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Honda%20City%20RS%202021.jpg",
    },
    {
      Title: "Đánh giá Honda Civic 1.5 G 2020",
      Advantages:
        "Hiệu suất vận hành mạnh mẽ, thiết kế hiện đại, tính năng an toàn cao",
      Disadvantages: "Giá bán cao, không gian phía sau hơi chật",
      Content:
        "Honda Civic 1.5 G 2020 mang đến hiệu suất vận hành mạnh mẽ, thiết kế hiện đại và các tính năng an toàn đầy đủ. Tuy nhiên, giá bán cao và không gian hàng ghế sau có thể hơi chật cho những chuyến đi dài.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Honda%20Civic%201.5%20G%202020.jpg",
    },
    {
      Title: "Đánh giá Honda CR-V 2.0 2014",
      Advantages:
        "Không gian rộng rãi, khả năng vận hành ổn định, tính năng an toàn tốt",
      Disadvantages:
        "Thiết kế không còn hiện đại, cảm giác lái chưa thật sự nổi bật",
      Content:
        "Honda CR-V 2.0 2014 là mẫu SUV với không gian rộng rãi và khả năng vận hành ổn định. Tuy nhiên, thiết kế không còn hiện đại và cảm giác lái chưa thật sự nổi bật so với các đối thủ trong phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Honda%20CR-V%202.0%202014.jpg",
    },
    {
      Title: "Đánh giá Honda Accord 2008",
      Advantages:
        "Nội thất sang trọng, động cơ mạnh mẽ, khả năng vận hành ổn định",
      Disadvantages: "Thiết kế đã cũ, tiêu thụ nhiên liệu khá cao",
      Content:
        "Honda Accord 2008 mang đến một không gian nội thất sang trọng, động cơ mạnh mẽ và khả năng vận hành ổn định. Tuy nhiên, thiết kế đã cũ và tiêu thụ nhiên liệu khá cao so với các mẫu xe hiện đại.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Honda%20Accord%202008.jpg",
    },
    {
      Title: "Đánh giá Honda Brio RS 2019",
      Advantages: "Kích thước nhỏ gọn, tiết kiệm nhiên liệu, giá bán hợp lý",
      Disadvantages:
        "Không gian nội thất hạn chế, khả năng vận hành chưa mạnh mẽ",
      Content:
        "Honda Brio RS 2019 là chiếc xe nhỏ gọn, tiết kiệm nhiên liệu và có giá bán hợp lý. Tuy nhiên, không gian nội thất hạn chế và khả năng vận hành chưa mạnh mẽ so với các mẫu xe khác trong phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Honda%20Brio%20RS%202019.jpg",
    },
    {
      Title: "Đánh giá Honda HR-V G 2023",
      Advantages:
        "Thiết kế hiện đại, công nghệ tiên tiến, không gian nội thất rộng rãi",
      Disadvantages: "Giá bán khá cao, khả năng vận hành chưa ấn tượng",
      Content:
        "Honda HR-V G 2023 mang đến thiết kế hiện đại với công nghệ tiên tiến và không gian nội thất rộng rãi. Tuy nhiên, giá bán khá cao và khả năng vận hành chưa thật sự ấn tượng so với các đối thủ trong phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Honda%20HR-V%20G%202023.jpg",
    },
    {
      Title: "Đánh giá Honda Jazz 2019",
      Advantages:
        "Tiết kiệm nhiên liệu, không gian rộng rãi, tính năng an toàn cao",
      Disadvantages:
        "Hiệu suất vận hành không mạnh mẽ, thiết kế chưa thật sự nổi bật",
      Content:
        "Honda Jazz 2019 là mẫu hatchback tiết kiệm nhiên liệu, không gian rộng rãi và tính năng an toàn tốt. Tuy nhiên, hiệu suất vận hành không mạnh mẽ và thiết kế chưa thật sự nổi bật so với các đối thủ cùng phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Honda%20Jazz%202019.jpg",
    },
    {
      Title: "Đánh giá Honda Odyssey 2.4 CVT 2016",
      Advantages: "Không gian rộng rãi, tiện nghi đầy đủ, vận hành êm ái",
      Disadvantages: "Giá bán khá cao, tiêu thụ nhiên liệu không thấp",
      Content:
        "Honda Odyssey 2.4 CVT 2016 là chiếc MPV với không gian rộng rãi, tiện nghi đầy đủ và khả năng vận hành êm ái. Tuy nhiên, giá bán khá cao và mức tiêu thụ nhiên liệu không thấp.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Honda%20Odyssey%202.4%20CVT%202016.jpg",
    },
    {
      Title: "Đánh giá Audi A4 1.8L TFSI 2013",
      Advantages:
        "Thiết kế sang trọng, cảm giác lái mượt mà, tiết kiệm nhiên liệu",
      Disadvantages:
        "Không gian nội thất khá hạn chế, khả năng vận hành chưa mạnh mẽ",
      Content:
        "Audi A4 1.8L TFSI 2013 có thiết kế sang trọng và cảm giác lái mượt mà, cùng khả năng tiết kiệm nhiên liệu tốt. Tuy nhiên, không gian nội thất khá hạn chế và khả năng vận hành chưa mạnh mẽ như các mẫu xe khác trong phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Audi%20A4%201.8L%20TFSI%202013.jpg",
    },
    {
      Title: "Đánh giá Audi A5 Sportback 2.0 TFSI 2013",
      Advantages:
        "Thiết kế thể thao, tiện nghi đầy đủ, khả năng vận hành ổn định",
      Disadvantages: "Giá cao, không gian hàng ghế sau hơi hạn chế",
      Content:
        "Audi A5 Sportback 2.0 TFSI 2013 mang đến thiết kế thể thao, tiện nghi đầy đủ và khả năng vận hành ổn định. Tuy nhiên, giá bán khá cao và không gian hàng ghế sau hơi hạn chế.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Audi%20A5%20Sportback%202.0%20TFSI%202013.jpg",
    },
    {
      Title: "Đánh giá Audi Q5 45 TFSI Quattro 2018",
      Advantages:
        "Động cơ mạnh mẽ, hệ dẫn động 4 bánh Quattro, không gian rộng rãi",
      Disadvantages: "Giá khá cao, tính năng giải trí chưa thật sự nổi bật",
      Content:
        "Audi Q5 45 TFSI Quattro 2018 sở hữu động cơ mạnh mẽ, hệ dẫn động 4 bánh Quattro và không gian nội thất rộng rãi. Tuy nhiên, giá bán khá cao và tính năng giải trí chưa thật sự nổi bật so với các đối thủ cùng phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Audi%20Q5%2045%20TFSI%20Quattro%202018.jpg",
    },
    {
      Title: "Đánh giá Audi A6 45 TFSI 2022",
      Advantages:
        "Thiết kế sang trọng, công nghệ tiên tiến, khả năng vận hành êm ái",
      Disadvantages: "Giá khá cao, không gian nội thất chưa thực sự rộng rãi",
      Content:
        "Audi A6 45 TFSI 2022 nổi bật với thiết kế sang trọng, công nghệ tiên tiến và khả năng vận hành êm ái. Tuy nhiên, giá bán khá cao và không gian nội thất chưa thực sự rộng rãi như những mẫu xe đối thủ.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Audi%20A6%2045%20TFSI%202022.jpg",
    },
    {
      Title: "Đánh giá Audi A8 4.2 2011",
      Advantages:
        "Nội thất sang trọng, khả năng vận hành mạnh mẽ, trang bị đầy đủ",
      Disadvantages: "Thiết kế có phần lỗi thời, tiêu thụ nhiên liệu khá cao",
      Content:
        "Audi A8 4.2 2011 mang đến nội thất sang trọng, khả năng vận hành mạnh mẽ và trang bị đầy đủ. Tuy nhiên, thiết kế có phần lỗi thời và mức tiêu thụ nhiên liệu khá cao so với các mẫu xe hiện đại.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Audi%20A8%204.2%202011.jpg",
    },
    {
      Title: "Đánh giá Audi Q7 2013",
      Advantages:
        "Không gian rộng rãi, khả năng vận hành ấn tượng, trang bị cao cấp",
      Disadvantages: "Giá cao, cảm giác lái chưa thật sự ấn tượng",
      Content:
        "Audi Q7 2013 là chiếc SUV có không gian rộng rãi, khả năng vận hành ấn tượng và trang bị cao cấp. Tuy nhiên, giá bán khá cao và cảm giác lái chưa thật sự ấn tượng so với các đối thủ trong phân khúc.",
      ImageURL:
        "https://lxaqtnuuqvsscavvqcxs.supabase.co/storage/v1/object/public/images/Audi%20Q7%202013.jpg",
    },
  ]);

  // Thêm dữ liệu vào bảng Listings
  await knex("Listings").insert([
    {
      UserID: 1,
      CarID: 1,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Vios E CVT 2022",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 2,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Toyota Innova 2. 0V Full Options 2019 siêu lướt",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 3,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 3",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 4,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 4",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 5,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 5",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 6,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 6",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 7,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 7",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 8,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 8",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 9,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 9",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 10,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 10",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 11,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 11",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 12,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 12",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 13,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 13",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 14,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 14",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 15,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 15",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 16,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 16",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 17,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 17",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 18,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 18",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 19,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 19",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 20,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 20",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 21,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 21",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 22,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 22",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 23,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 23",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 24,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 24",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 25,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 25",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 26,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 26",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 27,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 27",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 28,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 28",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 29,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 29",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 30,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 30",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 31,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 31",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 32,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 32",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 33,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 33",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 34,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 34",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 35,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 35",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 36,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 36",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 37,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 37",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 38,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 38",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 39,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 39",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 40,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 40",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 41,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 41",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 42,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 42",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 43,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 43",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 44,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 44",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 45,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 45",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 46,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 46",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 47,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 47",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 48,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 48",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 49,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 49",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 50,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 50",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 51,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 51",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 52,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 52",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 53,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 53",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 54,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 54",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 55,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 55",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 56,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 56",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 57,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 57",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 58,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 58",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 59,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 59",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 60,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 60",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 61,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 61",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 62,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 62",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 63,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 63",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 64,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 64",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 65,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 65",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 66,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 66",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 67,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 67",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 68,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 68",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 69,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 69",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 70,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 70",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 71,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 71",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 72,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 72",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 73,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 73",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 74,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 74",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 75,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 75",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 76,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 76",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 77,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 77",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 78,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 78",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 79,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 79",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 80,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 80",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 81,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 81",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 82,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 82",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 83,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 83",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 84,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 84",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 85,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 85",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 86,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 86",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 87,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 87",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 88,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 88",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 89,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 89",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 90,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 90",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 91,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 91",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 92,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 92",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 93,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 93",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 94,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 94",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 95,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 95",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 96,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 96",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 97,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 97",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 98,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 98",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 99,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 99",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 100,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 100",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 101,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 101",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 102,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 102",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 103,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 103",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 104,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 104",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 105,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 105",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 106,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 106",
      DatePosted: new Date(),
    },
    {
      UserID: 1,
      CarID: 107,
      Status: "Xe đẹp, đủ hồ sơ giấy tờ sang tên ngay",
      Description: "Car description 107",
      DatePosted: new Date(),
    },
    {
      UserID: 2,
      CarID: 108,
      Status: "Xe đẹp, trả góp lãi xuất ưu đãi, giá tốt",
      Description: "Car description 108",
      DatePosted: new Date(),
    },
  ]);

  // Thêm dữ liệu vào bảng Favorites
  await knex("Favorites").insert([
    { UserID: 1, ListingID: 1 },
    { UserID: 2, ListingID: 2 },
  ]);
};
