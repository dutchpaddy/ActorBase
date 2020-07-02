using System.Collections.Generic;
using ActorBase.Models;

namespace ActorBase.Repository
{
    public interface IActorsRepository
    {
        IEnumerable<Actors> GetActors();
        Actors GetActorById(int id);
        void CreateActor(Actors actor);
        void DeleteActor(int id);
        void SaveChanges();
    }
}
