using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRUD {
    internal class Controller {
        private static readonly Connection database = new Connection();

        public bool VerifyUserInfo(string name, string age, string gender) {
            try {
                int ageInt = int.Parse(age);
                if ((gender.Length == 1) && (gender.Equals("M") || gender.Equals("F"))) {
                    database.AddUser(new Users(name, ageInt, gender));
                    return true;
                }
                Console.WriteLine("\nO genêro deve ser um texto de tamanho igual a 1, e o texto deve ser M ou F.\n");
                return false;
            } catch (FormatException) {
                Console.WriteLine("\nA idade precisa ser um númeral inteiro.\n");
                return false;
            }
        }

        public bool VerifyUserUpdate(string id, string attribute, string value) {
            try {
                int idInt = int.Parse(id);
                if (attribute.Equals("name")) {
                    database.UpdateUser(idInt, attribute, value);
                    return true;
                } else if (attribute.Equals("gender")) {
                    if (value.Length == 1 && (value.Equals("M") || value.Equals("F"))) {
                        database.UpdateUser(idInt, attribute, value);
                        return true;
                    }
                    Console.WriteLine("\nO genêro deve ser um texto de tamanho igual a 1, e o texto deve ser M ou F.\n");
                    return false;
                } else if (attribute.Equals("age")) {
                    try {
                        int ageInt = int.Parse(value);
                        database.UpdateUser(idInt, attribute, ageInt);
                        return true;
                    } catch (FormatException) {
                        Console.WriteLine("\nA idade precisa ser um númeral inteiro.\n");
                        return false;
                    }
                }
                Console.WriteLine("\nO Atributo precisa ser válido.\n");
                return false;
            } catch (FormatException) {
                Console.WriteLine("\nO id precisa ser um númeral inteiro.\n");
                return false;
            }
        }

        public bool VerifyId(string id) {
            try {
                int idInt = int.Parse(id);
                database.DeleteUser(idInt);
                return true;
            } catch (FormatException) {
                Console.WriteLine("\nO id precisa ser um númeral inteiro.\n");
                return false;
            }
        }

        public void GetUsers() {
            database.GetUsers();
        }

        public void GetData(string table) {
            database.GetData(table);
        }
    }
}
