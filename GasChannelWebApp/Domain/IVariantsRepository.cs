using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasChannelWebApp.Domain
{
    public interface IVariantsRepository
    {
        IQueryable<Variants> All { get; }

        Variants CurrentVariant { get; }

        void InsertOrUpdate(Variants variants);

        void Remove(Variants variants);

        void Save();
    }
}