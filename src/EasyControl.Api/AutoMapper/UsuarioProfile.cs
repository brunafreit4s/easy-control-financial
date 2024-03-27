using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyControl.Api.Contract.Usuario;
using EasyControl.Api.Domain.Models;

namespace EasyControl.Api.AutoMapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioRequestContract>().ReverseMap();
            CreateMap<Usuario, UsuarioResponseContract>().ReverseMap();
        }
    }
}