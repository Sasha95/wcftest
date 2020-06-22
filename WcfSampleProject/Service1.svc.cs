using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfSampleProject
{
    public class Service1 : IService1
    {
        public void DeletePerson(int id)
        {
            PersonContext po = new PersonContext();
            var c = (from per in po.Persons where per.id == id select per).First();
            po.Persons.Remove(c);
            po.SaveChanges();
        }

        public IEnumerable<Person> GetPersons()
        {
            var persons = new List<Person>();
            PersonContext po = new PersonContext();
            persons = po.Persons.ToList();
            return persons;
        }

        public void InsertPerson(Person pobj)
        {
            PersonContext po = new PersonContext();
            po.Persons.Add(pobj);
            po.SaveChanges();
        }

        public void UpdatePerson(Person pobj)
        {
            PersonContext po = new PersonContext();
            var c = (from per in po.Persons where per.id == pobj.id select per).First();
            c.Name = pobj.Name;
            c.Address = pobj.Address;
            po.SaveChanges();
        }
    }
}
