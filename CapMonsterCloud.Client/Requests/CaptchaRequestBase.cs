namespace Zennolab.CapMonsterCloud.Requests
{    
    /// <summary>
    /// Base captcha recognition request
    /// </summary>
    public abstract class CaptchaRequestBase
    {        
        /// <summary>
        /// Gets recognition task type
        /// </summary>
        public abstract string Type { get; }


        internal virtual bool UseNoCache => false;
    }
}
