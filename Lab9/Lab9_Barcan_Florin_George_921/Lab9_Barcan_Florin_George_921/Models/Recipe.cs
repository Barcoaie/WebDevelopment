using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab9_Barcan_Florin_George_921.Models
{
    public class Recipe
    {
        public int Recipe_ID { get; set; }
        public int Recipe_Author_ID { get; set; }
        public string Recipe_Ingredients { get; set; }
        public string Recipe_Instructions { get; set; }
        public string Recipe_Name { get; set; }
    }
}