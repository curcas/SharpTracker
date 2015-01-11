using System;
using RestSharp.Portable;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using SharpTracker.Core;

namespace SharpTracker
{
	public class Request<T> where T : new()
	{
		private const string BaseUrl = "http://sharptracker.curcas.ch/api/v1";

		public async static Task<T> Post(string url, IEnumerable<KeyValuePair<string, object>> parameters)
		{
			var client = new RestClient (BaseUrl);
			var request = new RestRequest (BaseUrl + url, HttpMethod.Post);

			if (parameters != null) {
				foreach (var parameter in parameters) {
					request.AddParameter (parameter.Key, parameter.Value);
				}
			}

			var result = await client.Execute<T>(request);
			return result.Data;
		}

		public async static Task<T> Get(string url, IEnumerable<KeyValuePair<string, object>> parameters, IApp app)
		{
			var client = new RestClient (BaseUrl);
			var request = new RestRequest (BaseUrl + url, HttpMethod.Get);
			request.AddHeader ("Token", app.GetToken ());

			if (parameters != null) {
				foreach (var parameter in parameters) {
					request.AddParameter (parameter.Key, parameter.Value);
				}
			}

			var result = await client.Execute<T>(request);
			return result.Data;
		}
	}
}

