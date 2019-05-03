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

namespace AirsimClient
{
    /// <summary>
    /// Names of the AirSim Rpc methods
    /// </summary>
    internal static class Methods
    {
        internal const string ArmDisarm = "armDisarm";


        internal const string Ping = "ping";


        internal const string GetClientVersion = "getClientVersion";


        internal const string GetConnectionState = "getConnectionState";


        internal const string EnableApiControl = "enableApiControl";


        internal const string isApiControlEnabled = "isApiControlEnabled";


        internal const string GetMinRequiredServerVersion = "getMinRequiredServerVersion";


        internal const string GetMinRequiredClientVersion = "getMinRequiredClientVersion";


        internal const string GetServerVersion = "getServerVersion";


        internal const string Reset = "reset";


        internal const string GetHomeGeoPoint = "getHomeGeoPoint";


        internal const string SimSetSegmentationObjectID = "simSetSegmentationObjectID";


        internal const string SimGetSegmentationObjectID = "simGetSegmentationObjectID";


        internal const string SimGetCollisionInfo = "simGetCollisionInfo";


        internal const string SimGetVehiclePose = "simGetVehiclePose";


        internal const string SimSetVehiclePose = "simSetVehiclePose";


        internal const string SimGetImages = "simGetImages";


        internal const string SimGetImage = "simGetImage";


        internal const string SimPrintLogMessage = "simPrintLogMessage";


        internal const string SimIsPaused = "simIsPaused";


        internal const string SimPause = "simPause";


        internal const string SimContinueForTime = "simContinueForTime";


        internal const string SimEnableWeather = "simEnableWeather";


        internal const string SimSetWeatherParameter = "simSetWeatherParameter";


        internal const string SimSetTimeOfDay = "simSetTimeOfDay";


        internal const string SimGetObjectPose = "simGetObjectPose";


        internal const string SimSetObjectPose = "simSetObjectPose";


        internal const string SimGetCameraInfo = "simGetCameraInfo";


        internal const string SimSetCamerOrientation = "simSetCameraOrientation";


        internal const string SimGetGroundTruthKinematics = "simGetGroundTruthKinematics";


        internal const string SimGetGroundTruthEnvironment = "simGetGroundTruthEnvironment";


        internal const string CancelLastTask = "cancelLastTask";


        internal const string SimCharGetFaceExpression = "simCharGetFaceExpression";


        internal const string SimCharSetFaceExpression = "simCharSetFaceExpression";


        internal const string SimCharGetAvailableFaceExpressions = "simCharGetAvailableFaceExpressions";


        internal const string SimCharSetSkinDarkness = "simCharGetSkinDarkness";


        internal const string SimCharGetSkinDarkness = "simCharSetSkinDarkness";


        internal const string SimCharSetSkinAgeing = "simCharSetSkinAgeing";


        internal const string SimCharGetSkinAgeing = "simCharGetSkinAgeing";


        internal const string SimCharSetHeadRotation = "simCharSetHeadRotation";


        internal const string SimCharGetHeadRotation = "simCharGetHeadRotation";


        internal const string SimCharSetBonePose = "simCharSetBonePose";


        internal const string SimCharGetBonePose = "simCharGetBonePose";


        internal const string SimCharResetBonePose = "simCharResetBonePose";


        internal const string SimCharSetFacePreset = "simCharSetFacePreset";


        internal const string SimSetFacePresets = "simSetFacePresets";


        internal const string SimSetBonePoses = "simSetBonePoses";


        internal const string SimGetBonePoses = "simGetBonePoses";


        internal const string GetCarState = "getCarState";


        internal const string SetCarControls = "setCarControls";
    }
}
