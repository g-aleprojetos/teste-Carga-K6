using System;

namespace Server
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}
