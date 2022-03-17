using System;
using System.Collections.Generic;
using System.Linq;
using App.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace App.Data
{
    public class Repository : IRepository
    {
        public readonly AppContext _context;

        public Repository(AppContext context)
        {
            _context = context;
        }

        public EntityEntry<Dossier> AddDossier(Dossier dossier)
        {
            return _context.Dossiers.Add(dossier);
        }

        public Dossier Find(Guid id)
        {
            return _context.Dossiers.Find(id);
        }

        public Dossier GetDossierByOrg(string id)
        {
            return _context.Dossiers
                .Where(x => x.Organisation.Equals(id))
                .FirstOrDefault();
        }

        public List<Dossier> AllSubmissions()
        {
            return _context.Dossiers.ToList();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public class TEntity
        {
        }
    }
}
