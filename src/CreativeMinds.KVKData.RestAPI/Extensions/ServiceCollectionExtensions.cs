using CreativeMinds.KVKData.RestAPI.AppSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CreativeMinds.KVKData.RestAPI {

	public static class ServiceCollectionExtensions {

		public static IServiceCollection AddCVRElasticSearch(this IServiceCollection services, IConfiguration configuration) {
			services.Configure<KVKDataSettingsReader>(configuration.GetSection("KVKData"));
			services.AddTransient<IKVKDataSettings, KVKDataSettingsBridge>();

			//services.AddScoped<ISearchEngine, RawHttpSearchEngine>();
			services.AddSingleton<IKVKSearchEngine, KVKRestApiSearchEngine>();

			return services;
		}
	}
}
