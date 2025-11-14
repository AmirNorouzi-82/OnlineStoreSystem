using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineStoreSystem.Application.Features.CustomerFeatures.Requests.Commands;

namespace OnlineStoreSystem.Application.DTO.CustomerDTOs;

public class UpdateCustomerDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string? Phone { get; set; }
    public DateTime? Birthdate { get; set; }
    public bool Is_Active { get; set; }
}
