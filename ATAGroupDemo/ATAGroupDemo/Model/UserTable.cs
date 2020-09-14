using System;
using SQLite;

namespace ATAGroupDemo.Model
{
    [Table("User_Table")]
    public class UserTable
    {
        [PrimaryKey, AutoIncrement]
        [Column("UserId")]
        public int UserID { get; set; }

        [Column("UserName")]
        public String UserName { get; set; }

        [Column("Password")]
        public String Psssword { get; set; }

        [Column("UserRole")]
        public String Role { get; set; }

    }
}
