using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    interface IParameterSet
    {
        double[] Position { get; }
        double[] Time { get; }

        /// <summary>
        /// The Acceleration Time
        /// </summary>
        double AccelerationTime { get; }

        /// <summary>
        /// The Traverse Time
        /// </summary>
        double TraverseTime { get; }

        /// <summary>
        /// The Decceleration Time
        /// </summary>
        double DeccelerationTime { get; }

        /// <summary>
        /// The Dwel Time
        /// </summary>
        double DwelTime { get; }

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="distance">The distance the motor will travel</param>
        /// <param name="totalTime">The total time to travel</param>
        /// <param name="percentage">The percentage of time spent moving</param>
        /// <returns></returns>
        bool SetParametersDTP(double distance, double totalTime, double percentage);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="distance">The distance the motor will travel</param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="percentage">The percentage of time spent moving</param>
        /// <returns></returns>
        bool SetParametersDVP(double distance, double maxVelocity, double percentage);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="distance">The distance the motor will travel</param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="totalTime">The total time to travel</param>
        /// <returns></returns>
        bool SetParametersDMT(double distance, double maxVelocity, double totalTime);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="distance">The distance the motor will travel</param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="peakAcceleration"></param>
        /// <returns></returns>
        bool SetParametersDVA(double distance, double maxVelocity, double peakAcceleration);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="accelerationDistance"></param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="totalTravel"></param>
        /// <returns></returns>
        bool SetParametersAVT(double accelerationDistance, double maxVelocity, double totalTravel);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="accelerationDistance"></param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="totalTime">The total time to travel</param>
        /// <returns></returns>
        bool SetParametersAVT2(double accelerationDistance, double maxVelocity, double totalTime);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="peakAcceleration"></param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="maxTravel"></param>
        /// <returns></returns>
        bool SetParametersAVT3(double peakAcceleration, double maxVelocity, double maxTravel);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="peakAcceleration"></param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="totalTime">The total time to travel</param>
        /// <returns></returns>
        bool SetParametersAVT4(double peakAcceleration, double maxVelocity, double totalTime);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="peakAcceleration"></param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="maxTravel"></param>
        /// <returns></returns>
        bool SetParametersAVT5(double peakAcceleration, double maxVelocity, double maxTravel);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="peakAcceleration"></param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="scanDistance"></param>
        /// <returns></returns>
        bool SetParametersAVD(double peakAcceleration, double maxVelocity, double scanDistance);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="totalTravel"></param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="scanDistance"></param>
        /// <returns></returns>
        bool SetParametersTVD(double totalTravel, double maxVelocity, double scanDistance);

        /// <summary>
        /// Set the parameters for the solver
        /// </summary>
        /// <param name="totalTime">The total time to travel</param>
        /// <param name="maxVelocity">The max velocity obtained during motion</param>
        /// <param name="scanDistance"></param>
        /// <returns></returns>
        bool SetParametersTVD2(double totalTime, double maxVelocity, double scanDistance);
    }
}
