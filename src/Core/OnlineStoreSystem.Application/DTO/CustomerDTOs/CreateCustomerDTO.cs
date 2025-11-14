using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreSystem.Application.DTO.CustomerDTOs;

public class CreateCustomerDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Family { get; set; }
    public string? Phone { get; set; }
    public DateTime? Birthdate { get; set; }

    public DateTime Register_date { get; set; }
    public bool Is_Active { get; set; }
}
