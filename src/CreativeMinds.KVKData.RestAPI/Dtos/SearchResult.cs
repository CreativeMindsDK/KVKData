using System;
using System.Text.Json.Serialization;

namespace CreativeMinds.KVKData.RestAPI.Dtos {

	public class SearchResult {
		[JsonPropertyName("kvkNummer")]
		public String Id { get; set; }
	}
}
