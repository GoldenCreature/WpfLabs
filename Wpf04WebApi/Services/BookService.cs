using System.Numerics;
using Wpf04WebApi.Models;

namespace Wpf04WebApi.Services
{
    /*
     * BookService
     *  - 도서와 관련된 실제 기능을 처리
     *  
     *  Service
     *   - Controller와 데이터(Database) 사이에서
     *     프로그램의 기능과 업무 로직을 담당
     *  
     *  단, 실제 Database 대신 List<Book>을 활용
    */
    public class BookService : IBookService
    {
        // 임의의 도서 정보
        private readonly List<Book> _books = new()
        {
            new Book
            {
                Id = 1,
                Title = "Clean Code",
                Author = "Robert C. Martin",
                IsBorrowed = false
            },
            new Book
            {
                Id = 2,
                Title = "C# Programing",
                Author = "홍길동",
                IsBorrowed = true
            },
            new Book
            {
                Id = 3,
                Title = "ASP.Net 이란?",
                Author = "강감찬",
                IsBorrowed = false
            }
        };

        // 임의의 순번
        private int _nextId = 4;

        /*
         *  전체 도서를 반환
        */
        public List<Book> GetAll()
        {
            return _books;
        }

        /*
         * Id가 일치하는 도서 하나를 찾는다.
         */
        public Book? GetByID(int id)
        {
            return _books.FirstOrDefault(
                book => book.Id == id
                ); // 조건에 맞는 첫 번째 데이터를 반환, 없으면 null 반환
        }

        /*
         *  제목에 검색어가 포함된 도서들을 반환한다.
         */
        public List<Book> Search(string keyword)
        {
            return _books
                .Where(book =>
                    book.Title.Contains(
                        keyword,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /*
         *  새로운 Book을 생성하고 List에 추가한다.
         */
        public Book Create(BookRequest request)
        {
            Book newBook = new Book
            {
                Id = _nextId++,
                Title = request.Title,
                Author = request.Autor,
                IsBorrowed = request.IsBorrowed
            };
            _books.Add(newBook);
            return newBook;
        }

        /*
         *  Id가 일치하는 Book을 찾아 새로운 값으로 수정한다.
         */
        public Book? Update(int id, BookRequest request)
        {
            Book? book = GetByID(id);

            if(book == null)
            {
                return null;
            }

            book.Title = request.Title;
            book.Author = request.Autor;
            book.IsBorrowed = request.IsBorrowed;

            return book;
        }

        /*
         *  Id가 일치하는 Book을 삭제한다.
         *  성공하면 true, 찾지 못하면 false를 반환
         */
        public bool Delete(int id)
        {
            Book? book = GetByID(id);

            if (book == null)
            {
                return false;
            }

            _books.Remove(book);

            return true;
        }

    }
}
