using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program.Interfaces
{
    interface IParameterSet
    {
        public double[] Position;
        public double[] Time;

        /// <summary>
        /// The Acceleration Time
        /// </summary>
        public double AccelerationTime { get; }

        /// <summary>
        /// The Traverse Time
        /// </summary>
        public double TraverseTime { get; }

        /// <summary>
        /// The Decceleration Time
        /// </summary>
        public double DeccelerationTime { get; }

        /// <summary>
        /// The Dwel Time
        /// </summary>
        public double DwelTime { get; }

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="distance">The distance the motor will travel</param>
        /// <param name="totalTime">The total time to travel</param>
        /// <param name="percentage">The percentage of time spent moving</param>
        /// <returns></returns>
        public bool SetParameters(double distance, double totalTime, double percentage);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="distance">The distance the motor will travel</param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="percentage">The percentage of time spent moving</param>
        /// <returns></returns>
        public bool SetParameters(double distance, double maxVelocity, double percentage);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="distance">The distance the motor will travel</param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="totalTime">The total time to travel</param>
        /// <returns></returns>
        public bool SetParameters(double distance, double maxVelocity, double totalTime);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="distance">The distance the motor will travel</param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="peakAcceleration"></param>
        /// <returns></returns>
        public bool SetParameters(double distance, double maxVelocity, double peakAcceleration);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="accelerationDistance"></param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="totalTravel"></param>
        /// <returns></returns>
        public bool SetParameters(double accelerationDistance, double maxVelocity, double totalTravel);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="accelerationDistance"></param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="totalTime">The total time to travel</param>
        /// <returns></returns>
        public bool SetParameters(double accelerationDistance, double maxVelocity, double totalTime);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="peakAcceleration"></param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="maxTravel"></param>
        /// <returns></returns>
        public bool SetParameters(double peakAcceleration, double maxVelocity, double maxTravel);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="peakAcceleration"></param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="totalTime">The total time to travel</param>
        /// <returns></returns>
        public bool SetParameters(double peakAcceleration, double maxVelocity, double totalTime);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="peakAcceleration"></param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="maxTravel"></param>
        /// <returns></returns>
        public bool SetParameters(double peakAcceleration, double maxVelocity, double maxTravel);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="peakAcceleration"></param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="scanDistance"></param>
        /// <returns></returns>
        public bool SetParameters(double peakAcceleration, double maxVelocity, double scanDistance);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="totalTravel"></param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="scanDistance"></param>
        /// <returns></returns>
        public bool SetParameters(double totalTravel, double maxVelocity, double scanDistance);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="totalTime">The total time to travel</param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="scanDistance"></param>
        /// <returns></returns>
        public bool SetParameters(double totalTime, double maxVelocity, double scanDistance);
    }
}
