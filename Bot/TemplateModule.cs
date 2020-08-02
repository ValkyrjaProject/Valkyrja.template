using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Valkyrja.coreLite;
using Valkyrja.entities;
using Discord;
using Discord.Net;
using Discord.Rest;
using Discord.WebSocket;
using guid = System.UInt64;

namespace Valkyrja.modules
{
	public class TemplateModule: IModule
	{
		private IValkyrjaClient Client;

		public Func<Exception, string, guid, Task> HandleException{ get; set; }
		public bool DoUpdate{ get; set; } = true;

		public List<Command> Init(IValkyrjaClient iClient)
		{
			this.Client = iClient as ValkyrjaClient<BaseConfig>;
			List<Command> commands = new List<Command>();

// !exampleCommand
			Command newCommand = new Command("exampleCommand");
			newCommand.Type = CommandType.Standard;
			newCommand.Description = "This is an example command.";
			newCommand.ManPage = new ManPage("<arg1> [arg2]", "`<arg1>` - Something.\n\n`[arg2]` - Optional something else.");
			newCommand.RequiredPermissions = PermissionType.ServerOwner | PermissionType.Admin;
			newCommand.OnExecute += async e => {
				await e.SendReplySafe("Boo!");
			};
			commands.Add(newCommand);

			return commands;
		}

		public Task Update(IValkyrjaClient iClient)
		{
			return Task.CompletedTask;
		}
	}
}
