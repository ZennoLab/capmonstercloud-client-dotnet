using System;
using System.Collections.Generic;
using Zennolab.CapMonsterCloud.Requests;

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

        private static readonly IReadOnlyDictionary<Type, GetResultTimeouts> ResultTimeouts =
            new Dictionary<Type, GetResultTimeouts>
            {
                {
                    typeof(RecaptchaV2Request), new GetResultTimeouts
                    {
                        FirstRequestDelay = TimeSpan.FromSeconds(1),
                        FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                        RequestsInterval = TimeSpan.FromSeconds(3),
                        Timeout = TimeSpan.FromSeconds(180)
                    }
                },
                {
                    typeof(RecaptchaV2EnterpriseRequest),
                    new GetResultTimeouts
                    {
                        FirstRequestDelay = TimeSpan.FromSeconds(1),
                        FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                        RequestsInterval = TimeSpan.FromSeconds(3),
                        Timeout = TimeSpan.FromSeconds(180)
                    }
                },
                {
                    typeof(RecaptchaV3ProxylessRequest),
                    new GetResultTimeouts
                    {
                        FirstRequestDelay = TimeSpan.FromSeconds(1),
                        FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                        RequestsInterval = TimeSpan.FromSeconds(3),
                        Timeout = TimeSpan.FromSeconds(180)
                    }
                },
                {
                    typeof(ImageToTextRequest),
                    new GetResultTimeouts
                    {
                        FirstRequestDelay = TimeSpan.FromMilliseconds(350),
                        RequestsInterval = TimeSpan.FromMilliseconds(200),
                        Timeout = TimeSpan.FromSeconds(10)
                    }
                },
                {
                    typeof(ComplexImageTaskRequestBase),
                    new GetResultTimeouts
                    {
                        FirstRequestDelay = TimeSpan.FromMilliseconds(350),
                        RequestsInterval = TimeSpan.FromMilliseconds(200),
                        Timeout = TimeSpan.FromSeconds(10)
                    }
                },
                {
                    typeof(FunCaptchaRequest),
                    new GetResultTimeouts
                    {
                        FirstRequestDelay = TimeSpan.FromSeconds(1),
                        FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                        RequestsInterval = TimeSpan.FromSeconds(1),
                        Timeout = TimeSpan.FromSeconds(80)
                    }
                },
                {
                    typeof(HCaptchaRequest),
                    new GetResultTimeouts
                    {
                        FirstRequestDelay = TimeSpan.FromSeconds(1),
                        FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                        RequestsInterval = TimeSpan.FromSeconds(3),
                        Timeout = TimeSpan.FromSeconds(180)
                    }
                },
                {
                    typeof(GeeTestRequest),
                    new GetResultTimeouts
                    {
                        FirstRequestDelay = TimeSpan.FromSeconds(1),
                        RequestsInterval = TimeSpan.FromSeconds(1),
                        Timeout = TimeSpan.FromSeconds(80)
                    }
                },
                {
                    typeof(TurnstileRequest),
                    new GetResultTimeouts
                    {
                        FirstRequestDelay = TimeSpan.FromSeconds(1),
                        FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                        RequestsInterval = TimeSpan.FromSeconds(1),
                        Timeout = TimeSpan.FromSeconds(80)
                    }
                },
                {
                    typeof(DataDomeCustomTaskRequest),
                    new GetResultTimeouts
                    {
                        FirstRequestDelay = TimeSpan.FromSeconds(1),
                        RequestsInterval = TimeSpan.FromSeconds(3),
                        Timeout = TimeSpan.FromSeconds(180)
                    }
                },
                {
                    typeof(AmazonWafRequest),
                    new GetResultTimeouts
                    {
                        FirstRequestDelay = TimeSpan.FromSeconds(1),
                        FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                        RequestsInterval = TimeSpan.FromSeconds(3),
                        Timeout = TimeSpan.FromSeconds(180)
                    }
                },
                {
                    typeof(TenDiCustomTaskRequest),
                    new GetResultTimeouts
                    {
                        FirstRequestDelay = TimeSpan.FromSeconds(1),
                        FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                        RequestsInterval = TimeSpan.FromSeconds(3),
                        Timeout = TimeSpan.FromSeconds(180)
                    }
                },
                {
                    typeof(BasiliskCustomTaskRequest),
                    new GetResultTimeouts
                    {
                        FirstRequestDelay = TimeSpan.FromSeconds(1),
                        FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                        RequestsInterval = TimeSpan.FromSeconds(3),
                        Timeout = TimeSpan.FromSeconds(100)
                    }
                },
                {
                    typeof(BinanceTaskRequest),
                    new GetResultTimeouts
                    {
                        FirstRequestDelay = TimeSpan.FromSeconds(1),
                        RequestsInterval = TimeSpan.FromSeconds(1),
                        Timeout = TimeSpan.FromSeconds(20)
                    }
                }
            };
    }
}
