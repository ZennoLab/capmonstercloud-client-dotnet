namespace Zennolab.CapMonsterCloud
{
    /// <summary>
    /// Interface for <see cref="ICapMonsterCloudClient"/> factory
    /// </summary>
    public interface ICapMonsterCloudClientFactory
    {
        /// <summary>
        /// Creates new instance of <see cref="ICapMonsterCloudClient"/>
        /// </summary>
        /// <returns>instance of <see cref="ICapMonsterCloudClient"/></returns>
        ICapMonsterCloudClient Create();
    }
}