using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Wpf02Binding.Validations
{
    /*
        Validations(검증, 유효성 검사)
            - 사용자가 입력한 값이 올바른지 검사하는 클래스들을 모아두는 영역
             
        ProgressValidationRule
            - 사용자가 입력한 진행율 값이 숫자이고 0~100 범위인지 검사
            - Target에서 입력한 값을 Source에 저장하기 전에 검사하는 과정
    
        ValidationRule
         - WPF Binding에서 사용할 검증(유효성) 규칙을 만들 때 상속하는 클래스
         
        ValidationResult
         - 검증의 성공 또는 실패 결과를 반환
         
    */
    public class ProgressValidationRule : ValidationRule
    {
        /*
            Validate
             - 사용자가 입력한 값을 검사할 때 WPF가 자동으로 호출
             - 
        */
        public override ValidationResult Validate(
            object value, // TextBox에 입력한 값이 전달
            CultureInfo cultureInfo)
        {
            // 1. 숫자로 변환할 수 없으면 잘못된 입력으로 판단
            // 반환은 return new ValidationResult(false, "숫자를 입력하시오.")
            /*
                value?.ToString()
                 - value를 문자열(string)로 반환
                 - ?.는 null 조건 연산자로 value가 null이면 
                    ToString()을 실행하지 않고 null 반환

                int.TryParse()
                 - 문자열을 int로 변환할 수 있는지 시도하는 메서드
                 - 성공 : true, 실패 : false
                 
                out
                 - 메서드가 결과값을 바깥으로 전달할 때 사용하는 문법
                 - TryPares가 변환한 int 값을 progress 변수에 저장
                
                out int progress
                 - int progress : int 변수를 선언
                 - 변환에 성공하면 변환된 숫자가 progress에 저장
            */
            if(!int.TryParse(value?.ToString(), out int progress)) // !로 한번 꼬아서 변환 성공시엔 if문 실행 x,
                                                                   // 변환 실패시 !false => ture로 if문 내부 코드 실행 
            {
                return new ValidationResult(false, "숫자를 입력하시오.");
            }


            // 2. 0 ~ 100 사이의 값만 허용
            // return new ValidationResult(false, "0 ~ 100 사이의 숫자를 입력하시오."
            if (progress < 0 || progress > 100)
            {
                return new ValidationResult(false, "0 ~ 100 사이의 숫자를 입력하시오.");
            }

            return ValidationResult.ValidResult; // 검증을 통과한 값 반환
        }
    }
}
