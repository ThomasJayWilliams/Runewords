namespace Runewords.Interfaces
{
	public interface IHandler<T> where T : IOptions
	{
		void Handle(T options);
	}
}
