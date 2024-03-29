﻿using CreativeMinds.KVKData.RestAPI.AppSettings;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CreativeMinds.KVKData.RestAPI.Dtos;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Linq;

namespace CreativeMinds.KVKData.RestAPI {

	public class KVKRestApiSearchEngine : IKVKSearchEngine {
		//protected readonly IKVKDataSettings settings;
		protected String apiKey = String.Empty;

		public KVKRestApiSearchEngine(IKVKDataSettings settings) {
			//this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
			this.apiKey = settings.APIKey;
		}

		public KVKRestApiSearchEngine(IConfigurationSection settings) {
			this.apiKey = settings["APIKey"];
		}

		public async Task<SearchResponse> SearchForCompanyByIdAsync(Int32 companyId, Int32 maxHits, CancellationToken cancellationToken) {
			return await this.SearchAsync(new Dictionary<String, String> { { "kvkNummer", companyId.ToString() } }, maxHits, cancellationToken);
		}

		public async Task<SearchResponse> SearchForCompanyByNameAsync(String query, Int32 maxHits, CancellationToken cancellationToken) {
			return await this.SearchAsync(new Dictionary<String, String> { { "handelsnaam", query } }, maxHits, cancellationToken);
		}

		private async Task<SearchResponse> SearchAsync(Dictionary<String, String> parameters, Int32 maxHits, CancellationToken cancellationToken) {
			HttpClient client = new HttpClient();
			client.Timeout = new TimeSpan(0, 0, 0, 0, 5000);
			client.BaseAddress = new Uri("https://api.kvk.nl/test/api/v1/zoeken");
			client.DefaultRequestHeaders
				  .Accept
				  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

			try {
				String urlParameters = String.Join("&", parameters.Select(l => $"{l.Key}={l.Value}"));
				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"?{urlParameters}");
				request.Headers.Add("apikey", this.apiKey);
				//request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
				//request.Content = new StringContent(searchBody, Encoding.UTF8, "application/json");

				HttpResponseMessage response = await client.SendAsync(request);

				return await response.Content.ReadFromJsonAsync<SearchResponse>();

				//return new List<Object> {  };

				//return JsonConvert.DeserializeObject(output);

				// TODO: Handle 404, as "no results found".
			}
			catch (Exception ex) {
				throw ex;
			}
		}
	}
}
