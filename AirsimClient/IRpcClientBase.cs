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

using AirsimClient.Adaptors;
using AirsimClient.Common;
using MsgPackRpc;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using System.Threading.Tasks;

namespace AirsimClient
{
    /// <summary>
    /// Base client for interacting with API
    /// </summary>
    public interface IRpcClientBase
    {
        /// <summary>
        /// Establishes a connection over TCP
        /// </summary>
        Task<bool> ConnectAsync(int Port, IPAddress Address);

        /// <summary>
        /// Pings if there is a connection established
        /// </summary>
        Task<RpcResult<bool>> PingAsync();

        /// <summary>
        /// Gets the connection state
        /// </summary>
        Task<ConnectionState> GetConnectionStateAsync();

        /// <summary>
        /// Enables the client to use AirSim API
        /// </summary>
        Task<RpcResult> EnableApiControlAsync(bool IsEnabled, string VehicleName);


        Task<RpcResult<bool>> IsApiControlEnabledAsync(string VehicleName);

        Task<int> GetClientVersionAsync();

        Task<int> GetMinRequiredServerVersionAsync();

        Task<int> GetMinRequiredClientVersionAsync();

        Task<int> GetServerVersionAsync();

        Task<RpcResult> ResetAsync();

        Task<RpcResult<bool>> ArmDisarmAsync(bool Arm, string VehicleName);

        Task<RpcResult<GeoPoint>> GetHomeGeoPointAsync(string VehicleName);

        Task<RpcResult<bool>> SimSetSegmentationObjectIDAsync(string MeshName, int ObjectId, bool IsNameRegex);

        Task<RpcResult<int>> SimGetSegmentationObjectIdAsync(string MeshName);

        Task<RpcResult<CollisionInfo>> SimGetCollisionInfoAsync(string VehicleName);

        Task<RpcResult<Pose>> SimGetVehiclePoseAsync(string VehicleName);

        Task<RpcResult> SimSetVehiclePoseAsync(Pose Pose, bool IgnoreCollision, string VehicleName);

        Task<RpcResult<ImageResponse>> SimGetImagesAsync(ImageRequest Request, string VehicleName);

        Task<RpcResult<byte[]>> SimGetImageAsync(string CameraName, ImageType ImageType, string VehicleName);

        Task<RpcResult> SimPrintLogMessageAsync(string Message, string MessageParam, ushort severity);

        Task<RpcResult<bool>> SimIsPausedAsync();

        Task<RpcResult> SimPauseAsync(bool Pause);

        Task<RpcResult> SimContinueForTimeAsync(double Seconds);

        Task<RpcResult> SimEnableWeatherAsync(bool Enable);

        Task<RpcResult> SimSetWeatherParameterAsync(WeatherParameter Param, float Val);

        Task<RpcResult> SimSetTimeOfDayAsync(bool IsEnabled, string StartDateTime, bool IsStartDateTimeDST,
           float CelestialClockSpeed, float UpdateIntervalSecs, bool MoveSun);

        Task<RpcResult<Pose>> SimGetObjectPoseAsync(string ObjectName);

        Task<RpcResult<bool>> SimSetObjectPoseAsync(string ObjectName, Pose Pose, bool Teleport);

        Task<RpcResult<CameraInfo>> SimGetCameraInfoAsync(string CameraName, string VehicleName);

        Task<RpcResult> SimSetCameraOrientationAsync(string CameraName, Quaternion Orientation, string VehicleName);

        Task<RpcResult<KinematicsState>> SimGetGroundTruthKinematicsAsync(string VehicleName);

        Task<RpcResult<EnvironmentState>> SimGetGroundTruthEnvironmentAsync(string VehicleName);

        Task<RpcResult> CancelLastTaskAsync(string VehicleName);

        Task<RpcResult> SimCharSetFaceExpressionAsync(string ExpressionName, float Value, string CharacterName);

        Task<RpcResult<float>> SimCharGetFaceExpressionAsync(string ExpressionName, string CharacterName);

        Task<RpcResult<string[]>> SimCharGetAvailableFaceExpressionsAsync();

        Task<RpcResult> SimCharSetSkinDarknessAsync(float Value, string CharacterName);

        Task<RpcResult<float>> SimCharGetSkinDarknessAsync(string CharacterName);

        Task<RpcResult> SimCharSetSkinAgeingAsync(float Value, string CharacteName);

        Task<RpcResult<float>> SimCharGetSkinAgeingAsync(string CharacterName);

        Task<RpcResult> SimCharSetHeadRotationAsync(Quaternion q, string CharacterName);

        Task<RpcResult<Quaternion>> SimCharGetHeadRotationAsync(string CharaterName);

        Task<RpcResult> SimCharSetBonePoseAsync(string BoneName, Pose pose, string CharacterName);

        Task<RpcResult<Pose>> SimCharGetBonePoseAsync(string BoneName, string CharacterName);

        Task<RpcResult> SimCharResetBonePoseAsync(string BoneName, string CharaterName);

        Task<RpcResult> SimCharSetFacePresetAsync(string PresetName, float Value, string CharacterName);

        Task<RpcResult> SimSetFacePresetsAsync(Dictionary<string, float> Presets, string CharacterName);

        Task<RpcResult> SimSetBonePosesAsync(Dictionary<string, Pose> Poses, string CharacterName);

        Task<RpcResult<Dictionary<string, Pose>>> SimGetBonePosesAsync(string[] BoneNames, string CharacterName);

        /// <summary>
        /// Reads data from a lidar sensor on  a vehicle.
        /// </summary>       
        Task<RpcResult<LidarData>> GetLidarData(string LidarName, string VehicleName);
    }
}
