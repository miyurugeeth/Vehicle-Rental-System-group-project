using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace VehicleRentSystem
{
    public class DatabaseHelper
    {
        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VehicleRent.db");
        private static string connectionString = $"Data Source={dbPath};Version=3;";

        public static void InitializeDatabase()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string createVehicles = @"
                    CREATE TABLE IF NOT EXISTS Vehicles (
                        VehicleID       INTEGER PRIMARY KEY AUTOINCREMENT,
                        VehicleNo       TEXT NOT NULL UNIQUE,
                        VehicleType     TEXT NOT NULL,
                        Brand           TEXT NOT NULL,
                        Model           TEXT NOT NULL,
                        RentPrice       REAL NOT NULL,
                        Status          TEXT NOT NULL DEFAULT 'Available'
                    );";

                string createCustomers = @"
                    CREATE TABLE IF NOT EXISTS Customers (
                        CustomerID      INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name            TEXT NOT NULL,
                        NIC             TEXT NOT NULL UNIQUE,
                        LicenseNo       TEXT NOT NULL,
                        Phone           TEXT NOT NULL,
                        Address         TEXT
                    );";

                string createRentals = @"
                    CREATE TABLE IF NOT EXISTS Rentals (
                        RentalID            INTEGER PRIMARY KEY AUTOINCREMENT,
                        CustomerID          INTEGER NOT NULL,
                        VehicleID           INTEGER NOT NULL,
                        RentDate            TEXT NOT NULL,
                        ExpectedReturnDate  TEXT NOT NULL,
                        ActualReturnDate    TEXT,
                        BaseAmount          REAL,
                        LateFee             REAL DEFAULT 0,
                        TotalAmount         REAL,
                        Status              TEXT NOT NULL DEFAULT 'Active',
                        FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
                        FOREIGN KEY (VehicleID)  REFERENCES Vehicles(VehicleID)
                    );";

                ExecuteNonQueryConn(createVehicles, conn);
                ExecuteNonQueryConn(createCustomers, conn);
                ExecuteNonQueryConn(createRentals, conn);

                InsertSampleData(conn);
            }
        }

        private static void InsertSampleData(SQLiteConnection conn)
        {
            string checkVehicles = "SELECT COUNT(*) FROM Vehicles";
            long count = (long)new SQLiteCommand(checkVehicles, conn).ExecuteScalar();

            if (count == 0)
            {
                string[] vehicles = {
                    "INSERT INTO Vehicles (VehicleNo, VehicleType, Brand, Model, RentPrice) VALUES ('CAB-1234', 'Car', 'Toyota', 'Aqua', 3500)",
                    "INSERT INTO Vehicles (VehicleNo, VehicleType, Brand, Model, RentPrice) VALUES ('CAB-5678', 'Car', 'Honda', 'Fit', 3000)",
                    "INSERT INTO Vehicles (VehicleNo, VehicleType, Brand, Model, RentPrice) VALUES ('CAB-9012', 'Van', 'Toyota', 'HiAce', 6000)",
                    "INSERT INTO Vehicles (VehicleNo, VehicleType, Brand, Model, RentPrice) VALUES ('CAB-3456', 'Motorcycle', 'Honda', 'CB150R', 1500)",
                    "INSERT INTO Vehicles (VehicleNo, VehicleType, Brand, Model, RentPrice) VALUES ('CAB-7890', 'SUV', 'Nissan', 'X-Trail', 8000)"
                };
                foreach (var v in vehicles)
                    ExecuteNonQueryConn(v, conn);

                string[] customers = {
                    "INSERT INTO Customers (Name, NIC, LicenseNo, Phone, Address) VALUES ('Kamal Perera', '199012345678', 'B1234567', '0771234567', 'Colombo 05')",
                    "INSERT INTO Customers (Name, NIC, LicenseNo, Phone, Address) VALUES ('Nimal Silva', '198587654321', 'B7654321', '0769876543', 'Kandy')",
                    "INSERT INTO Customers (Name, NIC, LicenseNo, Phone, Address) VALUES ('Sunil Fernando', '200034567890', 'B9876543', '0752345678', 'Galle')"
                };
                foreach (var c in customers)
                    ExecuteNonQueryConn(c, conn);
            }
        }

        // Internal helper — uses existing open connection
        private static void ExecuteNonQueryConn(string sql, SQLiteConnection conn)
        {
            using (var cmd = new SQLiteCommand(sql, conn))
                cmd.ExecuteNonQuery();
        }

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(connectionString);
            conn.Open();
            return conn;
        }

        // Main public ExecuteNonQuery — accepts parameters
        public static int ExecuteNonQuery(string sql, SQLiteParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        public static DataTable ExecuteQuery(string sql, SQLiteParameter[] parameters = null)
        {
            var dt = new DataTable();
            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                using (var adapter = new SQLiteDataAdapter(cmd))
                    adapter.Fill(dt);
            }
            return dt;
        }

        public static object ExecuteScalar(string sql, SQLiteParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }
    }
}
