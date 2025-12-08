namespace PetShop.Services;

using System.Collections.Generic;
using PetShop.Models;

public class _petService : IPetService
{

    private static List<Pet> pets = new();
    public List<Pet> GetPets()
    {
        return pets;
    }

    public Pet PosPet(Pet newPet)
    {
        newPet.Id = pets.Count() + 1;
        pets.Add(newPet);
        return newPet;
    }

    public Pet PutPet(int petId, Pet updatedPet)
    {
        var existingPet = pets.Find(p => p.Id == petId);
        if (existingPet != null)
        {
            existingPet.Name = updatedPet.Name;
            existingPet.Breed = updatedPet.Breed;
            existingPet.Age = updatedPet.Age;
            return existingPet;
        }
        throw new Exception("Pet not found");
    }

    public void DeletePet(int petId)
    {
        var petToDelete = pets.Find(p => p.Id == petId);
        if (petToDelete != null)
        {
            pets.Remove(petToDelete);
        }
        throw new Exception("Pet not found");
    }
}