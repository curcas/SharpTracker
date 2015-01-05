using SharpTracker.Core.Entities;

namespace SharpTracker.Core.Repositories
{
	public interface ITokenRepository
	{
		IToken Get(string value);
		void Save(IToken token);
	}
}