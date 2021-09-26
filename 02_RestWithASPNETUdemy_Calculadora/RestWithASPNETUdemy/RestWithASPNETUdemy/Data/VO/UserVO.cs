using System;

namespace RestWithASPNETUdemy.Data.VO
{
    public class UserVO
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string RefreshToKen { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
