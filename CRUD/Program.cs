using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD {
    internal class Program {
        static Controller controller = new Controller();

        static void Main(string[] args) {
            bool isToContinue = true;

            do {
                Console.WriteLine(
                    "Digite um número para escolher uma das opções: \n" +
                    "1 - Criar novo usuário.\n" +
                    "2 - Atualizar um usuário. \n" +
                    "3 - Deletar um usuário. \n" +
                    "4 - Mostrar todos os usuários. \n" +
                    "5 - Sair."
                );
                string choice = Console.ReadLine();

                try {
                    int choiceInt = int.Parse(choice);
                    if (choiceInt > 0 && choiceInt < 5) Choices(choice);
                    else isToContinue = false;
                } catch (FormatException) {
                    Console.WriteLine("A string não é um formato válido de número.");
                }

            } while (isToContinue);
        }

        static void Choices(string choise) {
            switch (choise) {
                case "1":
                    CreateUser(); break;
                case "2":
                    UpdateUser(); break;
                case "3":
                    DeleteUser(); break;
                case "4":
                    ShowUsers(); break;
            }
        }

        static void CreateUser() {
            bool isWrong;
            do {
                Console.WriteLine("Digite o nome do usuário: ");
                string name = Console.ReadLine();
                Console.WriteLine("Digite a idade do usuário: ");
                string age = Console.ReadLine();
                Console.WriteLine("Digite o genêro do usuário:\n(obs: digite 'M' para Masculino e 'F' para feminino).");
                string gender = Console.ReadLine();

                isWrong = !controller.VerifyUserInfo(name, age, gender);
            } while (isWrong);
        }

        static void UpdateUser() {
            bool isWrong;
            do {
                Console.WriteLine("Digite o id do usuário que você deseja atualizar: ");
                string id = Console.ReadLine();
                Console.WriteLine("Digite qual atributo você deseja alterar: ");
                string attribute = Console.ReadLine();
                Console.WriteLine("Novo valor: ");
                string value = Console.ReadLine();

                isWrong = !controller.VerifyUserUpdate(id, attribute, value);
            } while (isWrong);
        }

        static void DeleteUser() {
            bool isWrong;
            do {
                ShowUsersSimple();
                Console.WriteLine("Insira o Id do usuário que você deseja excluir: ");
                string id = Console.ReadLine();
                isWrong = !controller.VerifyId(id);
            } while (isWrong);
        }

        static void ShowUsers() {
            controller.GetUsers();
        }

        static void ShowUsersSimple() {
            controller.GetData("Users");
        }
    }
}
