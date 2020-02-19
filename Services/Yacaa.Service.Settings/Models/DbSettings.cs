using System.Text;
using Newtonsoft.Json;
using Yacaa.Shared.Encryption;

namespace Yacaa.Service.Settings.Models
{
    public class DbSettings
    {
        public string Server { get; set; }
        public bool LocalDb { get; set; }
        public string Username { get; set; }
        public string PasswordKey { get; set; }
        public bool TrustedConnection { get; set; }
        public string Database { get; set; }
        [JsonIgnore]
        public string ConnectionString =>
            GenerateConnectionString(server: Server, localdb: LocalDb,
                username: Username, passwordKey: PasswordKey,
                trustedConnection: TrustedConnection, database: Database);

        private static string GenerateConnectionString(string server, bool localdb, string username,
            string passwordKey, bool trustedConnection, string database)
        {
            // Check for validity
            if (string.IsNullOrEmpty(database) ||
                (!localdb && string.IsNullOrEmpty(server)) || 
                (!trustedConnection && 
                 (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(passwordKey))))
                return string.Empty;

            var sb = new StringBuilder();
            const string delimiter = "; ";
            const string serverPrefix = "Server=";
            const string localdbString = "(localdb)";
            const string usernamePrefix = "Username=";
            const string passwordPrefix = "Password=";
            const string trustedConnectionString = "Trusted_Connection=True";
            const string databasePrefix = "Database=";
            
            // Server=
            sb.Append(serverPrefix);
            // Server=Something
            sb.Append(localdb ? localdbString : server);
            sb.Append(delimiter);
            // Server=Something; Auth
            if (trustedConnection)
                sb.Append(trustedConnectionString);
            else
            {
                sb.Append(usernamePrefix);
                sb.Append(username);
                sb.Append(delimiter);
                sb.Append(passwordPrefix);
                sb.Append(passwordKey.DecryptString().ToUnsecuredString());
                sb.Append(delimiter);
            }
            // Server=Something; Auth; Database=
            sb.Append(databasePrefix);
            // Server=Something; Auth; Database=SomethingElse
            sb.Append(database);
            sb.Append(delimiter);
            
            return sb.ToString();
        }
    }
}