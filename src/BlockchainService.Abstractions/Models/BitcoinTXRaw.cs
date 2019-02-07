using Newtonsoft.Json;

namespace BlockchainService.Abstractions.Models
{
    public class BitcoinTXRaw
    {
        [JsonProperty("tx")]
        public string Tx { get; set; }
    }
}
