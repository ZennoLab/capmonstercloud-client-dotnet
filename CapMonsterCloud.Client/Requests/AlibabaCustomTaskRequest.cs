namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Alibaba CustomTask recognition request.
    /// </summary>
    /// <remarks>
    /// Covers both Alibaba CAPTCHA and Alibaba WAF, including the invisible TRACELESS type
    /// (no user challenge; the CAPTCHA load response contains "CaptchaType": "TRACELESS").
    /// Websites behind Alibaba WAF set the ssxmod_itna and ssxmod_itna2 cookies; a regular Alibaba CAPTCHA does not.
    /// </remarks>
    /// <example>
    /// https://docs.capmonster.cloud/docs/captchas/alibaba-task/
    /// </example>
    public sealed class AlibabaCustomTaskRequest : CustomTaskRequestBase
    {
        /// <inheritdoc/>
        public override string Class => "alibaba";

        /// <summary>
        ///
        /// These values will be set to Metadata property.
        ///
        /// - sceneId: "sceneId": "1ww7426c4"
        /// Field is required.
        /// CAPTCHA scenario identifier. See documentation for how to find this value
        /// 
        /// - prefix: "prefix": "dlw3kug"
        /// Field is required.
        /// CAPTCHA initialization parameter, passed in the URL of the request used to load the task text on the page.
        /// For example, if the URL looks like: https://dlw3kug.captcha-open.example.aliyuncs.com/, then the value of the prefix parameter corresponds to the subdomain — dlw3kug
        /// 
        /// 
        /// Other fields are optional and must only be specified if they are present on the target website:
        /// 
        /// - userId: "userId": "..."
        /// A unique identifier of the user or session on the website side.
        /// 
        /// - userUserId: "userUserId": "..."
        /// An additional (secondary) user identifier.
        ///  
        /// - verifyType: "verifyType": "..."
        /// The version or type of the captcha verification mechanism.
        /// 
        /// - region: "region": "..."
        /// The server or data center region through which the captcha is processed.
        /// 
        /// - UserCertifyId: "UserCertifyId": "..."
        /// A unique verification ID associated with the current captcha session.
        /// 
        /// - apiGetLib: "apiGetLib": "..."
        /// A link to the captcha JS library used by the website. The value is generated on the client side and may change dynamically on each page render.
        ///
        /// - punishUrl: "punishUrl": "https://example.com/_____tmd_____/punish?x5secdata=...x5step=2"
        /// Full URL of the verification page for websites where Alibaba triggers verification through a separate /punish URL.
        ///
        /// - cookieRequired: "cookieRequired": true
        /// Set to true to receive cookies together with the CAPTCHA solution.
        /// Use it for websites behind Alibaba WAF (they set the ssxmod_itna and ssxmod_itna2 cookies) that require cookies after verification.
        ///
        /// </summary>
        public AlibabaCustomTaskRequest(string sceneId,
            string prefix,
            string userId = null,
            string userUserId = null,
            string verifyType = null,
            string region = null,
            string UserCertifyId = null,
            string apiGetLib = null,
            string punishUrl = null,
            bool? cookieRequired = null)
            =>
            Metadata = new
            {
                sceneId,
                prefix,
                userId,
                userUserId,
                verifyType,
                region,
                UserCertifyId,
                apiGetLib,
                punishUrl,
                cookieRequired
            };
    }
}
