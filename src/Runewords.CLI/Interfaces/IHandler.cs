namespace Runewords.CLI.Interfaces
{
	public interface IHandler<TVerb>
		where TVerb : class, IVerb
	{
		void Handle(TVerb verb);
	}
}
