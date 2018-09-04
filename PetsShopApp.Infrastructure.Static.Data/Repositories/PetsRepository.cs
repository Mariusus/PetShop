using PetsShopApp.Core.DomainService;
using PetsShopApp.Core.DomainService.IPetsRepository;
using System;
using System.Collections.Generic;
using System.Text;
namespace PetsShopApp.Core.Entity.Repositories
{
    public class PetsRepository : IPetsRepository
    {
        static int id = 1;
        public List<Pets> _PetsList = new List<Pets>(); 

        public Pets Create(Pets pet)
        {
            pet.ID = id++;
            _PetsList.Add(pet);
            return pet;
        }

        public Pets DeletePet(int ID)
        {
            var petFound = this.ReadID(ID);
            if (petFound != null) {
                _PetsList.Remove(petFound);
            } return null;
        }

        public List<Pets> ReadAll()
        {
            return _PetsList;
        }

        public Pets ReadID(int ID)
        {
            foreach (var pet in _PetsList) {

                if (pet.ID == id) {
                    return pet;
                        }

            }
            return null;
        }

        public Pets UpdatePet(Pets petUpdate)
        {
            var petDB = this.ReadID(petUpdate.ID);
            if (petDB != null) {
                petDB.Name = petUpdate.Name;
                petDB.Type = petUpdate.Type;
                petDB.Color = petUpdate.Color;
                petDB.Birthdate = petUpdate.Birthdate;
                petDB.Price = petUpdate.Price;
                petDB.SoldDate = petUpdate.SoldDate;
                petDB.PreviousOwner = petUpdate.PreviousOwner;
                return petDB;
             

            }
            return null;
        }
        
    }
}
