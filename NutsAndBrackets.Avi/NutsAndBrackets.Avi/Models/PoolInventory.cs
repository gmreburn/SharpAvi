namespace NutsAndBrackets.Avi.Models
{
    using System.Collections.Generic;
    
    public class PoolInventory
    {
        public virtual int count { get; set; }

        public virtual List<Result> results { get; set; }
    }
}