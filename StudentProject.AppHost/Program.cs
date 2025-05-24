var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WepApiForAppIns>("wepapiforappins");

builder.AddProject<Projects.BackGroundApi>("backgroundapi");

builder.AddProject<Projects.Netflix_Rental_Jobs>("netflix-rental-jobs");

builder.Build().Run();
