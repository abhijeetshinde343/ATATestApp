using System;
using SQLite;

namespace ATAGroupDemo.Model
{
    [Table("Document_Table")]
    public class DocumentTable
    {
        public DocumentTable()
        {
        }

        [PrimaryKey, AutoIncrement]
        [Column("DocumentId")]
        public int DocumentId { get; set; }

        [Column("DocumentName")]
        public String DocumentName { get; set; }

        [Column("Base64String")]
        public String Base64String { get; set; }

        [Column("DocumentNo")]
        public String DocumentNo { get; set; }
    }
}
