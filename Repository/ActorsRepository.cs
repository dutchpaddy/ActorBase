using ActorBase.Models;
using System.Collections.Generic;
using System.Linq;
using ActorBase.Data;

namespace ActorBase.Repository
{
    public class ActorsRepository : IActorsRepository
    {
        private ActorDbContext _context;

        public ActorsRepository(ActorDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Actors> GetActors()
        {
            return _context.Actors.ToList();
        }


        public Actors GetActorById(int id)
        {
            //return _context.Actors.Include(b => b.Name)
            //    .SingleOrDefault(c => c.Id == id);
            return _context.Actors.Find(id);
        }


        public void CreateActor(Actors actor)
        {
            if (actor.Name != null && actor.Name.Length > 0)
            {
                _context.Add(actor);
                _context.SaveChanges();
            }
        }

        public void DeleteActor(int id)
        {
            //var actor = _context.Actors.SingleOrDefault(c => c.Id == id);
            var actor = _context.Actors.Find( id);
            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
