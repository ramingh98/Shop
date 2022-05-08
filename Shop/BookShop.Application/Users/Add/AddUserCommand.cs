using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.UserAgg.Enums;
using Common.Application;
using Common.Domain.ValueObjects;

namespace BookShop.Application.Users.Add
{
    public class AddUserCommand : IBaseCommand
    {
        public AddUserCommand(string name, string family, string phoneNumber, string email, string password, Gender gender)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
        }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Gender Gender { get; private set; }
    }
}
