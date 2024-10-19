// Domain
global using Finansium.Domain.Abstractions;

// Api
global using Finansium.Api.Extensions;

// System
global using System.Text.Json;
global using System.Reflection;
global using System.Text.Json.Serialization;

// Microsoft
global using Microsoft.AspNetCore.Http.Json;

// Libs
global using MediatR;
global using Serilog;
global using Serilog.Context;
global using HealthChecks.UI.Client;

// Layers
global using Finansium.Application;
global using Finansium.Persistence;
global using Finansium.Infrastructure;
