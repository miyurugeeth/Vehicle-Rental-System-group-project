-- 1. Roles Table
CREATE TABLE Roles (
    RoleID INTEGER PRIMARY KEY AUTOINCREMENT,
    RoleName TEXT NOT NULL UNIQUE
);

-- 2. Users Table
CREATE TABLE Users (
    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL UNIQUE,
    PasswordHash TEXT NOT NULL,
    RoleID INTEGER,
    Status TEXT DEFAULT 'Active',
    FOREIGN KEY(RoleID) REFERENCES Roles(RoleID)
);

-- 3. Vehicles Table
CREATE TABLE Vehicles (
    VehicleID INTEGER PRIMARY KEY AUTOINCREMENT,
    VehicleNo TEXT NOT NULL UNIQUE,
    Brand TEXT,
    Model TEXT,
    Type TEXT, -- Car/Bike/Van/Truck
    FuelType TEXT,
    RentPrice REAL,
    Status TEXT DEFAULT 'Available',
    InsuranceExpiry TEXT,
    ImagePath TEXT
);

-- 4. Customers Table
CREATE TABLE Customers (
    CustomerID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    NIC TEXT NOT NULL UNIQUE,
    LicenseNo TEXT NOT NULL,
    Phone TEXT,
    Address TEXT
);

-- 5. Rentals Table
CREATE TABLE Rentals (
    RentalID INTEGER PRIMARY KEY AUTOINCREMENT,
    CustomerID INTEGER,
    VehicleID INTEGER,
    RentDate TEXT,
    ExpectedReturnDate TEXT,
    ActualReturnDate TEXT,
    BaseAmount REAL,
    LateFee REAL DEFAULT 0.0,
    TotalAmount REAL,
    FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY(VehicleID) REFERENCES Vehicles(VehicleID)
);

-- 6. Payments Table
CREATE TABLE Payments (
    PaymentID INTEGER PRIMARY KEY AUTOINCREMENT,
    RentalID INTEGER,
    Amount REAL,
    PaymentDate TEXT,
    PaymentMethod TEXT, -- Cash/Card
    PaymentStatus TEXT,
    FOREIGN KEY(RentalID) REFERENCES Rentals(RentalID)
);


INSERT INTO Roles (RoleName) VALUES ('Admin');
INSERT INTO Roles (RoleName) VALUES ('Staff');


INSERT INTO Users (Username, PasswordHash, RoleID) VALUES ('admin', 'admin123', 1);