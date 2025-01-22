
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private readonly IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateItemQuality(item);
            }
        }

        private void UpdateItemQuality(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    UpdateAgedBrie(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateBackstagePass(item);
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    // Sulfuras does not change in quality
                    break;
                default:
                    UpdateNormalItem(item);
                    break;
            }
        }

        private void UpdateAgedBrie(Item item)
        {
            IncreaseQuality(item);
            item.SellIn--;

            if (item.SellIn < 0)
            {
                IncreaseQuality(item);
            }
        }

        private void UpdateBackstagePass(Item item)
        {
            IncreaseQuality(item);

            if (item.SellIn <= 10)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn <= 5)
            {
                IncreaseQuality(item);
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }

        private void UpdateNormalItem(Item item)
        {
            DecreaseQuality(item);
            item.SellIn--;

            if (item.SellIn < 0)
            {
                DecreaseQuality(item);
            }
        }

        private void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        private void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return $"{Name}, {SellIn}, {Quality}";
        }
    }
}
