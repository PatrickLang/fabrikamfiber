namespace FabrikamFiber.DAL.Models
{
    using System;

    public class Alert
    {
        public int ID { get; set; }

        public DateTime Created { get; set; }

        public string Description { get; set; }
    }
}