using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CurrencyService.Services;
using CurrencyService.Services.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CurrencyService.Test
{
    [TestClass]
    public class CurrenctConversionServiceTests
    {
        [TestMethod]
        public async Task Given_CurrencyRate_When_ConvertingFromSekToUsd_Then_ConvertedAmountIsCorrect()
        {
            //Arrange
            var currencyService = new Mock<ICurrencyService>();
            var currencyRate = 8.6502M;
            currencyService.Setup(p => p.GetCurrencyRate(It.IsAny<CurrencyConversion>())).ReturnsAsync(currencyRate);

            var currencyConversionService = new CurrencyConversionService(currencyService.Object);
            var currencyConversion = new CurrencyConversion()
            {
                OutputCurrency = Currency.USD,
                InputCurrency = Currency.SEK,
                Amount = 100,
                ExchangeRateDate = new DateTime(2020, 08, 19)
            };

            //Act
            currencyConversion = await currencyConversionService.Convert(currencyConversion);

            //Assert
            Assert.AreEqual(11.56M, decimal.Round(currencyConversion.ConvertedAmount,2));
        }

        [TestMethod]
        public async Task Given_CurrencyRate_When_ConvertingFromUsdToSek_Then_ConvertedAmountIsCorrect()
        {
            //Arrange
            var currencyService = new Mock<ICurrencyService>();
            var currencyRate = 8.6502M;
            currencyService.Setup(p => p.GetCurrencyRate(It.IsAny<CurrencyConversion>())).ReturnsAsync(currencyRate);

            var currencyConversionService = new CurrencyConversionService(currencyService.Object);
            var currencyConversion = new CurrencyConversion()
            {
                OutputCurrency = Currency.SEK,
                InputCurrency = Currency.USD,
                Amount = 100,
                ExchangeRateDate = new DateTime(2020, 08, 19)
            };

            //Act
            currencyConversion = await currencyConversionService.Convert(currencyConversion);

            //Assert
            Assert.AreEqual(865.02M, decimal.Round(currencyConversion.ConvertedAmount, 2));
        }

        [TestMethod]
        public async Task Given_CurrencyRate_When_ConvertingFromSekToEur_Then_ConvertedAmountIsCorrect()
        {
            //Arrange
            var currencyService = new Mock<ICurrencyService>();
            var currencyRate = 10.3183M;
            currencyService.Setup(p => p.GetCurrencyRate(It.IsAny<CurrencyConversion>())).ReturnsAsync(currencyRate);

            var currencyConversionService = new CurrencyConversionService(currencyService.Object);
            var currencyConversion = new CurrencyConversion()
            {
                OutputCurrency = Currency.EUR,
                InputCurrency = Currency.SEK,
                Amount = 100,
                ExchangeRateDate = new DateTime(2020, 08, 19)
            };

            //Act
            currencyConversion = await currencyConversionService.Convert(currencyConversion);

            //Assert
            Assert.AreEqual(9.69M, decimal.Round(currencyConversion.ConvertedAmount, 2));
        }

        [TestMethod]
        public async Task Given_CurrencyRate_When_ConvertingFromEurToSek_Then_ConvertedAmountIsCorrect()
        {
            //Arrange
            var currencyService = new Mock<ICurrencyService>();
            var currencyRate = 10.3183M;
            currencyService.Setup(p => p.GetCurrencyRate(It.IsAny<CurrencyConversion>())).ReturnsAsync(currencyRate);

            var currencyConversionService = new CurrencyConversionService(currencyService.Object);
            var currencyConversion = new CurrencyConversion()
            {
                OutputCurrency = Currency.SEK,
                InputCurrency = Currency.EUR,
                Amount = 100,
                ExchangeRateDate = new DateTime(2020, 08, 19)
            };

            //Act
            currencyConversion = await currencyConversionService.Convert(currencyConversion);

            //Assert
            Assert.AreEqual(1031.83M, decimal.Round(currencyConversion.ConvertedAmount, 2));
        }
    }
}
