using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharpTracker.Api.Areas.Version1.Filters;
using SharpTracker.Api.Areas.Version1.Models;
using SharpTracker.Core.Entities;
using SharpTracker.Core.Repositories;
using SharpTracker.Entities;
using SharpTracker.Repositories;

namespace SharpTracker.Api.Areas.Version1.Controllers
{
	public class WorkingTypeController : ApiController
	{
		private readonly SharpTrackerContext _sharpTrackerContext;
		private readonly IWorkingTypeRepository _workingTypeRepository;

		public WorkingTypeController(SharpTrackerContext sharpTrackerContext, IWorkingTypeRepository workingTypeRepository)
		{
			_sharpTrackerContext = sharpTrackerContext;
			_workingTypeRepository = workingTypeRepository;
		}

		[TokenValidation]
		public IEnumerable<IWorkingType> Get()
		{
			return _workingTypeRepository.GetAll();
		}

		[TokenValidation]
		public IWorkingType Get(int id)
		{
			return _workingTypeRepository.Get(id);
		}

		[TokenValidation]
		[ValidateModel]
		public WorkingTypeModel Post(WorkingTypeModel model)
		{
			var workingType = new WorkingType
			{
				Name = model.Name,
				IsHoliday = model.IsHoliday,
				IsFlexitime = model.IsFlexitime
			};

			_workingTypeRepository.Save(workingType);
			SaveChanges();

			model.Id = workingType.Id;

			return model;
		}

		[TokenValidation]
		[ValidateModel]
		public WorkingTypeModel Post(int id, WorkingTypeModel model)
		{
			var workingType = _workingTypeRepository.Get(id);
			workingType.Name = model.Name;
			workingType.IsHoliday = model.IsHoliday;
			workingType.IsFlexitime = model.IsFlexitime;

			_workingTypeRepository.Save(workingType);
			SaveChanges();

			return model;
		}

		[TokenValidation]
		public HttpResponseMessage Delete(int id)
		{
			_workingTypeRepository.Delete(id);
			SaveChanges();

			return Request.CreateResponse(HttpStatusCode.OK);
		}

		[NonAction]
		private void SaveChanges()
		{
			//TODO: Move this shit into a base class...ApiController inheritance from a base class is not working...
			_sharpTrackerContext.SaveChanges();
		}
	}
}