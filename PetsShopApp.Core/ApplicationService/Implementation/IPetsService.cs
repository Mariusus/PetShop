using PetsShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetsShopApp.Core.ApplicationService.Implementation
{
    public interface IPetsService
    {
        Pets CreatePet(string Name, string Color, string Type, DateTime Birthdate, double Price, DateTime SoldDate, string PreviousOwner);
        Pets SavePet(Pets pet);
        Pets UpdatePet(Pets petUpdate);
        List<Pets> ReadAllPets();
        Pets SearchById(int id);
        Pets DeletePet(int id);
        List<Pets> SearchPetsByType(string Type);

    }
}
