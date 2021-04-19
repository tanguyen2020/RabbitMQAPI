using QueueRabbitMQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendQueueAPI.Services
{
    public interface ISendMessage
    {
        Task CreatePatientAsync(PatientInfo patient);
        Task UpdatePatientAsync(PatientInfo patient);
    }
}
