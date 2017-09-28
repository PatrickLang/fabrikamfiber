namespace FabrikamFiber.DAL.Data
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using FabrikamFiber.DAL.Models;

    public interface IMessageRepository
    {
        IQueryable<Message> All { get; }

        IQueryable<Message> AllIncluding(params Expression<Func<Message, object>>[] includeProperties);

        Message Find(int id);

        void InsertOrUpdate(Message message);

        void Delete(int id);

        void Save();
    }

    public class MessageRepository : IMessageRepository
    {
        private FabrikamFiberWebContext context = new FabrikamFiberWebContext();

        public IQueryable<Message> All
        {
            get { return this.context.Messages; }
        }

        public IQueryable<Message> AllIncluding(params Expression<Func<Message, object>>[] includeProperties)
        {
            IQueryable<Message> query = this.context.Messages;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public Message Find(int id)
        {
            return this.context.Messages.Find(id);
        }

        public void InsertOrUpdate(Message message)
        {
            if (message.ID == default(int))
            {
                this.context.Messages.Add(message);
            }
            else
            {
                this.context.Entry(message).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var message = this.context.Messages.Find(id);
            this.context.Messages.Remove(message);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}