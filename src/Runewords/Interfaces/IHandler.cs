namespace Runewords.Interfaces
{
	public interface IHandler<T> where T : IVerb
	{
		void Handle(T options);
	}
}
