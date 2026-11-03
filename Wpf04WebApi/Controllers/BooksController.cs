using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wpf04WebApi.Models;
using Wpf04WebApi.Services;

namespace Wpf04WebApi.Controllers
{
    /*
     * BooksController
     *  - 도서와 관련된 HTTP Requset를 받고
     *    HTTP Response를 반환한다.
     *    
     *  API (Aplication Programming Interface)
     *   - 다른 프로그램이 기능이나 데이터를 사용할 수 있도록 
     *     제공하는 인터페이스(규칙, 연결 다리)
     *   
     *  Web API
     *   - HTTP를 이용해서 제공하는 API
     *   
     *  REST
     *   - Resource는 URL로 표현하고
     *     동작은 HTTP Method로 구분하는 방식
     *     
     *  CRUD
     *  Create = POST
     *  Read   = GET
     *  Update = PUT / PATCH
     *  Delete  = DELETE
     *  
     *  Attribute
     *   - 코드에 추가 정보를 제공하는 Metadata
     *   
     *  [ApiController]
     *   - Web API Controller로 지정
     *   
     *  [Route("api/books")]
     *   - 기본 URL 지정
     *   
     *  [HttpGet]                   : GET 요청 처리
     *  [HttpGet("{id:int}")]       : GET 요청 + id를 URL에서 받음
     *  [HttpPost]                  : POST 요청 처리
     *  [HttpPut("{id:int}")]       : PUT 요청 + id를 URL에서 받음
     *  [HttpDelete("{id:int}")]    : DELETE 요청 + id를 URL에서 받음
     *  
    */
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        /*
         * Controller Injection
         *  - 생성자를 통해 필요한 객체를 외부에서 전달받는 DI 방식
         *  - Program.cs에 등록된 BookService가 IBookService 형태로 전달
         */

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /*
         *  전체 도서 조회
         *  Get /api/books
         *  
         *  성공: 200 OK
         */
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Book> books = _bookService.GetAll();

            return Ok(books);
        }

        /*
         *  특정 도서 조회
         *  GET /api/books/1
         * 
         *  Route Parameter(= Path Parameter)
         *   URL의 일부를 값으로 전달한다.
         *  
         *  /api/books/1
         *   -> id = 1
         */
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Book? book = _bookService.GetByID(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /*
         *  도서 검색
         *  GET /api/books/search?keyword=Code
         *  
         *  Query String (= Query Parameter)
         *   URL 뒤의 ?를 이용해서 그 이후의 문자열 전체를 의미하며,
         *   Key-Value 형태로 파라미터를 전달한다.
         *   2개 이상인 경우 &를 이용하여 구분한다.
         *   
         *   /api/books/search?keyword=Code
         *    -> keyword = code 와 같이 전달
         *    
         *   /api/books/search?keyword=Code&author=홍길동
         *    -> keyword = Code, author = 홍길동
         */
        [HttpGet("search")]
        public IActionResult Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest("검색어를 입력해주세요.");
            }

            List<Book> result = _bookService.Search(keyword);

            return Ok(result);
        }

        /*
         *  새로운 도서 추가
         *  POST /api/books
         *  
         *  Request Body의 JSON 형태로 전달이 되고,
         *  BookRequest 객체로 변환된다.
         *  
         *  성공 
         *  201 Created
         */
        [HttpPost]
        public IActionResult Create(BookRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return BadRequest("도서 제목을 입력해주세요.");
            }

            if (string.IsNullOrWhiteSpace(request.Author))
            {
                return BadRequest("저자를 입력해주세요.");
            }

            Book newBook = _bookService.Create(request);

            /*
             *  CreatedAtAction
             *  201 Created와 함께 생성한 Resource 정보를 반환
             */
            return CreatedAtAction(nameof(GetById)
                                  , new {id = newBook.Id}
                                  , newBook); 

        }

        /*
         *  기존 도서 수정
         *  PUT /api/books/1
         *  
         *  성공
         *  200 OK
         */
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, BookRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return BadRequest("도서 제목을 입력해주세요.");
            }

            if (string.IsNullOrWhiteSpace(request.Author))
            {
                return BadRequest("저자를 입력해주세요.");
            }

            Book? book = _bookService.Update(id, request);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        /*
         *  도서 삭제
         *  DELETE /api/books/1
         *  
         *  성공
         *  204 No Content
         */
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            bool result = _bookService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
