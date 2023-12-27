global using FluentValidation.AspNetCore;
global using Microsoft.ApplicationInsights;
global using Microsoft.ApplicationInsights.Channel;
global using Microsoft.ApplicationInsights.DataContracts;
global using Microsoft.ApplicationInsights.Extensibility;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.ApiExplorer;
global using Microsoft.AspNetCore.Mvc.Authorization;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.AspNetCore.WebUtilities;
global using Microsoft.Extensions.Options;
global using Microsoft.OpenApi.Any;
global using Microsoft.OpenApi.Models;
global using MongoDB.Driver;
global using Swashbuckle.AspNetCore.Annotations;
global using Swashbuckle.AspNetCore.SwaggerGen;
global using System.Diagnostics;
global using System.Diagnostics.CodeAnalysis;
global using System.Net;
global using System.Net.Mime;
global using System.Reflection;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using IntegrationCustomers.API.ActionResults;
global using IntegrationCustomers.API.Extensions;
global using IntegrationCustomers.API.Filters;
global using IntegrationCustomers.API.Utils;
global using IntegrationCustomers.Common.Configurations;
global using IntegrationCustomers.Common.Exceptions;
global using IntegrationCustomers.Common.Interfaces.HttpClients;
global using IntegrationCustomers.Common.Interfaces.Repositories;
global using IntegrationCustomers.Common.Interfaces.Services;

global using IntegrationCustomers.Common.Models.Entities;

global using IntegrationCustomers.Common.Models.Requests;
global using IntegrationCustomers.Common.Models.Responses;
global using IntegrationCustomers.DataAccess.Mongo;
global using IntegrationCustomers.DataAccess.SQL;
global using IntegrationCustomers.Service.HttpClients;
global using IntegrationCustomers.Service.Implementations;


 global using IntegrationCustomers.Service.Implementations;