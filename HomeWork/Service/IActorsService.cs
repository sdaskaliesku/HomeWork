using System.Collections.Generic;
using HomeWork.Models;

namespace HomeWork.Service
{
    public interface IActorsService : IService<Actors>
    {
        IEnumerable<Actors> GetAllActors(Movies movies);
    }
}
