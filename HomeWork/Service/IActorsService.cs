using System;
using System.Collections.Generic;
using HomeWork.Models;

namespace HomeWork.Service
{
    public interface IActorsService : IService<Actors>
    {
        IEnumerable<Actors> GetAllActorsByLastName(String lastName);
        IEnumerable<Actors> GetAllActorsOlderThen(int age);
        IEnumerable<Actors> GetAllActorsByGender(bool gender);
    }
}
