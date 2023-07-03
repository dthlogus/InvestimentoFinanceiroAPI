using System.Text.Json.Serialization;

namespace API_Financeira.Config
{
    public class FirebaseSettings
    {
        [JsonPropertyName("project_id")]
        public static string ProjectId => "investimentofinanceiro-ab26f";

        [JsonPropertyName("private_key_id")]
        public string PrivateKeyId => "78fba5ac513cd9d82ae1aee66ea1cb990f58c081";

    }
}
