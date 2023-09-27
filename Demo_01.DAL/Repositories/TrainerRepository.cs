using Demo_01.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_01.DAL.Repositories
{
    public class TrainerRepository
    {
        #region Fake "DB" -> A remplacer par des vrais accès DB
        private static List<Trainer> _trainers = new List<Trainer>{
            new Trainer
            {
                Id = 1,
                LastName = "Beurive",
                FirstName = "Aude",
                BirthDate = new DateTime(1989, 10, 16)
            },
             new Trainer
            {
                Id = 2,
                LastName = "Chaineux",
                FirstName = "Gavin",
                BirthDate = new DateTime(1996, 10, 18)
            },
              new Trainer
            {
                Id = 4,
                LastName = "Strimelle",
                FirstName = "Aurélien",
                BirthDate = new DateTime(1989, 11, 1)
            }
        };
        private static int NextId = 5;
        #endregion

        //CRUD :
        // READ
        public IEnumerable<Trainer> GetAll()
        {
            return _trainers.AsEnumerable(); //Pour transformer en IEnumerable la liste, on pourra la parcourir mais pas la modifier
        }

        public Trainer? GetById(int trainerId)
        {
            // On renvoie le trainer qui correspond à l'id / ! \ Peut être null si mauvais id
            return _trainers.SingleOrDefault(trainer => trainer.Id == trainerId);
        }

        // CREATE
        public Trainer Create(Trainer trainer)
        {
            // Création du nouveau Trainer à ajouter avec Id incrémenté par nous (à ne pas faire si vraie DB)
            Trainer trainerToCreate = new Trainer
            {
                Id = NextId++,
                LastName = trainer.LastName,
                FirstName = trainer.FirstName,
                BirthDate = trainer.BirthDate,
            };

            // Ajout dans la liste
            _trainers.Add(trainerToCreate);

            // Renvoie du Trainer
            return trainerToCreate;
        }

        // DELETE
        public bool Delete(int trainerId)
        {
            // Voir si le Trainer est dans la liste
            Trainer? trainerToDelete = _trainers.SingleOrDefault(trainer => trainer.Id == trainerId);

            // Si pas de Trainer trouvé, on renvoie nope
            if (trainerToDelete is null)
            {
                return false;
            }

            // Si trainer Trouvé, on le dégage et on renvoie ouip
            _trainers.Remove(trainerToDelete);
            return true;
        }

        // UPDATE
    }
}
