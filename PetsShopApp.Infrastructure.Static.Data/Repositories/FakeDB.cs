using PetsShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopRemastered.Infrastructure.Static.Data.Repositories
{
    public static class FakeDB
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
                
                Price = 22.22,
                
                PreviousOwner = "PlayerOne"



            };
           

            Pets pet2 = new Pets()
            {
                ID = PetID++,
                Name = "Bronch",
                Color = "Yellow",
                Type = "Cat",
                
                Price = 22.22,
             
                PreviousOwner = "Nose"



            };
           

            Pets pet3 = new Pets()
            {
                ID = PetID++,
                Name = "Salad",
                Color = "Green",
                Type = "Cat",
               
                Price = 22.22,
                
                PreviousOwner = "Earth"



            };
            

            Pets pet4 = new Pets()
            {
                ID = PetID++,
                Name = "John",
                Color = "Wicked",
                Type = "Dog",
               
                Price = 22.22,
               
                PreviousOwner = "Mafia"



            };
           

            Pets pet5 = new Pets()
            {
                ID = PetID++,
                Name = "TimeTraveler",
                Color = "Black",
                Type = "Horse",
               
                Price = 22.22,
   
                PreviousOwner = "Brosnki"



            };
            

            Pets pet6 = new Pets()
            {
                ID = PetID++,
                Name = "Jonhu",
                Color = "White",
                Type = "Dog",
              
                Price = 15.22,
          
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
