using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient.Car
{
    public interface ICarRpcClient : IRpcClientBase
    {
        void SetCarControls(CarControls Controls, string VehicleName);

        CarState GetCarState(string VehicleName);
    }
}
