using AutoMapper;
using Microsoft.AspNetCore.Routing.Matching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueClassValidation.Data.Entities;
using VueClassValidation.Models;

namespace VueClassValidation.Data.Maps
{
  public class CustomerMaps : Profile
  {
    public CustomerMaps()
    {
      CreateMap<Customer, CustomerModel>()
         .ForMember(c => c.FullName, opt => opt.MapFrom(c => $"{c.FirstName} {c.LastName}"))
         .ReverseMap();
    }

  }
}
