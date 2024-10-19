// Domain
global using Finansium.Domain.Abstractions;
global using Finansium.Domain.Users;

// Application
global using Finansium.Application.Abstractions.Data;
global using Finansium.Application.Abstractions.Messaging;
global using Finansium.Application.Abstractions.Behaviors;
global using Finansium.Application.Abstractions.Authentication;

// Microsoft
global using Microsoft.Extensions.Logging;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;

// Libs
global using MediatR;
global using Serilog.Context;
global using FluentValidation;
global using System.Reflection;
