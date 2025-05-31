var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Netflix_Rental_Jobs>("netflix-rental-jobs");

builder.AddAzureFunctionsProject<Projects.FunctionApp1>("functionapp1");

builder.AddProject<Projects.Netflix_MovieCatalog_Api>("netflix-moviecatalog-api");

builder.AddProject<Projects.Netflix_Rental_Client>("frontend");

var rentalApi = builder.AddProject<Projects.Netflix_Rental_Api>("netflixRentalApi");

builder.AddProject<Projects.Netflix_User_Api>("userapi").WithReference(rentalApi);

builder.Build().Run();
