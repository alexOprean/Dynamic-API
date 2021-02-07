namespace Dynamic.Core.AutoMapper
{
    using Dynamic.Core.ViewModels;
    using Dynamic.Data.Models;
    using global::AutoMapper;

    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Document, DocumentViewModel>().ReverseMap();
        }
    }
}
