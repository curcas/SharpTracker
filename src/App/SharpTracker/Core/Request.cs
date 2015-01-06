using System;
using RestSharp.Portable;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;

namespace SharpTracker
{
	public class Request<T> where T : new()
	{
		private const string BaseUrl = "http://192.168.1.20:1234/api/v1";

		public async static Task<T> Post(string url, IEnumerable<KeyValuePair<string, object>> parameters)
		{
			var client = new RestClient (BaseUrl);
			var request = new RestRequest (BaseUrl + url, HttpMethod.Post);

			foreach (var parameter in parameters)
			{
				request.AddParameter(parameter.Key, parameter.Value);
			}

			var result = await client.Execute<T>(request);
			return result.Data;
		}
	}
}

