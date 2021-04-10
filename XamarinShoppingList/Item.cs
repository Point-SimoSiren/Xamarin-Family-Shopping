using System;

namespace XamarinShoppingList
{
    public partial class Item
    {
        public DateTime TimeAdded { get; set; }
        public string ItemName { get; set; }
        public int? Pieces { get; set; }
        public int Id { get; set; }
    }
}
