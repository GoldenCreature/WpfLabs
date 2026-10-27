using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf01Basic
{
    /*
        WPF 프로젝트 구조
        WpfLabs (솔루션)
         |- Wpf01Basic (프로젝트)
            |- Dependencies (종속성)
            |- App.xaml
            |- MainWindow.xaml

        Solution (솔루션)
         - Visual Studio에서 하나 이상의 Project를 관리하는 단위

        Project (프로젝트)
         - 실제 프로그램을 구성하는 Source Code, Resource, Configuration File 등을 관리하는 단위
        
        Dependencies (종속성)
         - 현재 Project가 실해애되기 위해 필요한 Framework, Library, Package 등의 의존성을 관리
        
        Framework (프레임워크)
         - 프로그램 개발에 필요한 기본 구조와 기능을 제공하는 개발 환경

        Microsoft.NETCore.APP
         -  .NET Application의 기본 실행 환경을 제공

            .NET 이란?
                - Microsoft에서 제공하는 Software Development Platform
                - C# 프로그램을 개발하고 실행하기 위한 환경과 기능을 제공

            C# 이란?
                - 프로그램의 동작을 작성하는 Programming Language
            
            WPF
                - .NET 기반의 WIndows Desktop UI Framework
                
            Visual Studio 2022
                - 코드를 작성하고 Build, Debug하는 IDE
            
            * Visual Studio > C# > .NET > WPF > Windows Desktop Application
    */
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}