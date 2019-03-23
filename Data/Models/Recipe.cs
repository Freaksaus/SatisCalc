using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public List<Input> Inputs { get; set; }
        public List<Output> Outputs { get; set; }
        public int CraftingTime { get; set; }

        public Building Building { get; set; }
    }
}
