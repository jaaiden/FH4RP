using System;
using System.Collections.Generic;
using System.Text;

namespace FH4RP.DataStructs
{
    public struct TelemetryData
    {
        /// <summary>
        /// Returns 1 when in a race, 0 when in menus or otherwise
        /// </summary>
        public int IsRaceOn { get; set; }

        /// <summary>
        /// Timestamp in MS, can overflow to 0 eventually
        /// </summary>
        public uint TimestampMS { get; set; }



        public float EngineMaxRPM { get; set; }
        public float EngineIdleRPM { get; set; }
        public float EngineCurrentRPM { get; set; }



        /// <summary>
        /// Right (x) position axis in local space
        /// </summary>
        public float AccelerationX { get; set; }

        /// <summary>
        /// Up (y) position axis in local space
        /// </summary>
        public float AccelerationY { get; set; }

        /// <summary>
        /// Forward (z) position axis in local space
        /// </summary>
        public float AccelerationZ { get; set; }



        /// <summary>
        /// Right (x) velocity axis in local space
        /// </summary>
        public float VelocityX { get; set; }

        /// <summary>
        /// Up (y) velocity axis in local space
        /// </summary>
        public float VelocityY { get; set; }

        /// <summary>
        /// Forward (z) velocity axis in local space
        /// </summary>
        public float VelocityZ { get; set; }



        /// <summary>
        /// Pitch (x) velocity in local space
        /// </summary>
        public float AngularVelocityX { get; set; }

        /// <summary>
        /// Yaw (y) velocity in local space
        /// </summary>
        public float AngularVelocityY { get; set; }

        /// <summary>
        /// Roll (z) velocity in local space
        /// </summary>
        public float AngularVelocityZ { get; set; }



        public float Yaw { get; set; }
        public float Pitch { get; set; }
        public float Roll { get; set; }


        
        /// <summary>
        /// Normalized suspension travel (Front Left Tire) - 0.0 = max stretch | 1.0 = max compression
        /// </summary>
        public float NormalizedSuspensionTravelFrontLeft { get; set; }

        /// <summary>
        /// Normalized suspension travel (Front Right Tire) - 0.0 = max stretch | 1.0 = max compression
        /// </summary>
        public float NormalizedSuspensionTravelFrontRight { get; set; }

        /// <summary>
        /// Normalized suspension travel (Rear Left Tire) - 0.0 = max stretch | 1.0 = max compression
        /// </summary>
        public float NormalizedSuspensionTravelRearLeft { get; set; }

        /// <summary>
        /// Normalized suspension travel (Rear Right Tire) - 0.0 = max stretch | 1.0 = max compression
        /// </summary>
        public float NormalizedSuspensionTravelRearRight { get; set; }



        /// <summary>
        /// Normalized tire slip ratio (Front Left Tire) - 0.0 = 100% grip and |ratio| > 1.0 means loss of grip
        /// </summary>
        public float TireSlipRatioFrontLeft { get; set; }

        /// <summary>
        /// Normalized tire slip ratio (Front Right Tire) - 0.0 = 100% grip and |ratio| > 1.0 means loss of grip
        /// </summary>
        public float TireSlipRatioFrontRight { get; set; }

        /// <summary>
        /// Normalized tire slip ratio (Rear Left Tire) - 0.0 = 100% grip and |ratio| > 1.0 means loss of grip
        /// </summary>
        public float TireSlipRatioRearLeft { get; set; }

        /// <summary>
        /// Normalized tire slip ratio (Rear Right Tire) - 0.0 = 100% grip and |ratio| > 1.0 means loss of grip
        /// </summary>
        public float TireSlipRatioRearRight { get; set; }



        /// <summary>
        /// Wheel rotation speed in radians/sec - Front Left Tire
        /// </summary>
        public float WheelRotationSpeedFrontLeft { get; set; }

        /// <summary>
        /// Wheel rotation speed in radians/sec - Front Right Tire
        /// </summary>
        public float WheelRotationSpeedFrontRight { get; set; }

        /// <summary>
        /// Wheel rotation speed in radians/sec - Rear Left Tire
        /// </summary>
        public float WheelRotationSpeedRearLeft { get; set; }

        /// <summary>
        /// Wheel rotation speed in radians/sec - Rear Right Tire
        /// </summary>
        public float WheelRotationSpeedRearRight { get; set; }



        /// <summary>
        /// Returns 1 when the front left wheel is on a rumble strip, 0 when not
        /// </summary>
        public int WheelOnRumbleStripFrontLeft { get; set; }

        /// <summary>
        /// Returns 1 when the front right wheel is on a rumble strip, 0 when not
        /// </summary>
        public int WheelOnRumbleStripFrontRight { get; set; }

        /// <summary>
        /// Returns 1 when the rear left wheel is on a rumble strip, 0 when not
        /// </summary>
        public int WheelOnRumbleStripRearLeft { get; set; }

        /// <summary>
        /// Returns 1 when the rear right wheel is on a rumble strip, 0 when not
        /// </summary>
        public int WheelOnRumbleStripRearRight { get; set; }



        // From 0 to 1, where 1 is the deepest puddle
        public float WheelInPuddleDepthFrontLeft { get; set; }
        public float WheelInPuddleDepthFrontRight { get; set; }
        public float WheelInPuddleDepthRearLeft { get; set; }
        public float WheelInPuddleDepthRearRight { get; set; }

        // Non-dimensional surface rumble values passed to controller force feedback
        public float SurfaceRumbleFrontLeft { get; set; }
        public float SurfaceRumbleFrontRight { get; set; }
        public float SurfaceRumbleRearLeft { get; set; }
        public float SurfaceRumbleRearRight { get; set; }

        // Tire normalized slip angle, = 0 means 100% grip and |angle| > 1.0 means loss of grip.
        public float TireSlipAngleFrontLeft { get; set; }
        public float TireSlipAngleFrontRight { get; set; }
        public float TireSlipAngleRearLeft { get; set; }
        public float TireSlipAngleRearRight { get; set; }

        // Tire normalized combined slip, = 0 means 100% grip and |slip| > 1.0 means loss of grip.
        public float TireCombinedSlipFrontLeft { get; set; }
        public float TireCombinedSlipFrontRight { get; set; }
        public float TireCombinedSlipRearLeft { get; set; }
        public float TireCombinedSlipRearRight { get; set; }

        // Actual suspension travel in meters
        public float SuspensionTravelFrontLeft { get; set; }
        public float SuspensionTravelFrontRight { get; set; }
        public float SuspensionTravelRearLeft { get; set; }
        public float SuspensionTravelRearRight { get; set; }

        /// <summary>
        /// The Car ID
        /// </summary>
        public int CarOrdinal { get; set; }

        /// <summary>
        /// The car class - see <see cref="Vehicle.CarClass"/>
        /// </summary>
        public Vehicle.CarClass CarClass { get; set; }

        /// <summary>
        /// The performance index value
        /// </summary>
        public int CarPI { get; set; }

        /// <summary>
        /// The current drivetrain type - see <see cref="Vehicle.DrivetrainType"/>
        /// </summary>
        public Vehicle.DrivetrainType DrivetrainType { get; set; }

        /// <summary>
        /// The number of cylinders
        /// </summary>
        public int NumCylinders { get; set; }



        /// <summary>
        /// X position in meters
        /// </summary>
        public float PositionX { get; set; }

        /// <summary>
        /// Y position in meters
        /// </summary>
        public float PositionY { get; set; }

        /// <summary>
        /// Z position in meters
        /// </summary>
        public float PositionZ { get; set; }

        /// <summary>
        /// Current speed in meters per second
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// The amount of power in watts
        /// </summary>
        public float Power { get; set; }

        /// <summary>
        /// The amount of torque in newton-meters
        /// </summary>
        public float Torque { get; set; }

        // Tire temperature (celcius)
        public float TireTempFrontLeft { get; set; }
        public float TireTempFrontRight { get; set; }
        public float TireTempRearLeft { get; set; }
        public float TireTempRearRight { get; set; }

        /// <summary>
        /// Boost amount
        /// </summary>
        public float Boost { get; set; }

        /// <summary>
        /// Fuel amount
        /// </summary>
        public float Fuel { get; set; }

        /// <summary>
        /// Distance traveled (meters)
        /// </summary>
        public float DistanceTraveled { get; set; }

        /// <summary>
        /// Best lap time
        /// </summary>
        public float BestLap { get; set; }

        /// <summary>
        /// Last lap time
        /// </summary>
        public float LastLap { get; set; }

        /// <summary>
        /// Current lap time
        /// </summary>
        public float CurrentLap { get; set; }

        /// <summary>
        /// Current race (total) time
        /// </summary>
        public float CurrentRaceTime { get; set; }

        /// <summary>
        /// Current lap number
        /// </summary>
        public UInt16 LapNumber { get; set; }

        /// <summary>
        /// Current race position
        /// </summary>
        public byte RacePosition { get; set; }

        /// <summary>
        /// Acceleration amount
        /// </summary>
        public byte Accel { get; set; }

        /// <summary>
        /// Brake amount
        /// </summary>
        public byte Brake { get; set; }

        /// <summary>
        /// Clutch amount
        /// </summary>
        public byte Clutch { get; set; }

        /// <summary>
        /// Handbrake amount
        /// </summary>
        public byte Handbrake { get; set; }

        /// <summary>
        /// Current gear
        /// </summary>
        public byte Gear { get; set; }

        /// <summary>
        /// Current steering amount
        /// </summary>
        public sbyte Steer { get; set; }

        public sbyte NormalizedDrivingLine { get; set; }
        public sbyte NormalizedAIBrakeDifference { get; set; }

        public int GetMPH()
        {
            return (int)(VelocityZ * 2.23694f);
        }
    }
}
