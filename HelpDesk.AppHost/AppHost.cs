var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.HelpDesk>("helpdesk");

builder.Build().Run();
