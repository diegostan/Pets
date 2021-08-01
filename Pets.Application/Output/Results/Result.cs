using System.Collections.Generic;
using Pets.Application.Output.Results.Interfaces;
using Pets.Domain.Notifications;

namespace Pets.Application.Output.Results
{
    public class Result : IResultBase
    {
        private List<Notification> _notifications;

        public Result(int resultCode, string message, bool isOk)
        {
            ResultCode = resultCode;
            Message = message;
            IsOk = isOk;
            _notifications = new List<Notification>();
        }

        public int ResultCode { get; private set; }
        public string Message { get; private set; }
        public bool IsOk { get; private set; }
        public object Data { get; private set; }        
        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public void SetNotifications(List<Notification> notifications)
        {
            _notifications = notifications;
        }
        public void SetData(object data)
        {
            Data = data;
        }
    }
}