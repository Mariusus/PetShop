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
using PetsShopApp.Core.ApplicationService.Implementation;

namespace PetsShopRemastered
{
    public class Printer
    {
        private IPetsService _PetsService;

        public Printer(IPetsService PetsService)
        {
            _PetsService = PetsService;
            Console.SetWindowSize(130, 44);
            Console.WriteLine("Nice Pet shop  \n  Write the shown number for selection  \n____1: Display all available pets \n____2: Search pets by type \n____3: Create a new pet \n____4: Delete a pet \n____5: Update a pet \n____6: Sort pets by price from lowest \n____7: Get 5 cheapest available pets");
            Console.ReadLine();
            MakeMenu();
        }


        void MakeMenu()
        {

            Console.WriteLine("\n____1: Display all available pets \n____2: Delete a pet \n____3: Create a new pet \n____4: Search by type \n____5: Update a pet \n____6: Sort pets by price from lowest \n____7: Get 5 cheapest available pets");

            var selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    ReadAllPets();
                    MakeMenu();
                    break;
                case 2:
                    int idForDelete = PrintFindPetById();
                    _PetsService.DeletePet(idForDelete);
                    break;
                    
                case 3:
                    var name = Question("name: ");
                    var color = Question("color: ");
                    var type = Question("type: ");
                    var birthdate = Question3("Birth Date: ");
                    var price = Question1("price: ");
                    var solddate = Question3("Sold Date: ");
                    var previousowner = Question("Previous Owner: ");
                    var pet = _PetsService.CreatePet(name, color, type, birthdate, price, solddate, previousowner);
                    _PetsService.SavePet(pet);
                    MakeMenu();
                    break;

                case 4:
                    
                    Console.WriteLine("Enter type to look for: ");
                    var search = Console.ReadLine();
                    var petsByType = _PetsService.SearchPetsByType(search);
                    ReadAllPets(petsByType);
                    Console.ReadLine();
                    Console.Clear();
                    break;


                case 5:
                    var idEdit = PrintFindPetById();
                    var petEdit = _PetsService.SearchById(idEdit);
                    Console.WriteLine("Name" +pet.Name);

                    var newName = Question("Name of Pet:");
                    var newColor = Question("Color:");
                    var newType = Question("Type:");
                    var newBirthDate = Question3("Birth Date:");
                    var newPrice = Question1("Price:");
                    var newSoldDate = Question3("Sold Date:");
                    var newPreviousOwner = Question("Previous Owner:");
                    _PetsService.UpdatePet(new Pets()
                    {
                        ID = idEdit,
                        Name = newName,
                        Color = newColor,
                         Type = newType,
                        BirthDate = newBirthDate, 
                        Price = newPrice,
                       SoldDate = newSoldDate,
                        PreviousOwner = newPreviousOwner
                            });
                    

                    Console.WriteLine("Edit Done");
                    Console.ReadLine();
                   
                    break;
                    UpdatePet();
                    MakeMenu();
                    break;



            }


        }

        IEnumerable<Pets> ReadAllPets()
        {
            return PetsRepository.ReadAll();
        }

        string Question(string question) {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        double Question1(string question)
        {
            Console.WriteLine(question);
            return Convert.ToDouble(Console.ReadLine());
        }
        DateTime Question3(string question)
        {
            Console.WriteLine(question);
            return Convert.ToDateTime(Console.ReadLine());
        }


        Pets CreatePet(string name, string color, string type, DateTime birthdate, double price, DateTime solddate, string previousowner)
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

        Pets SavePet(Pets pet) {
           return PetsRepository.Create(pet);

        }

        void UpdatePet()
        {
            var id = PrintFindPetById();
            var pet = SearchById(id);
            Console.WriteLine("Name: ");
            pet.Name = Console.ReadLine();
            Console.WriteLine("Type: ");
            pet.Type = Console.ReadLine();
            Console.WriteLine("Birthday: ");
            pet.BirthDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Disposal date: ");
            pet.SoldDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Color: ");
            pet.Color = Console.ReadLine();
            Console.WriteLine("Price: ");
            pet.Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Previous Owner: ");
            pet.PreviousOwner = Console.ReadLine();
        }



        void PrintList(List<Pets> PetsList)
        {
            Console.WriteLine("\nList of Pets");
            foreach (var pet in PetsList)
            {
             Console.WriteLine($"\nId: {pet.ID} " +
             $"\nName: {pet.Name} " +
             $"\nSpecies: {pet.Type} " +
             $"\nBirth Date: {pet.BirthDate}" +
             $"\nSold Date: {pet.SoldDate} " +
             $"\nColor: {pet.Color} " +
             $"\nPrevious Owner: {pet.PreviousOwner} " +
             $"\nPrice: {pet.Price} ");
            }
            Console.WriteLine("\n");
        }
    

        int PrintFindPetById()
        {
            int id;
            Console.WriteLine("Insert Id:");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Insert valid Id");
            }
            return id;
        }
    



        public Pets SearchById(int id)
        {
           
            return PetsRepository.ReadID(id);
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
            _PetsService.CreatePet(pet1);

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
            _PetsService.CreatePet(pet2);

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
            _PetsService.CreatePet(pet3);

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
            _PetsService.CreatePet(pet4);

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
            _PetsService.CreatePet(pet5);

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
            _PetsService.CreatePet(pet6);





        }





        void DeletePet()
        {
            var id = PrintFindPetById();
            PetsRepository.DeletePet(id);

        }


    }
}




