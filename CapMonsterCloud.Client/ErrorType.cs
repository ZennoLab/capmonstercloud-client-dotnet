namespace Zennolab.CapMonsterCloud
{
    /// <summary>
    /// Error types
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// Captcha recognition timeout is expired
        /// </summary>
        Timeout = -2,
        /// <summary>
        /// Unknown error. Maybe client library is outdated
        /// </summary>
        Unknown = -1,
        /// <summary>
        /// Account authorization key not found in the system or has incorrect format
        /// </summary>
        KEY_DOES_NOT_EXIST = 0,
        /// <summary>
        /// The size of the captcha you are uploading is less than 100 bytes.
        /// </summary>
        ZERO_CAPTCHA_FILESIZE,
        /// <summary>
        /// The size of the captcha you are uploading is more than 50,000 bytes.
        /// </summary>
        TOO_BIG_CAPTCHA_FILESIZE,
        /// <summary>
        /// Account has zero balance
        /// </summary>
        ZERO_BALANCE,
        /// <summary>
        /// Request with current account key is not allowed from your IP
        /// </summary>
        IP_NOT_ALLOWED,
        /// <summary>
        /// This type of captchas is not supported by the service
        /// or the image does not contain an answer, perhaps it is too noisy.
        /// It could also mean that the image is corrupted or was incorrectly rendered.
        /// </summary>
        CAPTCHA_UNSOLVABLE,
        /// <summary>
        /// The captcha that you are requesting was not found.
        /// Make sure you are requesting a status update only within 5 minutes of uploading.
        /// </summary>
        NO_SUCH_CAPCHA_ID,
        /// <summary>
        /// You have exceeded the limit of requests with the wrong api key,
        /// check the correctness of your api key in the control panel and after some time, try again
        /// </summary>
        IP_BANNED,
        /// <summary>
        /// This method is not supported or empty
        /// </summary>
        NO_SUCH_METHOD,
        /// <summary>
        /// You have exceeded the limit of requests to receive an answer for one task.
        /// Try to request the result of the task no more than 1 time in 2 seconds.
        /// </summary>
        TOO_MUCH_REQUESTS,
        /// <summary>
        /// Captcha from some domains cannot be solved in CapMonster Cloud.
        /// If you try to create a task for such a domain, this error will return.
        /// </summary>
        DOMAIN_NOT_ALLOWED,
        /// <summary>
        /// Captcha provider server reported that the additional token has expired.
        /// Try creating task with a new token.
        /// </summary>
        TOKEN_EXPIRED,
        /// <summary>
        /// You have excedded requests rate limit, try to decrease parallel tasks amount.
        /// </summary>
        NO_SLOT_AVAILABLE
    }
}
