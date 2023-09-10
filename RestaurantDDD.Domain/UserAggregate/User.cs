﻿using RestaurantDDD.Domain.Common.Models;
using RestaurantDDD.Domain.User.ValueObjects;

namespace RestaurantDDD.Domain.User
{
    public sealed class User : AggregateRoot<UserId>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private User(
            UserId id,
            string firstName,
            string lastName,
            string email,
            string password,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public User Craete(string firstName,
            string lastName,
            string email,
            string password) => new(UserId.CreateUnique(),
                                    firstName,
                                    lastName,
                                    email,
                                    password,
                                    DateTime.UtcNow,
                                    DateTime.UtcNow);

    }
}