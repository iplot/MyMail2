using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Interfaces;

namespace Entities
{
    public class Account : IEntity
    {
        public Account()
        {
            Contacts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string SmtpServerHost { get; set; }
        public int SmtpServerPort { get; set; }
        public string ImapServerHost { get; set; }
        public int ImapServerPort { get; set; }
        public string MailAddress { get; set; }
        public string MailPassword { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Account> Contacts { get; set; }
    }
}
