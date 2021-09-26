using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book); // Converte um VO para uma Entidade
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity); // Converte uma Entidade para VO 
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book); // Converte um VO para uma Entidade
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity); // Converte uma Entidade para VO 
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }  
}
