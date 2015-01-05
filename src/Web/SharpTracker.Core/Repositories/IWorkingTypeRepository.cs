using System.Collections.Generic;
using SharpTracker.Core.Entities;

namespace SharpTracker.Core.Repositories
{
	public interface IWorkingTypeRepository
	{
		IEnumerable<IWorkingType> GetAll();
		IWorkingType Get(int id);
		void Save(IWorkingType workingType);
		void Delete(int id);
	}
}