﻿using AutoMapper;
using BusinessLogicLayerVMS.DTO;
using DataAccessLayerOfGeneralUser;
using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerVMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerVMS.Service
{
    public class AdminService
    {
        public static bool DeleteUserAccount(int id)
        {
            return DataAccessPanel.AdminControl().Delete(id);
        }

        public static LogInDataDTO login(LoginDTO loginData)
        {
            var data = (from n in DataAccessPanel.AdminControl().Get()
                        where n.emailphn == loginData.Emailphn && n.password == loginData.Password
                        select new LogInDataDTO
                        {
                            Id = n.id,
                            Emailphn = n.emailphn,
                            Password = n.password,
                            Fname = n.Fname,
                            Lname = n.Lname,
                            Gender = n.Gender,
                            Nid = n.nid,
                            Address = n.address,
                            Usertype = n.usertype
                        }).FirstOrDefault();
            Console.WriteLine(data);

            if (data != null)
            {
                data.Password = "";
                return data;
            }
            else
            {
                var LoginError = new LogInDataDTO();
                LoginError.Emailphn = "Wrong Email/Phone";
                LoginError.Password = "Worng Password";
                return LoginError;
            }
        }

        public static UserDTO viewProfile ( int id)
        {
            var UserData = DataAccessPanel.UserData().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserVM, UserDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<UserDTO>(UserData);
            return cnvrted;
        }

        public static bool UpdateAdminProfile(UserDTO value, int id)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, UserVM>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<UserVM>(value);
            return DataAccessPanel.AdminControl().Update(conv, id);
        }

        public static bool CreateUserAccount(UserDTO user)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, UserVM>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<UserVM>(user);
            return DataAccessPanel.AdminControl().Create(conv);
        }

        public static List<UserDTO> ShowAllUser()
        {
            var data = DataAccessPanel.AdminControl().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserVM, UserDTO>();
            });
            var mapper = new Mapper(config);
            var convertedValue = mapper.Map<List<UserDTO>>(data);
            return convertedValue;
        }

        public static List <VehicleDTO> ShowAllVehicle()
        {
            var data = DataAccessPanel.VehicleControl().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Vehicle, VehicleDTO>();
            });
            var mapper = new Mapper(config);
            var convertedValue = mapper.Map<List<VehicleDTO>>(data);
            return convertedValue;
        }
    }
}
