/************************************************************************************
 【PXR SDK】
 Copyright 2015-2020 Pico Technology Co., Ltd. All Rights Reserved.

************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.XR.PXR
{
    public class PXR_System
    {
        /// <summary>
        /// Turn on power service
        /// </summary>
        /// <param name="objName"></param>
        /// <returns></returns>
        public static bool StartBatteryReceiver(string objName)
        {
            return PXR_Plugin.System.UPxr_StartBatteryReceiver(objName);
        }

        /// <summary>
        /// Turn off power service
        /// </summary>
        /// <returns></returns>
        public static bool StopBatteryReceiver()
        {
            return PXR_Plugin.System.UPxr_StopBatteryReceiver();
        }

        /// <summary>
        /// Set the brightness value of the current general device
        /// </summary>
        /// <param name="brightness">brightness value range is 0-255</param>
        /// <returns></returns>
        public static bool SetCommonBrightness(int brightness)
        {
            return PXR_Plugin.System.UPxr_SetBrightness(brightness);
        }

        /// <summary>
        /// Get the brightness value of the current general device
        /// </summary>
        /// <returns>brightness value range: 0-255</returns>
        public static int GetCommonBrightness()
        {
            return PXR_Plugin.System.UPxr_GetCurrentBrightness();
        }

        /// <summary>
        /// Gets the brightness level of the current screen
        /// </summary>
        /// <returns>int array. The first bit is the total brightness level supported, the second bit is the current brightness level, and it is the interval value of the brightness level from the third bit to the end bit</returns>
        public static int[] GetScreenBrightnessLevel()
        {
            int[] currentLight = { 0 };
            currentLight = PXR_Plugin.System.UPxr_GetScreenBrightnessLevel();
            return currentLight;
        }

        /// <summary>
        /// Set the brightness of the screen
        /// </summary>
        /// <param name="brightness">Brightness mode</param>
        /// <param name="level">Brightness value (brightness level value). If brightness passes in 1, level passes in brightness level; if brightness passes in 0, it means that the system default brightness setting mode is adopted. Level can be set to a value between 1 and 255.</param>
        public static void SetScreenBrightnessLevel(int brightness, int level)
        {
            PXR_Plugin.System.UPxr_SetScreenBrightnessLevel(brightness, level);
        }

        /// <summary>
        /// Turn on volume service
        /// </summary>
        /// <param name="objName"></param>
        /// <returns></returns>
        public static bool StartAudioReceiver(string objName)
        {
            return PXR_Plugin.System.UPxr_StartAudioReceiver(objName);
        }

        /// <summary>
        /// Turn off volume service
        /// </summary>
        /// <returns></returns>
        public static bool StopAudioReceiver()
        {
            return PXR_Plugin.System.UPxr_StopAudioReceiver();
        }

        /// <summary>
        /// Get maximum volume
        /// </summary>
        /// <returns></returns>
        public static int GetMaxVolumeNumber()
        {
            return PXR_Plugin.System.UPxr_GetMaxVolumeNumber();
        }

        /// <summary>
        /// Get the current volume
        /// </summary>
        /// <returns></returns>
        public static int GetCurrentVolumeNumber()
        {
            return PXR_Plugin.System.UPxr_GetCurrentVolumeNumber();
        }

        /// <summary>
        /// Increase volume
        /// </summary>
        /// <returns></returns>
        public static bool VolumeUp()
        {
            return PXR_Plugin.System.UPxr_VolumeUp();
        }

        /// <summary>
        /// Decrease volume
        /// </summary>
        /// <returns></returns>
        public static bool VolumeDown()
        {
            return PXR_Plugin.System.UPxr_VolumeDown();
        }

        /// <summary>
        /// Set volume
        /// </summary>
        /// <param name="volume"></param>
        /// <returns></returns>
        public static bool SetVolumeNum(int volume)
        {
            return PXR_Plugin.System.UPxr_SetVolumeNum(volume);
        }

        /// <summary>
        /// Judging whether current device’s permission is valid
        /// </summary>
        /// <returns></returns>
        public static PXR_PlatformSetting.simulationType IsCurrentDeviceValid()
        {
            return PXR_Plugin.PlatformSetting.UPxr_IsCurrentDeviceValid();
        }

        /// <summary>
        /// Use appid to get result whether entitlement required by app is present
        /// </summary>
        /// <param name="appid"></param>
        /// <returns>value: True: Succes; False: Fail</returns>
        public static bool AppEntitlementCheck(string appid)
        {
            return PXR_Plugin.PlatformSetting.UPxr_AppEntitlementCheck(appid);
        }

        /// <summary>
        /// Use publicKey to get error code of entitlement check result
        /// </summary>
        /// <param name="publicKey"></param>
        /// <returns>value: True: Succes; False: Fail</returns>
        public static bool KeyEntitlementCheck(string publicKey)
        {
            return PXR_Plugin.PlatformSetting.UPxr_KeyEntitlementCheck(publicKey);
        }

        /// <summary>
        /// Use appid to get error code of entitlement check result
        /// </summary>
        /// <param name="appid"></param>
        /// <returns>value: 0:success -1:invalid params -2:service not exist (old versions of ROM have no Service. If the application needs to be limited to operating in old versions, this state needs processing) -3:time out</returns>
        public static int AppEntitlementCheckExtra(string appid)
        {
            return PXR_Plugin.PlatformSetting.UPxr_AppEntitlementCheckExtra(appid);
        }

        /// <summary>
        /// Use publicKey to get error code of entitlement check result
        /// </summary>
        /// <param name="publicKey"></param>
        /// <returns>value: 0:success -1:invalid params -2:service not exist (old versions of ROM have no Service. If the application needs to be limited to operating in old versions, this state needs processing) -3:time out</returns>
        public static int KeyEntitlementCheckExtra(string publicKey)
        {
            return PXR_Plugin.PlatformSetting.UPxr_KeyEntitlementCheckExtra(publicKey);
        }

        /// <summary>
        /// Get SDK version number
        /// </summary>
        /// <returns></returns>
        public static string GetSDKVersion()
        {
            return PXR_Plugin.System.UPxr_GetSDKVersion();
        }
    }
}

