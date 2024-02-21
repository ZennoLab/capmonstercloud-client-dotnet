using System;

namespace Zennolab.CapMonsterCloud
{
    public partial class CapMonsterCloudClient
    {
        private struct GetResultTimeouts
        {
            public TimeSpan FirstRequestDelay { get; set; }

            public TimeSpan? FirstRequestNoCacheDelay { get; set; }

            public TimeSpan RequestsInterval { get; set; }

            public TimeSpan Timeout { get; set; }
        }

        private static readonly GetResultTimeouts RecaptchaV2Timeouts = new GetResultTimeouts
        {
            FirstRequestDelay = TimeSpan.FromSeconds(1),
            FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
            RequestsInterval = TimeSpan.FromSeconds(3),
            Timeout = TimeSpan.FromSeconds(180)
        };

        private static readonly GetResultTimeouts RecaptchaV2EnterpriseTimeouts = new GetResultTimeouts
        {
            FirstRequestDelay = TimeSpan.FromSeconds(1),
            FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
            RequestsInterval = TimeSpan.FromSeconds(3),
            Timeout = TimeSpan.FromSeconds(180)
        };

        private static readonly GetResultTimeouts RecaptchaV3Timeouts = new GetResultTimeouts
        {
            FirstRequestDelay = TimeSpan.FromSeconds(1),
            FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
            RequestsInterval = TimeSpan.FromSeconds(3),
            Timeout = TimeSpan.FromSeconds(180)
        };

        private static readonly GetResultTimeouts ImageToTextTimeouts = new GetResultTimeouts
        {
            FirstRequestDelay = TimeSpan.FromMilliseconds(350),
            RequestsInterval = TimeSpan.FromMilliseconds(200),
            Timeout = TimeSpan.FromSeconds(10)
        };

        private static readonly GetResultTimeouts FunCaptchaTimeouts = new GetResultTimeouts
        {
            FirstRequestDelay = TimeSpan.FromSeconds(1),
            FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
            RequestsInterval = TimeSpan.FromSeconds(1),
            Timeout = TimeSpan.FromSeconds(80)
        };

        private static readonly GetResultTimeouts HCaptchaTimeouts = new GetResultTimeouts
        {
            FirstRequestDelay = TimeSpan.FromSeconds(1),
            FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
            RequestsInterval = TimeSpan.FromSeconds(3),
            Timeout = TimeSpan.FromSeconds(180)
        };

        private static readonly GetResultTimeouts GeeTestTimeouts = new GetResultTimeouts
        {
            FirstRequestDelay = TimeSpan.FromSeconds(1),
            RequestsInterval = TimeSpan.FromSeconds(1),
            Timeout = TimeSpan.FromSeconds(80)
        };

        private static readonly GetResultTimeouts TurnstileTimeouts = new GetResultTimeouts
        {
            FirstRequestDelay = TimeSpan.FromSeconds(1),
            FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
            RequestsInterval = TimeSpan.FromSeconds(1),
            Timeout = TimeSpan.FromSeconds(80)
        };

        private static readonly GetResultTimeouts DataDomeTimeouts = new GetResultTimeouts
        {
            FirstRequestDelay = TimeSpan.FromSeconds(1),
            RequestsInterval = TimeSpan.FromSeconds(3),
            Timeout = TimeSpan.FromSeconds(180)
        };
    }
}
