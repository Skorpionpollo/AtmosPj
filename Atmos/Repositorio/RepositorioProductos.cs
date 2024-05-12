using Atmos.Modelos;
using Microsoft.EntityFrameworkCore;
namespace Atmos.Repositorio
{
    public class RepositorioProductos : IRepositorioProductos
    {
        private readonly AtmosDBContext _context;
        public RepositorioProductos(AtmosDBContext context)
        {
            _context = context;
        }
        public async Task<Producto> Add(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
            return producto;
        }
        public async Task Delete(int id)
        {
            var producto= await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Producto?> Get(int id)
        {
            return await _context.Productos.FindAsync(id);
        }
        public async Task<List<Producto>> GetAll()
        {
            return await _context.Productos.ToListAsync();   
        }
        public async Task Update(int id, Producto producto)
        {
            var productoactual = await _context.Productos.FindAsync(id);
            if (productoactual != null)
            {
                productoactual.Nombre = producto.Nombre;
                productoactual.Precio = producto.Precio;
                productoactual.Descripcion = producto.Descripcion;
                productoactual.Stock = producto.Stock;
                await _context.SaveChangesAsync();
            }
        }
    }
}
