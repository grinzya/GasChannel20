using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GasChannelWebApp.Domain;
using WebMatrix.WebData;

namespace GasChannelWebApp.Infrastructure
{
    public class InputDataVariantsRepository : IInputDataVariantsRepository
    {
        GasChannelDB _context;

        public InputDataVariantsRepository(GasChannelDB context)
        {
            _context = context;
        }

        IQueryable<InputDataVariants> IInputDataVariantsRepository.All
        {
            get { return _context.InputDataVariants; }
        }

        void IInputDataVariantsRepository.InsertOrUpdate(InputDataVariants inputDataVariants)
        {
            if (inputDataVariants.ID_InputDataVariant == default(int))
            {
                _context.InputDataVariants.Add(inputDataVariants);
            }
            else
            {
                _context.Entry(inputDataVariants).State = System.Data.Entity.EntityState.Modified;
            }
        }

        void IInputDataVariantsRepository.Remove(InputDataVariants inputDataVariants)
        {
            _context.Entry(inputDataVariants).State = System.Data.Entity.EntityState.Deleted;
        }

        void IInputDataVariantsRepository.Save()
        {
            _context.SaveChanges();
        }
    }
}