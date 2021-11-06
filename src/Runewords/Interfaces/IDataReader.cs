using Runewords.Models;
using System.Threading.Tasks;

namespace Runewords.Interfaces
{
	public interface IDataReader
	{
		Task<Data> GetDataAsync();
		Data GetData();
	}
}
