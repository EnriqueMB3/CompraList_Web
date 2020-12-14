using System;
using System.Collections.Generic;

namespace CompraList_Web.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Listo { get; set; }
        public string QuienAgrego { get; set; }
    }
}
