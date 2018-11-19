using FluentValidator;
using System;

namespace Store.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            Active = true;
        }

        public Guid Id { get; private set; }
        public bool Active { get; private set; }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;
    }
}
