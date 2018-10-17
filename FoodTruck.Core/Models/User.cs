using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Core.Models
{
    public class User : BindableBase
    {
        private string _email;
        public string Email { get { return _email; } set { SetProperty(ref _email, value); } }
        private string _passwordHash;
        public string PasswordHash { get { return _passwordHash; } set { SetProperty(ref _passwordHash, value); } }
        private decimal _id;
        public decimal Id { get { return _id; } set { SetProperty(ref _id, value); } }
        private string _firstName;
        public string FirstName { get { return _firstName; } set { SetProperty(ref _firstName, value); } }
        private string _lastName;
        public string LastName { get { return _lastName; } set { SetProperty(ref _lastName, value); } }
        private DateTime _birthDate;
        public DateTime BirthDate { get { return _birthDate; } set { SetProperty(ref _birthDate, value); } }
        private string _address;
        public string Address { get { return _address; } set { SetProperty(ref _address, value); } }
        private TypeGender _gender;
        public TypeGender Gender { get { return _gender; } set { SetProperty(ref _gender, value); } }
        private string _company;
        public string Company { get { return _company; } set { SetProperty(ref _company, value); } }
    }
}
