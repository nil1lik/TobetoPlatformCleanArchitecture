using Application.Features.CatalogPaths.Queries.GetById;
using Application.Features.CatalogPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CatalogPaths.Queries.GetCatalogById;
public class GetCatalogByIdResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string InstructorName { get; set; }
    public string InstructorSurname { get; set; }
    public int Time { get; set; }
}
