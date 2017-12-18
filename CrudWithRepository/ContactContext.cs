using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CrudWithRepository.Models;

namespace CrudWithRepository
{
    public class ContactContext : DbContext
    {
        public ContactContext()
            : base("name=ContactConnectionString")
        {
        }

        public DbSet<Contact> Contacts { get; set; } 
    }
}