using AutoMapper;

namespace Monitoria.Infra.CrossCutting.Mappings
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //DomainToModelMapMonitoring();
            //DomainToModelMapParameters();
        }

        //private void DomainToModelMapMonitoring()
        //{
        //    CreateMap<Log, LogModel>();
        //}

        //private void DomainToModelMapParameters()
        //{

        //    CreateMap<Class, ClassModel>();

        //    CreateMap<Class, ClassModel>();

        //    CreateMap<Class, ClassModel>()
        //        .ForMember(d => d.EquipmentType, m => m.MapFrom(s => s.EquipmentType.Name))
        //        .ForMember(d => d.Class, m => m.MapFrom(s => s.Class.Name));

        //    CreateMap<Class, ClassModel>();
        //    CreateMap<Class, ClassModel>()
        //        .ForMember(d => d.Id, m => m.MapFrom(s => s.Id))
        //        .ForMember(d => d.LmiType, m => m.MapFrom(s => s.LmiType))
        //        .ForMember(d => d.MinIndemnityLimit, m => m.MapFrom(s => s.MinIndemnityLimit))
        //        .ForMember(d => d.MaxIndemnityLimit, m => m.MapFrom(s => s.MaxIndemnityLimit))
        //        .ForMember(d => d.MaxLimit, m => m.MapFrom(s => s.MaxLimit))
        //        .ForMember(d => d.EquipmentTypeId, m => m.MapFrom(s => s.EquipmentTypeId));
        //}
    }
}
