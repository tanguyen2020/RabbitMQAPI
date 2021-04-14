using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendQueueAPI.Services
{
    public interface ISendMessage
    {
        void SendMessageQueue(object body);
    }
}
