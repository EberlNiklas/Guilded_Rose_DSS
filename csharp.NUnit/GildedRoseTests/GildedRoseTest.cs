using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
            public void NormalItem_DegradesQualityByOne_BeforeSellIn()
            {
                // Arrange
                var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 10, Quality = 20 } };
                var app = new GildedRose(items);

                // Act
                app.UpdateQuality();

                // Assert
                Assert.AreEqual(9, items[0].SellIn);
                Assert.AreEqual(19, items[0].Quality);
            }

    [Test]
            public void AgedBrie_IncreasesQualityOverTime()
            {
                // Arrange
                var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
                var app = new GildedRose(items);

                // Act
                app.UpdateQuality();

                // Assert
                Assert.AreEqual(1, items[0].SellIn);
                Assert.AreEqual(1, items[0].Quality);
            }
}