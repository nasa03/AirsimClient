﻿#region MIT License (c) 2018 Isaac Walker

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


using System;
using System.Threading.Tasks;
using AirsimClient.Adaptors;
using MsgPackRpc;

namespace AirsimClient.Car
{
    /// <summary>
    /// Implementation of the Client API for the Car
    /// </summary>
    public sealed class CarRpcClient : RpcClientBase, ICarRpcClient
    {
        /// <inheritdoc cref="ICarRpcClient.GetCarStateAsync(string)" />
        public async Task<RpcResult<CarState>> GetCarStateAsync(string VehicleName)
        {
            Task<RpcResult<CarState>> res = m_proxy.CallAsyncAdaptor<CarStateRpc,CarState>(Methods.GetCarState, VehicleName);

            return await res;
        }

        /// <inheritdoc cref="ICarRpcClient.SetCarControlsAsync(CarControls, string)" />
        public async Task<RpcResult> SetCarControlsAsync(CarControls Controls, string VehicleName)
        {
            CarControlsRpc adapted = CarControlsRpc.AdaptFrom(Controls);

            return await m_proxy.CallAsync(Methods.SetCarControls, adapted, VehicleName);
        }
    }
}
