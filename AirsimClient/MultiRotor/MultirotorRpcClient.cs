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

using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using AirsimClient.Adaptors;
using AirsimClient.Common;
using AirsimClient.Safety;
using MsgPackRpc;

namespace AirsimClient.MultiRotor
{
    public class MultirotorRpcClient : RpcClientBase, IMultirotorRpcClient
    {
        public async Task<RpcResult<MultirotorState>> GetMultirotorStateAsync(string VehicleName)
        {
            return await m_proxy.CallAsyncAdaptor<MultirotorStateRpc, MultirotorState>(Methods.GetMultirotorState, VehicleName);
        }

        public async Task<RpcResult> GoHomeAsync(float TimeoutSec, string VehicleName)
        {
            return await m_proxy.CallAsync(Methods.GoHome, TimeoutSec, VehicleName);
        }

        public async Task<RpcResult> HoverAsync(string VehicleName)
        {
            return await m_proxy.CallAsync(Methods.Hover, VehicleName);
        }

        public async Task<RpcResult> LandAsync(float TimeoutSec, string VehicleName)
        {
            return await m_proxy.CallAsync(Methods.Land, TimeoutSec, VehicleName);
        }

        public async Task<RpcResult> MoveByAngleThrottleAsync(float Pitch, float Roll, float Z, float Yaw, float Duration, string VehicleName)
        {
            return await m_proxy.CallAsync(Methods.MoveByAngleThrottle, Pitch, Roll, Z, Yaw, Duration, VehicleName);
        }

        public async Task<RpcResult> MoveByAngleZAsync(float Pitch, float Roll, float Z, float Yaw, float Duration, string VehicleName)
        {
            return await m_proxy.CallAsync(Methods.MoveByAngleZ, Pitch, Roll, Z, Yaw, Duration, VehicleName);
        }

        public async Task<RpcResult> MoveByManualAsync(float VxMax, float VyMax, float ZMin, float Duration, DrivetrainType DriveTrain, YawMode YawMode, string VehicleName)
        {
            YawModeRpc adapted = YawModeRpc.AdaptFrom(YawMode);
            return await m_proxy.CallAsync(Methods.MoveByManual, VxMax, VyMax, ZMin, Duration, DriveTrain, adapted, VehicleName);
        }

        public async Task<RpcResult> MoveByRpcAsync(RCData RcData, string VehicleName)
        {
            RCDataRpc adapted = RCDataRpc.AdaptFrom(RcData);
            return await m_proxy.CallAsync(Methods.MoveByRC, adapted, VehicleName);
        }

        public async Task<RpcResult> MoveByVelocityAsync(float Vx, float Vy, float Vz, float Duration, DrivetrainType Drivetrain, YawMode YawMode, string VehicleName)
        {
            YawModeRpc adapted = YawModeRpc.AdaptFrom(YawMode);
            return await m_proxy.CallAsync(Methods.MoveByVelocity, Vx, Vy, Vz, Duration, Drivetrain, adapted, VehicleName);
        }

        public async Task<RpcResult> MoveByVelocityZAsync(float Vx, float Vy, float Z, float Duration, DrivetrainType Drivetrain, YawMode YawMode, string VehicleName)
        {
            YawModeRpc adapted = YawModeRpc.AdaptFrom(YawMode);
            return await m_proxy.CallAsync(Methods.MoveByVelocityZ, Vx, Vy, Z, Duration, Drivetrain, adapted, VehicleName);
        }

        public async Task<RpcResult> MoveOnPathAsync(Vector3[] Path, float Velocity, float Duration, DrivetrainType Drivetrain, YawMode YawMode, float Lookahead, float AdaptiveLookahead, string VehicleName)
        {
            YawModeRpc yawModeAdapted = YawModeRpc.AdaptFrom(YawMode);
            Vector3Rpc[] pathAdapted = Path.Select((P) => Vector3Rpc.AdaptFrom(P)).ToArray();

            return await m_proxy.CallAsync(Methods.MoveOnPath, pathAdapted, Velocity, Duration, Drivetrain, yawModeAdapted, Lookahead, AdaptiveLookahead, VehicleName);
        }

        public async Task<RpcResult> MoveToZAsync(float Z, float Velocity, float TimeoutSec, YawMode YawMode, float Lookahead, float AdaptiveLookahead, string VehicleName)
        {
            YawModeRpc yawModeAdapted = YawModeRpc.AdaptFrom(YawMode);
            return await m_proxy.CallAsync(Methods.MoveToZ, Z, Velocity, TimeoutSec, yawModeAdapted, Lookahead, AdaptiveLookahead, VehicleName);
        }

        public async Task<RpcResult> RotateByYawRateAsync(float YawRate, float Duration, string VehicleName)
        {
            return await m_proxy.CallAsync(Methods.RotateByYawRate, YawRate, Duration, VehicleName);
        }

        public async Task<RpcResult> RotateToYawAsync(float Yaw, float TimeoutSec, float Margin, string VehicleName)
        {
            return await m_proxy.CallAsync(Methods.RotateToYaw, Yaw, TimeoutSec, Margin, VehicleName);
        }

        public async Task<RpcResult<bool>> SetSafety(SafetyViolationType EnableReasons, float ObsClearance, ObsAvoidanceStrategy ObsStrategy, 
            float ObsAvoidanceVel, Vector3 Origin, float XyLength, float MaxZ, float MinZ, string VehicleName)
        {
            return await m_proxy.CallAsync<bool>(Methods.SetSafety, EnableReasons, ObsClearance, ObsStrategy, ObsAvoidanceVel,
                Vector3Rpc.AdaptFrom(Origin), XyLength, MaxZ, MinZ, VehicleName);
        }

        public async Task<RpcResult> TakeOffAsync(float TimeoutSec, string VehicleName)
        {
            return await m_proxy.CallAsync(Methods.TakeOff, TimeoutSec, VehicleName);
        }
    }
}
