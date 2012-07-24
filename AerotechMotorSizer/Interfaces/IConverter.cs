using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IConverter
    {
        /// <summary>
        /// Whether this converter has position outputs
        /// </summary>
        bool HasPosition { get; }
        /// <summary>
        /// Whether this converter has velocity outputs
        /// </summary>
        bool HasVelocity { get; }
        /// <summary>
        /// Whether this converter has acceleration outputs
        /// </summary>
        bool HasAcceleration { get; }

        double[] Position { get; }
        double[] Velocity { get; }
        double[] Acceleration { get; }
        double[] Time  {get; }
    }
}
