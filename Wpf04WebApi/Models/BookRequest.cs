namespace Wpf04WebApi.Models
{
    /*
     * BookRequest
     *  - Client가 도서를 추가하거나 수정할 때
     *    Server에게 전달하는 데이터
     *    
     * DTO (Data Transfer Object)
     *  - 프로그램 사이에서  데이터를 전달하기 위한 객체
     *  - Book과 다르게 Id가 존재하지 않는다.
     *  
     *  Model Binding
     *   - Request Body의 JSON 데이터를
     *     C# 객체로 자동 변환하는 기능
    */
    public class BookRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public bool IsBorrowed { get; set; }  
    }
}
