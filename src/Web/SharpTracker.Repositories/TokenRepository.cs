using System.Linq;
using SharpTracker.Core;
using SharpTracker.Core.Entities;
using SharpTracker.Core.Repositories;
using SharpTracker.Entities;

namespace SharpTracker.Repositories
{
    public class TokenRepository : ITokenRepository
    {
	    private readonly SharpTrackerContext _dbContext;

		public TokenRepository(SharpTrackerContext dbContext)
	    {
		    _dbContext = dbContext;
	    }

	    public IToken Get(string value)
	    {
		    return _dbContext.Tokens.FirstOrDefault(p => p.Value == value);
	    }

	    public void Save(IToken token)
	    {
		    _dbContext.Tokens.Add((Token)token);
	    }
    }
}
