using System.Collections.Generic;
using NUnit.Framework;

namespace csharp
{

    class InventoryItemFactory
    {
        public static InventoryItem Create(Item item)
        {
            InventoryItem invIt = new InventoryItem(item);

            if (invIt.IsSulfuras())
            {
                return new Sulfuras(item);
            }

            if (invIt.IsAgedBrie())
            {
                return new AgedBrie(item);
            }

            if (invIt.IsBackstagePass())
            {
                return new BackstagePass(item);
            }

            return invIt;
        }
    }

    public class GildedRose
    {
        IList<Item> Items;
        IList<InventoryItem> InventoryItems = [];
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;

            // initialize InventoryItems
            foreach (var item in Items)
            {
                InventoryItems.Add(InventoryItemFactory.Create(item));
            }
        }

        public void UpdateItems()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var invItem = InventoryItems[i];
                invItem.UpdateItem();
            }
        }
    }
}
