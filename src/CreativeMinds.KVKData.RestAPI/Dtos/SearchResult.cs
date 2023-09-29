using System;
using System.Text.Json.Serialization;

namespace CreativeMinds.KVKData.RestAPI.Dtos {

	public class SearchResult {
		[JsonPropertyName("kvkNummer")]
		public String Id { get; set; }
		[JsonPropertyName("handelsnaam")]
		public String Name { get; set; }
		[JsonPropertyName("adresType")]
		public String AddressType { get; set; }
		[JsonPropertyName("straatnaam")]
		public String Street { get; set; }
		[JsonPropertyName("plaats")]
		public String Place { get; set; }
		[JsonPropertyName("type")]
		public String Type { get; set; }
	}

	// https://developers.kvk.nl/documentation/testing/swagger-zoeken-api
}
