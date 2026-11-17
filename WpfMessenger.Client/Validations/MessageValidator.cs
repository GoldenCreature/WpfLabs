using WpfMessenger.Client.Configuration;

namespace WpfMessenger.Client.Validations;

internal static class MessageValidator
{
    // 공백뿐인 메시지와 글자 수 제한 검사
    public static bool IsVallid(string? text) =>
        !string.IsNullOrWhiteSpace(text) && text.Length <= MessengerConstants.MaxMessageLength;
}
