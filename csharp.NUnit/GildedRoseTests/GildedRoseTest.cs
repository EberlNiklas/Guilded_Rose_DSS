using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest {
    [Test]
    public void NormalItem_DegradesQualityByOne_BeforeSellIn() {
        // Arrange
        var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(items[0].SellIn, Is.EqualTo(9));
        Assert.That(items[0].Quality, Is.EqualTo(19));
    }

    [Test]
    public void AgedBrie_IncreasesQualityOverTime() {
        // Arrange
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(items[0].SellIn, Is.EqualTo(1));
        Assert.That(items[0].Quality, Is.EqualTo(1));
    }

    [Test]
    public void Sulfuras_DoesNotChangeQualityOrSellIn() {
        // Arrange
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(items[0].SellIn, Is.EqualTo(0));
        Assert.That(items[0].Quality, Is.EqualTo(80));
    }

    [Test]
    public void BackstagePasses_IncreaseQualityAsSellInApproaches() {
        // Arrange
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(items[0].SellIn, Is.EqualTo(10));
        Assert.That(items[0].Quality, Is.EqualTo(11));
    }

    [Test]
    public void BackstagePasses_QualityDropsToZeroAfterConcert() {
        // Arrange
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    [Test]
    public void Quality_NeverGoesAbove50() {
        // Arrange
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    [Test]
    public void Quality_NeverGoesBelowZero() {
        // Arrange
        var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 1, Quality = 0 } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }
}