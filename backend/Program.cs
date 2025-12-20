// register validators and the validation pipeline
using FluentValidation;
using FluentValidation.AspNetCore;
using Hotel.Application.Infrastructure.MediatR;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddValidatorsFromAssemblyContaining<RegisterUserCommandValidator>();
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// other service registrations (MediatR, DbContext, Identity, etc.)