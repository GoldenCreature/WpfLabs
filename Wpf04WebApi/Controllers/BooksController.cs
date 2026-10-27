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
    }
}
