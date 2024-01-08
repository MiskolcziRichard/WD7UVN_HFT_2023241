using System;
using System.Threading;
using System.Threading.Tasks;
using ConsoleTools;

namespace WD7UVN_HFT_2023241.Client
{
	public class Program
	{
		private static async Task Main(string[] args)
		{
			var commonConfig = new MenuConfig
			{
				Selector = "--> ",
				EnableFilter = true,
				EnableBreadcrumb = true,
				WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles)),
			};
			
			var nonCrudMenu = new ConsoleMenu(args, level: 2)
				.Add("Who maintains specified service?", () => NonCRUD.WhoMaintainsService())
				.Add("Get employee's subordinates", () => NonCRUD.GetSubordinates())
				.Add("Get clients using a specified service", () => NonCRUD.WhoUsesService())
				.Add("Get employees in specified maintainer team", () => NonCRUD.WhoWorksInMaintainerTeam())
				.Add("Get employee responsible for specified service", () => NonCRUD.WhoIsResponsibleForService())
				.Add("Back", ConsoleMenu.Close)
				.Add("Exit", () => Environment.Exit(0))
				.Configure(commonConfig)
				.Configure(config =>
				{
					config.Title = "Non-CRUD Operations";
				});
			
			var crudMenu = new ConsoleMenu(args, level: 1)
				.Add("Sub_One", () => SomeAction("Sub_One"))
				.Add("Sub_Five", async (cancellationToken) => await SomeAction2(cancellationToken))
				.Add("Get all", ConsoleMenu.Close)
				.Add("Get by id", ConsoleMenu.Close)
				.Add("Create", ConsoleMenu.Close)
				.Add("Update", ConsoleMenu.Close)
				.Add("Delete", ConsoleMenu.Close)
				.Add("Sub_Close", ConsoleMenu.Close)
				.Add("Sub_Exit", () => Environment.Exit(0))
				.Configure(commonConfig)
				.Configure(config =>
				{
					config.Title = "Tables";
				});
			
			var menu = new ConsoleMenu(args, level: 0)
				.Add("One", () => SomeAction("One"))
				.Add("CRUD", crudMenu.Show)
				.Add("Non-CRUD", nonCrudMenu.Show)
				.Add("Close", ConsoleMenu.Close)
				.Add("Exit", () => Environment.Exit(0))
				.Configure(commonConfig)
				.Configure(config =>
				{
					config.Title = "Main menu";
					config.EnableWriteTitle = true;
					config.EnableBreadcrumb = true;
				});
			
			var token = new CancellationTokenSource(7000).Token;
			await menu.ShowAsync(token);
		}

		private static void SomeAction(string text)
		{
			Console.WriteLine(text);
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}
		
		private static async Task SomeAction2(CancellationToken token)
		{
			Console.WriteLine("start delay...");
			await Task.Delay(2000, token);
			Console.WriteLine("end delay");
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}
	}
}
