using System;
using CurrencyService.Services.Models;
using FluentValidation;

namespace CurrencyService.Controllers.Models.Validators
{
    public class CurrencyConversationValidator : AbstractValidator<CurrencyConversionRequest>
    {
        public CurrencyConversationValidator()
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(c => c.Amount).GreaterThan(0).WithMessage("Amount needs to be a positive number");
            RuleFor(c => c.InputCurrency).NotEmpty().IsEnumName(typeof(Currency)).WithMessage("Not a supported inout currency");
            RuleFor(c => c.OutputCurrency).NotEmpty().IsEnumName(typeof(Currency)).WithMessage("Not a supported inout currency");
            RuleFor(c => c.ExchangeRateDate).LessThan(DateTime.UtcNow.AddDays(-1)).WithMessage("Date of exchange rate can not be in the future");
            RuleFor(c => c).Custom((c, context) =>
            {
                if (Enum.Parse<Currency>(c.InputCurrency) != Currency.SEK &&
                    Enum.Parse<Currency>(c.OutputCurrency) != Currency.SEK)
                {
                    context.AddFailure($"One of the currencies needs to be SEK");
                }
            });
            RuleFor(c => c).Custom((c, context) =>
            {
                if (Enum.Parse<Currency>(c.InputCurrency) == Enum.Parse<Currency>(c.OutputCurrency) )
                {
                    context.AddFailure($"Input currency can not be same as output currency");
                }
            });
        }
    }
}
