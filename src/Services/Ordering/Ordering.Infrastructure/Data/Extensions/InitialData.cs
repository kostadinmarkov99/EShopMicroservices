namespace Ordering.Infrastructure.Data.Extensions;

public class InitialData
{
    public static IEnumerable<Customer> Customers =>
        new List<Customer>
        {
            Customer.Create(
                CustomerId.Of(new Guid("7d3f1b8e-5f9c-4d91-8b7a-2c4f8e9d1a73")),
                "kostadin",
                "kostadin@gmail.com"),

            Customer.Create(
                CustomerId.Of(new Guid("c8a72f34-1e6d-4a91-b5c7-9f2d8a3e4b61")),
                "asen",
                "asen@gmail.com")
        };

    public static IEnumerable<Product> Products =>
        new List<Product>
        {
            Product.Create(
                ProductId.Of(new Guid("d1f8e9d1-8b7a-4d91-5f9c-7d3f1b8e5f9c")),
                "Iphone 19",
                500m),

            Product.Create(
                ProductId.Of(new Guid("e6d4a3e4-b61c-4a91-1e6d-c8a72f34b5c7")),
                "Samsung 10",
                400m),

            Product.Create(
                ProductId.Of(new Guid("f9c7d3f1-b8e5-4d91-5f9c-1e6d4a3e4b61")),
                "Huawei Plus",
                650m),

            Product.Create(
                ProductId.Of(new Guid("a3e4b61c-4a91-1e6d-c8a7-2f34b5c7d3f1")),
                "Xiaomi Mi",
                450m)
        };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of(
                "Kostadin",
                "Markov",
                "kostadin@gmail.com",
                "Sofia",
                "Bulgaria",
                "Sofia",
                "1000");

            var address2 = Address.Of(
                "Asen",
                "Petrov",
                "asen@gmail.com",
                "Plovdiv Center 1",
                "Bulgaria",
                "Plovdiv",
                "4000");

            var payment1 = Payment.Of(
                "Kostadin Markov",
                "5555555555554444",
                "12/28",
                "355",
                1);

            var payment2 = Payment.Of(
                "Asen Petrov",
                "8885555555554444",
                "06/30",
                "222",
                2);

            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("7d3f1b8e-5f9c-4d91-8b7a-2c4f8e9d1a73")),
                OrderName.Of("Ord1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1);

            order1.Add(
                ProductId.Of(new Guid("d1f8e9d1-8b7a-4d91-5f9c-7d3f1b8e5f9c")),
                2,
                500m);

            order1.Add(
                ProductId.Of(new Guid("e6d4a3e4-b61c-4a91-1e6d-c8a72f34b5c7")),
                1,
                400m);

            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("c8a72f34-1e6d-4a91-b5c7-9f2d8a3e4b61")),
                OrderName.Of("Ord2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment2);

            order2.Add(
                ProductId.Of(new Guid("f9c7d3f1-b8e5-4d91-5f9c-1e6d4a3e4b61")),
                3,
                650m);

            order2.Add(
                ProductId.Of(new Guid("a3e4b61c-4a91-1e6d-c8a7-2f34b5c7d3f1")),
                1,
                450m);

            return new List<Order>
            {
                order1,
                order2
            };
        }
    }
}