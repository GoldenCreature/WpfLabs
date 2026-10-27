namespace Wpf04WebApi.Models
{
    /*
     * Book
     *  - Server에서 관리할 하나의 도서 데이터를 표현하는 Model
     * 
     * Model
     *  - 프로그램에서 사용하는 데이터의 구조를 표현하는 객체
     *  - Server 내부에서는 C# 객체로 데이터를 사용
     *      Id = 1
     *      Title = "Clean Code:
     *      ...
     *  - Client에게 데이터를 전달할 때는 ASP.NET Core가 C# 객체를 JSON으로 변환
     *      {
     *          "id": 1,
     *          "title": "Clean Code,
     *          ...
     *      }
     *  
     *  Serialization (직렬화)
     *   - 객체를 외부(Network)로 전달하거나 저장할 수 있는 형태로 변환하는 과정
     *   - C# Object -> JSON
     *   
     *  Deserialization (역직렬화)
     *   - 전달받은 데이터를 다시 객체로 변환하는 과정
     *     (JSON -> C# Object)
     *  
     */
    public class Book
    {
        // 각각의 Book을 구분하기 위한 고유 번호
        // -> Database에서 Primary Key로 사용

        // 도서 id
        public int Id { get; set; }

        // 도서 제목
        public string Title { get; set; }

        // 저자
        public string Author { get; set; } = string.Empty;

        // 대여 여부 (대여 중인지...)
        public bool IsBorrowed { get; set; }

        public string Status
        {
            get
        }
    }
}
