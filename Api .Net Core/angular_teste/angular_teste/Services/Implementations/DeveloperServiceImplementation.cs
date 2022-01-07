using angular_teste.Context;
using angular_teste.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace angular_teste.Services.Implementations
{
    public class DeveloperServiceImplementation : IDeveloperService
    {
        private AppDbContext _context;

        public DeveloperServiceImplementation(AppDbContext context)
        {
            _context = context;
        }
        public Developer Create(Developer dev)
        {
            try
            {
                _context.Add(dev);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }

            return dev;
        }

        public void Delete(long id)
        {
            var result = _context.Developers.SingleOrDefault(d => d.ID.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Developers.Remove(result);
                    _context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<Developer> FindAll()
        {
            return _context.Developers.ToList();
        }

        public Developer FindByID(long id)
        {
            return _context.Developers.SingleOrDefault(d => d.ID.Equals(id));
        }

        public Developer Update(Developer dev)
        {
            if (!Exists(dev.ID)) return new Developer();

            var result = _context.Developers.SingleOrDefault(d => d.ID.Equals(dev.ID));

            if (result != null) { 
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(dev);
                    _context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
            

            return dev;
        }

        private bool Exists(long id)
        {
            return _context.Developers.Any(d => d.ID.Equals(id));
        }
    }
}
