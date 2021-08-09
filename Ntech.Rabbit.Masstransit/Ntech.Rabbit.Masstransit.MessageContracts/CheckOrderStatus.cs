using System;
using System.Collections.Generic;
using System.Text;

namespace Ntech.Rabbit.Masstransit.MessageContracts
{
    public interface CheckOrderStatus
    {
        string OrderId { get; }
    }

    public interface OrderStatusResult
    {
        string OrderId { get; }
        DateTime Timestamp { get; }
        short StatusCode { get; }
        string StatusText { get; }
    }
}
