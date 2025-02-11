using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Basilisk CustomTask recognition request
    /// </summary>
    public class BasiliskCustomTaskRequest : CustomTaskRequestBase
    {
        /// <inheritdoc/>
        public override string Class => "Basilisk";

        /// <summary>
        /// Can be found in the html code in the attribute data-sitekey of the captcha container or in the payload of a POST request to the https://basiliskcaptcha.com/challenge/check-site in the field site_key
        /// </summary>
        /// <example>b7890hre5cf2544b2759c19fb2600897</example>
        [JsonProperty("websiteKey", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string WebsiteKey { get; set; }
    }
}
