namespace Shopping.Web.Models.Catalog;

public class ProductModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public List<string> Category { get; set; } = new();
    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public decimal Price { get; set;} 
}

//wrapper classes
public record GetProductsRespose(IEnumerable<ProductModel> Products);
public record GetProductByCategoryRespose(IEnumerable<ProductModel> Products);
public record GetProductByIdRespose(ProductModel Product);