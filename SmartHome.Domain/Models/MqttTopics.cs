using System;
using System.Collections.Generic;

namespace SmartHome.Domain.Models
{
    public partial class MqttTopics
    {
        public MqttTopics()
        {
            DeviceMqttTopics = new HashSet<DeviceMqttTopics>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public int? LocationId { get; set; }
        public int QoSlevel { get; set; }

        public virtual ICollection<DeviceMqttTopics> DeviceMqttTopics { get; set; }
    }
}
