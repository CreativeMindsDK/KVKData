using CreativeMinds.KVKData.RestAPI.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CreativeMinds.KVKData.RestAPI {

	public interface IKVKSearchEngine {
		Task<SearchResponse> SearchForCompanyByNamesAsync(String query, Int32 maxHits, CancellationToken cancellationToken);
	}
}