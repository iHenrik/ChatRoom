using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatRoom.Entities
{
    public class MessageEntity : TableEntity
    {
        public MessageEntity(string nick, string connectionId, string message)
        {
            string dailyStamp = DateTime.UtcNow.ToString("yyyyMMdd");
            PartitionKey = dailyStamp;

            RowKey = connectionId;
            Nick = nick;
            Message = message;
        }

        public string DailyStamp => PartitionKey;
        public string ConnectionId => RowKey;
        public string Nick { get; set; }
        public string Message { get; set; }
    }
}