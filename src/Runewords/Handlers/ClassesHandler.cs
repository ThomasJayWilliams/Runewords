using Newtonsoft.Json;
using Runewords.Helpers;
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
			var filePath = Path.Combine(FileSystemHelper.AssemblyDirectory, Constants.DataFileName);
			var data = JsonConvert.DeserializeObject<Data>(
				File.ReadAllText(filePath))!;

			WriteLine("Shortcuts:");
			WriteLine($"\t{Constants.ConsoleShortLineBreak}");

			foreach (var @class in data.Classes)
			{
				WriteLine($"\t{@class}");
			}
		}
	}
}
