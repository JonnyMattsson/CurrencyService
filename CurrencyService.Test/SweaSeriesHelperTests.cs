using CurrencyService.Services.Helpers;
using CurrencyService.Services.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyService.Test
{
    [TestClass]
    public class SweaSeriesHelperTests
    {
        [TestMethod]
        public void Given_ConversionRequestFromUsdToSek_When_CreatingSeriesName_Then_SeriesIdIsValid()
        {
            //Arrange
            var inputCurrency = Currency.USD;
            var outputCurrency = Currency.SEK;
            var seriesHelper = new SweaSeriesHelper();

            //Act
            var seriesId = seriesHelper.GetSeriesId(inputCurrency, outputCurrency);

            //Assert
            Assert.AreEqual("SEKUSDPMI", seriesId,true);
        }

        [TestMethod]
        public void Given_ConversionRequestFromSekToUsd_When_CreatingSeriesName_Then_SeriesIdIsValid()
        {
            //Arrange
            var inputCurrency = Currency.SEK;
            var outputCurrency = Currency.USD;
            var seriesHelper = new SweaSeriesHelper();

            //Act
            var seriesId = seriesHelper.GetSeriesId(inputCurrency, outputCurrency);

            //Assert
            Assert.AreEqual("SEKUSDPMI", seriesId, true);
        }

        [TestMethod]
        public void Given_ConversionRequestFromEurToSek_When_CreatingSeriesName_Then_SeriesIdIsValid()
        {
            //Arrange
            var inputCurrency = Currency.EUR;
            var outputCurrency = Currency.SEK;
            var seriesHelper = new SweaSeriesHelper();

            //Act
            var seriesId = seriesHelper.GetSeriesId(inputCurrency, outputCurrency);

            //Assert
            Assert.AreEqual("SEKEURPMI", seriesId, true);
        }

        [TestMethod]
        public void Given_ConversionRequestFromSekToEur_When_CreatingSeriesName_Then_SeriesIdIsValid()
        {
            //Arrange
            var inputCurrency = Currency.SEK;
            var outputCurrency = Currency.EUR;
            var seriesHelper = new SweaSeriesHelper();

            //Act
            var seriesId = seriesHelper.GetSeriesId(inputCurrency, outputCurrency);

            //Assert
            Assert.AreEqual("SEKEURPMI", seriesId, true);
        }
    }
}
