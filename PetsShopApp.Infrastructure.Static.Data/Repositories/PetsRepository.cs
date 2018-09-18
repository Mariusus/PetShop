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
         List<Pets> _PetsList = new List<Pets>(); 

        public Pets Create(Pets pet)
        {
            pet.ID = id++;
            _PetsList.Add(pet);
            return pet;
        }

        void InitData()
        {
            var pet1 = new Pets()
            {
                Name = "Artemis",
                Color = "Blue",
                Type = "Horse",
                BirthDate = Convert.ToDateTime(2777 / 07 / 07),
                Price = 22.22,
                SoldDate = Convert.ToDateTime(1994 / 04 / 16),
                PreviousOwner = "PlayerOne"



            };
            Create(pet1);

            var pet2 = new Pets()
            {
                Name = "Bronch",
                Color = "Yellow",
                Type = "Cat",
                BirthDate = Convert.ToDateTime(1952 / 02 / 12),
                Price = 22.22,
                SoldDate = Convert.ToDateTime(1294 / 04 / 16),
                PreviousOwner = "Nose"



            };
            Create(pet2);

            var pet3 = new Pets()
            {
                Name = "Salad",
                Color = "Green",
                Type = "Cat",
                BirthDate = Convert.ToDateTime(1422 / 03 / 12),
                Price = 22.22,
                SoldDate = Convert.ToDateTime(1543 / 06 / 11),
                PreviousOwner = "Earth"



            };
            Create(pet3);

            var pet4 = new Pets()
            {
                Name = "John",
                Color = "Wicked",
                Type = "Dog",
                BirthDate = Convert.ToDateTime(1492 / 11 / 12),
                Price = 22.22,
                SoldDate = Convert.ToDateTime(1544 / 08 / 19),
                PreviousOwner = "Mafia"



            };
            Create(pet4);

            var pet5 = new Pets()
            {
                Name = "TimeTravelel",
                Color = "Black",
                Type = "Horse",
                BirthDate = Convert.ToDateTime(1992 / 03 / 12),
                Price = 22.22,
                SoldDate = Convert.ToDateTime(1204 / 06 / 12),
                PreviousOwner = "Brosnki"



            };
            Create(pet5);

            var pet6 = new Pets()
            {
                Name = "Jonhu",
                Color = "White",
                Type = "Dog",
                BirthDate = Convert.ToDateTime(1952 / 02 / 19),
                Price = 15.22,
                SoldDate = Convert.ToDateTime(1954 / 04 / 16),
                PreviousOwner = "Jundo"



            };
            Create(pet6);





        }

        public Pets DeletePet(int ID)
        {
            var petFound = this.ReadID(ID);
            if (petFound != null) {
                _PetsList.Remove(petFound);
            } return null;
        }

        public IEnumerable<Pets> ReadAll()
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
                petDB.BirthDate = petUpdate.BirthDate;
                petDB.Price = petUpdate.Price;
                petDB.SoldDate = petUpdate.SoldDate;
                petDB.PreviousOwner = petUpdate.PreviousOwner;
                return petDB;
             

            }
            return null;
        }
        
    }
}
