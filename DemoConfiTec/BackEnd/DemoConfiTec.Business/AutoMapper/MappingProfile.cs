using AutoMapper;
using DemoConfiTec.Business.ViewModels;
using DemoConfiTec.Domain.Models;

namespace DemoConfiTec.Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapeamento De/Para
            //CreateMap<classe, ViewModel>().ReverseMap();
            #region ENTITIES

            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();

            #endregion


        }
    }
}