using System;

namespace AuthAPI.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SessionToken { get; set; }
        public string Role { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}