using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;

namespace GnC
{
    internal class CreateSampleData
    {
        private static readonly string[] FirstNames = {
        "James", "Mary", "John", "Patricia", "Robert", "Jennifer", "Michael", "Linda",
        "William", "Elizabeth", "David", "Barbara", "Richard", "Susan", "Joseph", "Jessica",
        "Thomas", "Sarah", "Christopher", "Karen", "Charles", "Helen", "Daniel", "Nancy",
        "Matthew", "Betty", "Anthony", "Dorothy", "Mark", "Lisa", "Donald", "Sandra",
        "Steven", "Donna", "Paul", "Carol", "Andrew", "Ruth", "Kenneth", "Sharon",
        "Joshua", "Michelle", "Kevin", "Laura", "Brian", "Sarah", "George", "Kimberly",
        "Timothy", "Deborah", "Ronald", "Dorothy", "Jason", "Lisa", "Edward", "Nancy",
        "Jeffrey", "Karen", "Ryan", "Betty", "Jacob", "Helen", "Gary", "Sandra",
        "Nicholas", "Donna", "Eric", "Carol", "Jonathan", "Ruth", "Stephen", "Sharon",
        "Larry", "Michelle", "Justin", "Laura", "Scott", "Sarah", "Brandon", "Kimberly",
        "Benjamin", "Deborah", "Samuel", "Dorothy", "Gregory", "Amy", "Alexander", "Angela",
        "Patrick", "Ashley", "Jack", "Brenda", "Dennis", "Emma", "Jerry", "Olivia",
        "Tyler", "Cynthia", "Aaron", "Marie", "Jose", "Janet", "Henry", "Catherine"
    };

        private static readonly string[] LastNames = {
        "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis",
        "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas",
        "Taylor", "Moore", "Jackson", "Martin", "Lee", "Perez", "Thompson", "White",
        "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson", "Walker", "Young",
        "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores",
        "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell",
        "Carter", "Roberts", "Gomez", "Phillips", "Evans", "Turner", "Diaz", "Parker",
        "Cruz", "Edwards", "Collins", "Reyes", "Stewart", "Morris", "Morales", "Murphy",
        "Cook", "Rogers", "Gutierrez", "Ortiz", "Morgan", "Cooper", "Peterson", "Bailey",
        "Reed", "Kelly", "Howard", "Ramos", "Kim", "Cox", "Ward", "Richardson",
        "Watson", "Brooks", "Chavez", "Wood", "James", "Bennett", "Gray", "Mendoza",
        "Ruiz", "Hughes", "Price", "Alvarez", "Castillo", "Sanders", "Patel", "Myers"
    };

        public static void CreateAndPopulateDatabase(string databasePath, int recordCount = 1000000)
        {
            string connectionString = $"Data Source={databasePath};Version=3;";
            var random = new Random();
            var stopwatch = Stopwatch.StartNew();

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Enable WAL mode and other optimizations for faster inserts
                    ExecuteNonQuery(connection, "PRAGMA journal_mode=WAL;");
                    ExecuteNonQuery(connection, "PRAGMA synchronous=NORMAL;");
                    ExecuteNonQuery(connection, "PRAGMA cache_size=10000;");
                    ExecuteNonQuery(connection, "PRAGMA temp_store=MEMORY;");

                    // Create the table
                    CreateTable(connection);

                    Console.WriteLine($"Starting to insert {recordCount:N0} records...");

                    // Use transaction for better performance
                    using (var transaction = connection.BeginTransaction())
                    {
                        string insertSql = @"INSERT INTO people (first_name, last_name, full_name, age, created_date) 
                                       VALUES (@firstName, @lastName, @fullName, @age, @createdDate)";

                        using (var command = new SQLiteCommand(insertSql, connection, transaction))
                        {
                            // Prepare parameters once
                            var firstNameParam = command.Parameters.Add("@firstName", System.Data.DbType.String);
                            var lastNameParam = command.Parameters.Add("@lastName", System.Data.DbType.String);
                            var fullNameParam = command.Parameters.Add("@fullName", System.Data.DbType.String);
                            var ageParam = command.Parameters.Add("@age", System.Data.DbType.Int32);
                            var createdDateParam = command.Parameters.Add("@createdDate", System.Data.DbType.DateTime);

                            command.Prepare();

                            for (int i = 0; i < recordCount; i++)
                            {
                                // Generate random name data
                                string firstName = FirstNames[random.Next(FirstNames.Length)];
                                string lastName = LastNames[random.Next(LastNames.Length)];
                                string fullName = $"{firstName} {lastName}";
                                int age = random.Next(18, 85);
                                DateTime createdDate = DateTime.Now.AddDays(-random.Next(0, 365 * 5)); // Random date within last 5 years

                                // Set parameter values
                                firstNameParam.Value = firstName;
                                lastNameParam.Value = lastName;
                                fullNameParam.Value = fullName;
                                ageParam.Value = age;
                                createdDateParam.Value = createdDate;

                                command.ExecuteNonQuery();

                                // Progress indicator
                                if (i % 50000 == 0 && i > 0)
                                {
                                    Console.WriteLine($"Inserted {i:N0} records... ({(double)i / recordCount * 100:F1}%)");
                                }
                            }
                        }

                        transaction.Commit();
                    }

                    // Create index for better query performance
                    Console.WriteLine("Creating indexes...");
                    ExecuteNonQuery(connection, "CREATE INDEX IF NOT EXISTS idx_last_name ON people(last_name);");
                    ExecuteNonQuery(connection, "CREATE INDEX IF NOT EXISTS idx_first_name ON people(first_name);");
                    ExecuteNonQuery(connection, "CREATE INDEX IF NOT EXISTS idx_age ON people(age);");
                }

                stopwatch.Stop();
                Console.WriteLine($"Successfully inserted {recordCount:N0} records in {stopwatch.Elapsed.TotalSeconds:F2} seconds!");
                Console.WriteLine($"Average: {recordCount / stopwatch.Elapsed.TotalSeconds:F0} records per second");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public static void CreateAndPopulateCaseTable(int recordCount = 1000000)
        {
            string connectionString = $"Data Source=cache.db;Version=3;";
            var random = new Random();
            var stopwatch = Stopwatch.StartNew();

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Enable WAL mode and other optimizations for faster inserts
                    ExecuteNonQuery(connection, "PRAGMA journal_mode=WAL;");
                    ExecuteNonQuery(connection, "PRAGMA synchronous=NORMAL;");
                    ExecuteNonQuery(connection, "PRAGMA cache_size=10000;");
                    ExecuteNonQuery(connection, "PRAGMA temp_store=MEMORY;");

                    // Create the table
                    CreateTable(connection);

                    Console.WriteLine($"Starting to insert {recordCount:N0} records...");

                    // Use transaction for better performance
                    using (var transaction = connection.BeginTransaction())
                    {
                        string insertSql = @"INSERT INTO cases (caseno, casetitle, district, created_date) 
                                       VALUES (@caseno, @casetitle, @district, @createdDate)";

                        using (var command = new SQLiteCommand(insertSql, connection, transaction))
                        {
                            // Prepare parameters once
                            var caseNoParam = command.Parameters.Add("@caseno", System.Data.DbType.String);
                            var caseTitleParam = command.Parameters.Add("@casetitle", System.Data.DbType.String);
                            var districtParam = command.Parameters.Add("@district", System.Data.DbType.Int32);
                            var createdDateParam = command.Parameters.Add("@createdDate", System.Data.DbType.DateTime);

                            command.Prepare();

                            for (int i = 0; i < recordCount; i++)
                            {
                                // Set parameter values
                                string caseno = "" + random.Next(10, 99) + "-" + random.Next(100, 999) + "-" + random.Next(10000, 99999);
                                caseNoParam.Value = "CV" + caseno;
                                caseTitleParam.Value = "Case Title " + caseno;
                                districtParam.Value = random.Next(1, 7);

                                DateTime createdDate = DateTime.Now.AddDays(-random.Next(0, 365 * 5)); // Random date within last 5 years
                                createdDateParam.Value = createdDate;

                                command.ExecuteNonQuery();

                                // Progress indicator
                                if (i % 50000 == 0 && i > 0)
                                {
                                    Console.WriteLine($"Inserted {i:N0} records... ({(double)i / recordCount * 100:F1}%)");
                                }
                            }
                        }

                        transaction.Commit();
                    }
                }

                stopwatch.Stop();
                Console.WriteLine($"Successfully inserted {recordCount:N0} records in {stopwatch.Elapsed.TotalSeconds:F2} seconds!");
                Console.WriteLine($"Average: {recordCount / stopwatch.Elapsed.TotalSeconds:F0} records per second");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        private static void CreateTable(SQLiteConnection connection)
        {
            string createPeopleTableSql = @"
            CREATE TABLE IF NOT EXISTS people (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                first_name TEXT NOT NULL,
                last_name TEXT NOT NULL,
                full_name TEXT NOT NULL,
                age INTEGER NOT NULL,
                created_date DATETIME NOT NULL
            );";

            ExecuteNonQuery(connection, createPeopleTableSql);
            Console.WriteLine("Table 'people' created successfully.");

            string createCasesTableSql = @"
            CREATE TABLE IF NOT EXISTS cases (
                id            INTEGER  PRIMARY KEY AUTOINCREMENT,
                caseno        TEXT     NOT NULL,
                casetitle     TEXT     NOT NULL,
                district      INTEGER  NOT NULL
                                       DEFAULT 1,
                starred       INTEGER  NOT NULL
                                       DEFAULT 0,
                created_date  DATETIME NOT NULL,
                datefiled     DATE,
                casecategory  TEXT,
                casetype      TEXT,
                securitygroup TEXT
            );";

            ExecuteNonQuery(connection, createCasesTableSql);
            Console.WriteLine("Table 'cases' created successfully.");
        }

        private static void ExecuteNonQuery(SQLiteConnection connection, string sql)
        {
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        // Method to get statistics about the populated data
        public static void GetDatabaseStats(string databasePath)
        {
            string connectionString = $"Data Source={databasePath};Version=3;";

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Get total count
                    using (var command = new SQLiteCommand("SELECT COUNT(*) FROM people", connection))
                    {
                        long totalCount = (long)command.ExecuteScalar();
                        Console.WriteLine($"Total records: {totalCount:N0}");
                    }

                    // Get some sample data
                    using (var command = new SQLiteCommand("SELECT * FROM people LIMIT 5", connection))
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("\nSample records:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["id"]}, Name: {reader["full_name"]}, Age: {reader["age"]}, Created: {reader["created_date"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting stats: {ex.Message}");
            }
        }

        public static void writeCaseParties()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection("Data Source=cache.db;"))
                {
                    // Open the connection
                    connection.Open();
                    for (int i = 1; i < 1000000; i++)
                    {
                        string sql = "INSERT INTO caseparty (casekey, partykey) VALUES (" + i + "," + (i + 1) + ");";
                        var command = new SQLiteCommand(sql, connection);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex) { Console.WriteLine($"SQL Error: {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"General Error: {ex.Message}"); }
        }

        // Example usage
        public static void CreateRecords()
        {
            string dbPath = "cache.db";

            // Create and populate with 1 million records
            CreateAndPopulateDatabase(dbPath, 1000000);

            // Show statistics
            GetDatabaseStats(dbPath);
        }

        public static void AddIndex(string databasePath = "cache.db")
        {
            string connectionString = $"Data Source={databasePath};Version=3;";

            try {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    ExecuteNonQuery(connection, "CREATE INDEX IF NOT EXISTS idx_first_name ON people(first_name);");
                }

            } catch (Exception ex) { Console.WriteLine($"Error adding index: {ex.Message}"); }
        }
    }
}
/*
 
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (5,'Guardianship - Adult');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (5,'Guardianship - Juvenile');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (5,'Conservatorship - Adult');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (5,'Conservatorship - Juvenile');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (5,'Both (G&C) - Adult Cases');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (5,'Both (G&C) - Juvenile');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (5,'Limited Guardianship - Adult');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (5,'Limited Guardianship - Juvenile');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (5,'Limited Conservatorship - Adult');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (5,'Limited Conservatorship - Juvenile');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (5,'Limited Both (G&C) - Adult');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (5,'Limited Both (G&C) - Juvenile');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (4,'Open/Pending');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (4,'Inactive');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (4,'Disposed/Set for Review');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (4,'Disposed/Closed');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (6,'Restoration of Rights');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (6,'Reached Age of Majority');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (6,'Death');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (6,'Transfer to State/County');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (6,'Transfer to Jurisdiction/Court');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (6,'Order Expired');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (6,'Dismissal');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (6,'Less Restrictive Alternative');
INSERT INTO AttributeOptions (AttributeKey, PossibleValue) VALUES (6,'Other Reason');

INSERT INTO Attributes (AttrNAme, AttrType) VALUES ('CaseStyle',0);
INSERT INTO Attributes (AttrNAme, AttrType) VALUES ('District',0);
INSERT INTO Attributes (AttrNAme, AttrType) VALUES ('DateFiled',0);
INSERT INTO Attributes (AttrNAme, AttrType) VALUES ('Case Status',2);
INSERT INTO Attributes (AttrNAme, AttrType) VALUES ('Probate Case Type',2);
INSERT INTO Attributes (AttrNAme, AttrType) VALUES ('Case Closure Reason',2);
INSERT INTO Attributes (AttrNAme, AttrType) VALUES ('Next steps',1);
INSERT INTO Attributes (AttrNAme, AttrType) VALUES ('Confidentiality Flag',3);
INSERT INTO Attributes (AttrNAme, AttrType) VALUES ('Appeal Filed Flag',3);
INSERT INTO Attributes (AttrNAme, AttrType) VALUES ('Interpreter Flag',3);
INSERT INTO Attributes (AttrNAme, AttrType) VALUES ('ICWA Case Flag',3);
INSERT INTO Attributes (AttrNAme, AttrType) VALUES ('Contested Flag',3);
INSERT INTO Attributes (AttrNAme, AttrType) VALUES ('Excluded Time Flag',3);
INSERT INTO Attributes (AttrNAme, AttrType) VALUES ('Interstate Flag',3);
INSERT INTO Attributes (AttrNAme, AttrType) VALUES ('Dependency Court Judgment Flag',3);

 */
