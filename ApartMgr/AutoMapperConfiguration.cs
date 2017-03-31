using ApartMgr.Models;
using ApartMgr.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartMgr
{
    public static class AutoMapperConfiguration
    {
        public static void Configuration()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                //Invoice
                config.CreateMap<Invoice, InvoiceList>()
                    .ForMember(dest => dest.PeriodName, opt => opt.MapFrom(src => src.Period.PeriodName));
                config.CreateMap<InvoiceCreate, Invoice>();
                config.CreateMap<InvoiceUpdate, Invoice>();
                config.CreateMap<Invoice, InvoiceUpdate>();
                //InvoiceProvider
                config.CreateMap<Provider, ProviderDetail>();
                config.CreateMap<ProviderCreate, Provider>();
            });
        }
    }
}
