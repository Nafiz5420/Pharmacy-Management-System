using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SellerService
    {
        public static List<SellerDTO> GET()
        {
            var data = DataAccessFactory.SellerData().GET();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Seller, SellerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<SellerDTO>>(data);

            return mapped;
        }
        public static SellerDTO GET(int SellerId)
        {
            var data = DataAccessFactory.SellerData().GET(SellerId);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Seller, SellerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SellerDTO>(data);
            return mapped;
        }



    }



}


