using System;
using System.Collections.Generic;
using System.Linq;
using HomeWork.Models;
using HomeWork.Repository;

namespace HomeWork.Service
{
    public class ActorsService : IActorsService
    {

        private readonly IActorsRepository _iActorsRepository;

        public ActorsService(IActorsRepository iActorsRepository)
        {
            _iActorsRepository = iActorsRepository;
        }

        public void Dispose()
        {
            _iActorsRepository.Dispose();
        }

        public Actors GetById(int id)
        {
            return _iActorsRepository.GetById(id);
        }

        public void Add(Actors actor)
        {
            _iActorsRepository.Add(actor);
        }

        public void Update(Actors actor)
        {
            _iActorsRepository.Update(actor);
        }

        public void Delete(Actors actor)
        {
            _iActorsRepository.Delete(actor);
        }

        public void Delete(int id)
        {
            Actors actor = _iActorsRepository.GetById(id);
            _iActorsRepository.Delete(actor);
        }

        public IEnumerable<Actors> GetAll()
        {
            return _iActorsRepository.GetAll();
        }

        public IEnumerable<Actors> GetByLambdaExpression(Func<Actors, bool> lambda)
        {
            return _iActorsRepository.GetByLambdaExpression(lambda);
        }

        public IEnumerable<Actors> GetAllActorsByGender(bool gender)
        {
            Func<Actors, bool> lambda = a => a.Gender == gender;
            return _iActorsRepository.GetByLambdaExpression(lambda);
        }

        public IEnumerable<Actors> GetAllActorsByLastName(String lastName)
        {
            Func<Actors, bool> lambda = a => a.LastName.ToUpper().Equals(lastName.ToUpper());
            return _iActorsRepository.GetByLambdaExpression(lambda);
        }

        public IEnumerable<Actors> GetAllActorsOlderThen(int age)
        {
            Func<Actors, bool> lambda = a => GetAge(a.DateOfBirth) >= age;
            return _iActorsRepository.GetByLambdaExpression(lambda);
        }

        private static int GetAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;
            return age;
        }
    }
}