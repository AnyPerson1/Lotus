using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Server.Logger;

namespace Lotus_Server_Form.Classes.Layers.Active_Layer
{
    public static class SqlFalanXD
    {
        private static MySqlConnection connection;

        //metod1
        public static void CreateConnection(string connectionString)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                Logger.Log("Connection Successful!",Logger.LogLayer.Layer1);
            }
            catch (Exception ex)
            {
                Logger.Log("Connection Failed: " + ex.Message,Logger.LogLayer.Layer2);
            }
        }

        //metod2
        public static void CreateTableIfNotExists(string tableName)
        {
            string query = $"CREATE TABLE IF NOT EXISTS {tableName} (id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(100))";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            try
            {
                cmd.ExecuteNonQuery();
                Logger.Log($"Table '{tableName}' checked/created.", Logger.LogLayer.Layer1);
            }
            catch (Exception ex)
            {
                Logger.Log("Error Creating Table: " + ex.Message,Logger.LogLayer.Layer2);
            }
        }

        //metod3
        public static void AddServerAndCreateTable(string serverName)
        {
            try
            {
                // Genel tabloyu oluştur (sunucular listesi)
                string generalTableQuery = "CREATE TABLE IF NOT EXISTS servers (id INT AUTO_INCREMENT PRIMARY KEY, server_name VARCHAR(100))";
                MySqlCommand generalCmd = new MySqlCommand(generalTableQuery, connection);
                generalCmd.ExecuteNonQuery();

                // Sunucuyu genel tabloya ekle
                string insertServerQuery = $"INSERT INTO servers (server_name) VALUES ('{serverName}')";
                MySqlCommand insertServerCmd = new MySqlCommand(insertServerQuery, connection);
                insertServerCmd.ExecuteNonQuery();

                // Eklenen sunucunun id'sini al
                string getServerIdQuery = $"SELECT id FROM servers WHERE server_name = '{serverName}'";
                MySqlCommand getServerIdCmd = new MySqlCommand(getServerIdQuery, connection);
                int serverId = Convert.ToInt32(getServerIdCmd.ExecuteScalar());

                // Sunucu için tablo oluştur ve genel tablodaki id'yi foreign key olarak kullan
                string serverTableQuery = $@"
                CREATE TABLE IF NOT EXISTS {serverName} (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    name VARCHAR(100),
                    server_id INT,
                    FOREIGN KEY (server_id) REFERENCES servers(id) ON DELETE CASCADE
                )";
                MySqlCommand serverCmd = new MySqlCommand(serverTableQuery, connection);
                serverCmd.ExecuteNonQuery();

                Logger.Log($"Sunucu '{serverName}' eklendi ve kendi tablosu '{serverName}' oluşturuldu. Foreign Key ayarlandı.",Logger.LogLayer.Layer1);
            }
            catch (Exception ex)
            {
                Logger.Log("Sunucu ekleme ve foreign key ayarlama hatası: " + ex.Message,Logger.LogLayer.Layer2);
            }
        }
        //metod4 ****istan'da

        //metod5
        public static void CreateUserTableAndAddUser(string userName, string password, string email)
        {
            string createUserTableQuery = "CREATE TABLE IF NOT EXISTS users (id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(100), password VARCHAR(100), email VARCHAR(100))";
            MySqlCommand cmd = new MySqlCommand(createUserTableQuery, connection);

            try
            {
                // Kullanıcılar tablosunu oluştur
                cmd.ExecuteNonQuery();

                // Kullanıcı ekleme
                string insertUserQuery = $"INSERT INTO users (name, password, email) VALUES ('{userName}', '{password}', '{email}')";
                MySqlCommand insertUserCmd = new MySqlCommand(insertUserQuery, connection);
                insertUserCmd.ExecuteNonQuery();

                Logger.Log($"User '{userName}' added to the users table.",Logger.LogLayer.Layer1);
            }
            catch (Exception ex)
            {
                Logger.Log("Error Creating User Table or Adding User: " + ex.Message,Logger.LogLayer.Layer2);
            }
        }


    }
}
