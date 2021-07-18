using RestWithASPNETUdemy.Models;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
           
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for (int i=0; i <= 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }



        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FisrtName = "Edu",
                LastName = "Rocha",
                Address = "Rua A, 20",
                Gender = "Masculino"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = i,
                FisrtName = "Edu - " + i.ToString(),
                LastName = "Rocha - " + i.ToString(),
                Address = "Rua A, 20 - " + i.ToString(),
                Gender = "Masculino - " + i.ToString()
            };
        }
    }
}
