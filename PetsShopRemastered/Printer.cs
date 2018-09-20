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
    public class Printer: IPrinter
    {
        readonly IPetsService _PetsService;

        public Printer(IPetsService PetsService)
        {
            _PetsService = PetsService;
            Console.SetWindowSize(130, 44);
            Console.WriteLine("Nice Pet shop  \n  Write the shown number for selection  \n____1: Display all available pets \n____2: Search pets by type \n____3: Create a new pet \n____4: Delete a pet \n____5: Update a pet \n____6: Sort pets by price from lowest \n____7: Get 5 cheapest available pets");
            Console.ReadLine();
            MakeMenu();
        }


        public void MakeMenu()
        {

            Console.WriteLine("\n____1: Display all available pets \n____2: Delete a pet \n____3: Create a new pet \n____4: Search by type \n____5: Update a pet \n____6: Sort pets by price from lowest \n____7: Get 5 cheapest available pets");

            var selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    
                    PrintList(_PetsService.ReadAllPets());
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
                    var birthdate = Question3("Birth Date (Format 7777/07/77): ");
                    var price = Question1("price: ");
                    var solddate = Question3("Sold Date (Format 7777/07/77): ");
                    var previousowner = Question("Previous Owner: ");
                    var pet = _PetsService.CreatePet(name, color, type, birthdate, price, solddate, previousowner);
                    _PetsService.SavePet(pet);
                    MakeMenu();
                    break;

                case 4:
                    
                    Console.WriteLine("Enter type to look for: ");
                    var search = Console.ReadLine();
                    var petsByType = _PetsService.SearchPetsByType(search);
                    
                    Console.ReadLine();
                    Console.Clear();
                    break;


                case 5:
                    var idEdit = PrintFindPetById();
                    var petEdit = _PetsService.SearchById(idEdit);

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

       

        void UpdatePet()
        {
            var id = PrintFindPetById();
            var pet = _PetsService.SearchById(id);
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

      
    }
}




