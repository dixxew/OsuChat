namespace ChatWebServer.Models
{
    public class GroupChat
    {
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public GroupStatus Status { get; set; }
    }
    public class GroupStatus
    {
        public bool IsBanned { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsCreator { get; set; }
    }
}

/*
 на клиенте
    чаты:
        по айдишнику юзера
        по глобал айдишнику группового чата

 на сервере
    юзер:
        список чатов с людьми
        список групповых чатов
    чаты:
        1-1: у юзеров в чатыАйди
        группы: тейбл с чатами где айди чата айди юзера
 */