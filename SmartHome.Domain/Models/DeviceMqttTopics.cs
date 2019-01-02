using System;
using System.Collections.Generic;

namespace SmartHome.Domain.Models
{
    public partial class DeviceMqttTopics
    {
        public Guid Id { get; set; }
        public Guid IoTdeviceId { get; set; }
        public Guid MqttTopicId { get; set; }

        public virtual Device IoTdevice { get; set; }
        public virtual MqttTopics MqttTopic { get; set; }
    }
}
