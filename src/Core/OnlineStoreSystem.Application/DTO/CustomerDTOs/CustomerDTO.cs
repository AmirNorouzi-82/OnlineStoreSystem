using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreSystem.Application.DTO.OrderDTOs;
using OnlineStoreSystem.Domain;

namespace OnlineStoreSystem.Application.DTO.CustomerDTOs;

public class CustomerDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string? Phone { get; set; }
    public DateTime? Birthdate { get; set; }

    public DateTime Register_date { get; set; }
    public bool Is_Active { get; set; }

    public ICollection<OrderDTO> Orders { get; set; }
}
