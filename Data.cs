using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Data.SQLite;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace GnC
{
    internal class Data
    {
        static string getUsername() { return WindowsIdentity.GetCurrent().Name; }

        static string connectionString = @"Server=fpw12odysql1dev\IDSQLODYDEV;Database=ISC;Integrated Security=true;";
        static string localConnectionString = @"Server=(LocalDb)\MSSQLLocalDB;Database=Local;Integrated Security=true;";
        //
        // @"Data Source=YOUR_SERVER_NAME;Initial Catalog=YOUR_DATABASE_NAME;Integrated Security=SSPI;";

        public static void readTable(string table)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();
                    Console.WriteLine("Connected to SQL Server successfully!");

                    // SQL query to read from a table
                    string query = "SELECT * FROM " + table;

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Print column headers
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"{reader.GetName(i)}\t");
                            }
                            Console.WriteLine();
                            Console.WriteLine(new string('-', 50));

                            // Read and display data
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader[i]}\t");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }

        }
    

        public static List<Dictionary<string, object>> ReadFromDatabase(string databasePath, string query)
        {
            var results = new List<Dictionary<string, object>>();

            // Connection string for SQLite
            string connectionString = $"Data Source={databasePath};Version=3;";

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var row = new Dictionary<string, object>();

                                // Read all columns in the current row
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string columnName = reader.GetName(i);
                                    object value = reader.IsDBNull(i) ? null : reader.GetValue(i);
                                    row[columnName] = value;
                                }

                                results.Add(row);
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"SQLite error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
                throw;
            }

            return results;
        }

        // Search name
        public static List<SearchResult> Search(string searchText, int searchResultStart = 0, int starred = 0, int district = 0)
        {
            var results = new List<SearchResult>();

            try
            {
                bool isParty = true;
                string query = $"SELECT id, first_name, last_name, age, created_date, rank FROM (SELECT id, first_name, last_name, age, created_date, 1 as rank FROM people WHERE last_name LIKE '{searchText}%' UNION SELECT id, first_name, last_name, age, created_date, 2 as rank FROM people WHERE first_name LIKE '{searchText}%') ORDER BY rank LIMIT {searchResultStart}, {searchResultStart+20};";    // Case 1: single word (First or Last Name)
                
                if (searchText.Contains(",")) query = $"SELECT id, first_name, last_name, age, created_date FROM people WHERE last_name LIKE '{searchText.Split(',')[0].Trim()}%' AND first_name LIKE '{searchText.Split(',')[1].Trim()}%' LIMIT {searchResultStart}, {searchResultStart + 20};";                  // Case 2: Contains comma - "Last, First" format
                else if (searchText.Contains(" ")) query = $"SELECT id, first_name, last_name, age, created_date FROM people WHERE last_name LIKE '{searchText.Split(' ')[1].Trim()}%' AND first_name LIKE '{searchText.Split(' ')[0].Trim()}%' LIMIT {searchResultStart}, {searchResultStart + 20};";             // Case 3: Contains space - "First Last" format
                
                if (Utils.IsDigits(searchText)) { isParty = false; query = $"SELECT id, caseno, casetitle, district, created_date, datefiled, casecategory, casetype, securitygroup FROM cases WHERE caseno LIKE '%{searchText.Trim()}' LIMIT {searchResultStart}, {searchResultStart + 20};"; }                                                                      // Case 4: Contains only digits, it's a case
                if (searchText.ToUpper().StartsWith("CV")) { isParty = false; query = $"SELECT id, caseno, casetitle, district, created_date, datefiled, casecategory, casetype, securitygroup FROM cases WHERE caseno LIKE '{searchText.Trim()}%' LIMIT {searchResultStart}, {searchResultStart + 20};"; }                                                                     // Case 5: Starts off with CV, it's a case

                // Connection string for SQLite
                string connectionString = $"Data Source=cache.db;Version=3;";

                try
                {
                    using (var connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        using (var command = new SQLiteCommand(query, connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var row = new SearchResult();
                                    row.ID = reader.GetInt32(0);
                                    row.IsParty = isParty;
                                    if (isParty) {
                                        row.FirstName = reader["first_name"].ToString();
                                        row.LastName = reader["last_name"].ToString();
                                        row.Age = reader.GetInt32(3);
                                        row.CreatedDate = "" + reader.GetDateTime(4).ToString();
                                    } else {
                                        row.CaseNo = reader["caseno"].ToString();
                                        row.CaseStyle = reader["casetitle"].ToString();
                                        row.District = reader.GetInt32(3);
                                        row.DateFiled = reader["datefiled"].ToString().Split(' ')[0];
                                        row.CaseCategory = reader["casecategory"].ToString();
                                        row.CaseType = reader["casetype"].ToString();
                                        row.SecurityGroups = reader["securitygroup"].ToString();
                                    }
                                    results.Add(row);
                                }
                            }
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine($"SQLite error: {ex.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General error: {ex.Message}");
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading database: {ex.Message}");
            }
            return results;
        }

        private static Dictionary<int, Attributes> attributes = null;
        public static Dictionary<int, Attributes> attrList()
        {
            if (attributes != null) return attributes;
            try
            {
                using (SqlConnection connection = new SqlConnection(localConnectionString))
                {
                    // Open the connection
                    connection.Open();

                    attributes = new Dictionary<int, Attributes>();
                    using (SqlCommand command = new SqlCommand("SELECT ID, AttrName, AttrType FROM Attributes", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                                attributes.Add(reader.GetInt32(0), new Attributes { ID = reader.GetInt32(0), AttrName = reader.GetString(1), AttrType = reader.GetInt32(2) });
                        }
                    }
                    using (SqlCommand command = new SqlCommand("SELECT ID, AttributeKey, PossibleValue FROM AttributeOptions;", connection)) {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) {
                                if (attributes[reader.GetInt32(1)].PossibleValues == null) attributes[reader.GetInt32(1)].PossibleValues = new Dictionary<int, string>();
                                attributes[reader.GetInt32(1)].PossibleValues.Add(reader.GetInt32(0), reader.GetString(2));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex) { Console.WriteLine($"SQL Error: {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"General Error: {ex.Message}"); }

            return attributes;
        }

        public static Dictionary<int, string> getAnswers(int caseKey)
        {
            Dictionary<int, string> answers = new Dictionary<int, string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(localConnectionString))
                {
                    // Open the connection
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT AttributeKey, Answer FROM Answers WHERE CaseKey = @CaseKey;", connection))
                    {
                        command.Parameters.AddWithValue("@CaseKey", caseKey);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                                answers.Add(reader.GetInt32(0), reader.GetString(1));
                        }
                    }
                }
            }
            catch (SqlException ex) { Console.WriteLine($"SQL Error: {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"General Error: {ex.Message}"); }

            return answers;
        }


        public static Dictionary<string, string> readCaseNotes(int caseKey)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(localConnectionString))
                {
                    // Open the connection
                    connection.Open();
                    //Console.WriteLine("Connected to SQL Server successfully!");

                    // SQL query to read from a table
                    string query = $"SELECT Modified, Notes FROM CaseNotes WHERE CaseKey = {caseKey} ORDER BY Modified DESC;";
                    string latest = "*";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) {
                                result.Add(latest + reader.GetDateTime(0).ToString("MM/dd/yyyy"), reader.GetString(1));
                                latest = string.Empty;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex) { Console.WriteLine($"SQL Error: {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"General Error: {ex.Message}"); }

            return result;
        }

        public static void writeCaseNotes(int caseKey, string notes)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(localConnectionString))
                {
                    // Open the connection
                    connection.Open();

                    const string sql = @"
                        MERGE CaseNotes AS target
                        USING (SELECT @CaseKey as CaseKey, @CaseNotes as CaseNotes, @Modified AS Modified) AS source
                        ON target.CaseKey = source.CaseKey AND target.Modified = source.Modified
                        WHEN MATCHED THEN
                            UPDATE SET 
                                Notes = source.CaseNotes
                        WHEN NOT MATCHED THEN
                            INSERT (CaseKey, Notes, Modified)
                            VALUES (source.CaseKey, source.CaseNotes, source.Modified);";

                    var command = new SqlCommand(sql, connection);

                    command.Parameters.Add(new SqlParameter("@Modified", SqlDbType.Date) { Value = DateTime.Now.Date });
                    command.Parameters.AddWithValue("@CaseKey", caseKey); 
                    command.Parameters.AddWithValue("@CaseNotes", notes);                    

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) { Console.WriteLine($"SQL Error: {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"General Error: {ex.Message}"); }
        }


        public static DataTable readCaseHistory(int CaseKey)
        {
            try
            {
                // Create connection and command objects
                using (SqlConnection connection = new SqlConnection(localConnectionString))
                using (SqlCommand command = new SqlCommand("SELECT Attribute, ValueFrom, ValueTo, DateOccured, Username FROM CaseHistory WHERE CaseKey = @CaseKey ORDER BY DateOccured DESC;", connection))
                {
                    command.Parameters.AddWithValue("@CaseKey", CaseKey);
                    //Debug.WriteLine("Actual SQL: " + GetCommandAsSql(command));
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command)) {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);              //Debug.WriteLine($"Rows returned: {dataTable.Rows.Count}");          
                        return dataTable;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public static string GetCommandAsSql(SqlCommand cmd)
        {
            StringBuilder sql = new StringBuilder(cmd.CommandText);

            foreach (SqlParameter p in cmd.Parameters)
            {
                string value = p.Value != null ? p.Value.ToString() : "NULL";
                if (p.DbType == DbType.String || p.DbType == DbType.DateTime)
                    value = "'" + value + "'";

                sql.Replace(p.ParameterName, value);
            }

            return sql.ToString();
        }

        public static List<string> Hearings(string CaseNo)
        {
            string sql = $@"
                SELECT 
                    HE.HearingID,
                    (select county from ISC..NodeListReporting nlr where nlr.NodeID = CAH.NodeID ) as 'County'
                    ,(select OrgUnitName from ISC..NodeListReporting nlr where nlr.NodeID = CAH.NodeID ) as 'Court'
                    ,CAH.CaseNbr AS 'CaseNumber'
                    ,CONVERT(VARCHAR(10),CtS.SessionDate,101) AS 'HearingDate'
                    ,Justice.dbo.fnFormatTime(CASE WHEN CtS.StartAtType = '0' OR CtS.StartAtType = '1' THEN CONVERT(TIME(0),DATEADD(n, CtSB.OffsetMinutes + S.OffsetMinutes, CtS.StartTime),108) WHEN CtS.StartAtType = '2' THEN CONVERT(TIME(0),CtS.StartTime,108) END) AS 'HearingTime'
                    ,Cd.Code as 'HearingType'
                    ,CtS.Description
                    ,CCH.CaseID
                    ,CCH.CaseCategoryKey
                    ,CAH.JudgeID
                    ,CtS.SessionDate
                FROM Justice..CtSession CtS 
                    JOIN Justice..CtSessionBlock CtSB  ON CtS.CourtSessionID = CtSB.CourtSessionID
                    JOIN Justice..Setting S  ON CtSB.CourtSessionBlockID = S.CourtSessionBlockID
                    JOIN Justice..HearingEvent HE  ON S.HearingID = HE.HearingID
                    JOIN Justice..Event E  ON E.EventID = HE.HearingID
                    JOIN Justice..uCode Cd ON E.EventTypeID = Cd.CodeID
                    JOIN Justice..ClkCaseHdr CCH  ON HE.CaseID = CCH.CaseID
                    JOIN Justice..CaseAssignHist CAH  on CAH.CaseAssignmentHistoryID = CCH.CaseAssignmentHistoryIDCur
                    JOIN ISC..NodeListReporting NLR ON NLR.NodeID = CAH.NodeID
	                JOIN Justice..Party P ON P.PartyID = CAH.JudgeID
                WHERE CAH.CaseNbr = '{CaseNo}'
                ORDER BY CtS.SessionDate DESC
            "; 
            /*
                    AND ISNULL(CCH.CaseSecGrpID,0) IN (0, 9718)  	
                    AND NLR.NodeIDProduct = 1         
                    AND NLR.PreFileFlag = 0   					
                    AND NLR.OrgUnitTypeID in (2,4) 				
                    AND NOT NLR.NodeID IN (100100,100200) 		
                    AND NOT NLR.CourtTypeID = 3 				
                    AND NOT CCH.CaseUTypeID IN (2105,2107,2110,2112,2997) 
                    AND S.CancelledStatus = 0 
                    AND HE.CancelledReasonID IS NULL
                    AND S.RescheduleSettingID IS NULL
                    AND S.ResultID IS NULL
                    AND E.Deleted = 0                     
            */
            List<string> result = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Print column headers
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"{reader.GetName(i)}\t");
                            }
                            Console.WriteLine(new string('-', 50));

                            while (reader.Read())
                            {
                                string line = string.Empty; 
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    line += $"{reader[i]}\t";
                                }
                                result.Add(line);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex) { Console.WriteLine($"SQL Error: {ex.Message}"); }
            catch (Exception ex)    { Console.WriteLine($"General Error: {ex.Message}"); }

            return result;
        }
    }
}
