namespace PasteleriaCanelas.Services.DTOs;

public class ProductoResumenDto
{
    public int ProductoId { get; set; }
    public string? Nombre { get; set; }
    public string? ImagenUrl { get; set; }
    
    public ICollection<ProductoPrecioDto> ProductoPrecios { get; set; } = new List<ProductoPrecioDto>();
}