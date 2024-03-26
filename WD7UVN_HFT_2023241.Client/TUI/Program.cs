using System;
using System.Threading;
using System.Threading.Tasks;
using ConsoleTools;
using WD7UVN_HFT_2023241.Client.Shared;

namespace WD7UVN_HFT_2023241.Client.TUI
{
	public enum CRUDActions
	{
		GetAll,
		GetById,
		Create,
		Update,
		Delete
	}

	public class Program
	{
		private static async Task Main(string[] args)
		{
			try
			{
				RestService.Init();
			}
			catch (EndpointNotAvailableException e)
			{
				Console.WriteLine(e.Message);
				Environment.Exit(1);
			}

		//	var commonConfig = new MenuConfig
		//	{
		//		Selector = "--> ",
		//		EnableFilter = true,
		//		EnableBreadcrumb = true,
		//		WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles)),
		//	};
			
			var nonCrudMenu = new ConsoleMenu(args, level: 2)
				.Add("Who maintains specified service?", () => NonCRUD.WhoMaintainsService())
				.Add("Get employee's subordinates", () => NonCRUD.GetSubordinates())
				.Add("Get clients using a specified service", () => NonCRUD.WhoUsesService())
				.Add("Get employees in specified maintainer team", () => NonCRUD.WhoWorksInMaintainerTeam())
				.Add("Get employee responsible for specified service", () => NonCRUD.WhoIsResponsibleForService())
				.Add("Back", ConsoleMenu.Close)
				.Add("Exit", () => Environment.Exit(0))
				//.Configure(commonConfig)
				.Configure(config =>
				{
					config.Title = "Non-CRUD Operations";
				});
			
			var crudMenu = new ConsoleMenu(args, level: 1)
				.Add("Get all", () => CRUD.TypeSelectorMenu(CRUDActions.GetAll))
				.Add("Get by id", () => CRUD.TypeSelectorMenu(CRUDActions.GetById))
				.Add("Create", () => CRUD.TypeSelectorMenu(CRUDActions.Create))
				.Add("Update", () => CRUD.TypeSelectorMenu(CRUDActions.Update))
				.Add("Delete", () => CRUD.TypeSelectorMenu(CRUDActions.Delete))
				.Add("Back", ConsoleMenu.Close)
				.Add("Exit", () => Environment.Exit(0))
				//.Configure(commonConfig)
				.Configure(config =>
				{
					config.Title = "Tables";
				});
			
			var menu = new ConsoleMenu(args, level: 0)
				.Add("CRUD", crudMenu.Show)
				.Add("Non-CRUD", nonCrudMenu.Show)
				.Add("Exit", () => Environment.Exit(0))
				//.Configure(commonConfig)
				.Configure(config =>
				{
					config.Title = "Main menu";
					config.EnableWriteTitle = true;
					config.EnableBreadcrumb = true;
				});
			
			var token = new CancellationTokenSource().Token;
			await menu.ShowAsync(token);
		}
	}
}
