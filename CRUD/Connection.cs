using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD {
    internal class Connection {

        MySqlConnection connection;

        public Connection() {
            ConnectionDB();
        }

        public void ConnectionDB() {
            try {
                connection = new MySqlConnection("server=localhost;uid=root;pwd=#Ef-44717959884;database=StudyingDB");
                connection.Open();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        public void GetData(string table) {
            MySqlCommand command = new MySqlCommand($"SELECT * FROM {table}", connection);
            using (MySqlDataReader reader = command.ExecuteReader()) {
                Console.WriteLine("\nLista completa: \n");
                while (reader.Read()) {
                    Console.WriteLine($"{reader["id"]} => {reader["name"]}");
                }
                Console.WriteLine("\nFim.\n");
            }
        }

        public void GetUsers() {
            MySqlCommand command = new MySqlCommand($"SELECT * FROM Users", connection);
            using (MySqlDataReader reader = command.ExecuteReader()) {
                Console.WriteLine("\nUsuários cadastrados: \n");
                while (reader.Read()) {
                    Console.WriteLine($"{reader["id"]} => {reader["name"]}, {reader["age"]} anos, {reader["gender"]}");
                }
                Console.WriteLine("\nFim.\n");
            }
        }

        public void AddUser(Users users) {
            string insert = "INSERT INTO Users VALUES (null, @value1, @value2, @value3);";
            using (MySqlCommand command = new MySqlCommand(insert, connection)) {
                command.Parameters.AddWithValue("@value1", users.GetName());
                command.Parameters.AddWithValue("@value2", users.GetAge());
                command.Parameters.AddWithValue("@value3", users.GetGender());
                command.ExecuteNonQuery();
                Console.WriteLine("\nInserção efetuado com sucesso!!!\n");
            }
        }

        public void DeleteUser(int id) {
            string delete = "DELETE FROM Users WHERE id = @id";
            using (MySqlCommand command = new MySqlCommand(delete, connection)) {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                Console.WriteLine("\nExclusão efetuada com sucesso!!!\n");
            }
        }

        public void UpdateUser(int id, string attribute, string value) {
            string update = $"UPDATE Users SET {attribute} = @value WHERE id = @id";
            using (MySqlCommand command = new MySqlCommand(update, connection)) {
                command.Parameters.AddWithValue("@value", value);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                Console.WriteLine("\nValor modificado com sucesso!!!\n");
            }
        }

        public void UpdateUser(int id, string attribute, int value) {
            string update = $"UPDATE Users SET {attribute} = @value WHERE id = @id";
            using (MySqlCommand command = new MySqlCommand(update, connection)) {
                command.Parameters.AddWithValue("@value", value);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                Console.WriteLine("\nValor modificado com sucesso!!!\n");
            }
        }
    }
}
