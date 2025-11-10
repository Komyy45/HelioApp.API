using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.CityServices;
using HelioApp.Domain.Entities.CityServices;

namespace HelioApp.Application.Services;

internal sealed class EmergencyContactsService(IEmergencyContactsRepository emergencyContactsRepository) : IEmergencyContactsService
{
    public async Task<IEnumerable<EmergencyContactDto>> GetAll()
    {
        var emergencyContacts = await emergencyContactsRepository.GetAllAsync();

        var response = emergencyContacts.Select(e => new EmergencyContactDto(
                e.Id,
                e.Title,
                e.Number,
                e.Type
            ));

        return response;
    }

    public async Task<Guid> Create(CreateEmergencyContactDto request)
    {
        var contact = new EmergencyContact()
        {
            Title = request.Title,
            Number = request.Number,
            Type = request.Type
        };

        await emergencyContactsRepository.AddAsync(contact);

        await emergencyContactsRepository.CompleteAsync();

        return contact.Id;
    }

    public async Task Update(UpdateEmergencyContactDto request)
    {
        var contact = await emergencyContactsRepository.GetByIdAsync(request.Id);

        if (contact is null) throw new Exception("Contact Not Found");

        contact.Title = request.Title;
        contact.Number = request.Number;
        contact.Type = request.Type;
        
        emergencyContactsRepository.Update(contact);

        await emergencyContactsRepository.CompleteAsync();
    }

    public async Task Delete(Guid id)
    {
        var contact = await emergencyContactsRepository.GetByIdAsync(id);

        if (contact is null) throw new Exception("Contact Not Found");
        
        emergencyContactsRepository.Delete(contact);

        await emergencyContactsRepository.CompleteAsync();
    }
}