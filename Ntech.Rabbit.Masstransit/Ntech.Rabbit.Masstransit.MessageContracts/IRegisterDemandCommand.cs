using System;

namespace Ntech.Rabbit.Masstransit.MessageContracts
{
    public interface IRegisterDemandCommand
    {
        public string Subject { get; set; }
        public string Description { get; set; }

    }
}
