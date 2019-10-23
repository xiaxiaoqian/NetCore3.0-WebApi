using System;

namespace XXX.Models.XXXEntities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string MsgCode { get; set; }
        public DateTime? RegTime { get; set; }
        public string NickName { get; set; }
        public int? State { get; set; }
    }
}
