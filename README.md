# Zennolab.CapMonsterCloud.Client

Official C# client library for [capmonster.cloud](https://capmonster.cloud/) captcha recognition service

## Installation

Via Package Manager:

    Install-Package Zennolab.CapMonsterCloud.Client

Via .NET CLI

    dotnet add package Zennolab.CapMonsterCloud.Client

## Usage

    var clientOptions = new ClientOptions
    {
        ClientKey = "<your capmonster.cloud API key>"
    };

    var cmCloudClient = CapMonsterCloudClientFactory.Create(clientOptions);

    // solve RecaptchaV2 (without proxy)
    var recaptchaV2Request = new RecaptchaV2ProxylessRequest
    {
        WebsiteUrl = "https://lessons.zennolab.com/captchas/recaptcha/v2_simple.php?level=high",
        WebsiteKey = "6Lcg7CMUAAAAANphynKgn9YAgA4tQ2KI_iqRyTwd",
    };
    var recaptchaV2Result = await cmCloudClient.SolveAsync(recaptchaV2Request);

    // solve HCaptcha (without proxy)
    var hcaptchaRequest = new HCaptchaProxylessRequest
    {
        WebsiteUrl = "https://lessons.zennolab.com/captchas/hcaptcha/?level=easy",
        WebsiteKey = "472fc7af-86a4-4382-9a49-ca9090474471",
    };
    var hcaptchaResult = await cmCloudClient.SolveAsync(hcaptchaRequest);

Supported captcha recognition requests:

- FunCaptchaProxylessRequest
- FunCaptchaRequest
- GeeTestProxylessRequest
- GeeTestRequest
- HCaptchaProxylessRequest
- HCaptchaRequest
- ImageToTextRequest
- RecaptchaV2ProxylessRequest
- RecaptchaV2Request
- RecaptchaV3ProxylessRequest