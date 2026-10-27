using Microsoft.AspNetCore.Mvc;

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
        
    }
}
