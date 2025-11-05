using PasteleriaCanelas.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PasteleriaCanelas.Services.Interfaces;

public interface IProductoService
{
    // Administrador
    Task<ProductoDetallesDto?> ObtenerProductoPorId(int productoId);
    Task<IEnumerable<ProductoDetallesDto>?> ObtenerTodosProductos();
    Task<ProductoDetallesDto?> CrearProducto(ProductoCreacionDto productoDto);
    Task<bool> ActualizarProducto(ProductoActualizacionDto productoDto);
    Task<bool> EliminarProducto(int productoId);

    // CRUD Precio Producto
    Task<ProductoPrecioDto?> CrearPrecio(ProductoPrecioCreacionDto precioDto);
    Task<bool> ActualizarPrecio(ProductoPrecioActualizacionDto precioDto);
    Task<bool> EliminarPrecio(int precioId);

    // Usuario normal
    Task<IEnumerable<ProductoResumenDto>?> ObtenerProductos();
    Task<IEnumerable<ProductoResumenDto>?> ObtenerProductosCategoria(string categoriaSlug);
    Task<ProductoDetallesDto?> GetProductoPorSlugAsync(string slug);
    Task<IEnumerable<ProductoResumenDto>> GetProductosDeTemporadaAsync();
    
    // ✨ NUEVO: Catálogo inicial optimizado
    Task<CatalogoInicialDto> ObtenerCatalogoInicial();
}