namespace PetShop.Services;

using PetShop.Models;

public interface IPetService
{
    List<Pet> GetPets();
    Pet PosPet(Pet newPet);
    Pet PutPet(int petId, Pet updatedPet);
    void DeletePet(int petId);
}