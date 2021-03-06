/**
 * Copyright (c) 2018 LG Electronics, Inc.
 *
 * This software contains code licensed as described in LICENSE.
 *
 */


using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(VehicleController))]
[RequireComponent(typeof(GpsDevice))]
public class CanBus : MonoBehaviour, Comm.BridgeClient
{
    public ROSTargetEnvironment targetEnv;
    // VehicleController controller;

    public string ApolloTopic = "/apollo/canbus/chassis";
    
    public float Frequency = 10f;

    public bool PublishMessage = false;

    uint seq;
    float NextSend;

    Comm.Bridge Bridge;
    Comm.Writer<Ros.Apollo.ChassisMsg> ApolloChassisWriter;
    Comm.Writer<Apollo.Canbus.Chassis> Apollo35ChassisWriter;
    Comm.Writer<Ros.TwistStamped> LgsvlWriter;

    Rigidbody mainRigidbody;
    VehicleController controller;
    VehicleInputController input_controller;
    GpsDevice gps;

    private void Start()
    {
        NextSend = Time.time + 1.0f / Frequency;
        controller = GetComponent<VehicleController>();
        input_controller = GetComponent<VehicleInputController>();
        gps = GetComponentInChildren<GpsDevice>();
        mainRigidbody = GetComponent<Rigidbody>();
    }

    public void GetSensors(List<Component> sensors)
    {
        sensors.Add(this);
    }

    public void OnBridgeAvailable(Comm.Bridge bridge)
    {
        Bridge = bridge;
        Bridge.OnConnected += () =>
        {
            if (targetEnv == ROSTargetEnvironment.AUTOWARE)
            {
                Debug.Log("CAN bus not implemented in Autoware (yet). Nothing to publish.");
            }

            else if (targetEnv == ROSTargetEnvironment.APOLLO)
            {
                ApolloChassisWriter = Bridge.AddWriter<Ros.Apollo.ChassisMsg>(ApolloTopic);
            }

            else if (targetEnv == ROSTargetEnvironment.APOLLO35)
            {
                Apollo35ChassisWriter = Bridge.AddWriter<Apollo.Canbus.Chassis>(ApolloTopic);
            }

            seq = 0;
        };
    }

    void Update()
    {
        if (targetEnv != ROSTargetEnvironment.APOLLO && targetEnv != ROSTargetEnvironment.APOLLO35 && targetEnv != ROSTargetEnvironment.AUTOWARE)
        {
            return;
        }

        if (Bridge == null || Bridge.Status != Comm.BridgeStatus.Connected || !PublishMessage)
        {
            return;
        }

        if (Time.time < NextSend)
        {
            return;
        }

        if (targetEnv == ROSTargetEnvironment.APOLLO)
        {
            Vector3 vel = mainRigidbody.velocity;
            Vector3 eul = mainRigidbody.rotation.eulerAngles;

            float dir;
            if (eul.y >= 0) dir = 45 * Mathf.Round((eul.y % 360) / 45.0f);
            else dir = 45 * Mathf.Round((eul.y % 360 + 360) / 45.0f);

            // (TODO) check for leap second issues.
            var gps_time = DateTimeOffset.FromUnixTimeSeconds((long) gps.measurement_time).DateTime.ToLocalTime();
            
            float accel = input_controller.controller.accellInput * 100;
            var apolloMessage = new Ros.Apollo.ChassisMsg()
            {
                engine_started = true,
                engine_rpm = controller.currentRPM,
                speed_mps = vel.magnitude,
                odometer_m = 0,
                fuel_range_m = 0,
                throttle_percentage = accel > 0 ? accel : 0,
                brake_percentage = accel < 0 ? -accel : 0,
                steering_percentage = - controller.steerInput * 100,
                // steering_torque_nm
                parking_brake = controller.handbrakeApplied,
                high_beam_signal = (controller.headlightMode == 2),
                low_beam_signal = (controller.headlightMode == 1),
                left_turn_signal = controller.leftTurnSignal,
                right_turn_signal = controller.rightTurnSignal,
                // horn
                wiper = (controller.wiperStatus != 0),
                // disengage_status
                driving_mode = Ros.Apollo.Chassis.DrivingMode.COMPLETE_AUTO_DRIVE,
                // error_code
                gear_location = controller.InReverse ? Ros.Apollo.Chassis.GearPosition.GEAR_REVERSE : Ros.Apollo.Chassis.GearPosition.GEAR_DRIVE,
                // steering_timestamp
                // signal
                // engage_advice              
               
                chassis_gps = new Ros.Apollo.Chassis.ChassisGPS()
                {
                    latitude = gps.latitude,
                    longitude = gps.longitude,
                    gps_valid = gps.PublishMessage,
                    year = gps_time.Year,
                    month = gps_time.Month,
                    day = gps_time.Day,
                    hours = gps_time.Hour,
                    minutes = gps_time.Minute,
                    seconds = gps_time.Second,
                    compass_direction = dir,
                    pdop = 0.1,
                    is_gps_fault = false,
                    is_inferred = false,
                    altitude = gps.height,
                    heading = eul.y,
                    hdop = 0.1,
                    vdop = 0.1,
                    quality = Ros.Apollo.Chassis.GpsQuality.FIX_3D,
                    num_satellites = 15,
                    gps_speed = vel.magnitude,

                },

                header = new Ros.ApolloHeader()
                {
                    timestamp_sec = Ros.Time.Now().secs,
                    module_name = "chassis",
                    sequence_num = seq,
                },
            };

            ApolloChassisWriter.Publish(apolloMessage);
        }

        else if (targetEnv == ROSTargetEnvironment.APOLLO35)
        {
            Vector3 vel = mainRigidbody.velocity;
            Vector3 eul = mainRigidbody.rotation.eulerAngles;

            float dir;
            if (eul.y >= 0) dir = 45 * Mathf.Round((eul.y % 360) / 45.0f);
            else dir = 45 * Mathf.Round((eul.y % 360 + 360) / 45.0f);

            // (TODO) check for leap second issues.
            var gps_time = DateTimeOffset.FromUnixTimeSeconds((long) gps.measurement_time).DateTime.ToLocalTime();
            
            System.DateTime Unixepoch = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
            double measurement_time = (double)(System.DateTime.UtcNow - Unixepoch).TotalSeconds;

            float accel = input_controller.controller.accellInput * 100;
            var apolloMessage = new Apollo.Canbus.Chassis()
            {
                EngineStarted = true,
                EngineRpm = controller.currentRPM,
                SpeedMps = vel.magnitude,
                OdometerM = 0,
                FuelRangeM = 0,
                ThrottlePercentage = accel > 0 ? accel : 0,
                BrakePercentage = accel < 0 ? -accel : 0,
                SteeringPercentage = - controller.steerInput * 100,
                // steering_torque_nm
                ParkingBrake = controller.handbrakeApplied,
                HighBeamSignal = (controller.headlightMode == 2),
                LowBeamSignal = (controller.headlightMode == 1),
                LeftTurnSignal = controller.leftTurnSignal,
                RightTurnSignal = controller.rightTurnSignal,
                // horn
                Wiper = (controller.wiperStatus != 0),
                // disengage_status
                DrivingMode = Apollo.Canbus.Chassis.Types.DrivingMode.CompleteAutoDrive,
                // error_code
                GearLocation = controller.InReverse ? Apollo.Canbus.Chassis.Types.GearPosition.GearReverse : Apollo.Canbus.Chassis.Types.GearPosition.GearDrive,
                // steering_timestamp
                // signal
                // engage_advice              
               
                ChassisGps = new Apollo.Canbus.ChassisGPS()
                {
                    Latitude = gps.latitude,
                    Longitude = gps.longitude,
                    GpsValid = gps.PublishMessage,
                    Year = gps_time.Year,
                    Month = gps_time.Month,
                    Day = gps_time.Day,
                    Hours = gps_time.Hour,
                    Minutes = gps_time.Minute,
                    Seconds = gps_time.Second,
                    CompassDirection = dir,
                    Pdop = 0.1,
                    IsGpsFault = false,
                    IsInferred = false,
                    Altitude = gps.height,
                    Heading = eul.y,
                    Hdop = 0.1,
                    Vdop = 0.1,
                    Quality = Apollo.Canbus.GpsQuality.Fix3D,
                    NumSatellites = 15,
                    GpsSpeed = vel.magnitude,

                },

                Header = new Apollo.Common.Header()
                {
                    TimestampSec = measurement_time,
                    ModuleName = "chassis",
                    SequenceNum = seq,
                },
            };

            Apollo35ChassisWriter.Publish(apolloMessage);

        }
    }
}
