using WpfMessenger.Client.Models;

namespace WpfMessenger.Client.Data;

// 임시 데이터
internal static class TempMessengerData
{
    public static IReadOnlyList<Employee> Employees { get; } =
    [
        new("E01", "김서연", "제품개발팀", "팀장"),
        new("E02", "박지훈", "제품개발팀", "소프트웨어 개발"),
        new("E03", "이민지", "운영지원팀", "운영 지원"),
        new("E04", "정하늘", "운영지원팀", "인사-총무"),
    ];

    public static Conversation[] Converstations(DateTime now)
    {
        var user1 = Conversation.Direct(Employees[0]); // 김서연
        var user2 = Conversation.Direct(Employees[1]); // 박지훈

        return
        [
            new("team:product", "제품개발팀", "그룹 채팅 - 3명", "개", null, 0,
            [
                new("김서연", "오후 회의 전에 이번 주 배포 범위를 확인해 주세요.", now.AddMinutes(-22), false),
                new("나", "채팅 화면과 메시지 입력까지 이번 주 범위로 정리하겠습니다.", now.AddMinutes(-18), true),
                new("박지훈", "좋습니다. 회의에서 테스트 항목도 같이 확인하시죠.", now.AddMinutes(-15), false)
            ]),
            user1 with { UnreadCount = 1, Messages = [
                new("김서연", "내일 오후 2시에 잠깐 시간 되세요?", now.AddMinutes(-26), false)
            ]},
            new("team:operations", "운영지원팀", "그룹 채팅 - 3명", "개", null, 1, 
            [
                new("이민지", "운영 지원 관련해서 보내드렸던 서류 작성 다 되셨나요?", now.AddMinutes(-12), false),
                new("나", "네 작성한 후 이민지 사원님 이메일로 보내드렸습니다.", now.AddMinutes(-8), true),
                new("이민지", "확인 했습니다.", now.AddMinutes(-7), false),
            ]),
            user2 with { UnreadCount = 2, Messages = [
                new("박지훈", "어제 요청드린 빌드 확인 부탁드립니다.", now.AddMinutes(-10), false),
                new("박지훈", "급한 건 아니니 편할 때 보세요.", now.AddMinutes(-10), false)
            ]}
        ];

    }
}
