using Newtonsoft.Json;
using Runewords.Interfaces;
using Runewords.Models;
using System.IO;
using static System.Console;

namespace Runewords.Handlers
{
	public sealed class ClassesHandler : IHandler<ClassesVerb>
	{
		public void Handle(ClassesVerb options)
		{
			var data = JsonConvert.DeserializeObject<Data>(
				File.ReadAllText(Constants.DataFileName))!;

			WriteLine("Shortcuts:");
			WriteLine(Constants.ConsoleLineBreak);

			foreach (var @class in data.Classes)
			{
				WriteLine(@class.ToString());
			}
		}
	}
}
