using Newtonsoft.Json;
using Runewords.Helpers;
using Runewords.Interfaces;
using Runewords.Models;
using System.IO;
using System.Threading.Tasks;

namespace Runewords.Services
{
	public class FileDataReader : IDataReader
	{
		public Data GetData()
		{
			return GetDataAsync().GetAwaiter().GetResult();
		}

		public async Task<Data> GetDataAsync()
		{
			var filePath = Path.Combine(FileSystemHelper.AssemblyDirectory, Constants.DataFileName);
			var text = await File.ReadAllTextAsync(filePath)!;

			return JsonConvert.DeserializeObject<Data>(text)!;
		}
	}
}
