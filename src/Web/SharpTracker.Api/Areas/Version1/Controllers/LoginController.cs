using System;
using System.Web.Http;
using SharpTracker.Api.Areas.Version1.Filters;
using SharpTracker.Api.Areas.Version1.Models;
using SharpTracker.Core.Repositories;
using SharpTracker.Entities;
using SharpTracker.Repositories;

namespace SharpTracker.Api.Areas.Version1.Controllers
{
	public class LoginController : ApiController
	{
		private readonly SharpTrackerContext _sharpTrackerContext;
		private readonly IUserRepository _userRepository;
		private readonly ITokenRepository _tokenRepository;

		public LoginController(SharpTrackerContext sharpTrackerContext, IUserRepository userRepository,
			ITokenRepository tokenRepository)
		{
			_sharpTrackerContext = sharpTrackerContext;
			_userRepository = userRepository;
			_tokenRepository = tokenRepository;
		}

		[ValidateModel]
		public LoginResponseModel Post(LoginModel model)
		{
			var user = _userRepository.Get(model.Name);

			var token = new Token
			{
				User = user,
				Value = Guid.NewGuid().ToString("n")
			};

			_tokenRepository.Save(token);
			SaveChanges();

			return new LoginResponseModel
			{
				Token = token.Value
			};
		}

		[NonAction]
		private void SaveChanges()
		{
			//TODO: Move this shit into a base class...ApiController inheritance from a base class is not working...
			_sharpTrackerContext.SaveChanges();
		}
	}
}