namespace CapMonsterCloud.Client.IntegrationTests;

public record HttpRequestSettings(
    RequestType Type,
    object ExpectedRequest,
    object ActualResponse);