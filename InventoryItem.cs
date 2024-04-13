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

        public bool IsPastExpiration()
        {
            return DaysUntilExpired < 0;
        }

        public bool IsBasicItem()
        {
            return !IsAgedBrie() && !IsBackstagePass() && !IsSulfuras();
        }

        public virtual void DecreaseDaysUntilExpired()
        {
            DaysUntilExpired--;
        }

        public virtual void updateOnlyQuality()
        {
            DecreaseQuality();

            if (IsPastExpiration())
            {
                DecreaseQuality();
            }
        }

        public void UpdateItem()
        {
            DecreaseDaysUntilExpired();
            updateOnlyQuality();
        }
    }

    class Sulfuras : InventoryItem
    {
        public Sulfuras(Item item) : base(item)
        {
        }

        public override void DecreaseDaysUntilExpired()
        {
            return;
        }

        public override void updateOnlyQuality()
        {
            return;
        }
    }

    class AgedBrie : InventoryItem
    {
        public AgedBrie(Item item) : base(item)
        {
        }

        public override void updateOnlyQuality()
        {
            IncreaseQuality();

            if (IsPastExpiration())
            {
                IncreaseQuality();
            }
        }
    }

    class BackstagePass : InventoryItem
    {
        public BackstagePass(Item item) : base(item)
        {
        }

        public void setQualityToZero()
        {
            Quality = 0;
        }

        public override void updateOnlyQuality()
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
}