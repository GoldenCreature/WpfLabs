using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Wpf03MVVM.Converters
{
    /*
        Converters
        Convert : 변환, Converter : 변환기
        Source의 값을 Target에서 사용하기 좋은 형태로 변환하는 클래스를 모아두는 영역

        ProgressStatusConverter
            : 숫자로 저장된 Progress를 업무 상태의 문자열로 변환한다.
        예시) 
        Progress = 0      -> "시작 전"
        Progress = 1 ~ 99 -> "진행 중"
        Progress = 100    -> "완료"

        IValueConverter
         - 하나의 Binding 값을 변환할 때 사용하는 인터페이스
        Convert     : Source -> Target 방향으로 값을 변환
        ConvertBack : Target -> Source 방향으로 값을 변환
    */
    public class ProgressStatusConverter : IValueConverter
    {
        /*
            Convert
            Source값이 int(Progress)라면, 값의 범위에 따라
            업무 상태를 나타내는 문자열로 변환해서 반환한다
         */
        public object Convert(
            object value, // Binding된 Progress 값이 전달
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            // value가 int 타입이라면, 값을 int 타입 변수 progress에 담아라(타입 검사)
            if(value is int progress)
            {
                if (progress == 0)
                    return "시작 전";
                if (progress < 100)
                    return "진행 중";
                return "완료";
            }
            return "";
        }
        /*
            ConvertBack
            Target 값을 다시 Source 형태로 변환
        */

        public object ConvertBack(
            object value, 
            Type targetType, 
            object parameter, 
            CultureInfo culture)
        {
            return Binding.DoNothing; // Source 값을 변경하지 않는다.
        }
    }
}
