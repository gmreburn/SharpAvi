namespace NutsAndBrackets.Avi.Models
{
    using System.Collections.Generic;

    public class Pool
    {
        public string uuid { get; set; }

        public string name { get; set; }

        public bool enabled { get; set; }

        public string tenant_ref { get; set; }

        public List<Server> servers { get; set; }
    }
}