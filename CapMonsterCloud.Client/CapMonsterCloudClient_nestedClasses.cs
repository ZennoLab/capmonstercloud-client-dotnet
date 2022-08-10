using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud
{
    public partial class CapMonsterCloudClient
    {
        private class ResponseBase
        {
#pragma warning disable IDE1006 // Naming Styles
            public int errorId { get; set; }

            public string errorCode { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        }

        private class GetBalanceResponse : ResponseBase
        {
#pragma warning disable IDE1006 // Naming Styles
            public decimal balance { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        }

        private class CreateTaskResponse : ResponseBase
        {
#pragma warning disable IDE1006 // Naming Styles
            public int taskId { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        }

        private class GetTaskResultResponse : ResponseBase
        {
#pragma warning disable IDE1006 // Naming Styles
            public string status { get; set; }

            public object solution { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        }

        private abstract class TaskResult
        {
            public class TaskInProgress : TaskResult
            {
            }

            public class TaskFailed : TaskResult
            {
                public TaskFailed(ErrorType error)
                {
                    this.Error = error;

                }

                public ErrorType Error { get; }
            }

            public class TaskCompleted : TaskResult
            {
                public TaskCompleted(object solution)
                {
                    this.Solution = solution;
                }

                public object Solution { get; }
            }

            public static TaskInProgress InProgress { get; } = new TaskInProgress();

            public static TaskFailed Failed(ErrorType error) => new TaskFailed(error);

            public static TaskCompleted Completed(object solution) => new TaskCompleted(solution);
        }

        private class CreateTaskRequest
        {
#pragma warning disable IDE1006 // Naming Styles
            public string clientKey { get; set; }

            public Requests.CaptchaRequestBase task { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int? softId { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        }
    }
}
