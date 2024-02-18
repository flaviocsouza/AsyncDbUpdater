using AsyncDbUpdaterShared;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace AsyncDbUpdaterApi;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ITopicProducer<string, RegisterProductMessage> _registerProductProducer;
    public ProductController(ITopicProducer<string, RegisterProductMessage> registerProductProducer)
    {
        _registerProductProducer = registerProductProducer;
    }


    [HttpPost]
    public async Task<IActionResult> RegisterProduct(RegisterProductDTO registerProduct)
    {
        await _registerProductProducer.Produce(
            Guid.NewGuid().ToString(),
            new RegisterProductMessage {
                Title = registerProduct.Title,
                Price = registerProduct.Price,
                Description = registerProduct.Description,
                Category = registerProduct.Category});
        
        return Accepted();
    }
}
