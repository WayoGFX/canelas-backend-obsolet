using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasteleriaCanelas.Api.Helpers;
using PasteleriaCanelas.Services.Interfaces;
using PasteleriaCanelas.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using PasteleriaCanelas.Services.Services;

namespace PasteleriaCanelas.Api.Controllers;

// controlador del catálogo para clientes

[ApiController]
[Route("api/[controller]")]
public class CatalogoController : ControllerBase
{
    //el controlador pide la interfaz de IProductoService | principio clave de la inyección de dependencias
    private readonly IProductoService _productoService;

    // el constructor recibe la interfaz de IProductoService, no la implementación directa
    // entonces .NET se encargade darle una instancia de la clase ProductoService
    public CatalogoController(IProductoService productoService)
    {
        _productoService = productoService;
    }


    // Endpoint NUEVO: Catálogo inicial optimizado
    // GET /api/Catalogo/inicial
    [HttpGet("inicial")]
    public async Task<ActionResult<CatalogoInicialDto>> GetCatalogoInicial()
    {
        var catalogo = await _productoService.ObtenerCatalogoInicial();
        return Ok(catalogo);
    }

    // Endpoint 1: para mostrar todos los productos | solo si están activos
    // GET /api/Catalogo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoResumenDto>>> GetTodosProductos()
    {
        //se retornan los datos y se envía respuesta
        var productos = await _productoService.ObtenerProductos();
        return Ok(productos);
    }


    // Endpoint 2: Mostrar productos por Categoria | solo si está activo
    // GET /api/Catalogo/Categoria/{slug}
    [HttpGet("categoria/{categoriaSlug}")]
    public async Task<ActionResult<IEnumerable<ProductoResumenDto>>> GetProductosCategoria(string categoriaSlug)
    {
        var productos = await _productoService.ObtenerProductosCategoria(categoriaSlug);

        // Si el servicio devuelve null, es porque la categoría no existe.
        if (productos == null)
        {
            return NotFound(ApiMensajes.CategoriaNoEncontrada);
        }
        return Ok(productos);
    }


    // Endpoint 3: Mostrar productos por Slug
    // GET /api/Catalogo/producto/{slug}
    [HttpGet("producto/{slug}")]
    public async Task<ActionResult<ProductoDetallesDto>> GetProductoPorSlug([FromRoute] string slug)
    {
        // se manda todo a la logica de negocio para validarlo
        var producto = await _productoService.GetProductoPorSlugAsync(slug);
        // si no hay producto entonces retorna null
        if (producto == null)
        {
            return NotFound(ApiMensajes.RecursoNoEncontrado);
        }
        // si hay se retorna la respuesta
        return Ok(producto);

    }

    // Endpoint 4: Mostrar productos de Temporada
    // GET /api/Catalogo/temporada
    [HttpGet("temporada")]
    public async Task<ActionResult<IEnumerable<ProductoResumenDto>>> GetProductosDeTemporada()
    {
        // se hace la petición en el service
        var productos = await _productoService.GetProductosDeTemporadaAsync();
        return Ok(productos);
    }

}
