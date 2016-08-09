using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using JetBrains.Annotations;

namespace bitwz.Types
{
    /// <summary>Represents a 32-bit signed integer.<para/>A "special" wrapper of <see cref="T:System.Int32"/> struct.</summary>
    [ComVisible(true), Serializable, StructLayout(LayoutKind.Sequential)]
    public struct int32 : IComparable, IComparable<int32>, IConvertible, IEquatable<int32>, IFormattable, ISerializable
    {
        /// <summary>Represents the largest possible value of an <see cref="T:System.Int32"/>. This field is constant.</summary>
        public const int MaxValue = int.MaxValue;
        /// <summary>Represents the smallest possible value of <see cref="T:System.Int32"/>. This field is constant.</summary>
        public const int MinValue = int.MinValue;
        private readonly int m_value;

        private int32(int value = default(int))
        {
            m_value = value;
        }

        private int32([CanBeNull] SerializationInfo info, StreamingContext context)
        {
            m_value = info?.GetInt32(nameof(m_value)) ?? default(int);
        }

        /// <summary></summary>
        /// <param name="index"></param>
        public bool this[int index] => BitwzMath.toBits(m_value)[index];

        /// <summary>Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with the data needed to serialize the target object.</summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"/>) for this serialization.</param>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(nameof(m_value), m_value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator int(int32 value) => value.m_value;

        /// <summary></summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator int32(int value) => new int32(value);

        /// <summary></summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int32 operator +(int32 value) => new int32(+value.m_value);

        /// <summary></summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int32 operator -(int32 value) => new int32(-value.m_value);

        /// <summary></summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int32 operator ~(int32 value) => new int32(~value.m_value);

        /// <summary></summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int32 operator ++(int32 value) => new int32(value.m_value + 1);

        /// <summary></summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int32 operator --(int32 value) => new int32(value.m_value - 1);

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator +(int32 left, int32 right) => new int32(left.m_value + right.m_value);

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator +(int32 left, int right) => new int32(left.m_value + right);

        // <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator +(int left, int32 right) => new int32(left + right.m_value);

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator -(int32 left, int32 right) => new int32(left.m_value - right.m_value);

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator -(int32 left, int right) => new int32(left.m_value - right);

        // <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator -(int left, int32 right) => new int32(left - right.m_value);

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator *(int32 left, int32 right) => new int32(left.m_value * right.m_value);

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator *(int32 left, int right) => new int32(left.m_value * right);

        // <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator *(int left, int32 right) => new int32(left * right.m_value);

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator /(int32 left, int32 right) => new int32(left.m_value / right.m_value);

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator /(int32 left, int right) => new int32(left.m_value / right);

        // <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator /(int left, int32 right) => new int32(left / right.m_value);

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator %(int32 left, int32 right) => new int32(left.m_value - right.m_value * (int)BitwzMath.floor((double)left.m_value / right.m_value));

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator %(int32 left, int right) => new int32(left.m_value - right * (int)BitwzMath.floor((double)left.m_value / right));

        // <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator %(int left, int32 right) => new int32(left - right.m_value * (int)BitwzMath.floor((double)left / right.m_value));

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator &(int32 left, int32 right) => new int32(BitwzMath.bAnd(left.m_value, right.m_value));

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator &(int32 left, int right) => new int32(BitwzMath.bAnd(left.m_value, right));

        // <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator &(int left, int32 right) => new int32(BitwzMath.bAnd(left, right.m_value));

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator |(int32 left, int32 right) => new int32(BitwzMath.bOr(left.m_value, right.m_value));

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator |(int32 left, int right) => new int32(BitwzMath.bOr(left.m_value, right));

        // <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator |(int left, int32 right) => new int32(BitwzMath.bOr(left, right.m_value));

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator ^(int32 left, int32 right) => new int32(BitwzMath.bXor(left.m_value, right.m_value));

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator ^(int32 left, int right) => new int32(BitwzMath.bXor(left.m_value, right));

        // <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator ^(int left, int32 right) => new int32(BitwzMath.bXor(left, right.m_value));

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator <<(int32 left, int right) => new int32(BitwzMath.bShl(left.m_value, right));

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int32 operator >>(int32 left, int right) => new int32(BitwzMath.bShr(left.m_value, right));

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(int32 left, int32 right) => left.m_value < right.m_value;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(int32 left, int right) => left.m_value < right;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(int left, int32 right) => left < right.m_value;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(int32 left, int32 right) => left.m_value > right.m_value;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(int32 left, int right) => left.m_value > right;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(int left, int32 right) => left > right.m_value;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(int32 left, int32 right) => left.m_value <= right.m_value;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(int32 left, int right) => left.m_value <= right;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(int left, int32 right) => left <= right.m_value;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(int32 left, int32 right) => left.m_value >= right.m_value;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(int32 left, int right) => left.m_value >= right;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(int left, int32 right) => left >= right.m_value;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(int32 left, int32 right) => left.m_value == right.m_value;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(int32 left, int right) => left.m_value == right;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(int left, int32 right) => left == right.m_value;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(int32 left, int32 right) => left.m_value != right.m_value;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(int32 left, int right) => left.m_value != right;

        /// <summary></summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(int left, int32 right) => left != right.m_value;

        /// <summary>Compares this instance to a specified 32-bit signed integer and returns an indication of their relative values.</summary>
        /// <param name="value">An integer to compare.</param>
        /// <returns>A signed number indicating the relative values of this instance and <paramref name="value"/>. The return value has these meanings: Less than zero This instance is less than <paramref name="value"/>. Zero This instance is equal to <paramref name="value"/>. Greater than zero This instance is greater than <paramref name="value"/>.</returns>
        public int CompareTo(int32 value) => m_value.CompareTo(value.m_value);

        /// <summary>Compares this instance to a specified object and returns an indication of their relative values.</summary>
        /// <param name="value">An object to compare, or null.</param>
        /// <returns>A signed number indicating the relative values of this instance and <paramref name="value"/>. The return value has these meanings: Less than zero This instance is less than <paramref name="value"/>. Zero This instance is equal to <paramref name="value"/>. Greater than zero This instance is greater than <paramref name="value"/>.-or- <paramref name="value"/> is null.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="value"/> is not an <see cref="T:System.Int32"/>.</exception>
        public int CompareTo(object value) => m_value.CompareTo(value);

        /// <summary>Returns a value indicating whether this instance is equal to a specified <see cref="T:System.Int32"/> value.</summary>
        /// <param name="obj">An <see cref="T:System.Int32"/> value to compare to this instance.</param>
        /// <returns>true if <paramref name="obj"/> has the same value as this instance; otherwise, false.</returns>
        public bool Equals(int32 obj) => m_value.Equals(obj.m_value);

        /// <summary>Returns a value indicating whether this instance is equal to a specified object.</summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>true if <paramref name="obj"/> is an instance of <see cref="T:System.Int32"/> and equals the value of this instance; otherwise, false.</returns>
        public override bool Equals(object obj) => m_value.Equals(obj);

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        public override int GetHashCode() => m_value.GetHashCode();

        /// <summary>Returns the <see cref="T:System.TypeCode"/> for value type <see cref="T:System.Int32"/>.</summary>
        /// <returns>The enumerated constant, <see cref="F:System.TypeCode.Int32"/>.</returns>
        public TypeCode GetTypeCode() => m_value.GetTypeCode();

        /// <summary>Converts the numeric value of this instance to its equivalent string representation.</summary>
        /// <returns>The string representation of the value of this instance, consisting of a negative sign if the value is negative, and a sequence of digits ranging from 0 to 9 with no leading zeroes.</returns>
        [System.Security.SecuritySafeCritical]
        public override string ToString() => m_value.ToString();

        /// <summary>Converts the numeric value of this instance to its equivalent string representation using the specified culture-specific format information.</summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>The string representation of the value of this instance as specified by <paramref name="provider"/>.</returns>
        [System.Security.SecuritySafeCritical]
        public string ToString(IFormatProvider provider) => m_value.ToString(provider);

        /// <summary>Converts the numeric value of this instance to its equivalent string representation, using the specified format.</summary>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <returns>The string representation of the value of this instance as specified by <paramref name="format"/>.</returns>
        /// <exception cref="T:System.FormatException"><paramref name="format"/> is invalid or not supported.</exception>
        [System.Security.SecuritySafeCritical]
        public string ToString(string format) => m_value.ToString(format);

        /// <summary>Converts the numeric value of this instance to its equivalent string representation using the specified format and culture-specific format information.</summary>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>The string representation of the value of this instance as specified by <paramref name="format"/> and <paramref name="provider"/>.</returns>
        /// <exception cref="T:System.FormatException"><paramref name="format"/> is invalid or not supported.</exception>
        [System.Security.SecuritySafeCritical]
        public string ToString(string format, IFormatProvider provider) => m_value.ToString(format, provider);

        /// <summary>Converts the string representation of a number to its 32-bit signed integer equivalent.</summary>
        /// <param name="s">A string containing a number to convert.</param>
        /// <returns>A 32-bit signed integer equivalent to the number contained in <paramref name="s"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="s"/> is null.</exception>
        /// <exception cref="T:System.FormatException"><paramref name="s"/> is not in the correct format.</exception>
        /// <exception cref="T:System.OverflowException"><paramref name="s"/> represents a number less than <see cref="F:System.Int32.MinValue"/> or greater than <see cref="F:System.Int32.MaxValue"/>.</exception>
        public static int Parse([NotNull] string s) => int.Parse(s);

        /// <summary>Converts the string representation of a number in a specified style to its 32-bit signed integer equivalent.</summary>
        /// <param name="s">A string containing a number to convert.</param>
        /// <param name="style">A bitwise combination of the enumeration values that indicates the style elements that can be present in <paramref name="s"/>. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer"/>.</param>
        /// <returns>A 32-bit signed integer equivalent to the number specified in <paramref name="s"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="s"/> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="style"/> is not a <see cref="T:System.Globalization.NumberStyles"/> value. -or-<paramref name="style"/> is not a combination of <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier"/> and <see cref="F:System.Globalization.NumberStyles.HexNumber"/> values.</exception>
        /// <exception cref="T:System.FormatException"><paramref name="s"/> is not in a format compliant with <paramref name="style"/>.</exception>
        /// <exception cref="T:System.OverflowException"><paramref name="s"/> represents a number less than <see cref="F:System.Int32.MinValue"/> or greater than <see cref="F:System.Int32.MaxValue"/>. -or-<paramref name="s"/> includes non-zero, fractional digits.</exception>
        public static int Parse([NotNull] string s, NumberStyles style) => int.Parse(s, style);

        /// <summary>Converts the string representation of a number in a specified style and culture-specific format to its 32-bit signed integer equivalent.</summary>
        /// <param name="s">A string containing a number to convert.</param>
        /// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="s"/>. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer"/>.</param>
        /// <param name="provider">An object that supplies culture-specific information about the format of <paramref name="s"/>.</param>
        /// <returns>A 32-bit signed integer equivalent to the number specified in <paramref name="s"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="s"/> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="style"/> is not a <see cref="T:System.Globalization.NumberStyles"/> value. -or-<paramref name="style"/> is not a combination of <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier"/> and <see cref="F:System.Globalization.NumberStyles.HexNumber"/> values.</exception>
        /// <exception cref="T:System.FormatException"><paramref name="s"/> is not in a format compliant with <paramref name="style"/>.</exception>
        /// <exception cref="T:System.OverflowException"><paramref name="s"/> represents a number less than <see cref="F:System.Int32.MinValue"/> or greater than <see cref="F:System.Int32.MaxValue"/>. -or-<paramref name="s"/> includes non-zero, fractional digits.</exception>
        public static int Parse([NotNull] string s, NumberStyles style, IFormatProvider provider) => int.Parse(s, style, provider);

        /// <summary>Converts the string representation of a number in a specified culture-specific format to its 32-bit signed integer equivalent.</summary>
        /// <param name="s">A string containing a number to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s"/>.</param>
        /// <returns>A 32-bit signed integer equivalent to the number specified in <paramref name="s"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="s"/> is null.</exception>
        /// <exception cref="T:System.FormatException"><paramref name="s"/> is not of the correct format.</exception>
        /// <exception cref="T:System.OverflowException"><paramref name="s"/> represents a number less than <see cref="F:System.Int32.MinValue"/> or greater than <see cref="F:System.Int32.MaxValue"/>.</exception>
        public static int Parse([NotNull] string s, IFormatProvider provider) => int.Parse(s, provider);

        /// <summary>Converts the string representation of a number to its 32-bit signed integer equivalent. A return value indicates whether the conversion succeeded.</summary>
        /// <param name="s">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the number contained in <paramref name="s"/>, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s"/> parameter is null  or <see cref="F:System.String.Empty"/>, is not of the correct format, or represents a number less than <see cref="F:System.Int32.MinValue"/> or greater than <see cref="F:System.Int32.MaxValue"/>. This parameter is passed uninitialized; any value originally supplied in <paramref name="result"/> will be overwritten.</param>
        /// <returns>true if <paramref name="s"/> was converted successfully; otherwise, false.</returns>
        public static bool TryParse(string s, out int result) => int.TryParse(s, out result);

        /// <summary>Converts the string representation of a number in a specified style and culture-specific format to its 32-bit signed integer equivalent. A return value indicates whether the conversion succeeded.</summary>
        /// <param name="s">A string containing a number to convert. The string is interpreted using the style specified by <paramref name="style"/>.</param>
        /// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="s"/>. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer"/>.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s"/>.</param>
        /// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the number contained in <paramref name="s"/>, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s"/> parameter is null  or <see cref="F:System.String.Empty"/>, is not in a format compliant with <paramref name="style"/>, or represents a number less than <see cref="F:System.Int32.MinValue"/> or greater than <see cref="F:System.Int32.MaxValue"/>. This parameter is passed uninitialized; any value originally supplied in <paramref name="result"/> will be overwritten.</param>
        /// <returns>true if <paramref name="s"/> was converted successfully; otherwise, false.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="style"/> is not a <see cref="T:System.Globalization.NumberStyles"/> value. -or-<paramref name="style"/> is not a combination of <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier"/> and <see cref="F:System.Globalization.NumberStyles.HexNumber"/> values.</exception>
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out int result) => int.TryParse(s, style, provider, out result);

        /// <summary>Converts the value of this instance to an equivalent Boolean value using the specified culture-specific formatting information.</summary>
        /// <returns>A Boolean value equivalent to the value of this instance.</returns>
        /// <param name="provider">An <see cref="T:System.IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <filterpriority>2</filterpriority>
        bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvertible)m_value).ToBoolean(provider);

        /// <summary>Converts the value of this instance to an equivalent 8-bit unsigned integer using the specified culture-specific formatting information.</summary>
        /// <returns>An 8-bit unsigned integer equivalent to the value of this instance.</returns>
        /// <param name="provider">An <see cref="T:System.IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <filterpriority>2</filterpriority>
        byte IConvertible.ToByte(IFormatProvider provider) => ((IConvertible)m_value).ToByte(provider);

        /// <summary>Converts the value of this instance to an equivalent Unicode character using the specified culture-specific formatting information.</summary>
        /// <returns>A Unicode character equivalent to the value of this instance.</returns>
        /// <param name="provider">An <see cref="T:System.IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <filterpriority>2</filterpriority>
        char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)m_value).ToChar(provider);

        /// <summary>Converts the value of this instance to an equivalent <see cref="T:System.DateTime"/> using the specified culture-specific formatting information.</summary>
        /// <returns>A <see cref="T:System.DateTime"/> instance equivalent to the value of this instance.</returns>
        /// <param name="provider">An <see cref="T:System.IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <filterpriority>2</filterpriority>
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)m_value).ToDateTime(provider);

        /// <summary>Converts the value of this instance to an equivalent <see cref="T:System.Decimal"/> number using the specified culture-specific formatting information.</summary>
        /// <returns>A <see cref="T:System.Decimal"/> number equivalent to the value of this instance.</returns>
        /// <param name="provider">An <see cref="T:System.IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <filterpriority>2</filterpriority>
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvertible)m_value).ToDecimal(provider);

        /// <summary>Converts the value of this instance to an equivalent double-precision floating-point number using the specified culture-specific formatting information.</summary>
        /// <returns>A double-precision floating-point number equivalent to the value of this instance.</returns>
        /// <param name="provider">An <see cref="T:System.IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <filterpriority>2</filterpriority>
        double IConvertible.ToDouble(IFormatProvider provider) => ((IConvertible)m_value).ToDouble(provider);

        /// <summary>Converts the value of this instance to an equivalent single-precision floating-point number using the specified culture-specific formatting information.</summary>
        /// <returns>A single-precision floating-point number equivalent to the value of this instance.</returns>
        /// <param name="provider">An <see cref="T:System.IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <filterpriority>2</filterpriority>
        float IConvertible.ToSingle(IFormatProvider provider) => ((IConvertible)m_value).ToSingle(provider);

        /// <summary>Converts the value of this instance to an equivalent 32-bit signed integer using the specified culture-specific formatting information.</summary>
        /// <returns>An 32-bit signed integer equivalent to the value of this instance.</returns>
        /// <param name="provider">An <see cref="T:System.IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <filterpriority>2</filterpriority>
        int IConvertible.ToInt32(IFormatProvider provider) => ((IConvertible)m_value).ToInt32(provider);

        /// <summary>Converts the value of this instance to an equivalent 64-bit signed integer using the specified culture-specific formatting information.</summary>
        /// <returns>An 64-bit signed integer equivalent to the value of this instance.</returns>
        /// <param name="provider">An <see cref="T:System.IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <filterpriority>2</filterpriority>
        long IConvertible.ToInt64(IFormatProvider provider) => ((IConvertible)m_value).ToInt64(provider);

        /// <summary>Converts the value of this instance to an <see cref="T:System.Object"/> of the specified <see cref="T:System.Type"/> that has an equivalent value, using the specified culture-specific formatting information.</summary>
        /// <returns>An <see cref="T:System.Object"/> instance of type <paramref name="conversionType"/> whose value is equivalent to the value of this instance.</returns>
        /// <param name="conversionType">The <see cref="T:System.Type"/> to which the value of this instance is converted.</param>
        /// <param name="provider">An <see cref="T:System.IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <filterpriority>2</filterpriority>
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)m_value).ToType(conversionType, provider);

        /// <summary>Converts the value of this instance to an equivalent 8-bit signed integer using the specified culture-specific formatting information.</summary>
        /// <returns>An 8-bit signed integer equivalent to the value of this instance.</returns>
        /// <param name="provider">An <see cref="T:System.IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <filterpriority>2</filterpriority>
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertible)m_value).ToSByte(provider);

        /// <summary>Converts the value of this instance to an equivalent 16-bit signed integer using the specified culture-specific formatting information.</summary>
        /// <returns>An 16-bit signed integer equivalent to the value of this instance.</returns>
        /// <param name="provider">An <see cref="T:System.IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <filterpriority>2</filterpriority>
        short IConvertible.ToInt16(IFormatProvider provider) => ((IConvertible)m_value).ToInt16(provider);

        /// <summary>Converts the value of this instance to an equivalent 32-bit unsigned integer using the specified culture-specific formatting information.</summary>
        /// <returns>An 32-bit unsigned integer equivalent to the value of this instance.</returns>
        /// <param name="provider">An <see cref="T:System.IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <filterpriority>2</filterpriority>
        uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertible)m_value).ToUInt32(provider);

        /// <summary>Converts the value of this instance to an equivalent 64-bit unsigned integer using the specified culture-specific formatting information.</summary>
        /// <returns>An 64-bit unsigned integer equivalent to the value of this instance.</returns>
        /// <param name="provider">An <see cref="T:System.IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <filterpriority>2</filterpriority>
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertible)m_value).ToUInt64(provider);

        /// <summary>Converts the value of this instance to an equivalent 16-bit unsigned integer using the specified culture-specific formatting information.</summary>
        /// <returns>An 16-bit unsigned integer equivalent to the value of this instance.</returns>
        /// <param name="provider">An <see cref="T:System.IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
        /// <filterpriority>2</filterpriority>
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertible)m_value).ToUInt16(provider);
    }
}