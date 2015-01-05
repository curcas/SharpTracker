using SharpTracker.Core;
using SharpTracker.Core.Entities;
using System.Linq;
using SharpTracker.Core.Repositories;

namespace SharpTracker.Repositories
{
    public class UserRepository : IUserRepository
    {
	    private readonly SharpTrackerContext _dbContext;

	    public UserRepository(SharpTrackerContext dbContext)
	    {
		    _dbContext = dbContext;
	    }

	    public IUser Get(int id)
	    {
		    return _dbContext.Users.SingleOrDefault(p => p.Id == id);
	    }

	    public IUser Get(string name)
	    {
			return _dbContext.Users.SingleOrDefault(p => p.Name == name);
	    }
    }
}
