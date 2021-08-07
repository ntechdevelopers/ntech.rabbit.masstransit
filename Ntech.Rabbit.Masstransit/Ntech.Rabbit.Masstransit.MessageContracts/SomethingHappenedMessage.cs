using System;
using System.Collections.Generic;
using System.Text;

namespace Ntech.Rabbit.Masstransit.MessageContracts
{
    public interface ISomethingHappened
    {
        public string What { get; set; }
        public DateTime When { get; set; }
    }

    public class SomethingHappenedMessage : ISomethingHappened
    {
        public string What { get; set; }
        public DateTime When { get; set; }
    }

    public interface IResponse
    {
        public string Message { get; set; }
    }

    public class ResponseMessage: IResponse
    {
        public string Message { get; set; }
    }
}
