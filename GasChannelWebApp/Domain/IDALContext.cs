using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GasChannelWebApp.Domain
{
    public interface IDALContext
    {
        IUserProfileRepository Users { get; }

        IVariantsRepository Variants { get; }

        IInputDataVariantsRepository InputDataVariants { get; }
    }
}