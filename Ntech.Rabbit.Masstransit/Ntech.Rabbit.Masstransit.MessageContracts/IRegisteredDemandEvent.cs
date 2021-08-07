using System;
using System.Collections.Generic;
using System.Text;

namespace Ntech.Rabbit.Masstransit.MessageContracts
{
  public  interface IRegisteredDemandEvent
    {
        public Guid DemandId { get; set; }
    }
}
