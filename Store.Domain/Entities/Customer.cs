﻿using Store.Domain.ValueObjects;
using Store.Shared.Entities;
using System;

namespace Store.Domain.Entities
{
    public class Customer : Entity
    {
        protected Customer()
        {

        }

        public Customer(Name name, Email email, Document document, User user)
        {
            Name = name;
            BirthDate = null;
            Email = email;
            Document = document;
            User = user;

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
        }

        public Name Name { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public User User { get; private set; }

        public void Update(Name name, DateTime? birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
    }
}
