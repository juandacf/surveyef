using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interface
{
    public interface IRolRepository : IGenericRepository<Rol>
    {
        void Attach(Rol rol);
    }
}