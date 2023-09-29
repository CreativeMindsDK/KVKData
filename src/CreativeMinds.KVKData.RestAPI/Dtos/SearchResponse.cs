using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CreativeMinds.KVKData.RestAPI.Dtos {

	public class SearchResponse {
		[JsonPropertyName("pagina")]
		public Int32 Page { get; set; }
		[JsonPropertyName("aantal")]
		public Int32 Count { get; set; }
		[JsonPropertyName("totaal")]
		public Int32 Total { get; set; }
		[JsonPropertyName("resultaten")]
		public IEnumerable<SearchResult> Results{ get; set; }
		[JsonPropertyName("vorige")]
		public String Previous { get; set; }
		[JsonPropertyName("volgende")]
		public String Next { get; set; }
		// TODO: Links		
	}
}
