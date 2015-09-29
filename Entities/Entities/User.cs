using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Interfaces;

namespace Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }//TODO delete late

        public string FirstName { get; set; }
        public string SymKey { get; set; }
        public string IdentVector { get; set; }
        public byte[] AsymKey { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string WorkPlace { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhotoPath { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
