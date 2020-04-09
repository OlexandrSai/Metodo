using AutoMapper;
using ManutationItemsApp.DAL;
using ManutationItemsApp.Domain.Entities;
using ManutationItemsApp.Models.Asset;
using ManutationItemsApp.Models.Dto;
using ManutationItemsApp.Service.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManutationItemsApp.Configuration
{
    public class AutomapperProfile : Profile
    {
      
        public AutomapperProfile()
        {


            CreateMap<ApplicationUser, UserDTO>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserName))
        .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company))
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
        .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
        .ReverseMap();

            //CreateMap<Asset, AssetCreateViewModel>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
            //    .ForMember(dest => dest.Characteristics, opt => opt.MapFrom(src => src.Characteristics))
            //    .ForMember(dest => dest.CommissioningDate, opt => opt.MapFrom(src => src.CommissioningDate))
            //    .ForMember(dest => dest.ConsumptionSpeed, opt => opt.MapFrom(src => src.ConsumptionSpeed))
            //    .ForMember(dest => dest.CountAtWarehouse, opt => opt.MapFrom(src => src.CountAtWarehouse))
            //    .ForMember(dest => dest.DetailedMachineZone, opt => opt.MapFrom(src => src.DetailedMachineZone))
            //    .ForMember(dest => dest.Deterioration, opt => opt.MapFrom(src => src.Deterioration))
            //    .ForMember(dest => dest.Function, opt => opt.MapFrom(src => src.Function))
            //    .ForMember(dest => dest.GeneralMachineZone, opt => opt.MapFrom(src => src.GeneralMachineZone))
            //    .ForMember(dest => dest.HandlingWay, opt => opt.MapFrom(src => src.HandlingWay))
            //    .ForMember(dest => dest.HourConterAtcommissioning, opt => opt.MapFrom(src => src.HourConterAtcommissioning))
            //    .ForMember(dest => dest.IntalledQuantity, opt => opt.MapFrom(src => src.IntalledQuantity))
            //    .ForMember(dest => dest.InternalIdentificationalCode, opt => opt.MapFrom(src => src.InternalIdentificationalCode))
            //    .ForMember(dest => dest.IsReparaible, opt => opt.MapFrom(src => src.IsReparaible))
            //    .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
            //    .ForMember(dest => dest.ManufacturerNumber, opt => opt.MapFrom(src => src.ManufacturerNumber))
            //    .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.ModelName))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
            //    .ForMember(dest => dest.OptimalPurchaseQuantity, opt => opt.MapFrom(src => src.OptimalPurchaseQuantity))
            //    .ForMember(dest => dest.ReorderLevelLr, opt => opt.MapFrom(src => src.ReorderLevelLr))
            //    .ForMember(dest => dest.SecurityLevelLs, opt => opt.MapFrom(src => src.SecurityLevelLs))
            //    .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
            //    .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size))
            //    .ForMember(dest => dest.TestDate, opt => opt.MapFrom(src => src.TestDate))
            //    .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version))
            //    .ForMember(dest => dest.WarrantyExpiresDate, opt => opt.MapFrom(src => src.WarrantyExpiresDate))
            //    .ForMember(dest => dest.WorkingHoursCount, opt => opt.MapFrom(src => src.WorkingHoursCount))
            //    .ForMember(dest => dest.YearOfManufacture, opt => opt.MapFrom(src => src.YearOfManufacture))
            //    .ForMember(dest => dest.InstructionsForUse, act => act.Ignore())
            //    .ForMember(dest => dest.MaintanceInstructions, act => act.Ignore())
            //    .ForMember(dest => dest.DeclarationOfConformity, act => act.Ignore())
            //    .ForMember(dest => dest.Schemes, act => act.Ignore())
            //    .ForMember(dest => dest.ItemsListFile, act => act.Ignore())
            //    .ForMember(dest => dest.TechnicalInformation, act => act.Ignore())
            //    .ForMember(dest => dest.BestPracticeExperience, act => act.Ignore())
            //    .ReverseMap();

            //     CreateMap<Manutation, ManutationDto>()
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.AssetID, opt => opt.MapFrom(src => src.Asset.Id))
            //.ForMember(dest => dest.ErrorCodeID, opt => opt.MapFrom(src => src.ErrorCode.Id))
            //.ForMember(dest => dest.ManutationTypeID, opt => opt.MapFrom(src => src.ManutationType.Id))
            //.ReverseMap();


        }

    }
}
