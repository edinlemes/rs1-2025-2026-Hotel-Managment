using Hotel.Domain.Entities.Users;
using static System.Net.Mime.MediaTypeNames;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Hotel.Application.Abstractions;


namespace Hotel.Application.Modules.Persons;

#region DTOs
public record PersonDto(int Id, string FirstName, string LastName, string Address, string City, string State, string ZipCode, string Country, string PhoneNumber, string MailAddress, string Gender, int UserId);

public record CreatePersonRequest(string FirstName, string LastName, string Address, string City, string State, string ZipCode, string Country, string PhoneNumber, string MailAddress, string Gender, int UserId);
public record UpdatePersonRequest(string FirstName, string LastName, string Address, string City, string State, string ZipCode, string Country, string PhoneNumber, string MailAddress, string Gender, int UserId);
#endregion

#region Queries
public record GetAllPersonsQuery : IRequest<List<PersonDto>>;

public sealed class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, List<PersonDto>>
{
    private readonly IAppDbContext _ctx;
    public GetAllPersonsQueryHandler(IAppDbContext ctx) => _ctx = ctx;

    public async Task<List<PersonDto>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
    {
        return await _ctx.Persons
            .AsNoTracking()
            .Select(p => new PersonDto(p.Id, p.FirstName, p.LastName, p.Address, p.City, p.State, p.ZipCode, p.Country, p.PhoneNumber, p.MailAddress, p.Gender, p.UserId))
            .ToListAsync(cancellationToken);
    }
}

public record GetPersonByIdQuery(int Id) : IRequest<PersonDto?>;

public sealed class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonDto?>
{
    private readonly IAppDbContext _ctx;
    public GetPersonByIdQueryHandler(IAppDbContext ctx) => _ctx = ctx;

    public async Task<PersonDto?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var p = await _ctx.Persons.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (p is null) return null;
        return new PersonDto(p.Id, p.FirstName, p.LastName, p.Address, p.City, p.State, p.ZipCode, p.Country, p.PhoneNumber, p.MailAddress, p.Gender, p.UserId);
    }
}
#endregion

#region Commands
public record CreatePersonCommand(CreatePersonRequest Payload) : IRequest<PersonDto>;

public sealed class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, PersonDto>
{
    private readonly IAppDbContext _ctx;
    public CreatePersonCommandHandler(IAppDbContext ctx) => _ctx = ctx;

    public async Task<PersonDto> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = new PersonsEntity
        {
            FirstName = request.Payload.FirstName,
            LastName = request.Payload.LastName,
            Address = request.Payload.Address,
            City = request.Payload.City,
            State = request.Payload.State,
            ZipCode = request.Payload.ZipCode,
            Country = request.Payload.Country,
            PhoneNumber = request.Payload.PhoneNumber,
            MailAddress = request.Payload.MailAddress,
            Gender = request.Payload.Gender,
            UserId = request.Payload.UserId,
            CreatedAtUtc = DateTime.UtcNow,
            
        };

        _ctx.Persons.Add(entity);
        await _ctx.SaveChangesAsync(cancellationToken);

        return new PersonDto(entity.Id, entity.FirstName, entity.LastName, entity.Address, entity.City, entity.State, entity.ZipCode, entity.Country, entity.PhoneNumber, entity.MailAddress, entity.Gender, entity.UserId);
    }
}

public record UpdatePersonCommand(int Id, UpdatePersonRequest Payload) : IRequest<PersonDto?>;

public sealed class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, PersonDto?>
{
    private readonly IAppDbContext _ctx;
    public UpdatePersonCommandHandler(IAppDbContext ctx) => _ctx = ctx;

    public async Task<PersonDto?> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _ctx.Persons.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity is null) return null;

        entity.FirstName = request.Payload.FirstName;
        entity.LastName = request.Payload.LastName;
        entity.Address = request.Payload.Address;
        entity.City = request.Payload.City;
        entity.State = request.Payload.State;
        entity.ZipCode = request.Payload.ZipCode;
        entity.Country = request.Payload.Country;
        entity.PhoneNumber = request.Payload.PhoneNumber;
        entity.MailAddress = request.Payload.MailAddress;
        entity.Gender = request.Payload.Gender;
        entity.UserId = request.Payload.UserId;

        await _ctx.SaveChangesAsync(cancellationToken);

        return new PersonDto(entity.Id, entity.FirstName, entity.LastName, entity.Address, entity.City, entity.State, entity.ZipCode, entity.Country, entity.PhoneNumber, entity.MailAddress, entity.Gender, entity.UserId);
    }
}

public record DeletePersonCommand(int Id) : IRequest<bool>;

public sealed class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
{
    private readonly IAppDbContext _ctx;
    public DeletePersonCommandHandler(IAppDbContext ctx) => _ctx = ctx;

    public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _ctx.Persons.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity is null) return false;

        entity.IsDeleted = true;
        entity.ModifiedAtUtc = DateTime.UtcNow;

        await _ctx.SaveChangesAsync(cancellationToken);
        return true;
    }
}
#endregion