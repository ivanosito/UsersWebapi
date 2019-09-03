using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UsersWebapi.Data.Models
{
    public class User
    {
        // Name, LastName, Address, CreateDate, UpdateDate
        public int id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdateDate { get; set; }
    }
}
