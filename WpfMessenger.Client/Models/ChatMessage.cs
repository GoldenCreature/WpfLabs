using System.Globalization; // CultureInfo 사용을 위한 선언
using System.Text.Json.Serialization;
using WpfMessenger.Client.Configuration;

namespace WpfMessenger.Client.Models;

// 메시지 작성자, 내용, 전송시간, 내가 전송했는지
public sealed record ChatMessage(string Author, string Text, DateTime SentAt, bool IsMine)
{
    // 화면용 시각 형식
    [JsonIgnore]
    public string TimeLabel => 
        SentAt.ToString(MessengerConstants.TimeFormat, CultureInfo.InvariantCulture);
}

