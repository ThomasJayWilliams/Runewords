using Runewords.Interfaces;
using Runewords.Options;
using static System.Console;

namespace Runewords.Handlers
{
	public sealed class ClassesHandler : IClassesHandler
	{
		private readonly IDataReader _dataReader;

		public ClassesHandler(IDataReader dataReader)
		{
			_dataReader = dataReader;
		}

		public void Handle(ClassesOptions options)
		{
			var data = _dataReader.GetData();

			WriteLine("Shortcuts:");
			WriteLine($"\t{Constants.ConsoleShortLineBreak}");

			foreach (var @class in data.Classes)
			{
				WriteLine($"\t{@class}");
			}
		}
	}
}
