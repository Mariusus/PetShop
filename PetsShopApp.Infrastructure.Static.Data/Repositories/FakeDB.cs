using PetsShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopRemastered.Infrastructure.Static.Data.Repositories
{
    public static class FakeDb
    {
        public static int PetID { get; set; }
        public static List<Pets> _PetsList = new List<Pets>();

        public static void InitData()
        {
            PetID = 0;
            Pets pet1 = new Pets()
            {
                ID = PetID++,
                Name = "Artemis",
                Color = "Blue",
                Type = "Horse",
                BirthDate = Convert.ToDateTime(2777 / 07 / 07),
                Price = 22.22,
                SoldDate = Convert.ToDateTime(1994 / 04 / 16),
                PreviousOwner = "PlayerOne"



            };
           

            Pets pet2 = new Pets()
            {
                ID = PetID++,
                Name = "Bronch",
                Color = "Yellow",
                Type = "Cat",
                BirthDate = Convert.ToDateTime(1952 / 02 / 12),
                Price = 22.22,
                SoldDate = Convert.ToDateTime(1294 / 04 / 16),
                PreviousOwner = "Nose"



            };
           

            Pets pet3 = new Pets()
            {
                ID = PetID++,
                Name = "Salad",
                Color = "Green",
                Type = "Cat",
                BirthDate = Convert.ToDateTime(1422 / 03 / 12),
                Price = 22.22,
                SoldDate = Convert.ToDateTime(1543 / 06 / 11),
                PreviousOwner = "Earth"



            };
            

            Pets pet4 = new Pets()
            {
                ID = PetID++,
                Name = "John",
                Color = "Wicked",
                Type = "Dog",
                BirthDate = Convert.ToDateTime(1492 / 11 / 12),
                Price = 22.22,
                SoldDate = Convert.ToDateTime(1544 / 08 / 19),
                PreviousOwner = "Mafia"



            };
           

            Pets pet5 = new Pets()
            {
                ID = PetID++,
                Name = "TimeTraveler",
                Color = "Black",
                Type = "Horse",
                BirthDate = Convert.ToDateTime(1992 / 03 / 12),
                Price = 22.22,
                SoldDate = Convert.ToDateTime(1204 / 06 / 12),
                PreviousOwner = "Brosnki"



            };
            

            Pets pet6 = new Pets()
            {
                ID = PetID++,
                Name = "Jonhu",
                Color = "White",
                Type = "Dog",
                BirthDate = Convert.ToDateTime(1952 / 02 / 19),
                Price = 15.22,
                SoldDate = Convert.ToDateTime(1954 / 04 / 16),
                PreviousOwner = "Jundo"



            };

            _PetsList.Add(pet1);
            _PetsList.Add(pet2);
            _PetsList.Add(pet3);
            _PetsList.Add(pet4);
            _PetsList.Add(pet5);
            _PetsList.Add(pet6);
        }
        
    }
}
