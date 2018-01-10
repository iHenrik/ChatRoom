using ChatRoom.Entities;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatRoom.Models
{
    public class ChatModel
    {
        private const string STORAGE_ACCOUNT = "chatroom";
        private const string STORAGE_KEY = "MtDPyFdejNeABc9n/XUN9CN3XRe4vC7lXLXWy2RxpiDrFOqdnZCDJdoXXz00/IjjoBEJYRCgw2wzK1tiTt6YyQ==";
        private const string CONVERSATION_TABLE = "Conversations";

        private static List<UserModel> users;
        private static CloudStorageAccount cloudStorage;

        private static CloudTable conversationTable;

        public ChatModel()
        {
            //Init storage connection and table
            cloudStorage = new CloudStorageAccount(new StorageCredentials(STORAGE_ACCOUNT, STORAGE_KEY), true);

            var tableClient = cloudStorage.CreateCloudTableClient();
            conversationTable = tableClient.GetTableReference(CONVERSATION_TABLE);
            conversationTable.CreateIfNotExists();

            users = new List<UserModel>();
        }

        public void SaveMessage(string nick, string connectionId, string message)
        {
            MessageEntity messageEntity = new MessageEntity(nick, connectionId, message);

            conversationTable.Execute(TableOperation.Insert(messageEntity));
        }

        public string AddUser(UserModel user)
        {
            users.Add(user);

            var userList = from u in users select u.Nick;

            return String.Join(",", userList);
        }

        public string RemoveUser(string connectionId)
        {
            users.Remove(users.Where(user => user.ConnectionId == connectionId).FirstOrDefault());

            var userList = from u in users select u.Nick;

            return String.Join(",", userList);
        }
    }
}