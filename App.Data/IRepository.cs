using System;
using System.Collections.Generic;
using App.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace App.Data
{
    public interface IRepository
    {
        Dossier Find(Guid id);
        Dossier GetDossierByOrg(string id);
        EntityEntry<Dossier> AddDossier(Dossier dossier);
        List<Dossier> AllSubmissions();
        bool SaveAll();
    }
}
