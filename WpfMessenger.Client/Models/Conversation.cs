namespace WpfMessenger.Client.Models;

public sealed record Conversation( string Id, string Title, string Category, string Initials, string? EmployeeId, int UnreadCount, ChatMessage[] Messages)
{
    public static Conversation Direct(Employee employee) => new(
        "direct:" + employee.Id, employee.Name, $"개인 채팅 - {employee.Department}"
        , employee.Name[^1..], employee.Id, 0, []);
}

