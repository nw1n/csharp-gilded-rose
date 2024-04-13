using System.Collections.Generic;

namespace csharp
{
    public class InventoryItem
    {
        private Item item;

        public InventoryItem(Item item)
        {
            this.item = item;
        }

        public string Name
        {
            get { return item.Name; }
            // set { item.Name = value; }
        }

        public int SellIn
        {
            get { return item.SellIn; }
            set { item.SellIn = value; }
        }

        public int DaysUntilExpired
        {
            get { return item.SellIn; }
            set { item.SellIn = value; }
        }

        public int Quality
        {
            get { return item.Quality; }
            set { item.Quality = value; }
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
                InventoryItems.Add(new InventoryItem(item));
            }
        }

        public static bool IsBackstagePass(InventoryItem item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var inventoryItem = InventoryItems[i];

                if (inventoryItem.Name != "Aged Brie" && !IsBackstagePass(inventoryItem))
                {
                    if (inventoryItem.Quality > 0)
                    {
                        if (inventoryItem.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            inventoryItem.Quality = inventoryItem.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (inventoryItem.Quality < 50)
                    {
                        inventoryItem.Quality = inventoryItem.Quality + 1;

                        if (IsBackstagePass(inventoryItem))
                        {
                            if (inventoryItem.SellIn < 11)
                            {
                                if (inventoryItem.Quality < 50)
                                {
                                    inventoryItem.Quality = inventoryItem.Quality + 1;
                                }
                            }

                            if (inventoryItem.SellIn < 6)
                            {
                                if (inventoryItem.Quality < 50)
                                {
                                    inventoryItem.Quality = inventoryItem.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (inventoryItem.Name != "Sulfuras, Hand of Ragnaros")
                {
                    inventoryItem.SellIn = inventoryItem.SellIn - 1;
                }

                if (inventoryItem.SellIn < 0)
                {
                    if (inventoryItem.Name != "Aged Brie")
                    {
                        if (!IsBackstagePass(inventoryItem))
                        {
                            if (inventoryItem.Quality > 0)
                            {
                                if (inventoryItem.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    inventoryItem.Quality = inventoryItem.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            inventoryItem.Quality = inventoryItem.Quality - inventoryItem.Quality;
                        }
                    }
                    else
                    {
                        if (inventoryItem.Quality < 50)
                        {
                            inventoryItem.Quality = inventoryItem.Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
