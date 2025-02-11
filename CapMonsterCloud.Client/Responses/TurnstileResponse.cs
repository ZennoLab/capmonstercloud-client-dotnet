using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Responses
{
    /// <summary>
    /// Turnstile recognition response
    /// </summary>
    public sealed class TurnstileResponse : CaptchaResponseBase
    {
        /// <summary>
        /// Turnstile token
        /// </summary>
        /// <example>
        /// 0.WqM7dkt15_d0Tgzhhsq21HtccdYp__spC7TehwqQ2ZoxhRVsFgnURYP5kyXb3njzY7jPqPGBoCewzPCmtmx_NygYniItwxy-On2ibrp1duuyUG3aH3l5WLvWeLHduY0gbalmJku57_nCoV-rS5qLNmEcqOlvLH60iUcjVfPhWBK2fO_ivCtnYt-S_FscDyDvt8dRwUs2D71aHRjF9Obzy8DmgyCNEsPWEbJrxM1FNQhwKfsgE2hp_HgudxAuomZzUtBVAi9aQXuDBUweh730iEHteOPCdkaroc6f9i5_tcJNXywGmNr8nQ-id57sakvqPOvjvLK-iIpBxRcK7MX-xJ9bFj1fG-m0q8DbWlLJf4Q.e8FaqGtmWuFkDOrmP03Ftg.763f08299cca9038d18afe499f6cb5427aa5f2d7e34f5cd585d34a0062158083
        /// </example>
        [JsonProperty("token")]
        public string Value { get; set; }
        
        /// <summary>
        /// Special cloudflare cookies that can be set in the browser
        /// </summary>
        [JsonProperty("cf_clearance")]
        public string Clearance { get; set; }
    }
}
