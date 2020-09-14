using System;
using SQLite;

namespace ATAGroupDemo.Model
{
    [Table("Address_Table")]
    public class AddressTable
    {
        public AddressTable()
        {
        }

        [PrimaryKey, AutoIncrement]
        [Column("AddressId")]
        public int AddressId { get; set; }

        [Column("City")]
        public String City { get; set; }

        [Column("PostCode")]
        public String PostCode { get; set; }

        [Column("Street")]
        public String Street { get; set; }

        [Column("Country")]
        public String Country { get; set; }

        [Column("State")]
        public String State { get; set; }
    }
}
