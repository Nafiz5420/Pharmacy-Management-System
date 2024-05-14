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
    public class SelectionService
    {
        public static List<SelectionDTO> GET()
        {
            var data = DataAccessFactory.SelectionData().GET();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Selection, SelectionDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<SelectionDTO>>(data);

            return mapped;
        }
        public static SelectionDTO GET(int Id)
        {
            var data = DataAccessFactory.SelectionData().GET(Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Selection, SelectionDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SelectionDTO>(data);
            return mapped;
        }
    }
}
