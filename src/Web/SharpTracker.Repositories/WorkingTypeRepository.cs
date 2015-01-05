using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using SharpTracker.Core.Entities;
using SharpTracker.Core.Repositories;
using SharpTracker.Entities;

namespace SharpTracker.Repositories
{
	public class WorkingTypeRepository : IWorkingTypeRepository
	{
		private readonly SharpTrackerContext _dbContext;

		public WorkingTypeRepository(SharpTrackerContext dbContext)
	    {
		    _dbContext = dbContext;
	    }

		public IEnumerable<IWorkingType> GetAll()
		{
			return _dbContext.WorkingTypes.ToList();
		}

		public IWorkingType Get(int id)
		{
			return _dbContext.WorkingTypes.FirstOrDefault(p => p.Id == id);
		}

		public void Save(IWorkingType workingType)
		{
			_dbContext.WorkingTypes.AddOrUpdate((WorkingType)workingType);
		}

		public void Delete(int id)
		{
			_dbContext.WorkingTypes.Remove(_dbContext.WorkingTypes.First(p => p.Id == id));
		}
	}
}