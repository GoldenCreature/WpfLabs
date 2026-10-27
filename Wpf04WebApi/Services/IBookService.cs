using Wpf04WebApi.Models;

namespace Wpf04WebApi.Services
{
    /*
     *  IBookService
     *   - BookService가 제공해야 하는 기능을 정의
     *   
     *  Interface
     *   - 클래스가 어떤 기능을 제공해야 하는지 규칙만 정의
     *   
     *  Controller는 실제 BookService가 아니라
     *  IBookService에 의존한다.
    */
    public interface IBookService
    {
        List<Book> GetAll();
        Book? GetByID(int id);
        List<Book> Search(string keyword);
        Book Create(BookRequest request);
        Book? Update(int id, BookRequest request);
        bool Delete(int id);
    }
}
