using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatRoom.Models
{
    public class UserModel
    {
        public UserModel(string nick, string connectionId)
        {
            Nick = nick;
            ConnectionId = connectionId;
        }

        public string Nick { get; set; }
        public string ConnectionId { get; set; }
    }
}