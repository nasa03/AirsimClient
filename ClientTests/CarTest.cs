#region MIT License (c) 2018 Isaac Walker

// Copyright 2018 Isaac Walker
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
// associated documentation files (the "Software"), to deal in the Software without restriction,
// including without limitation the rights to use, copy, modify, merge, publish, distribute,
// sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
// NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT
// OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion MIT License (c) 2018 Isaac Walker


using System.Net;
using AirsimClient;
using AirsimClient.Adaptors;
using AirsimClient.Car;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClientTests
{
    [TestClass]
    public class CarTest
    {
        private const int Port = 41451;


        private const string Address = "127.0.0.1";


        private readonly ICarRpcClient m_client;


        private static readonly string VehicleName = string.Empty;

        public CarTest()
        {
            m_client = new CarRpcClient();
        }

        [TestMethod]
        public void TestBasic()
        {
            bool Connected = m_client.ConnectAsync(Port, IPAddress.Parse(Address)).Result;
            Assert.IsTrue(Connected);

            bool ApiEnabled = m_client.EnableApiControlAsync(true, VehicleName).Result.Successful;
            Assert.IsTrue(ApiEnabled);

            bool ArmDisarmed = m_client.ArmDisarmAsync(true, VehicleName).Result.Successful;
            Assert.IsTrue(ArmDisarmed);

            bool CarStateSucc = m_client.GetCarStateAsync(VehicleName).Result.Successful;
            Assert.IsTrue(CarStateSucc);

            bool ControlsSet = m_client.SetCarControlsAsync(new CarControls() { Steering = 0.2f, Throttle = 0.4f }, VehicleName).Result.Successful;
            Assert.IsTrue(ControlsSet);

            bool GetImageSuccesful = m_client.SimGetImageAsync(string.Empty, ImageType.Scene, VehicleName).Result.Successful;
            Assert.IsTrue(GetImageSuccesful);

          
        }
    }
}
