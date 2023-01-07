using System;
using System.Collections.Generic;

namespace MyProject.Repositories.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public override string ToString()
        {
            return $"Role: Id = {Id}, Name={Name}, Description={Description}";
        }
    }
}
