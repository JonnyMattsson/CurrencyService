using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CurrencyService.ErrorHandling.Exceptions;
using CurrencyService.Services.Helpers;
using CurrencyService.Services.Models;

namespace CurrencyService.Services.External
{
    public class SweaCurrencyService : ICurrencyService
    {
        private readonly string _dateFormat = "yyyy-MM-dd";
        private readonly string _sweaUrl = "https://swea.riksbank.se/sweaWS/services/SweaWebServiceHttpSoap12Endpoint";
        private readonly string _sweaSchemeSource = "http://swea.riksbank.se/xsd";

        private readonly IHttpClientFactory _httpClientFactory;

        public SweaCurrencyService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<decimal> GetCurrencyRate(CurrencyConversion currencyConversion)
        {
            var client = _httpClientFactory.CreateClient();
            var requestBody = GetCurrencyRequestBody(currencyConversion);
                    
            var action = "urn:getInterestAndExchangeRates";
            var content = new StringContent(requestBody, Encoding.UTF8, "application/soap+xml");
            content.Headers.Add("SOAPAction", action);
            content.Headers.ContentType.Parameters.Add(
                new NameValueHeaderValue("action", $"\"{action}\""));

            try
            {
                var response = await client.PostAsync(_sweaUrl, content);

                //Unfortunately the model classed created from the WSDL can not be used in the serialization.
                //Maybe the WSDL is not aligned with the actual response from the api?
                var stringResponse = await response.Content.ReadAsStringAsync();
                var xmlResponse = new XmlDocument();
                xmlResponse.LoadXml(stringResponse);

                var namespaceManager = new XmlNamespaceManager(xmlResponse.NameTable);
                namespaceManager.AddNamespace("ns0", _sweaSchemeSource);

                var currencyRateAsExponentialValue = xmlResponse.SelectSingleNode("//resultrows/value", namespaceManager).InnerXml.Replace('.', ',');
                
                return decimal.Parse(currencyRateAsExponentialValue, NumberStyles.Float);
            }
            catch (Exception e)
            {
                throw new SweaCurrencyConversionException("Could not fetch currency rates", e);
            }
        }

        private string GetCurrencyRequestBody(CurrencyConversion currencyConversion)
        {
            var serieshelper = new SweaSeriesHelper();

            return $@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:xsd=""{_sweaSchemeSource}"">
                     <soap:Header/>
                     <soap:Body>
                      <xsd:getInterestAndExchangeRates>
                       <searchRequestParameters>
                        <aggregateMethod>D</aggregateMethod>
                        <datefrom>{currencyConversion.ExchangeRateDate.ToString(_dateFormat)}</datefrom>
                        <dateto>{currencyConversion.ExchangeRateDate.ToString(_dateFormat)}</dateto>
                        <languageid>en</languageid>
                        <min>false</min>
                        <avg>true</avg>
                        <max>false</max>
                        <ultimo>false</ultimo>			
                        <searchGroupSeries>		
                                        <groupid>130</groupid>			
                         <seriesid>{serieshelper.GetSeriesId(currencyConversion.InputCurrency, currencyConversion.OutputCurrency)}</seriesid>
                        </searchGroupSeries>
                       </searchRequestParameters>
                      </xsd:getInterestAndExchangeRates>
                     </soap:Body>
                    </soap:Envelope>";
        }
    }
}
