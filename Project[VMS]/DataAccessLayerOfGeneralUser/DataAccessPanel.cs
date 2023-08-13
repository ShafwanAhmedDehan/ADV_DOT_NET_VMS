using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerVMS.Interface;
using DataAccessLayerVMS.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerVMS
{
    public class DataAccessPanel
    {
        public static BasicOperation <UserVM, int, bool> UserData()
        {
            return new GeneralUserManage();
        }

        public static BasicOperation<Vehicle, int, bool> VehicleControl()
        {
            return new VehicleManage();
        }
		
		 public static BasicOperation<UserVM, int, bool> AdminControl()
        {
            return new AdminControl();
        }
    }
}
