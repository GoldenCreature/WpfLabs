/*
    App.xaml.cs
        - App.xaml과 연결되는 C# 코드 파일
        - App 클래스가 Application을 상속받아 WPF 프로그램 전체를 관리

    using
        - 다른 namespace에 있는 클래스를 사용하기 위해 명시 
        - 짧은 이름으로 사용할 수 있다.
    예시) 
    System.Windows.Application; 가 있을 때
    using System.Windows; 선언 후
    짧게 Application 이름으로 사용할 수 있다.

    namespace
        - 관련된 클래스 등의 이름을 하나의 공간으로 묶어 관리
        - 코드의 이름과 소속을 구분하기 위한 개념적인 공간
        - 관련 코드 분류, 이름 충돌 방지, 프로젝트 구조 관리
 */

using System.Configuration;
using System.Data;
using System.Windows;

namespace Wpf01Basic
{
    /*
        public 
            - 접근 제한자(Access Modifier)
            - 클래스나 멤버를 어디에서 사용할 수 있는지 정의
        
        멤버(Member)
            - 클래스 안에 정의되는 구성 요소
            - Field, Property, Method, Constructor
        
        partial
            - 하나의 클래스를 여러 파일로 나누어 작성할 수 있게 해주는 키워드
            - 자동 생성 코드와 개발자가 작성한 코드를 연결할 때 사용

        상속(Inheritance)
            - ": Application" 과 같이 사용
            - 기존 클래스의 기능을 새로운 클래스가 물려받는 것
        
    */
    public partial class App : Application
    {
    }

}
