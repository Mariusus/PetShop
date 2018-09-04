using PetsShopApp.Core.Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using PetsShopApp.Core.DomainService;
using PetsShopApp.Core.DomainService.IPetsRepository;
using System;
using System.Collections.Generic;
using System.Text;
using PetsShopApp.Core.Entity;



namespace PetsShopRemastered
{
   public class Printer
    {
        public IPetsRepository PetsRepository;

        public Printer()
        {
            PetsRepository = new PetsRepository();
            Console.SetWindowSize(130, 44);
            Console.WriteLine("Nice Pet shop  \n  Write the shown number for selection  \n____1: Display all available pets \n____2: Search pets by type \n____3: Create a new pet \n____4: Delete a pet \n____5: Update a pet \n____6: Sort pets by price from lowest \n____7: Get 5 cheapest available pets");
            var selection = Convert.ToInt32(Console.ReadLine());
            while (selection != 9) {
                switch(selection)
                {
                    case 1:
                        ReadAllPets();
                        break;
                    case 2:


                        break;
                    case 3:
                        CreatePet();
                        break;
                    
                    case 5:
                        UpdatePet();
                        break;
                    

                }

            }



            PetsRepository pets = new PetsRepository();
            void CreatePet()
            {
                Console.WriteLine("pick a name");
                var name = Console.ReadLine();
                Console.WriteLine("pick a type");
                var type = Console.ReadLine();
                Console.WriteLine("pick a color");
                var color = Console.ReadLine();
                Console.WriteLine("pick a birthday");
                var birthdate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("pick a date of disposal");
                var soldDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("pick a price");
                var price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("pick the previous owner");
                var previousOwner = Console.ReadLine();

                var pet = new Pets()
                {
                    Name = name,
                    Type = type,
                    Color = color,
                    Birthdate = birthdate,
                    SoldDate = soldDate,
                    Price = price,
                    PreviousOwner = previousOwner
                };

                PetsRepository.Create(pet);  

            }
            void UpdatePet()
            {

                var pet = SearchById();
                Console.WriteLine("Name: ");
                pet.Name = Console.ReadLine();
                Console.WriteLine("Type: ");
                pet.Type = Console.ReadLine();
                Console.WriteLine("Birthday: ");
                pet.Birthdate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Disposal date: ");
                pet.SoldDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Color: ");
                pet.Color = Console.ReadLine();
                Console.WriteLine("Price: ");
                pet.Price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Previous Owner: ");
                pet.PreviousOwner = Console.ReadLine();
            }

        }

        void ReadAllPets()
        {
            PetsRepository = new PetsRepository();
            foreach (var pet in PetsRepository.ReadAll())
            {
                Console.WriteLine($"{pet.Name} {"Type: " + pet.Type} {"Price: " + pet.Price + "$"} {"Color: " + pet.Color} {"Birthday: " + pet.Birthdate} {"Previous Owner: " + pet.PreviousOwner} {"SoldDate: " + pet.SoldDate}");
            }
           
        }
        public  Pets SearchById() {
            int id;
            Console.WriteLine("Insert Id:");
                while(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Insert valid Id");
            }
            return PetsRepository.ReadID(id);
        }


        void MakeMenu()
        {

            Console.WriteLine("\n____1: Display all available pets \n____2: Search pets by type \n____3: Create a new pet \n____4: Delete a pet \n____5: Update a pet \n____6: Sort pets by price from lowest \n____7: Get 5 cheapest available pets");
            int selection = Convert.ToInt32(Console.ReadLine());
        }
        

        void DeletePet(int ID)
        {
            var petFound = PetsRepository.ReadID(ID);
            if (petFound != null)
            {
                PetsRepository.DeletePet(petFound.ID);
            }
           
        }

    }
}


