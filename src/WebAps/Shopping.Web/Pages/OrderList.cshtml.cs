namespace Shopping.Web.Pages
{
    public class OrderListModel(IOrderingService orderingService,
                                ILogger<OrderListModel> logger) : PageModel
    {
        public IEnumerable<OrderModel> Orders { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var customerId = new Guid("7d3f1b8e-5f9c-4d91-8b7a-2c4f8e9d1a73");

            var response = await orderingService.GetOrdersByCustomer(customerId);
            Orders = response.Orders;

            return Page();
        }
    }
}
