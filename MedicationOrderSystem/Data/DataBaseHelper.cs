using System.Data.SQLite;

public class DatabaseHelper
{
    private const string ConnectionString = "Data Source=pharmacyOrders.db;Version=3;";

    public DatabaseHelper()
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Orders (
                    OrderId INTEGER PRIMARY KEY AUTOINCREMENT,
                    MedicationName TEXT NOT NULL,
                    MedicationType TEXT NOT NULL,
                    Quantity INTEGER NOT NULL,
                    Distributor TEXT NOT NULL,
                    PharmacyBranch TEXT NOT NULL,
                    OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP
                );";
            var command = new SQLiteCommand(createTableQuery, connection);
            command.ExecuteNonQuery();
        }
    }

    public void InsertOrder(string medicationName, string medicationType, int quantity, string distributor, string pharmacyBranch)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string insertQuery = @"
                INSERT INTO Orders (MedicationName, MedicationType, Quantity, Distributor, PharmacyBranch) 
                VALUES (@name, @type, @quantity, @distributor, @branch);";
            var command = new SQLiteCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@name", medicationName);
            command.Parameters.AddWithValue("@type", medicationType);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@distributor", distributor);
            command.Parameters.AddWithValue("@branch", pharmacyBranch);
            command.ExecuteNonQuery();
        }
    }
}
