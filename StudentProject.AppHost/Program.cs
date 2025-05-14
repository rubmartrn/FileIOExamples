var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WepApiForAppIns>("wepapiforappins");

builder.AddProject<Projects.BackGroundApi>("backgroundapi");

builder.Build().Run();
