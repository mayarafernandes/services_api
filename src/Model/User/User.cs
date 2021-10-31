﻿using System;

namespace Company.Services.Model.User
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public User() { }

        public User(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}