using System.Text.Json.Serialization;

namespace MiniE_Commerce.Application.DTO.Facebook
{
    public class FacebookUserAccessTokenValidation
    {
        [JsonPropertyName("data")]
        public FacebookUserAccessTokenValidationData Data { get; set; }
    }
    public class FacebookUserAccessTokenValidationData
    {
        [JsonPropertyName("data.is_valid")]
        public bool IsValid { get; set; }
        [JsonPropertyName("data.user_id")]
        public string UserId { get; set; }
    }

}
