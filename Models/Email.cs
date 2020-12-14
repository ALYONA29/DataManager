using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Email
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
