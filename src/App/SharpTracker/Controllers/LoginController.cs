using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SharpTracker.Models;

namespace SharpTracker
{
	public class LoginController
	{
		public async Task<LoginModel> DoLogin(string username, string password)
		{
			var parameters = new Dictionary<string, object>
			{
				{"name", username},
				{"password", password}
			};

			return await Request<LoginModel>.Post("/login", parameters);
		}
	}
}

