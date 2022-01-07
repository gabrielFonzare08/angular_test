using angular_teste.Model;
using System.Collections.Generic;


namespace angular_teste.Services
{
    public interface IDeveloperService
    {
        Developer Create(Developer dev);

        Developer FindByID(long id);

        List<Developer> FindAll();

        Developer Update(Developer dev);

        void Delete(long id);

    }
}
