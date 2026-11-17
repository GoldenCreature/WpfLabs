using System.Globalization;
using System.Text.Json.Serialization;
using WpfMessenger.Client.Configuration;

namespace WpfMessenger.Client.Models;

public sealed record ScheduleEntry(Guid Id, DateTime Date, TimeOnly StartTime, string Title, string Location)
{
    //화면용 시작 시간
    [JsonIgnore]
    public string DisplayTime => 
        StartTime.ToString(MessengerConstants.TimeFormat, CultureInfo.InvariantCulture);
}

