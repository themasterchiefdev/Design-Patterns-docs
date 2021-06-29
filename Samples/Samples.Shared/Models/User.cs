using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Samples.Shared.Models
{
    public partial class User
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("company")]
        public Company Company { get; set; }
    }

    public class Address
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("suite")]
        public string Suite { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("zipcode")]
        public string Zipcode { get; set; }

        [JsonPropertyName("geo")]
        public Geo Geo { get; set; }
    }

    public class Geo
    {
        [JsonPropertyName("lat")]
        public string Lat { get; set; }

        [JsonPropertyName("lng")]
        public string Lng { get; set; }
    }

    public class Company
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonPropertyName("bs")]
        public string Bs { get; set; }
    }

    public partial class User
    {

        public static List<User> FromJson(string json) => JsonSerializer.Deserialize<List<User>>(json);
    }

    public static class Serialize
    {
        public static string ToJson(this List<User> self) => JsonSerializer.Serialize(self);
    }


}
