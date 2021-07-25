using RestWithASPNETUdemy.Models;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);

        Book Update(Book book);

        void Delete(int id);

        Book FindById(int id);

        List<Book> FindAll();
    }
}
