using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasChannelWebApp.Domain
{
    public interface IInputDataVariantsRepository
    {
        IQueryable<InputDataVariants> All { get; }

        void InsertOrUpdate(InputDataVariants inputDataVariants);

        void Remove(InputDataVariants inputDataVariants);

        void Save();
    }
}