using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Basket.API.Basket.CheckoutBasket;

public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto) : ICommand<CheckoutBasketResult>;

public record CheckoutBasketResult(bool IsSuccess);

public class CheckoutBasketCommandValidator : AbstractValidator<CheckoutBasketCommand>
{
    public CheckoutBasketCommandValidator()
    {
        RuleFor(x => x.BasketCheckoutDto).NotNull().WithMessage("BasketCheckoutDto is required.");
        RuleFor(x => x.BasketCheckoutDto.UserName).NotEmpty().WithMessage("UserName is required.");
        RuleFor(x => x.BasketCheckoutDto.EmailAddress).NotEmpty().WithMessage("EmailAddress is required.");
    }
}

public class CheckoutBasketHandler(
    IBasketRepository repository,
    IPublishEndpoint publishEndpoint) : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
{
    public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken ct)
    {
        var checkout = command.BasketCheckoutDto;

        var basket = await repository.GetBasketAsync(checkout.UserName, ct);

        if (basket is null)
        {
            return new CheckoutBasketResult(false);
        }

        var eventMessage = new BasketCheckoutEvent
        {
            UserName = checkout.UserName,
            CustomerId = checkout.CustomerId,
            TotalPrice = basket.TotalPrice,

            FirstName = checkout.FirstName,
            LastName = checkout.LastName,
            EmailAddress = checkout.EmailAddress,
            AddressLine = checkout.AddressLine,
            Country = checkout.Country,
            State = checkout.State,
            ZipCode = checkout.ZipCode,

            CardName = checkout.CardName,
            CardNumber = checkout.CardNumber,
            Expiration = checkout.Expiration,
            CVV = checkout.CVV,
            PaymentMethod = checkout.PaymentMethod
        };

        await publishEndpoint.Publish(eventMessage, ct);

        await repository.DeleteBasket(checkout.UserName, ct);

        return new CheckoutBasketResult(true);
    }
}