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
            if (Quality == 50)
            {
                return;
            }
            Quality++;
        }

        public void DecreaseQuality()
        {
            if (Quality == 0)
            {
                return;
            }
            Quality--;
        }

        public void DecreaseDaysUntilExpired()
        {
            if (IsSulfuras())
            {
                return;
            }
            DaysUntilExpired--;
        }

        public bool IsPastExpiration()
        {
            return DaysUntilExpired < 0;
        }

        public bool IsBasicItem()
        {
            return !IsAgedBrie() && !IsBackstagePass() && !IsSulfuras();
        }

        public void updateOnlyQuality()
        {
            if (IsSulfuras())
            {
                return;
            }

            if (IsAgedBrie())
            {
                IncreaseQuality();

                if (IsPastExpiration())
                {
                    IncreaseQuality();
                }
            }

            if (IsBasicItem())
            {
                DecreaseQuality();

                if (IsPastExpiration())
                {
                    DecreaseQuality();
                }
            }

            if (IsBackstagePass())
            {
                if (IsPastExpiration())
                {
                    setQualityToZero();
                    return;
                }

                IncreaseQuality();

                if (DaysUntilExpired < 10)
                {
                    IncreaseQuality();
                }

                if (DaysUntilExpired < 5)
                {
                    IncreaseQuality();
                }
            }
        }



        public void UpdateItem()
        {
            DecreaseDaysUntilExpired();
            updateOnlyQuality();
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
