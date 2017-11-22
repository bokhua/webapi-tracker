using System;

namespace webapi.Models
{
    public class ClientView
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public string RemoteAddress { get; set; }

        public string RemotePort { get; set; }

        public string UserAgent { get; set; }
    }
}