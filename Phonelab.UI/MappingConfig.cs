using AutoMapper;
using Phonelab.UI.DTOs;
using Phonelab.UI.ViewModels;

namespace Phonelab.UI;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        // Mapeamento para Categorias
        CreateMap<CategoriaDto, CategoriaVM>()
            .ForMember(dest => dest.FotoUrl, opt => opt.MapFrom(src => src.Foto))
            .ForMember(dest => dest.Foto, opt => opt.Ignore());

        CreateMap<CategoriaVM, CategoriaDto>()
            .ForMember(dest => dest.Foto, opt => opt.Ignore());
    }
}


