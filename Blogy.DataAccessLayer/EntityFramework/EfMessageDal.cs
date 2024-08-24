using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        private readonly BlogyContext context;

        public EfMessageDal(BlogyContext context)
        {
            this.context = context;
        }

        public List<Message> GetMessageByArticleId(int id)
        {
            var values = context.Messages.Where(x => x.MessageID == id).ToList();
            return values;
        }

        public List<Message> GetMessageListByWriter(string p)
        {
            var values = context.Messages.Where(x => x.ReceiverMail == p).OrderByDescending(z => z.Date).ToList();
            return values;
        }
    }
}
