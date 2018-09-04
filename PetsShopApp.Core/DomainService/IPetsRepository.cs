using System;
using System.Collections.Generic;
using System.Text;
using PetsShopApp.Core.Entity;

namespace PetsShopApp.Core.DomainService.IPetsRepository
{
   public interface  IPetsRepository
    {
        Pets Create(Pets pet);

        Pets ReadID(int ID);

        List<Pets> ReadAll();

        Pets UpdatePet(Pets petUpdate);

        Pets DeletePet(int ID);


    } 
}
