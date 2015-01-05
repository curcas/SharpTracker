using SharpTracker.Core.Entities;

namespace SharpTracker.Core.Repositories
{
	public interface IUserRepository
	{
		IUser Get(int id);
		IUser Get(string name);
	}
}
