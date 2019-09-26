using System;
using System.Net;
using System.Net.Sockets;
using Forza7Telemetry.Monitor.Telemetry;
using Newtonsoft.Json;

namespace Forza7Telemetry.Monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var listener = new TelemetryListener(11001, (data) => 
                {
                var message = new Message(data);
                Console.SetCursorPosition(0, 0);
                
                if (message.IsRaceOn == 1)
                {
                    Console.WriteLine("RPM: {0}", message.CurrentEngineRpm);
                    Console.WriteLine("Velocity - X: {0}, Y: {1}, Z: {2}         ", message.VelocityX, message.VelocityY, message.VelocityZ);
                    Console.WriteLine("Acceleration - X: {0}, Y: {1}, Z: {2}      ", message.AccelerationX, message.AccelerationY, message.AccelerationZ);
                    Console.WriteLine("Cyl: {0} ", message.NumCylinders);
                    Console.WriteLine("Meters per Second: {0}", message.Speed);
                    Console.WriteLine("Km/H {0}", message.Speed * (3.6));
                    Console.WriteLine("kW: {0}", message.Power);
                    Console.WriteLine("PS: {0}", message.Power / (735.499));
                    Console.WriteLine("Torque (NM): {0}", message.Torque);

                    Console.WriteLine("DistanceTraveled: {0}", message.DistanceTraveled);
                    Console.WriteLine("BestLap: {0}", message.BestLap);
                    Console.WriteLine("LastLap: {0}", message.LastLap);
                    Console.WriteLine("CurrentLap: {0}", message.CurrentLap);
                    Console.WriteLine("CurrentRaceTime: {0}", message.CurrentRaceTime);

                    Console.WriteLine("LapNumber: {0}", message.LapNumber+1);
                    Console.WriteLine("RacePosition: {0}", message.RacePosition);

                    Console.WriteLine("Accel: {0}", message.Accel);
                    Console.WriteLine("Brake: {0}", message.Brake);
                    Console.WriteLine("Clutch: {0}", message.Clutch);
                    Console.WriteLine("HandBrake: {0}", message.HandBrake);
                    Console.WriteLine("Gear: {0}", message.Gear);
                    Console.WriteLine("Steer: {0}", message.Steer);
                }
                else
                {
                    Console.WriteLine("Waiting for race to start");
                }
            });

            listener.StartListener();
        }
    }
}
