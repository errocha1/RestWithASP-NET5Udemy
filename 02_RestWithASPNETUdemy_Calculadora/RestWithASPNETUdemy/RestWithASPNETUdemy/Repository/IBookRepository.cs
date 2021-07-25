using RestWithASPNETUdemy.Models;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository
{
     public interface IBookRepository
    {
        Book Create(Book person);

        Book Update(Book person);

        void Delete(int id);

        Book FindById(int id);

        List<Book> FindAll();

        bool Exists(int id);        
    }
}
