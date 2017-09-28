namespace FabrikamFiber.DAL.Models
{
    using System;

    public class Message
    {
        public int ID { get; set; }

        public DateTime Sent { get; set; }

        public string Description { get; set; }
    }
}