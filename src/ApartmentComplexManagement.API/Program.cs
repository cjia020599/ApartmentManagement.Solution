using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using TenantAndLeaseManagement.Controllers;
using TenantAndLeaseManagement.Application;
using TenantAndLeaseManagement.Infrastructure;
using TenantAndLeaseManagement.Infrastructure.MappingProfiles;
using OwnerManagement.Controllers;
using OwnerManagement.Application;
using OwnerManagement.Infrastructure;
using OwnerManagement.Infrastructure.MappingProfiles;
using PropertyManagement.Controllers;
using PropertyManagement.Application;
using PropertyManagement.Infrastructure;
using PropertyManagement.Infrastructure.MappingProfiles;
using FinancialManagement.Controllers;
using FinancialManagement.Application;
using FinancialManagement.Infrastructure;
using FinancialManagement.Infrastructure.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(PropertiesController).Assembly)
    .AddApplicationPart(typeof(TenantAndLeaseController).Assembly)
    .AddApplicationPart(typeof(OwnerController).Assembly)
    .AddApplicationPart(typeof(FinancialController).Assembly);
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((doc, ctx, ct) =>
    {
        doc.Components ??= new();
        doc.Components.SecuritySchemes["BearerAuth"] = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization"
        };
        return Task.CompletedTask;
    });

    options.AddOperationTransformer((op, ctx, ct) =>
    {
        var hasAuth = ctx.Description.ActionDescriptor?.EndpointMetadata?
            .OfType<Microsoft.AspNetCore.Authorization.IAuthorizeData>()
            .Any() == true;

        if (hasAuth)
        {
            op.Security ??= new List<OpenApiSecurityRequirement>();
            op.Security.Add(new OpenApiSecurityRequirement
            {
                [new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    { Type = ReferenceType.SecurityScheme, Id = "BearerAuth" }
                }] = Array.Empty<string>()
            });
        }
        return Task.CompletedTask;
    });
});
builder.Services.AddAutoMapper(cfg => {
    cfg.AddMaps(typeof(PropertyMappingProfile).Assembly);
    cfg.AddMaps(typeof(LeaseAgreementMappingProfile).Assembly);
    cfg.AddMaps(typeof(TenantMappingProfile).Assembly);
    cfg.AddMaps(typeof(OwnerMappingProfile).Assembly);
    cfg.AddMaps(typeof(IndividualUnitMappingProfile).Assembly);
    cfg.AddMaps(typeof(RentPaymentMappingProfile).Assembly);
});
builder.Services.AddPropertyApplication();
builder.Services.AddPropertyInfrastructure(builder.Configuration);
builder.Services.AddTenantAndLeaseManagementApplication();
builder.Services.AddTenantAndLeaseManagementInfrastructure(builder.Configuration);
builder.Services.AddOwnerManagementApplication();
builder.Services.AddOwnerManagementInfrastructure(builder.Configuration);
builder.Services.AddFinancialManagementApplication();
builder.Services.AddFinancialManagementInfrastructure(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapScalarApiReference(
    options => options.WithTheme(ScalarTheme.Mars).WithDarkMode()
    );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
