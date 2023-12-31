﻿global using FluentValidation.AspNetCore;
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
global using FCUBS.Customer.Service.API.ActionResults;
global using FCUBS.Customer.Service.API.Extensions;
global using FCUBS.Customer.Service.API.Filters;
global using FCUBS.Customer.Service.API.Utils;
global using FCUBS.Customer.Service.Common.Configurations;
global using FCUBS.Customer.Service.Common.Exceptions;
global using FCUBS.Customer.Service.Common.Interfaces.HttpClients;
global using FCUBS.Customer.Service.Common.Interfaces.Repositories;
global using FCUBS.Customer.Service.Common.Interfaces.Services;

global using FCUBS.Customer.Service.Common.Models.Entities;

global using FCUBS.Customer.Service.Common.Models.Requests;
global using FCUBS.Customer.Service.Common.Models.Responses;
global using FCUBS.Customer.Service.DataAccess.Mongo;
global using FCUBS.Customer.Service.DataAccess.SQL;
global using FCUBS.Customer.Service.Services.HttpClients;
global using FCUBS.Customer.Service.Services.Implementations;