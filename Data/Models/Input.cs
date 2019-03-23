using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Input
    {
        public int InputId { get; set; }
        public int Amount { get; set; }

        public Item Item { get; set; }
        public Recipe Recipe { get; set; }
    }
}
