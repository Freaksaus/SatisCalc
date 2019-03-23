using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Output
    {
        public int OutputId { get; set; }
        public int Amount { get; set; }

        public Item Item { get; set; }
        public Recipe Recipe { get; set; }
    }
}
