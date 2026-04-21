using System;

namespace ConsoleApp1
{
    /// <summary>
    /// Service for circle-related calculations.
    /// </summary>
    public static class CircleService
    {
        /// <summary>
        /// Calculates the area of a circle for the given radius using A = π * r^2.
        /// </summary>
        /// <param name="radius">The radius of the circle. Must be a finite, non-negative number.</param>
        /// <returns>The area of the circle.</returns>
        /// <exception cref="ArgumentException">Thrown when radius is NaN or Infinity.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when radius is negative.</exception>
        public static double CalculateArea(double radius)
        {
            if (double.IsNaN(radius) || double.IsInfinity(radius))
            {
                throw new ArgumentException("Radius must be a finite number.", nameof(radius));
            }

            if (radius < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be non-negative.");
            }

            return Math.PI * radius * radius;
        }

        /// <summary>
        /// Calculates the circumference of a circle for the given radius using C = 2 * π * r.
        /// </summary>
        /// <param name="radius">The radius of the circle. Must be a finite, non-negative number.</param>
        /// <returns>The circumference of the circle.</returns>
        /// <exception cref="ArgumentException">Thrown when radius is NaN or Infinity.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when radius is negative.</exception>
        public static double CalculateCircumference(double radius)
        {
            if (double.IsNaN(radius) || double.IsInfinity(radius))
            {
                throw new ArgumentException("Radius must be a finite number.", nameof(radius));
            }

            if (radius < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be non-negative.");
            }

            return 2 * Math.PI * radius;
        }
    }
}
