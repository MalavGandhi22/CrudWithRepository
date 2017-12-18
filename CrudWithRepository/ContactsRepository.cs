using CrudWithRepository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CrudWithRepository
{
    public class ContactsRepository : IRepository<Contact>
    {
        private ContactContext entities = new ContactContext();

        public IEnumerable<Contact> GetAll(Func<Contact, bool> predicate = null)
        {
            if (predicate != null)
            {
                if (predicate != null)
                {
                    return entities.Contacts.Where(predicate);
                }
            }

            return entities.Contacts;
        }

        public Contact Get(Func<Contact, bool> predicate)
        {
            return entities.Contacts.FirstOrDefault(predicate);
        }

        public void Add(Contact entity)
        {
            entities.Contacts.Add(entity);
        }

        public void Attach(Contact entity)
        {
            entities.Contacts.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Contact entity)
        {
            entities.Contacts.Remove(entity);
        }

        internal void SaveChanges()
        {
            entities.SaveChanges();
        }
    }
}