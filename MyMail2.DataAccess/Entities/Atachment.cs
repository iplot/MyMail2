using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Interfaces;

namespace Entities
{
    public class Atachment : IEntity
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }

        public int MailId { get; set; }
        public virtual ICollection<Mail> Mails { get; set; }
    }
}
