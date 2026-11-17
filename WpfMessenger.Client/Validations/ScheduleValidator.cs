using System.Globalization;
using WpfMessenger.Client.Configuration;

namespace WpfMessenger.Client.Validations;

internal static class ScheduleValidator
{
    // 화면 표시와 저장에 동일한 24시간제 검사 적용
    public static bool TryParseStartTime(string input, out TimeOnly time) =>
        TimeOnly.TryParseExact(input.Trim(), MessengerConstants.TimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out time);

    // 시간 변환 성공 여부와 일정 저장 조건 확인
    public static bool TryValidate(DateTime? date, string title, string startTime, string location, out TimeOnly time)
    {
        bool hasValidTime = TryParseStartTime(startTime, out time);

        return (date.HasValue && !string.IsNullOrWhiteSpace(title) &&
            title.Length <= MessengerConstants.MaxScheduleTitleLength && location.Length <= MessengerConstants.MaxScheduleLocationLength) &&
            hasValidTime;
    }
}
