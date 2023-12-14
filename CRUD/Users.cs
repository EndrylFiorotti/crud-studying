using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD {
    internal class Users {
        private string name;
        private int age;
        private string gender;

        public Users(string name, int age, string gender) {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public void SetName(string name) { this.name = name; }

        public string GetName() { return this.name; }

        public void SetAge(int age) { this.age = age; }

        public int GetAge() { return this.age; }

        public void SetGender(string gender) {  this.gender = gender; }

        public string GetGender() { return this.gender; }
    }
}
