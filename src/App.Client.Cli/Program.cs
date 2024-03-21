using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using App.Client.Cli;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Cli.Commons.Extensions;
using Microsoft.Kiota.Http.HttpClientLibrary;

var rootCommand = new AppClientCli().BuildRootCommand();

rootCommand.Description = "Kiota CLI";

var builder = new CommandLineBuilder(rootCommand)
    .UseDefaults()
    .UseRequestAdapter(context =>
    {
        var authProvider = new AnonymousAuthenticationProvider();
        var adapter = new HttpClientRequestAdapter(authProvider)
        {
            BaseUrl = "http://localhost:5102"
        };

        return adapter;
    }).RegisterCommonServices();

return await builder.Build().InvokeAsync(args);