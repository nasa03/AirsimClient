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


        protected RpcProxy m_proxy;

        public RpcClientBase()
        {
            _connectionState = ConnectionState.Initial;
            m_proxy = new RpcProxy();

        }

        public async Task<RpcResult<bool>> ArmDisarmAsync(bool Arm, string VehicleName)
        {
            return await m_proxy.CallAsync<bool>(Methods.ArmDisarm, Arm, VehicleName);
        }

        public async Task<RpcResult> CancelLastTaskAsync(string VehicleName)
        {
            return await m_proxy.CallAsync(VehicleName);
        }

        public async Task<bool> ConnectAsync(int Port, IPAddress Address)
        {
            IPEndPoint iPEndPoint = new IPEndPoint(Address, Port);
            return await m_proxy.ConnectAsync(iPEndPoint);
        }

        public async Task<RpcResult> EnableApiControlAsync(bool IsEnabled, string VehicleName)
        {
            return await m_proxy.CallAsync(Methods.EnableApiControl, IsEnabled, VehicleName);           
        }

        public async Task<int> GetClientVersionAsync()
        {
            return await new Task<int>(() =>
            {
                return 1;
            });
        }

        public async Task<ConnectionState> GetConnectionStateAsync()
        {
            return await new Task<ConnectionState>(() => 
            {
                return _connectionState;
            });
        }

        public async Task<RpcResult<GeoPoint>> GetHomeGeoPointAsync(string VehicleName)
        {
            return await m_proxy.CallAsync<GeoPoint>(Methods.GetHomeGeoPoint, VehicleName);
        }

        public async Task<int> GetMinRequiredClientVersionAsync()
        {
            return await new Task<int>(() =>
            {
                return 1;
            });
        }

        public async Task<int> GetMinRequiredServerVersionAsync()
        {
            return await new Task<int>(() =>
            {
                return 1;
            });
        }

        public async Task<int> GetServerVersionAsync()
        {
            return await new Task<int>(() =>
            {
                return 1;
            });
        }

        public async Task<RpcResult<bool>> IsApiControlEnabledAsync(string VehicleName)
        {
            return await m_proxy.CallAsync<bool>(Methods.isApiControlEnabled, VehicleName);
        }

        public async Task<RpcResult<bool>> PingAsync()
        {
            return await m_proxy.CallAsync<bool>(Methods.Ping);
        }

        public async Task<RpcResult> ResetAsync()
        {
            return await m_proxy.CallAsync(Methods.Reset);
        }

        public async Task<RpcResult<string[]>> SimCharGetAvailableFaceExpressionsAsync()
        {
            return await m_proxy.CallAsync<string[]>(Methods.SimCharGetAvailableFaceExpressions);
        }

        public async Task<RpcResult<Pose>> SimCharGetBonePoseAsync(string BoneName, string CharacterName)
        {
            return await m_proxy.CallAsyncAdaptor<PoseRpc,Pose>(Methods.SimCharGetBonePose, BoneName, CharacterName);
        }

        public async Task<RpcResult<float>> SimCharGetFaceExpressionAsync(string ExpressionName, string CharacterName)
        {
            return await m_proxy.CallAsync<float>(Methods.SimCharGetFaceExpression, ExpressionName, CharacterName);
        }

        public async Task<RpcResult<Quaternion>> SimCharGetHeadRotationAsync(string CharaterName)
        {
            return await m_proxy.CallAsyncAdaptor<QuaternionRpc, Quaternion>(Methods.SimCharGetHeadRotation, CharaterName);
        }

        public async Task<RpcResult<float>> SimCharGetSkinAgeingAsync(string CharacterName)
        {
            return await m_proxy.CallAsync<float>(Methods.SimCharGetSkinAgeing, CharacterName);
        }

        public async Task<RpcResult<float>> SimCharGetSkinDarknessAsync(string CharacterName)
        {
            return await m_proxy.CallAsync<float>(Methods.SimCharGetSkinDarkness, CharacterName);
        }

        public async Task<RpcResult> SimCharResetBonePoseAsync(string BoneName, string CharaterName)
        {
            return await m_proxy.CallAsync(Methods.SimCharResetBonePose, BoneName, CharaterName);
        }

        public async Task<RpcResult> SimCharSetBonePoseAsync(string BoneName, Pose pose, string CharacterName)
        {
            PoseRpc adaptedPose = PoseRpc.AdaptFrom(pose);
            return await m_proxy.CallAsync(Methods.SimCharSetBonePose, BoneName, adaptedPose, CharacterName);
        }

        public async Task<RpcResult> SimCharSetFaceExpressionAsync(string ExpressionName, float Value, string CharacterName)
        {
            return await m_proxy.CallAsync(Methods.SimCharSetFaceExpression, ExpressionName, Value, CharacterName);
        }

        public async Task<RpcResult> SimCharSetFacePresetAsync(string PresetName, float Value, string CharacterName)
        {
            return await m_proxy.CallAsync(Methods.SimCharSetFacePreset, PresetName, Value, CharacterName);
        }

        public async Task<RpcResult> SimCharSetHeadRotationAsync(Quaternion q, string CharacterName)
        {
            QuaternionRpc adapted = QuaternionRpc.AdaptFrom(q);
            return await m_proxy.CallAsync(Methods.SimCharSetHeadRotation, q, CharacterName);
        }

        public async Task<RpcResult> SimCharSetSkinAgeingAsync(float Value, string CharacteName)
        {
            return await m_proxy.CallAsync(Methods.SimCharSetSkinAgeing, Value, CharacteName);
        }

        public async Task<RpcResult> SimCharSetSkinDarknessAsync(float Value, string CharacterName)
        {
            return await m_proxy.CallAsync(Methods.SimCharSetSkinDarkness, Value, CharacterName);
        }

        public async Task<RpcResult> SimContinueForTimeAsync(double Seconds)
        {
            return await m_proxy.CallAsync(Methods.SimContinueForTime, Seconds);
        }

        public async Task<RpcResult> SimEnableWeatherAsync(bool Enable)
        {
            return await m_proxy.CallAsync(Methods.SimEnableWeather, Enable);
        }

        public async Task<RpcResult<Dictionary<string, Pose>>> SimGetBonePosesAsync(string[] BoneNames, string CharacterName)
        {
            return await m_proxy.CallAsync<Dictionary<string, Pose>>(Methods.SimGetBonePoses, BoneNames, CharacterName);
        }

        public async Task<RpcResult<CameraInfo>> SimGetCameraInfoAsync(string CameraName, string VehicleName)
        {
            return await m_proxy.CallAsyncAdaptor<CameraInfoRpc, CameraInfo>(Methods.SimGetCameraInfo, CameraName, VehicleName);

        }

        public async Task<RpcResult<CollisionInfo>> SimGetCollisionInfoAsync(string VehicleName)
        {
                return await m_proxy.CallAsyncAdaptor<CollisionInfoRpc, CollisionInfo>(Methods.SimGetCameraInfo, VehicleName);
        }

        public async Task<RpcResult<EnvironmentState>> SimGetGroundTruthEnvironmentAsync(string VehicleName)
        {
            return await m_proxy.CallAsync<EnvironmentState>(Methods.SimGetGroundTruthEnvironment, VehicleName);
        }

        public async Task<RpcResult<KinematicsState>> SimGetGroundTruthKinematicsAsync(string VehicleName)
        {
            return await m_proxy.CallAsyncAdaptor<KinematicsStateRpc, KinematicsState>(Methods.SimGetGroundTruthKinematics, VehicleName);
        }

        public async Task<RpcResult<ushort[]>> SimGetImageAsync(string CameraName, ImageType ImageType, string VehicleName)
        {
            return await m_proxy.CallAsync<ushort[]>(Methods.SimGetImage, CameraName, ImageType, VehicleName);
        }

        public async Task<RpcResult<ImageResponse>> SimGetImagesAsync(ImageRequest Request, string VehicleName)
        {
            ImageRequestRpc adapted = ImageRequestRpc.AdaptFrom(Request);
            return await m_proxy.CallAsyncAdaptor<ImageResponseRpc, ImageResponse>(Methods.SimGetImages, adapted, VehicleName);
        }

        public async Task<RpcResult<Pose>> SimGetObjectPoseAsync(string ObjectName)
        {
            return await m_proxy.CallAsyncAdaptor<PoseRpc, Pose>(Methods.SimGetObjectPose, ObjectName);
        }

        public async Task<RpcResult<int>> SimGetSegmentationObjectIdAsync(string MeshName)
        {
            return await m_proxy.CallAsync<int>(Methods.SimGetSegmentationObjectID, MeshName);
        }

        public async Task<RpcResult<Pose>> SimGetVehiclePoseAsync(string VehicleName)
        {
            return await m_proxy.CallAsyncAdaptor<PoseRpc, Pose>(Methods.SimGetVehiclePose, VehicleName);
        }

        public async Task<RpcResult<bool>> SimIsPausedAsync()
        {
            return await m_proxy.CallAsync<bool>(Methods.SimIsPaused);
        }

        public async Task<RpcResult> SimPauseAsync(bool Pause)
        {
            return await m_proxy.CallAsync(Methods.SimPause, Pause);
        }

        public async Task<RpcResult> SimPrintLogMessageAsync(string Message, string MessageParam, ushort severity)
        {
            return await m_proxy.CallAsync(Methods.SimPrintLogMessage, Message, MessageParam, severity);
        }

        public async Task<RpcResult> SimSetBonePosesAsync(Dictionary<string, Pose> Poses, string CharacterName)
        {
            Dictionary<string, PoseRpc> PosesAdapted = Poses.ToDictionary((F) => F.Key, (F) => PoseRpc.AdaptFrom(F.Value));
            return await m_proxy.CallAsync(Methods.SimSetBonePoses, Poses, CharacterName);
        }

        public async Task<RpcResult> SimSetCameraOrientationAsync(string CameraName, Quaternion Orientation, string VehicleName)
        {
            QuaternionRpc adapted = QuaternionRpc.AdaptFrom(Orientation);
            return await m_proxy.CallAsync(Methods.SimSetCamerOrientation, CameraName, adapted, VehicleName);
        }

        public async Task<RpcResult> SimSetFacePresetsAsync(Dictionary<string, float> Presets, string CharacterName)
        {
            return await m_proxy.CallAsync(Methods.SimSetFacePresets, Presets, CharacterName);
        }

        public async Task<RpcResult<bool>> SimSetObjectPoseAsync(string ObjectName, Pose Pose, bool Teleport)
        {
            PoseRpc adapted = PoseRpc.AdaptFrom(Pose);
            return await m_proxy.CallAsync<bool>(Methods.SimSetObjectPose, ObjectName, adapted, Teleport);
        }

        public async Task<RpcResult<bool>> SimSetSegmentationObjectIDAsync(string MeshName, int ObjectId, bool IsNameRegex)
        {
            return await m_proxy.CallAsync<bool>(Methods.SimSetSegmentationObjectID, MeshName, ObjectId, IsNameRegex);
        }

        public async Task<RpcResult> SimSetTimeOfDayAsync(bool IsEnabled, string StartDateTime, bool IsStartDateTimeDST, float CelestialClockSpeed, float UpdateIntervalSecs, bool MoveSun)
        {
            return await m_proxy.CallAsync(Methods.SimSetTimeOfDay, IsEnabled, StartDateTime, IsStartDateTimeDST, CelestialClockSpeed, UpdateIntervalSecs, MoveSun);
        }

        public async Task<RpcResult> SimSetVehiclePoseAsync(Pose Pose, bool IgnoreCollision, string VehicleName)
        {
            PoseRpc adapted = PoseRpc.AdaptFrom(Pose);
            return await m_proxy.CallAsync(Methods.SimSetVehiclePose, adapted, IgnoreCollision, VehicleName);
        }

        public async Task<RpcResult> SimSetWeatherParameterAsync(WeatherParameter Param, float Val)
        {
            return await m_proxy.CallAsync(Methods.SimSetWeatherParameter, Param, Val);
        }
    }
}
