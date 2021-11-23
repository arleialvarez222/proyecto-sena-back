using AutoMapper;
using Sena.core.DTO;
using Sena.core.Models;


namespace WebAPISena.Configuratios
{
    public class AutomapperConfiguration: Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<Users, UserForRegistrationDto>().ReverseMap();
            CreateMap<Producto, ProductDto>().ReverseMap();
            CreateMap<Cliente, ClientsDto>().ReverseMap();
            CreateMap<Inventario, InventoryDto>().ReverseMap();
            CreateMap<Inventario, RequestInventoryDto>().ReverseMap();
            CreateMap<Proveedor, ProvedorDto>().ReverseMap();
            CreateMap<Reserva, ReservaDto>().ReverseMap();
            CreateMap<Empleado, EmployeDto>().ReverseMap();
            CreateMap<Pedido, OrderDto>().ReverseMap();
            CreateMap<Pedido, RequestOrderDto>().ReverseMap();
        }
    }
}
