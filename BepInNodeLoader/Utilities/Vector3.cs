
using System.Globalization;
using System.Text;
using UnityEngine;

namespace System.Numerics;

public partial struct Vector3 : IEquatable<Vector3>, IFormattable
{
    #region Public Static Properties
    /// <summary>
    /// Returns the vector (0,0,0).
    /// </summary>
    public static Vector3 Zero { get { return new Vector3(); } }
    /// <summary>
    /// Returns the vector (1,1,1).
    /// </summary>
    public static Vector3 One { get { return new Vector3(1.0f, 1.0f, 1.0f); } }
    /// <summary>
    /// Returns the vector (1,0,0).
    /// </summary>
    public static Vector3 UnitX { get { return new Vector3(1.0f, 0.0f, 0.0f); } }
    /// <summary>
    /// Returns the vector (0,1,0).
    /// </summary>
    public static Vector3 UnitY { get { return new Vector3(0.0f, 1.0f, 0.0f); } }
    /// <summary>
    /// Returns the vector (0,0,1).
    /// </summary>
    public static Vector3 UnitZ { get { return new Vector3(0.0f, 0.0f, 1.0f); } }
    #endregion Public Static Properties

    #region Public Instance Methods
    /// <summary>
    /// Returns a boolean indicating whether the given Object is equal to this Vector3 instance.
    /// </summary>
    /// <param name="obj">The Object to compare against.</param>
    /// <returns>True if the Object is equal to this Vector3; False otherwise.</returns>
    public override bool Equals(object obj)
    {
        if (!(obj is Vector3))
            return false;
        return Equals((Vector3)obj);
    }

    /// <summary>
    /// Returns a String representing this Vector3 instance.
    /// </summary>
    /// <returns>The string representation.</returns>
    public override string ToString()
    {
        return ToString("G", CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// Returns a String representing this Vector3 instance, using the specified format to format individual elements.
    /// </summary>
    /// <param name="format">The format of individual elements.</param>
    /// <returns>The string representation.</returns>
    public string ToString(string format)
    {
        return ToString(format, CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// Returns a String representing this Vector3 instance, using the specified format to format individual elements 
    /// and the given IFormatProvider.
    /// </summary>
    /// <param name="format">The format of individual elements.</param>
    /// <param name="formatProvider">The format provider to use when formatting elements.</param>
    /// <returns>The string representation.</returns>
    public string ToString(string format, IFormatProvider formatProvider)
    {
        StringBuilder sb = new StringBuilder();
        string separator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;
        sb.Append('<');
        sb.Append(((IFormattable)this.X).ToString(format, formatProvider));
        sb.Append(separator);
        sb.Append(' ');
        sb.Append(((IFormattable)this.Y).ToString(format, formatProvider));
        sb.Append(separator);
        sb.Append(' ');
        sb.Append(((IFormattable)this.Z).ToString(format, formatProvider));
        sb.Append('>');
        return sb.ToString();
    }
    #endregion Public Instance Methods

    #region Public Static Methods
    /// <summary>
    /// Computes the cross product of two vectors.
    /// </summary>
    /// <param name="vector1">The first vector.</param>
    /// <param name="vector2">The second vector.</param>
    /// <returns>The cross product.</returns>
    public static Vector3 Cross(Vector3 vector1, Vector3 vector2)
    {
        return new Vector3(
            vector1.Y * vector2.Z - vector1.Z * vector2.Y,
            vector1.Z * vector2.X - vector1.X * vector2.Z,
            vector1.X * vector2.Y - vector1.Y * vector2.X);
    }

    /// <summary>
    /// Restricts a vector between a min and max value.
    /// </summary>
    /// <param name="value1">The source vector.</param>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>The restricted vector.</returns>
    public static Vector3 Clamp(Vector3 value1, Vector3 min, Vector3 max)
    {
        // This compare order is very important!!!
        // We must follow HLSL behavior in the case user specified min value is bigger than max value.

        float x = value1.X;
        x = (x > max.X) ? max.X : x;
        x = (x < min.X) ? min.X : x;

        float y = value1.Y;
        y = (y > max.Y) ? max.Y : y;
        y = (y < min.Y) ? min.Y : y;

        float z = value1.Z;
        z = (z > max.Z) ? max.Z : z;
        z = (z < min.Z) ? min.Z : z;

        return new Vector3(x, y, z);
    }

    /// <summary>
    /// Transforms a vector by the given Quaternion rotation value.
    /// </summary>
    /// <param name="value">The source vector to be rotated.</param>
    /// <param name="rotation">The rotation to apply.</param>
    /// <returns>The transformed vector.</returns>
    public static Vector3 Transform(Vector3 value, Quaternion rotation)
    {
        float x2 = rotation.x + rotation.x;
        float y2 = rotation.y + rotation.y;
        float z2 = rotation.z + rotation.z;

        float wx2 = rotation.w * x2;
        float wy2 = rotation.w * y2;
        float wz2 = rotation.w * z2;
        float xx2 = rotation.x * x2;
        float xy2 = rotation.x * y2;
        float xz2 = rotation.x * z2;
        float yy2 = rotation.y * y2;
        float yz2 = rotation.y * z2;
        float zz2 = rotation.z * z2;

        return new Vector3(
            value.X * (1.0f - yy2 - zz2) + value.Y * (xy2 - wz2) + value.Z * (xz2 + wy2),
            value.X * (xy2 + wz2) + value.Y * (1.0f - xx2 - zz2) + value.Z * (yz2 - wx2),
            value.X * (xz2 - wy2) + value.Y * (yz2 + wx2) + value.Z * (1.0f - xx2 - yy2));
    }
    #endregion Public Static Methods

    #region Public operator methods

    // All these methods should be inlined as they are implemented
    // over JIT intrinsics

    /// <summary>
    /// Adds two vectors together.
    /// </summary>
    /// <param name="left">The first source vector.</param>
    /// <param name="right">The second source vector.</param>
    /// <returns>The summed vector.</returns>
    public static Vector3 Add(Vector3 left, Vector3 right)
    {
        return left + right;
    }

    /// <summary>
    /// Subtracts the second vector from the first.
    /// </summary>
    /// <param name="left">The first source vector.</param>
    /// <param name="right">The second source vector.</param>
    /// <returns>The difference vector.</returns>
    public static Vector3 Subtract(Vector3 left, Vector3 right)
    {
        return left - right;
    }

    /// <summary>
    /// Multiplies two vectors together.
    /// </summary>
    /// <param name="left">The first source vector.</param>
    /// <param name="right">The second source vector.</param>
    /// <returns>The product vector.</returns>
    public static Vector3 Multiply(Vector3 left, Vector3 right)
    {
        return left * right;
    }

    /// <summary>
    /// Multiplies a vector by the given scalar.
    /// </summary>
    /// <param name="left">The source vector.</param>
    /// <param name="right">The scalar value.</param>
    /// <returns>The scaled vector.</returns>
    public static Vector3 Multiply(Vector3 left, Single right)
    {
        return left * right;
    }

    /// <summary>
    /// Multiplies a vector by the given scalar.
    /// </summary>
    /// <param name="left">The scalar value.</param>
    /// <param name="right">The source vector.</param>
    /// <returns>The scaled vector.</returns>
    public static Vector3 Multiply(Single left, Vector3 right)
    {
        return left * right;
    }

    /// <summary>
    /// Divides the first vector by the second.
    /// </summary>
    /// <param name="left">The first source vector.</param>
    /// <param name="right">The second source vector.</param>
    /// <returns>The vector resulting from the division.</returns>
    public static Vector3 Divide(Vector3 left, Vector3 right)
    {
        return left / right;
    }

    /// <summary>
    /// Divides the vector by the given scalar.
    /// </summary>
    /// <param name="left">The source vector.</param>
    /// <param name="divisor">The scalar value.</param>
    /// <returns>The result of the division.</returns>
    public static Vector3 Divide(Vector3 left, Single divisor)
    {
        return left / divisor;
    }

    /// <summary>
    /// Negates a given vector.
    /// </summary>
    /// <param name="value">The source vector.</param>
    /// <returns>The negated vector.</returns>
    public static Vector3 Negate(Vector3 value)
    {
        return -value;
    }
    #endregion Public operator methods
}