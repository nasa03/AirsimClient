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

using AirsimClient.Common;
using AirsimClient.Safety;
using MsgPackRpc;
using System.Numerics;
using System.Threading.Tasks;

namespace AirsimClient.MultiRotor
{
    public interface IMultirotorRpcClient : IRpcClientBase
    {
        Task<RpcResult> TakeOffAsync(float TimeoutSec, string VehicleName);

        Task<RpcResult> LandAsync(float TimeoutSec, string VehicleName);

        Task<RpcResult> GoHomeAsync(float TimeoutSec, string VehicleName);

        Task<RpcResult> MoveByAngleZAsync(float Pitch, float Roll, float Z, float Yaw, float Duration, string VehicleName);

        Task<RpcResult> MoveByAngleThrottleAsync(float Pitch, float roll, float Z, float Yaw, float Duration, string VehicleName);

        Task<RpcResult> MoveByVelocityAsync(float Vx, float Vy, float Vz, float Duration, DrivetrainType Drivetrain, YawMode YawMode, string VehicleName);

        Task<RpcResult> MoveByVelocityZAsync(float Vx, float Vy, float Z, float Duration, DrivetrainType Drivetrain, YawMode YawMode, string VehicleName);

        Task<RpcResult> MoveOnPathAsync(Vector3[] Path, float Velocity, float Duration, DrivetrainType Drivetrain, YawMode YawMode, float Lookahead, float AdaptiveLookahead, string VehicleName);

        Task<RpcResult> MoveToZAsync(float Z, float Velocity, float TimeoutSec, YawMode YawMode, float Lookahead, float AdaptiveLookahead, string VehicleName);

        Task<RpcResult> MoveByManualAsync(float VxMax, float VyMax, float ZMin, float Duration, DrivetrainType DriveTrain, YawMode YawMode, string VehicleName);

        Task<RpcResult> RotateToYawAsync(float Yaw, float TimeoutSec, float Margin, string VehicleName);

        Task<RpcResult> RotateByYawRateAsync(float YawRate, float Duration, string VehicleName);

        Task<RpcResult> HoverAsync(string VehicleName);

        Task<RpcResult<bool>> SetSafety(SafetyViolationType EnableReasons, float ObsClearance, ObsAvoidanceStrategy ObsStrategy,
            float ObsAvoidanceVel, Vector3 Origin, float XyLength, float MaxZ, float MinZ, string VehicleName);

        Task<RpcResult<MultirotorState>> GetMultirotorStateAsync(string VehicleName);

        Task<RpcResult> MoveByRpcAsync(RCData RcData, string VehicleName);      
    }
}
