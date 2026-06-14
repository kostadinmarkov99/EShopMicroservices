using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync()) return;

            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync(cancellation);
        }

        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
        {
            new Product()
            {
                Id = new Guid("a3f9c2d1-7b4e-4f8a-9c6d-1e2f3a4b5c6d"),
                Name = "IPhone X",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageFile = "product-1.png",
                Price = 950.00M
            },
            new Product()
            {
                Id = new Guid("8d72b1f4-5e9c-43a7-b2d8-7f1c9e6a3b5d"),
                Name = "Samsung Galaxy S10",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageFile = "product-2.png",
                Price = 900.00M
            },
            new Product()
            {
                Id = new Guid("c4a8e7f1-2d3b-4c9a-8e5f-6b1d7a2c9f4e"),
                Name = "Google Pixel 4",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageFile = "product-3.png",
                Price = 800.00M
            },
            new Product()
            {
                Id = new Guid("f1b2c3d4-e5f6-4789-abcd-1234567890ab"),
                Name = "OnePlus 7 Pro",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageFile = "product-4.png",
                Price = 700.00M
            }
        };
    }
}