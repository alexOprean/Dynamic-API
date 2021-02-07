namespace Dynamic.Core.ViewModels
{
    using System;

    public class ErrorViewModel
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string InnerMessage { get; set; }
        public string StackTrace { get; set; }

        public ErrorViewModel(Exception ex)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;

            if (ex.InnerException != null)
            {
                InnerMessage = ex.InnerException.Message;
            }
            StackTrace = ex.ToString();
        }
    }
}
