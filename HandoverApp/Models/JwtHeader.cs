using System;
using Newtonsoft.Json;

namespace HandoverApp.Models
{
	public class JwtHeader
	{
		[JsonProperty("alg")]
		public string Algorithm { get; set; }
		[JsonProperty("typ")]
		public string Type { get; set; }
	}
	public class JwtExpiration
	{
		[JsonProperty("exp")]
		public double? Expiration { get; set; }
	}
}

