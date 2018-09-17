using PetsShopApp.Core.ApplicationService.Implementation;
using PetsShopApp.Core.DomainService.IPetsRepository;
using PetsShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetsShopApp.Core.ApplicationService.Services
{
    public class PetsService : IPetsService
    {
        readonly IPetsRepository _PetsRepo;

        public PetsService(IPetsRepository petsRepository) {
            _PetsRepo = petsRepository;
        }
        public Pets CreatePet(string name, string color, string type, DateTime birthdate, double price, DateTime solddate, string previousowner)
        {
            var pet = new Pets()
            {
                Name = name,
                Color = color,
                Type = type,
                BirthDate = birthdate,
                Price = price,
                SoldDate = solddate,            
                PreviousOwner = previousowner
            };
            return pet;
        }
        public Pets SavePet(Pets pet)
        {
            return _PetsRepo.Create(pet);
        }

        public Pets DeletePet(int id)
        {
            return _PetsRepo.DeletePet(id);
        }

        public List<Pets> ReadAllPets()
        {
            return _PetsRepo.ReadAll().ToList();
        }

        

        public Pets SearchById(int id)
        {
            return _PetsRepo.ReadID(id);
        }

        public List<Pets> SearchPetsByType(string Types)
        {
            var list = _PetsRepo.ReadAll();
            var queryContinued = list.Where(pet => pet.Type.Equals(Types));
            queryContinued.OrderBy(pet => pet.Type);
            return queryContinued.ToList();
        }

        public Pets UpdatePet(Pets petUpdate)
        {
            
            var pet = SearchById(petUpdate.ID);
            pet.Name = petUpdate.Name;
            pet.Type = petUpdate.Type;
            pet.BirthDate = petUpdate.BirthDate;
            pet.SoldDate = petUpdate.SoldDate;
            pet.Color = petUpdate.Color;
            pet.Price = petUpdate.Price;
            pet.PreviousOwner = petUpdate.PreviousOwner;
            return pet;
        }
    }
}
