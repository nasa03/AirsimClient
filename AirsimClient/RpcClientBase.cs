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

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Threading.Tasks;
using AirsimClient.Adaptors;
using AirsimClient.Common;
using MsgPackRpc;

namespace AirsimClient
{
    /// <summary>
    /// Base implementation of Airsim client
    /// </summary>
    public class RpcClientBase : IRpcClientBase
    {

        protected ConnectionState _connectionState;


        protected readonly RpcProxy m_proxy;

        public RpcClientBase()
        {
            _connectionState = ConnectionState.Initial;
            m_proxy = new RpcProxy();

        }

        /// <inheritdoc cref="IRpcClientBase.ArmDisarmAsync(bool, string)" />
        public async Task<RpcResult<bool>> ArmDisarmAsync(bool Arm, string VehicleName)
        {
            return await m_proxy.CallAsync<bool>(Methods.ArmDisarm, Arm, VehicleName);
        }

        /// <inheritdoc cref="IRpcClientBase.CancelLastTaskAsync(string)" />
        public async Task<RpcResult> CancelLastTaskAsync(string VehicleName)
        {
            return await m_proxy.CallAsync(VehicleName);
        }

        /// <inheritdoc cref="IRpcClientBase.ConnectAsync(int, IPAddress)" />
        public async Task<bool> ConnectAsync(int Port, IPAddress Address)
        {
            IPEndPoint iPEndPoint = new IPEndPoint(Address, Port);

            Task<bool> IsConnected = m_proxy.ConnectAsync(iPEndPoint);

            if (IsConnected.Result)
                _connectionState = ConnectionState.Connected;

            return await IsConnected;
        }

        /// <inheritdoc cref="IRpcClientBase.EnableApiControlAsync(bool, string)" />
        public async Task<RpcResult> EnableApiControlAsync(bool IsEnabled, string VehicleName)
        {
            return await m_proxy.CallAsync(Methods.EnableApiControl, IsEnabled, VehicleName);           
        }

        /// <inheritdoc cref="IRpcClientBase.GetClientVersionAsync" />
        public async Task<int> GetClientVersionAsync()
        {
            return await new Task<int>(() =>
            {
                return 1;
            });
        }

        /// <inheritdoc cref="IRpcClientBase.GetConnectionStateAsync" />
        public async Task<ConnectionState> GetConnectionStateAsync()
        {
            return await new Task<ConnectionState>(() => 
            {
                return _connectionState;
            });
        }

        /// <inheritdoc cref="IRpcClientBase.GetHomeGeoPointAsync(string)" />
        public async Task<RpcResult<GeoPoint>> GetHomeGeoPointAsync(string VehicleName)
        {
            return await m_proxy.CallAsync<GeoPoint>(Methods.GetHomeGeoPoint, VehicleName);
        }

        /// <inheritdoc cref="IRpcClientBase.GetMinRequiredClientVersionAsync" />
        public async Task<int> GetMinRequiredClientVersionAsync()
        {
            return await new Task<int>(() =>
            {
                return 1;
            });
        }

        /// <inheritdoc cref="IRpcClientBase.GetMinRequiredServerVersionAsync" />
        public async Task<int> GetMinRequiredServerVersionAsync()
        {
            return await new Task<int>(() =>
            {
                return 1;
            });
        }

        /// <inheritdoc cref="IRpcClientBase.GetServerVersionAsync" />
        public async Task<int> GetServerVersionAsync()
        {
            return await new Task<int>(() =>
            {
                return 1;
            });
        }

        /// <inheritdoc cref="IRpcClientBase.IsApiControlEnabledAsync(string)" />
        public async Task<RpcResult<bool>> IsApiControlEnabledAsync(string VehicleName)
        {
            return await m_proxy.CallAsync<bool>(Methods.isApiControlEnabled, VehicleName);
        }

        /// <inheritdoc cref="IRpcClientBase.PingAsync" />
        public async Task<RpcResult<bool>> PingAsync()
        {
            return await m_proxy.CallAsync<bool>(Methods.Ping);
        }

        /// <inheritdoc cref="IRpcClientBase.ResetAsync" />
        public async Task<RpcResult> ResetAsync()
        {           
            Task<RpcResult> ResetRes = m_proxy.CallAsync(Methods.Reset);

            if (ResetRes.Result.Successful)
                _connectionState = ConnectionState.Reset;

            return await ResetRes;
        }

        /// <inheritdoc cref="IRpcClientBase.SimCharGetAvailableFaceExpressionsAsync" />
        public async Task<RpcResult<string[]>> SimCharGetAvailableFaceExpressionsAsync()
        {
            return await m_proxy.CallAsync<string[]>(Methods.SimCharGetAvailableFaceExpressions);
        }

        /// <inheritdoc cref="IRpcClientBase.SimCharGetBonePoseAsync(string, string)" />
        public async Task<RpcResult<Pose>> SimCharGetBonePoseAsync(string BoneName, string CharacterName)
        {
            return await m_proxy.CallAsyncAdaptor<PoseRpc,Pose>(Methods.SimCharGetBonePose, BoneName, CharacterName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimCharGetFaceExpressionAsync(string, string)" />
        public async Task<RpcResult<float>> SimCharGetFaceExpressionAsync(string ExpressionName, string CharacterName)
        {
            return await m_proxy.CallAsync<float>(Methods.SimCharGetFaceExpression, ExpressionName, CharacterName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimCharGetHeadRotationAsync(string)" />
        public async Task<RpcResult<Quaternion>> SimCharGetHeadRotationAsync(string CharaterName)
        {
            return await m_proxy.CallAsyncAdaptor<QuaternionRpc, Quaternion>(Methods.SimCharGetHeadRotation, CharaterName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimCharGetSkinAgeingAsync(string)" />
        public async Task<RpcResult<float>> SimCharGetSkinAgeingAsync(string CharacterName)
        {
            return await m_proxy.CallAsync<float>(Methods.SimCharGetSkinAgeing, CharacterName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimCharGetSkinDarknessAsync(string)" />
        public async Task<RpcResult<float>> SimCharGetSkinDarknessAsync(string CharacterName)
        {
            return await m_proxy.CallAsync<float>(Methods.SimCharGetSkinDarkness, CharacterName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimCharResetBonePoseAsync(string, string)" />
        public async Task<RpcResult> SimCharResetBonePoseAsync(string BoneName, string CharaterName)
        {
            return await m_proxy.CallAsync(Methods.SimCharResetBonePose, BoneName, CharaterName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimCharSetBonePoseAsync(string, Pose, string)" />
        public async Task<RpcResult> SimCharSetBonePoseAsync(string BoneName, Pose pose, string CharacterName)
        {
            PoseRpc adaptedPose = PoseRpc.AdaptFrom(pose);
            return await m_proxy.CallAsync(Methods.SimCharSetBonePose, BoneName, adaptedPose, CharacterName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimCharSetFaceExpressionAsync(string, float, string)" />
        public async Task<RpcResult> SimCharSetFaceExpressionAsync(string ExpressionName, float Value, string CharacterName)
        {
            return await m_proxy.CallAsync(Methods.SimCharSetFaceExpression, ExpressionName, Value, CharacterName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimCharSetFacePresetAsync(string, float, string)" />
        public async Task<RpcResult> SimCharSetFacePresetAsync(string PresetName, float Value, string CharacterName)
        {
            return await m_proxy.CallAsync(Methods.SimCharSetFacePreset, PresetName, Value, CharacterName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimCharSetHeadRotationAsync(Quaternion, string)" />
        public async Task<RpcResult> SimCharSetHeadRotationAsync(Quaternion q, string CharacterName)
        {
            QuaternionRpc adapted = QuaternionRpc.AdaptFrom(q);
            return await m_proxy.CallAsync(Methods.SimCharSetHeadRotation, q, CharacterName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimCharSetSkinAgeingAsync(float, string)" />
        public async Task<RpcResult> SimCharSetSkinAgeingAsync(float Value, string CharacteName)
        {
            return await m_proxy.CallAsync(Methods.SimCharSetSkinAgeing, Value, CharacteName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimCharSetSkinDarknessAsync(float, string)" />
        public async Task<RpcResult> SimCharSetSkinDarknessAsync(float Value, string CharacterName)
        {
            return await m_proxy.CallAsync(Methods.SimCharSetSkinDarkness, Value, CharacterName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimContinueForTimeAsync(double)" />
        public async Task<RpcResult> SimContinueForTimeAsync(double Seconds)
        {
            return await m_proxy.CallAsync(Methods.SimContinueForTime, Seconds);
        }

        /// <inheritdoc cref="IRpcClientBase.SimEnableWeatherAsync(bool)" />
        public async Task<RpcResult> SimEnableWeatherAsync(bool Enable)
        {
            return await m_proxy.CallAsync(Methods.SimEnableWeather, Enable);
        }

        /// <inheritdoc cref="IRpcClientBase.SimGetBonePosesAsync(string[], string)" />
        public async Task<RpcResult<Dictionary<string, Pose>>> SimGetBonePosesAsync(string[] BoneNames, string CharacterName)
        {
            return await m_proxy.CallAsync<Dictionary<string, Pose>>(Methods.SimGetBonePoses, BoneNames, CharacterName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimGetCameraInfoAsync(string, string)" />
        public async Task<RpcResult<CameraInfo>> SimGetCameraInfoAsync(string CameraName, string VehicleName)
        {
            return await m_proxy.CallAsyncAdaptor<CameraInfoRpc, CameraInfo>(Methods.SimGetCameraInfo, CameraName, VehicleName);

        }

        /// <inheritdoc cref="IRpcClientBase.SimGetCollisionInfoAsync(string)" />
        public async Task<RpcResult<CollisionInfo>> SimGetCollisionInfoAsync(string VehicleName)
        {
                return await m_proxy.CallAsyncAdaptor<CollisionInfoRpc, CollisionInfo>(Methods.SimGetCameraInfo, VehicleName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimGetGroundTruthEnvironmentAsync(string)" />
        public async Task<RpcResult<EnvironmentState>> SimGetGroundTruthEnvironmentAsync(string VehicleName)
        {
            return await m_proxy.CallAsync<EnvironmentState>(Methods.SimGetGroundTruthEnvironment, VehicleName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimGetGroundTruthKinematicsAsync(string)" />
        public async Task<RpcResult<KinematicsState>> SimGetGroundTruthKinematicsAsync(string VehicleName)
        {
            return await m_proxy.CallAsyncAdaptor<KinematicsStateRpc, KinematicsState>(Methods.SimGetGroundTruthKinematics, VehicleName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimGetImageAsync(string, ImageType, string)" />
        public async Task<RpcResult<byte[]>> SimGetImageAsync(string CameraName, ImageType ImageType, string VehicleName)
        {
            return await m_proxy.CallAsync<byte[]>(Methods.SimGetImage, CameraName, ImageType, VehicleName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimGetImagesAsync(ImageRequest, string)" />
        public async Task<RpcResult<ImageResponse>> SimGetImagesAsync(ImageRequest Request, string VehicleName)
        {
            ImageRequestRpc adapted = ImageRequestRpc.AdaptFrom(Request);
            return await m_proxy.CallAsyncAdaptor<ImageResponseRpc, ImageResponse>(Methods.SimGetImages, adapted, VehicleName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimGetObjectPoseAsync(string)" />
        public async Task<RpcResult<Pose>> SimGetObjectPoseAsync(string ObjectName)
        {
            return await m_proxy.CallAsyncAdaptor<PoseRpc, Pose>(Methods.SimGetObjectPose, ObjectName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimGetSegmentationObjectIdAsync(string)" />
        public async Task<RpcResult<int>> SimGetSegmentationObjectIdAsync(string MeshName)
        {
            return await m_proxy.CallAsync<int>(Methods.SimGetSegmentationObjectID, MeshName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimGetVehiclePoseAsync(string)" />
        public async Task<RpcResult<Pose>> SimGetVehiclePoseAsync(string VehicleName)
        {
            return await m_proxy.CallAsyncAdaptor<PoseRpc, Pose>(Methods.SimGetVehiclePose, VehicleName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimIsPausedAsync" />
        public async Task<RpcResult<bool>> SimIsPausedAsync()
        {
            return await m_proxy.CallAsync<bool>(Methods.SimIsPaused);
        }

        /// <inheritdoc cref="IRpcClientBase.SimPauseAsync(bool)" />
        public async Task<RpcResult> SimPauseAsync(bool Pause)
        {
            return await m_proxy.CallAsync(Methods.SimPause, Pause);
        }

        /// <inheritdoc cref="IRpcClientBase.SimPrintLogMessageAsync(string, string, ushort)" />
        public async Task<RpcResult> SimPrintLogMessageAsync(string Message, string MessageParam, ushort severity)
        {
            return await m_proxy.CallAsync(Methods.SimPrintLogMessage, Message, MessageParam, severity);
        }

        /// <inheritdoc cref="IRpcClientBase.SimSetBonePosesAsync(Dictionary{string, Pose}, string)" />
        public async Task<RpcResult> SimSetBonePosesAsync(Dictionary<string, Pose> Poses, string CharacterName)
        {
            Dictionary<string, PoseRpc> PosesAdapted = Poses.ToDictionary((F) => F.Key, (F) => PoseRpc.AdaptFrom(F.Value));
            return await m_proxy.CallAsync(Methods.SimSetBonePoses, Poses, CharacterName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimSetCameraOrientationAsync(string, Quaternion, string)" />
        public async Task<RpcResult> SimSetCameraOrientationAsync(string CameraName, Quaternion Orientation, string VehicleName)
        {
            QuaternionRpc adapted = QuaternionRpc.AdaptFrom(Orientation);
            return await m_proxy.CallAsync(Methods.SimSetCamerOrientation, CameraName, adapted, VehicleName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimSetFacePresetsAsync(Dictionary{string, float}, string)" />
        public async Task<RpcResult> SimSetFacePresetsAsync(Dictionary<string, float> Presets, string CharacterName)
        {
            return await m_proxy.CallAsync(Methods.SimSetFacePresets, Presets, CharacterName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimSetObjectPoseAsync(string, Pose, bool)" />
        public async Task<RpcResult<bool>> SimSetObjectPoseAsync(string ObjectName, Pose Pose, bool Teleport)
        {
            PoseRpc adapted = PoseRpc.AdaptFrom(Pose);
            return await m_proxy.CallAsync<bool>(Methods.SimSetObjectPose, ObjectName, adapted, Teleport);
        }

        /// <inheritdoc cref="IRpcClientBase.SimSetSegmentationObjectIDAsync(string, int, bool)" />
        public async Task<RpcResult<bool>> SimSetSegmentationObjectIDAsync(string MeshName, int ObjectId, bool IsNameRegex)
        {
            return await m_proxy.CallAsync<bool>(Methods.SimSetSegmentationObjectID, MeshName, ObjectId, IsNameRegex);
        }

        /// <inheritdoc cref="IRpcClientBase.SimSetTimeOfDayAsync(bool, string, bool, float, float, bool)" />
        public async Task<RpcResult> SimSetTimeOfDayAsync(bool IsEnabled, string StartDateTime, bool IsStartDateTimeDST, float CelestialClockSpeed, float UpdateIntervalSecs, bool MoveSun)
        {
            return await m_proxy.CallAsync(Methods.SimSetTimeOfDay, IsEnabled, StartDateTime, IsStartDateTimeDST, CelestialClockSpeed, UpdateIntervalSecs, MoveSun);
        }

        /// <inheritdoc cref="IRpcClientBase.SimSetVehiclePoseAsync(Pose, bool, string)" />
        public async Task<RpcResult> SimSetVehiclePoseAsync(Pose Pose, bool IgnoreCollision, string VehicleName)
        {
            PoseRpc adapted = PoseRpc.AdaptFrom(Pose);
            return await m_proxy.CallAsync(Methods.SimSetVehiclePose, adapted, IgnoreCollision, VehicleName);
        }

        /// <inheritdoc cref="IRpcClientBase.SimSetWeatherParameterAsync(WeatherParameter, float)" />
        public async Task<RpcResult> SimSetWeatherParameterAsync(WeatherParameter Param, float Val)
        {
            return await m_proxy.CallAsync(Methods.SimSetWeatherParameter, Param, Val);
        }

        /// <inheritdoc cref="IRpcClientBase.GetLidarData(string, string)" />
        public async Task<RpcResult<LidarData>> GetLidarData(string LidarName, string VehicleName)
        {
            return await m_proxy.CallAsyncAdaptor<LidarDataRpc, LidarData>(Methods.GetLidarData, LidarName, VehicleName);
        }
    }
}
