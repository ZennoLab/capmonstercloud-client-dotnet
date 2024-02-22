namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// DataDome CustomTask recognition request base
    /// </summary>
    public abstract class DataDomeCustomTaskRequestBase : CustomTaskRequestBase
    {        
        /// <inheritdoc/>
        public override string Class => "DataDome";

        /// <inheritdoc/>
        protected DataDomeCustomTaskRequestBase(string captchaUrl) => Metadata = new { captchaUrl };
    }
}
