using AirsimClient.Common;
using Microsoft.Spatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AirsimClient
{
    public interface IRpcClientBase
    {
        bool Ping();

        ConnectionState GetConnectionState();

        void EnableApiControl(string VehicleName);

        bool IsApiControlEnabled(string VehicleName);

        int GetClientVersion();

        int GetMinRequiredServerVersion();

        int GetMinRequiredClientVersion();

        int GetServerVersion();

        void Reset();

        bool ArmDisarm(bool Arm, string VehicleName);

        GeographyPoint GetHomeGeoPoint(string VehicleName);

        bool SimSetSegmentationObjectID(string MeshName, int ObjectId, bool IsNameRegex);

        int SimGetSegmentationObjectId(string MeshName);

        CollisionInfo SimGetCollisionInfo(string VehicleName);

        Pose SimGetVehiclePose(string VehicleName);

        void SimSetVehiclePose(Pose Pose, bool IgnoreCollision, string VehicleName);

        ImageResponse SimGetImages(ImageRequest Request, string VehicleName);

        ushort[] SimGetImage(string CameraName, ImageType ImageType, string VehicleName);

        void SimPrintLogMessage(string Message, string MessageParam, ushort severity);

        bool SimIsPaused();

        void SimPause(bool Pause);

        void SimContinueForTime(double Seconds);

        void SimEnableWeather(bool Enable);

        void SimSetWeatherParameter(WeatherParameter Param, float Val);

        void SimSetTimeOfDay(bool IsEnabled, string StartDateTime, bool IsStartDateTimeDST,
           float CelestialClockSpeed, float UpdateIntervalSecs, bool MoveSun);

        Pose SimGetObjectPose(string ObjectName);

        bool SimSetObjectPose(string ObjectName, Pose Pose, bool Teleport);

        CameraInfo SimGetCameraInfo(string CameraName, string VehicleName);

        void SimSetCameraOrientation(string CameraName, Quaternion Orientation, string VehicleName);

        KinematicsState SimGetGroundTruthKinematics(string VehicleName);

        EnvironmentState SimGetGroundTruthEnvironment(string VehicleName);

        void CancelLastTask(string VehicleName);

        void SimCharSetFaceExpression(string ExpressionName, float Value, string CharacterName);

        float SimCharGetFaceExpression(string ExpressionName, string CharacterName);

        string[] SimCharGetAvailableFaceExpressions();

        void SimCharSetSkinDarkness(float Value, string CharacterName);

        float SimCharGetSkinDarkness(string CharacterName);

        void SimCharSetSkinAgeing(float Value, string CharacteName);

        float SimCharGetSkinAgeing(string CharacterName);

        void SimCharSetHeadRotation(Quaternion q, string CharacterName);

        Quaternion SimCharGetHeadRotation(string CharaterName);

        void SimCharSetBonePose(string BoneName, Pose pose, string CharacterName);

        Pose SimCharGetBonePose(string BoneName, string CharacterName);

        void SimCharResetBonePose(string BoneName, string CharaterName);

        void SimCharSetFacePreset(string PresetName, float Value, string CharacterName);

        void SimSetFacePresets(IDictionary<string, float> Presets, string CharacterName);

        void SimSetBonePoses(IDictionary<string, Pose> Poses, string CharacterName);

        IDictionary<string, Pose> SimGetBonePoses(string[] BoneNames, string CharacterName);
    }
}
