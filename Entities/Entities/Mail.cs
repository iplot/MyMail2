using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Interfaces;

namespace Entities
{
    public class Mail : IEntity
    {
        public int Id { get; set; }
        public DateTime RecieveDate { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public States State { get; set; }

        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
