using System.Collections.Generic;
using NUnit.Framework;

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

        public override string ToString()
        {
            return Name + ", " + SellIn + ", " + Quality;
        }

        public bool IsBackstagePass()
        {
            return Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public bool IsAgedBrie()
        {
            return Name == "Aged Brie";
        }

        public bool IsSulfuras()
        {
            return Name == "Sulfuras, Hand of Ragnaros";
        }

        public bool IsQualityLessThan50()
        {
            return Quality < 50;
        }

        public bool IsQualityGreaterThan0()
        {
            return Quality > 0;
        }

        public void setQualityToZero()
        {
            Quality = 0;
        }

        public void IncreaseQuality()
        {
            Quality++;
        }

        public void DecreaseQuality()
        {
            Quality--;
        }

        public void DecreaseDaysUntilExpired()
        {
            SellIn--;
        }

        public bool IsPastExpiration()
        {
            return SellIn < 0;
        }

        public void UpdateQuality()
        {
            if (!IsAgedBrie() && !IsBackstagePass())
            {
                if (IsQualityGreaterThan0())
                {
                    if (!IsSulfuras())
                    {
                        DecreaseQuality();
                    }
                }
            }
            else
            {
                if (IsQualityLessThan50())
                {
                    IncreaseQuality();

                    if (IsBackstagePass())
                    {
                        if (SellIn < 11)
                        {
                            if (IsQualityLessThan50())
                            {
                                IncreaseQuality();
                            }
                        }

                        if (SellIn < 6)
                        {
                            if (IsQualityLessThan50())
                            {
                                IncreaseQuality();
                            }
                        }
                    }
                }
            }

            if (!IsSulfuras())
            {
                DecreaseDaysUntilExpired();
            }

            if (IsPastExpiration())
            {
                if (IsAgedBrie())
                {
                    if (IsQualityLessThan50())
                    {
                        IncreaseQuality();
                    }
                }
                else
                {
                    if (!IsBackstagePass())
                    {
                        if (IsQualityGreaterThan0())
                        {
                            if (!IsSulfuras())
                            {
                                DecreaseQuality();
                            }
                        }
                    }
                    else
                    {
                        setQualityToZero();
                    }
                }
            }
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

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var invItem = InventoryItems[i];
                invItem.UpdateQuality();
            }
        }
    }
}
