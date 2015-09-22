using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    class AtachmentsRepository : BaseRepository<Atachment>, IAtachmentsRepository
    {
        public AtachmentsRepository(IDbContextFactory contextFactory) : base(contextFactory)
        {
        }
    }
}
