/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
*/
exports.up = async function (knex) {
    await knex.raw(`
        CREATE TABLE Users(
            UserID INT PRIMARY KEY IDENTITY(1,1),
            Username VARCHAR(50) NOT NULL,
            Password VARCHAR(255) NOT NULL,
            FullName NVARCHAR(255),
            Phone VARCHAR(15),
            Email VARCHAR(100) UNIQUE,
            Address NVARCHAR(255)
        );
    `);

    await knex.raw(`
        CREATE TABLE Manufacturers(
            ManufacturerID INT PRIMARY KEY IDENTITY(1,1),
            ManufacturerName VARCHAR(255) NOT NULL
        );
    `);

    await knex.raw(`
        CREATE TABLE CarModels(
            ModelID INT PRIMARY KEY IDENTITY(1,1),
            ManufacturerID INT,
            ModelName NVARCHAR(255) NOT NULL
        );
    `);

    await knex.raw(`
        CREATE TABLE Cars(
            CarID INT PRIMARY KEY IDENTITY(1,1),
            ModelID INT,
            Year INT,
            Style NVARCHAR(255),
            Condition NVARCHAR(255),
            Origin NVARCHAR(255),
            Mileage decimal(10,2),
            Gear NVARCHAR(255),
            FuelType NVARCHAR(255),
            Price decimal(18,2)
        );
    `);

    await knex.raw(`
        CREATE TABLE CarImages(
            ImageID INT PRIMARY KEY IDENTITY(1,1),
            CarID INT,
            ImageURL NVARCHAR(255)
        );
    `);

    await knex.raw(`
        CREATE TABLE Listings(
            ListingID INT PRIMARY KEY IDENTITY(1,1),
            UserID INT,
            CarID INT,
            Status NVARCHAR(50) DEFAULT 'available',
            Description NVARCHAR(500),
            DatePosted DATETIME DEFAULT GETDATE()
        )
    `);

    await knex.raw(`
        CREATE TABLE Favorites(
            FavoriteID INT PRIMARY KEY IDENTITY(1,1),
            UserID INT,
            ListingID INT
        )
    `);

    await knex.schema.alterTable('CarModels', (table) => {
        table.foreign('ManufacturerID').references('ManufacturerID').inTable('Manufacturers');
    });

    await knex.schema.alterTable('Cars', (table) => {
        table.foreign('ModelID').references('ModelID').inTable('CarModels');
    });

    await knex.schema.alterTable('CarImages', (table) => {
        table.foreign('CarID').references('CarID').inTable('Cars');
    });

    await knex.schema.alterTable('Listings', (table) => {
        table.foreign('UserID').references('UserID').inTable('Users');
        table.foreign('CarID').references('CarID').inTable('Cars');
    });

    await knex.schema.alterTable('Favorites', (table) => {
        table.foreign('UserID').references('UserID').inTable('Users');
        table.foreign('ListingID').references('ListingID').inTable('Listings');
    });
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = async function(knex) {
    // Xóa khóa ngoại
    await knex.schema.alterTable('Favorites', (table) => {
        table.dropForeign('UserID');
        table.dropForeign('ListingID');
    });

    await knex.schema.alterTable('Listings', (table) => {
        table.dropForeign('UserID');
        table.dropForeign('CarID');
    });

    await knex.schema.alterTable('CarImages', (table) => {
        table.dropForeign('CarID');
    });

    await knex.schema.alterTable('Cars', (table) => {
        table.dropForeign('ModelID');
    });

    await knex.schema.alterTable('CarModels', (table) => {
        table.dropForeign('ManufacturerID');
    });

    // Xóa bảng
    await knex.schema.dropTableIfExists('Favorites');
    await knex.schema.dropTableIfExists('Listings');
    await knex.schema.dropTableIfExists('CarImages');
    await knex.schema.dropTableIfExists('Cars');
    await knex.schema.dropTableIfExists('CarModels');
    await knex.schema.dropTableIfExists('Manufacturers');
    await knex.schema.dropTableIfExists('Users');
};
