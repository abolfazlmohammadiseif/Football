using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Domain.Seedwork
{
    public abstract class Entity
    {
        int? _requestedHashCode;
        int _Id;
        public virtual int Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }
    }
}
