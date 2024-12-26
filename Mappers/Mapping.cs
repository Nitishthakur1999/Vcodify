using VCodify.DatabaseEntities;
using VCodify.Models;
using AutoMapper;

namespace VCodify.Mappers


{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Enquiry, EnquiryVM>();
            CreateMap<EnquiryVM, Enquiry>();
            
        }
    }
    }
