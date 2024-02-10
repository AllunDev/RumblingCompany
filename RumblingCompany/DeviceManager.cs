using Buttplug.Client;
using Buttplug.Client.Connectors.WebsocketConnector;
using Buttplug.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RumblingCompany
{
    public class DeviceManager
    {
        private List<ButtplugClientDevice> ConnectedDevices { get; set; }
        private ButtplugClient ButtplugClient { get; set; }

        private float currentVibration = 0f;
        private float spikeVibration = 0f;
        private float vibrationIncreasePerSecond = 2f;
        private float vibrationDecreasePerSecond = 0.25f;

        
        public bool isRunning = false;
        public bool isUsingJetpack = false;
        public bool isSpectating = false;
        public bool isUsingWalkieTalkie = false;
        public bool isRecievingWalkieTalkie = false;
        public bool isZapping = false;
        public bool isBeingZapped = false;

        public DeviceManager(string clientName)
        {
            ConnectedDevices = new List<ButtplugClientDevice>();
            Plugin.Mls.LogInfo($"Attempting to connect to Intiface server at ws://localhost:12345");
            ButtplugClient = new ButtplugClient(clientName);
            Plugin.Mls.LogInfo("Connection successful. Beginning scan for devices");

            ButtplugClient.DeviceAdded += HandleDeviceAdded;
            ButtplugClient.DeviceRemoved += HandleDeviceRemoved;
        }
        

        public void Vibrate()
        {
            float targetVibration = calculateVibrationTarget();

            currentVibration = currentVibration < targetVibration ? Mathf.Clamp(currentVibration + vibrationIncreasePerSecond * Time.deltaTime, 0f, Mathf.Min(targetVibration, 1f)) : Mathf.Clamp01(currentVibration - vibrationDecreasePerSecond * Time.deltaTime);

            async void Action(ButtplugClientDevice device)
            {
                await device.VibrateAsync(Mathf.Clamp(currentVibration, 0f, 1.0f));
            }

            ConnectedDevices.ForEach(Action);

            // if (currentVibration > 0f) Plugin.Mls.LogInfo($"Current vibration: {Mathf.CeilToInt(currentVibration * 100)}");
            
            spikeVibration = Mathf.Clamp(spikeVibration - vibrationDecreasePerSecond * Time.deltaTime, 0f, 2f);
        }

        public void increaseVibration(float increase)
        {
            spikeVibration += increase;
        }

        public float calculateVibrationTarget()
        {
            float continuous = 0f;

            if (isRunning) continuous += 0.2f;

            if (isUsingJetpack) continuous += 0.5f;

            if (isSpectating) continuous += 0.15f;

            if (isUsingWalkieTalkie) continuous += 0.2f;

            if (isRecievingWalkieTalkie) continuous += 0.25f;
            
            if (isZapping) continuous += 0.3f;

            if (isBeingZapped) continuous += 0.8f;

            return spikeVibration + continuous;
        }

        public async void ConnectDevices()
        {
            if (ButtplugClient.Connected) { return; }

            try
            {
                await ButtplugClient.ConnectAsync(new ButtplugWebsocketConnector(new Uri("ws://localhost:12345")));
                await ButtplugClient.StartScanningAsync();
            }
            catch (ButtplugException)
            {
                Plugin.Mls.LogInfo("Something went wrong");
            }
        }

        private void HandleDeviceAdded(object sender, DeviceAddedEventArgs args)
        {
            if (!IsVibratableDevice(args.Device))
            {
                Plugin.Mls.LogInfo($"{args.Device.Name} was detected but ignored due to it not being vibratable.");
                return;
            }

            Plugin.Mls.LogInfo($"{args.Device.Name} connected to client {ButtplugClient.Name}");
            ConnectedDevices.Add(args.Device);
        }

        private void HandleDeviceRemoved(object sender, DeviceRemovedEventArgs args)
        {
            if (!IsVibratableDevice(args.Device)) { return; }

            Plugin.Mls.LogInfo($"{args.Device.Name} disconnected from client {ButtplugClient.Name}");
            ConnectedDevices.Remove(args.Device);
        }

        private bool IsVibratableDevice(ButtplugClientDevice device)
        {
            return device.VibrateAttributes.Count > 0;
        }
    }
}