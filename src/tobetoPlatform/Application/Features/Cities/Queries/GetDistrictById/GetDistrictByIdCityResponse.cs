﻿using Application.Features.Cities.Queries.GetDistrictList;
using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Queries.GetDistrictById;
public class GetDistrictByIdCityResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<DistrictDto> Districts { get; set; }
}
