using System;
using SQLite;

namespace ATAGroupDemo.Model
{
    [Table("StudentTable")]
    public class StudentTable
    {
        public StudentTable()
        {
        }

        [PrimaryKey, AutoIncrement]
        [Column("StudentID")]
        public int StudentID { get; set; }

        [Column("StudentName")]
        public String StudentName { get; set; }

        [Column("StudentGender")]
        public String StudentGender { get; set; }

        [Column("StudentEmail")]
        public String StudentEmail { get; set; }

        [Column("StudentContact")]
        public String StudentContact { get; set; }

        [Column("AddressID")]
        public int AddressID { get; set; }

        [Column("DocumentID")]
        public int DocumentID { get; set; }

        [Column("StudnetDOB")]
        public String StudnetDOB { get; set; }

        [Column("StudentClass")]
        public String StudentClass { get; set; }

        [Column("ISAuditable")]
        public String ISAuditable { get; set; }

        [Column("UserID")]
        public int UserID { get; set; }
        
    }
}
