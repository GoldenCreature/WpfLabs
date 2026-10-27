/*
 * Program.cs
 *  - ASP.NET Core Web API 프로그램이 시작되는 파일
 *  - Web Server에 필요한 기능을 등록하고 Server를 실행
 *  
 * 이전의 WPF 프로젝트
 *  -> Window를 실행하는 Desktop Application
 *  
 * ASP.NET Core web API
 *  -> Client의 HTTP Request를 기다리는 Server를 실행
 *  
 *  Client 
 *   - 고객, 서비스를 Request(요청)하는 측
 *   - Server에게 데이터나 기능을 요청하는 프로그램
 *   
 *  Server
 *   - 서비스를 제공하는 측
 *   - Client가 보낸 Request를 받아 처리하고
 *     결과를 Response(응답)로 반환하는 프로그램
 *  
 *  Requset  : Client가 Server에게 보내는 요청
 *  Response : Server가 Request에 대해 처리 후 Client에게 반환하는 응답
 *  
 *  흐름) Client -> Request -> Server -> Response -> Client
 *  
 *  NetWork
 *   - 컴퓨터와 컴퓨터 또는 프로그램과 프로그램이 연결되어
 *     데이터를 주고받는 구조를 의미
 *   예시) Client <-> Server
 *   
 *  HTTP (HyperText Transfer Protocol)
 *   - 확장된 텍스트 전송 통신 규약 
 *   - Client와 Server가 데이터를 주고받기 위해 사용하는
 *     대표적인 통신 규약    
 *  
 *  IP (Internet Protocol)
 *   - 네트워크에서 컴퓨터들이 장치를 식별하고 
 *     데이터를 주고받기 위한 통신 규약
 *     
 *  IP Address
 *   - 네트워크에서 컴퓨터를 구분하기 위한 주소
 *   
 *  Port Number
 *   - 한 컴퓨터 안에서 어떤 서버 프로그램과 통신할 것인지
 *     구분하는 번호
 *   
 *  예시) 127.0.0.1:5000
 *  127.0.0.1 -> 어느 컴퓨터인가?
 *  5000      -> 그 컴퓨터의 어느 서버 프로그램인가?
 *  
 *  URL (Uniform Resource Locator)
 *   - 통일된 자원 위치 지정자
 *   - 인터넷에 있는 정보의 위치를 나타내는 주소
 *  예시) http://127.0.0.1:5000/hello
 *  http://   -> Protocol
 *  127.0.0.1 -> IP Address
 *  5000      -> Prot Number
 *  /hello    -> Path
 *     
 *  "HTTP를 이용하여 내 컴퓨터의 5000번 포트에서 실행중인
 *   서버에게 /hello 기능을 요청한다."
*/

// Web Application을 생성하기 위한 빌더(Builder) 생성
using Wpf04WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Web Server가 사용할 주소를 직접 지정
// Server 주소 : http://localhost:5000
// API 주소 예 : http://localhost:5000/api/books
builder.WebHost.UseUrls("http://localhost:5000");

// Controller를 사용할 수 있도록 필요한 기능을 등록
builder.Services.AddControllers();

/*
 * DI (Dependency Injection)
 *  - 필요한 객체를 직접 생성하지 않고
 *    외부에서 전달받아 사용하는 방식
 *    
 * IBookService가 필요하면 BookService 객체를 제공하도록 등록한다.
 * 
 * Singleton
 *  - Server가 실행되는 동안 하나의 BookService 객체를 계속 사용해라.
 *  - BookService가 List<Book> 데이터를 가지고 있으니 Singleton을 사용한다.
 */
builder.Services.AddSingleton<IBookService, BookService>();

// 위에서 설정한 내용을 기반으로 실제 WebApplication 객체 생성
var app = builder.Build();

// Controller에 작성된 Route와 실제 HTTP Request를 연결
app.MapControllers();

// Web Server를 실행
app.Run();

/*
 *  MVC (Model - View - Controller) (MVC 패턴)
 *  Model      : 데이터와 데이터 구조 -> 데이터
 *  View       : 사용자에게 보여주는 화면 -> 화면
 *  Controller : 사용자의 요청을 받아 Model과 View를 연결 -> 요청 처리
 *  
 *  Builder Pattern (빌더 패턴)
 *   - 복잡한 객체를 한 번에 만들지 않고,
 *     필요한 설정을 하나씩 조립해서 만드는 방식
 *     
 *  var builder = WebApplication.CreateBuiler(args)
 *   -> WebApplication 객체를 생성하기 위한 건축가 생성
 *  
 *  builder.WebHost.UseUrls("...")
 *   -> 객체의 설정을 추가
 *   
 *  // TODO 필요한 설정을 계속 추가...
 *   
 *  var app = builder.Build()
 *   -> 지금까지 설정한 내용을 바탕으로 실제 사용할 객체 생성
*/