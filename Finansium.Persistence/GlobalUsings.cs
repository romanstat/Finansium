// Domain
global using Finansium.Domain.Shared;
global using Finansium.Domain.Abstractions;

// Application
global using Finansium.Application.Abstractions.Data;

// Persistence
global using Finansium.Persistence.Options;
global using Finansium.Persistence.Database;
global using Finansium.Persistence.Converters;
global using static Finansium.Persistence.Constants;

// System
global using System.Reflection;

// Microsoft
global using Microsoft.Extensions.Options;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.EntityFrameworkCore.Migrations;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

// Libs
global using Scrutor;
