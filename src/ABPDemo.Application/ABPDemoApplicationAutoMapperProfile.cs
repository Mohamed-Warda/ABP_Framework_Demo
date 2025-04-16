using AutoMapper;
using ABPDemo.Books;

namespace ABPDemo;

public class ABPDemoApplicationAutoMapperProfile : Profile
{
    public ABPDemoApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
