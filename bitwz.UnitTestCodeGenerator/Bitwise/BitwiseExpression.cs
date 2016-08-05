using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace bitwz.CodeGenerator.Bitwise
{
    internal abstract class Expression : IEquatable<Expression>
    {
        public bool Equals([CanBeNull] Expression other) => !ReferenceEquals(null, other) && (ReferenceEquals(this, other) || (Kind == other.Kind));

        public abstract ExpressionKind Kind
        {
            get;
        }

        [NotNull]
        public virtual Expression BaseExpression => this;

        public static bool operator ==([CanBeNull] Expression left, [CanBeNull] Expression right) => Equals(left, right);

        public static bool operator !=([CanBeNull] Expression left, [CanBeNull] Expression right) => !Equals(left, right);

        public override bool Equals([CanBeNull] object obj) => !ReferenceEquals(null, obj) && (ReferenceEquals(this, obj) || Equals(obj as Expression));

        public override int GetHashCode() => Kind.GetHashCode();

        public override string ToString() => Kind.ToString();
    }

    internal sealed class NumberLiteralExpression : Expression, IEquatable<NumberLiteralExpression>, INotifyPropertyChanged
    {
        private sbyte _sbyte;
        private byte _byte;
        private char _char;
        private short _int16;
        private ushort _uint16;
        private int _int32;
        private uint _uint32;
        private long _int64;
        private ulong _uint64;

        public NumberLiteralExpression(sbyte value)
        {
            SetValue(value);
        }

        public NumberLiteralExpression(byte value)
        {
            SetValue(value);
        }

        public NumberLiteralExpression(char value)
        {
            SetValue(value);
        }

        public NumberLiteralExpression(short value)
        {
            SetValue(value);
        }

        public NumberLiteralExpression(ushort value)
        {
            SetValue(value);
        }

        public NumberLiteralExpression(int value)
        {
            SetValue(value);
        }

        public NumberLiteralExpression(uint value)
        {
            SetValue(value);
        }

        public NumberLiteralExpression(long value)
        {
            SetValue(value);
        }

        public NumberLiteralExpression(ulong value)
        {
            SetValue(value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Equals([CanBeNull] NumberLiteralExpression other) => !ReferenceEquals(null, other) && (ReferenceEquals(this, other) || (base.Equals(other) && Double.Equals(other.Double)));

        public override ExpressionKind Kind => ExpressionKind.None;

        public override Expression BaseExpression => this;

        public sbyte SByte
        {
            get
            {
                return _sbyte;
            }
            set
            {
                if (value == _sbyte)
                {
                    return;
                }

                SetValue(value);
                OnPropertyChanged();
            }
        }

        public byte Byte
        {
            get
            {
                return _byte;
            }
            set
            {
                if (value == _byte)
                {
                    return;
                }

                SetValue(value);
                OnPropertyChanged();
            }
        }

        public char Char
        {
            get
            {
                return _char;
            }
            set
            {
                if (value == _char)
                {
                    return;
                }

                SetValue(value);
                OnPropertyChanged();
            }
        }

        public short Int16
        {
            get
            {
                return _int16;
            }
            set
            {
                if (value == _int16)
                {
                    return;
                }

                SetValue(value);
                OnPropertyChanged();
            }
        }

        public ushort UInt16
        {
            get
            {
                return _uint16;
            }
            set
            {
                if (value == _uint16)
                {
                    return;
                }

                SetValue(value);
                OnPropertyChanged();
            }
        }

        public int Int32
        {
            get
            {
                return _int32;
            }
            set
            {
                if (value == _int32)
                {
                    return;
                }

                SetValue(value);
                OnPropertyChanged();
            }
        }

        public uint UInt32
        {
            get
            {
                return _uint32;
            }
            set
            {
                if (value == _uint32)
                {
                    return;
                }

                SetValue(value);
                OnPropertyChanged();
            }
        }

        public long Int64
        {
            get
            {
                return _int64;
            }
            set
            {
                if (value == _int64)
                {
                    return;
                }

                SetValue(value);
                OnPropertyChanged();
            }
        }

        public ulong UInt64
        {
            get
            {
                return _uint64;
            }
            set
            {
                if (value == _uint64)
                {
                    return;
                }

                SetValue(value);
                OnPropertyChanged();
            }
        }

        public double Double
        {
            get;
            private set;
        }

        [NotNull]
        public static NumberLiteralExpression operator +([NotNull] NumberLiteralExpression number)
        {
            number.SetValue(+number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -([NotNull] NumberLiteralExpression number)
        {
            number.SetValue(-number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator ++([NotNull] NumberLiteralExpression number)
        {
            number.SetValue(number.Double + 1.0D);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator --([NotNull] NumberLiteralExpression number)
        {
            number.SetValue(number.Double - 1.0D);
            return number;
        }

        public static int operator ~([NotNull] NumberLiteralExpression number) => ~number.Int32;

        public static int operator <<([NotNull] NumberLiteralExpression leftNumber, int shift) => leftNumber.Int32 << shift;

        public static int operator >>([NotNull] NumberLiteralExpression leftNumber, int shift) => leftNumber.Int32 >> shift;

        public static int operator &([NotNull] NumberLiteralExpression leftNumber, [NotNull] NumberLiteralExpression rightNumber) => leftNumber.Int32 & rightNumber.Int32;

        public static int operator ^([NotNull] NumberLiteralExpression leftNumber, [NotNull] NumberLiteralExpression rightNumber) => leftNumber.Int32 ^ rightNumber.Int32;

        public static int operator |([NotNull] NumberLiteralExpression leftNumber, [NotNull] NumberLiteralExpression rightNumber) => leftNumber.Int32 | rightNumber.Int32;

        [NotNull]
        public static NumberLiteralExpression operator +([NotNull] NumberLiteralExpression number, sbyte value)
        {
            number.SetValue(number.Double + value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +(sbyte value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value + number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +([NotNull] NumberLiteralExpression number, byte value)
        {
            number.SetValue(number.Double + value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +(byte value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value + number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +([NotNull] NumberLiteralExpression number, char value)
        {
            number.SetValue(number.Double + value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +(char value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value + number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +([NotNull] NumberLiteralExpression number, short value)
        {
            number.SetValue(number.Double + value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +(short value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value + number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +([NotNull] NumberLiteralExpression number, ushort value)
        {
            number.SetValue(number.Double + value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +(ushort value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value + number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +([NotNull] NumberLiteralExpression number, int value)
        {
            number.SetValue(number.Double + value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +(int value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value + number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +([NotNull] NumberLiteralExpression number, uint value)
        {
            number.SetValue(number.Double + value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +(uint value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value + number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +([NotNull] NumberLiteralExpression number, long value)
        {
            number.SetValue(number.Double + value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +(long value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value + number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +([NotNull] NumberLiteralExpression number, ulong value)
        {
            number.SetValue(number.Double + value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +(ulong value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value + number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +([NotNull] NumberLiteralExpression number, double value)
        {
            number.SetValue(number.Double + value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator +(double value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value + number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -([NotNull] NumberLiteralExpression number, sbyte value)
        {
            number.SetValue(number.Double - value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -(sbyte value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value - number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -([NotNull] NumberLiteralExpression number, byte value)
        {
            number.SetValue(number.Double - value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -(byte value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value - number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -([NotNull] NumberLiteralExpression number, char value)
        {
            number.SetValue(number.Double - value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -(char value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value - number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -([NotNull] NumberLiteralExpression number, short value)
        {
            number.SetValue(number.Double - value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -(short value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value - number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -([NotNull] NumberLiteralExpression number, ushort value)
        {
            number.SetValue(number.Double - value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -(ushort value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value - number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -([NotNull] NumberLiteralExpression number, int value)
        {
            number.SetValue(number.Double - value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -(int value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value - number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -([NotNull] NumberLiteralExpression number, uint value)
        {
            number.SetValue(number.Double - value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -(uint value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value - number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -([NotNull] NumberLiteralExpression number, long value)
        {
            number.SetValue(number.Double - value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -(long value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value - number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -([NotNull] NumberLiteralExpression number, ulong value)
        {
            number.SetValue(number.Double - value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -(ulong value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value - number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -([NotNull] NumberLiteralExpression number, double value)
        {
            number.SetValue(number.Double - value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator -(double value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value - number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *([NotNull] NumberLiteralExpression number, sbyte value)
        {
            number.SetValue(number.Double * value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *(sbyte value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value * number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *([NotNull] NumberLiteralExpression number, byte value)
        {
            number.SetValue(number.Double * value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *(byte value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value * number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *([NotNull] NumberLiteralExpression number, char value)
        {
            number.SetValue(number.Double * value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *(char value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value * number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *([NotNull] NumberLiteralExpression number, short value)
        {
            number.SetValue(number.Double * value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *(short value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value * number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *([NotNull] NumberLiteralExpression number, ushort value)
        {
            number.SetValue(number.Double * value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *(ushort value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value * number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *([NotNull] NumberLiteralExpression number, int value)
        {
            number.SetValue(number.Double * value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *(int value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value * number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *([NotNull] NumberLiteralExpression number, uint value)
        {
            number.SetValue(number.Double * value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *(uint value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value * number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *([NotNull] NumberLiteralExpression number, long value)
        {
            number.SetValue(number.Double * value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *(long value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value * number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *([NotNull] NumberLiteralExpression number, ulong value)
        {
            number.SetValue(number.Double * value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *(ulong value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value * number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *([NotNull] NumberLiteralExpression number, double value)
        {
            number.SetValue(number.Double * value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator *(double value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value * number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /([NotNull] NumberLiteralExpression number, sbyte value)
        {
            number.SetValue(number.Double / value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /(sbyte value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value / number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /([NotNull] NumberLiteralExpression number, byte value)
        {
            number.SetValue(number.Double / value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /(byte value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value / number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /([NotNull] NumberLiteralExpression number, char value)
        {
            number.SetValue(number.Double / value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /(char value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value / number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /([NotNull] NumberLiteralExpression number, short value)
        {
            number.SetValue(number.Double / value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /(short value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value / number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /([NotNull] NumberLiteralExpression number, ushort value)
        {
            number.SetValue(number.Double / value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /(ushort value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value / number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /([NotNull] NumberLiteralExpression number, int value)
        {
            number.SetValue(number.Double / value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /(int value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value / number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /([NotNull] NumberLiteralExpression number, uint value)
        {
            number.SetValue(number.Double / value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /(uint value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value / number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /([NotNull] NumberLiteralExpression number, long value)
        {
            number.SetValue(number.Double / value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /(long value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value / number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /([NotNull] NumberLiteralExpression number, ulong value)
        {
            number.SetValue(number.Double / value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /(ulong value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value / number.Double);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /([NotNull] NumberLiteralExpression number, double value)
        {
            number.SetValue(number.Double / value);
            return number;
        }

        [NotNull]
        public static NumberLiteralExpression operator /(double value, [NotNull] NumberLiteralExpression number)
        {
            number.SetValue(value / number.Double);
            return number;
        }

        public static bool operator <([NotNull] NumberLiteralExpression number, sbyte value) => number.SByte < value;

        public static bool operator <(sbyte value, [NotNull] NumberLiteralExpression number) => value < number.SByte;

        public static bool operator <([NotNull] NumberLiteralExpression number, byte value) => number.Byte < value;

        public static bool operator <(byte value, [NotNull] NumberLiteralExpression number) => value < number.Byte;

        public static bool operator <([NotNull] NumberLiteralExpression number, char value) => number.Char < value;

        public static bool operator <(char value, [NotNull] NumberLiteralExpression number) => value < number.Char;

        public static bool operator <([NotNull] NumberLiteralExpression number, short value) => number.Int16 < value;

        public static bool operator <(short value, [NotNull] NumberLiteralExpression number) => value < number.Int16;

        public static bool operator <([NotNull] NumberLiteralExpression number, ushort value) => number.UInt16 < value;

        public static bool operator <(ushort value, [NotNull] NumberLiteralExpression number) => value < number.UInt16;

        public static bool operator <([NotNull] NumberLiteralExpression number, int value) => number.Int32 < value;

        public static bool operator <(int value, [NotNull] NumberLiteralExpression number) => value < number.Int32;

        public static bool operator <([NotNull] NumberLiteralExpression number, uint value) => number.UInt32 < value;

        public static bool operator <(uint value, [NotNull] NumberLiteralExpression number) => value < number.UInt32;

        public static bool operator <([NotNull] NumberLiteralExpression number, long value) => number.Int64 < value;

        public static bool operator <(long value, [NotNull] NumberLiteralExpression number) => value < number.Int64;

        public static bool operator <([NotNull] NumberLiteralExpression number, ulong value) => number.UInt64 < value;

        public static bool operator <(ulong value, [NotNull] NumberLiteralExpression number) => value < number.UInt64;

        public static bool operator <([NotNull] NumberLiteralExpression number, double value) => number.Double < value;

        public static bool operator <(double value, [NotNull] NumberLiteralExpression number) => value < number.Double;

        public static bool operator >([NotNull] NumberLiteralExpression number, sbyte value) => number.SByte > value;

        public static bool operator >(sbyte value, [NotNull] NumberLiteralExpression number) => value > number.SByte;

        public static bool operator >([NotNull] NumberLiteralExpression number, byte value) => number.Byte > value;

        public static bool operator >(byte value, [NotNull] NumberLiteralExpression number) => value > number.Byte;

        public static bool operator >([NotNull] NumberLiteralExpression number, char value) => number.Char > value;

        public static bool operator >(char value, [NotNull] NumberLiteralExpression number) => value > number.Char;

        public static bool operator >([NotNull] NumberLiteralExpression number, short value) => number.Int16 > value;

        public static bool operator >(short value, [NotNull] NumberLiteralExpression number) => value > number.Int16;

        public static bool operator >([NotNull] NumberLiteralExpression number, ushort value) => number.UInt16 > value;

        public static bool operator >(ushort value, [NotNull] NumberLiteralExpression number) => value > number.UInt16;

        public static bool operator >([NotNull] NumberLiteralExpression number, int value) => number.Int32 > value;

        public static bool operator >(int value, [NotNull] NumberLiteralExpression number) => value > number.Int32;

        public static bool operator >([NotNull] NumberLiteralExpression number, uint value) => number.UInt32 > value;

        public static bool operator >(uint value, [NotNull] NumberLiteralExpression number) => value > number.UInt32;

        public static bool operator >([NotNull] NumberLiteralExpression number, long value) => number.Int64 > value;

        public static bool operator >(long value, [NotNull] NumberLiteralExpression number) => value > number.Int64;

        public static bool operator >([NotNull] NumberLiteralExpression number, ulong value) => number.UInt64 > value;

        public static bool operator >(ulong value, [NotNull] NumberLiteralExpression number) => value > number.UInt64;

        public static bool operator >([NotNull] NumberLiteralExpression number, double value) => number.Double > value;

        public static bool operator >(double value, [NotNull] NumberLiteralExpression number) => value > number.Double;

        public static bool operator <=([NotNull] NumberLiteralExpression number, sbyte value) => number.SByte <= value;

        public static bool operator <=(sbyte value, [NotNull] NumberLiteralExpression number) => value <= number.SByte;

        public static bool operator <=([NotNull] NumberLiteralExpression number, byte value) => number.Byte <= value;

        public static bool operator <=(byte value, [NotNull] NumberLiteralExpression number) => value <= number.Byte;

        public static bool operator <=([NotNull] NumberLiteralExpression number, char value) => number.Char <= value;

        public static bool operator <=(char value, [NotNull] NumberLiteralExpression number) => value <= number.Char;

        public static bool operator <=([NotNull] NumberLiteralExpression number, short value) => number.Int16 <= value;

        public static bool operator <=(short value, [NotNull] NumberLiteralExpression number) => value <= number.Int16;

        public static bool operator <=([NotNull] NumberLiteralExpression number, ushort value) => number.UInt16 <= value;

        public static bool operator <=(ushort value, [NotNull] NumberLiteralExpression number) => value <= number.UInt16;

        public static bool operator <=([NotNull] NumberLiteralExpression number, int value) => number.Int32 <= value;

        public static bool operator <=(int value, [NotNull] NumberLiteralExpression number) => value <= number.Int32;

        public static bool operator <=([NotNull] NumberLiteralExpression number, uint value) => number.UInt32 <= value;

        public static bool operator <=(uint value, [NotNull] NumberLiteralExpression number) => value <= number.UInt32;

        public static bool operator <=([NotNull] NumberLiteralExpression number, long value) => number.Int64 <= value;

        public static bool operator <=(long value, [NotNull] NumberLiteralExpression number) => value <= number.Int64;

        public static bool operator <=([NotNull] NumberLiteralExpression number, ulong value) => number.UInt64 <= value;

        public static bool operator <=(ulong value, [NotNull] NumberLiteralExpression number) => value <= number.UInt64;

        public static bool operator <=([NotNull] NumberLiteralExpression number, double value) => number.Double <= value;

        public static bool operator <=(double value, [NotNull] NumberLiteralExpression number) => value <= number.Double;

        public static bool operator >=([NotNull] NumberLiteralExpression number, sbyte value) => number.SByte >= value;

        public static bool operator >=(sbyte value, [NotNull] NumberLiteralExpression number) => value >= number.SByte;

        public static bool operator >=([NotNull] NumberLiteralExpression number, byte value) => number.Byte >= value;

        public static bool operator >=(byte value, [NotNull] NumberLiteralExpression number) => value >= number.Byte;

        public static bool operator >=([NotNull] NumberLiteralExpression number, char value) => number.Char >= value;

        public static bool operator >=(char value, [NotNull] NumberLiteralExpression number) => value >= number.Char;

        public static bool operator >=([NotNull] NumberLiteralExpression number, short value) => number.Int16 >= value;

        public static bool operator >=(short value, [NotNull] NumberLiteralExpression number) => value >= number.Int16;

        public static bool operator >=([NotNull] NumberLiteralExpression number, ushort value) => number.UInt16 >= value;

        public static bool operator >=(ushort value, [NotNull] NumberLiteralExpression number) => value >= number.UInt16;

        public static bool operator >=([NotNull] NumberLiteralExpression number, int value) => number.Int32 >= value;

        public static bool operator >=(int value, [NotNull] NumberLiteralExpression number) => value >= number.Int32;

        public static bool operator >=([NotNull] NumberLiteralExpression number, uint value) => number.UInt32 >= value;

        public static bool operator >=(uint value, [NotNull] NumberLiteralExpression number) => value >= number.UInt32;

        public static bool operator >=([NotNull] NumberLiteralExpression number, long value) => number.Int64 >= value;

        public static bool operator >=(long value, [NotNull] NumberLiteralExpression number) => value >= number.Int64;

        public static bool operator >=([NotNull] NumberLiteralExpression number, ulong value) => number.UInt64 >= value;

        public static bool operator >=(ulong value, [NotNull] NumberLiteralExpression number) => value >= number.UInt64;

        public static bool operator >=([NotNull] NumberLiteralExpression number, double value) => number.Double >= value;

        public static bool operator >=(double value, [NotNull] NumberLiteralExpression number) => value >= number.Double;

        public static bool operator ==([CanBeNull] NumberLiteralExpression left, [CanBeNull] NumberLiteralExpression right) => Equals(left, right);

        public static bool operator !=([CanBeNull] NumberLiteralExpression left, [CanBeNull] NumberLiteralExpression right) => !Equals(left, right);

        public static explicit operator sbyte([NotNull] NumberLiteralExpression number) => number.SByte;

        public static explicit operator byte([NotNull] NumberLiteralExpression number) => number.Byte;

        public static explicit operator char([NotNull] NumberLiteralExpression number) => number.Char;

        public static explicit operator short([NotNull] NumberLiteralExpression number) => number.Int16;

        public static explicit operator ushort([NotNull] NumberLiteralExpression number) => number.UInt16;

        public static explicit operator int([NotNull] NumberLiteralExpression number) => number.Int32;

        public static explicit operator uint([NotNull] NumberLiteralExpression number) => number.UInt32;

        public static explicit operator long([NotNull] NumberLiteralExpression number) => number.Int64;

        public static explicit operator ulong([NotNull] NumberLiteralExpression number) => number.UInt64;

        public static explicit operator double([NotNull] NumberLiteralExpression number) => number.Double;

        [NotNull]
        public static implicit operator NumberLiteralExpression(sbyte value) => new NumberLiteralExpression(value);

        [NotNull]
        public static implicit operator NumberLiteralExpression(byte value) => new NumberLiteralExpression(value);

        [NotNull]
        public static implicit operator NumberLiteralExpression(char value) => new NumberLiteralExpression(value);

        [NotNull]
        public static implicit operator NumberLiteralExpression(short value) => new NumberLiteralExpression(value);

        [NotNull]
        public static implicit operator NumberLiteralExpression(ushort value) => new NumberLiteralExpression(value);

        [NotNull]
        public static implicit operator NumberLiteralExpression(int value) => new NumberLiteralExpression(value);

        [NotNull]
        public static implicit operator NumberLiteralExpression(uint value) => new NumberLiteralExpression(value);

        [NotNull]
        public static implicit operator NumberLiteralExpression(long value) => new NumberLiteralExpression(value);

        [NotNull]
        public static implicit operator NumberLiteralExpression(ulong value) => new NumberLiteralExpression(value);

        public override bool Equals(object obj) => !ReferenceEquals(null, obj) && (ReferenceEquals(this, obj) || Equals(obj as NumberLiteralExpression));

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ Double.GetHashCode();
            }
        }

        public override string ToString() => Double.ToString(CultureInfo.InvariantCulture);

        private void SetValue(double value)
        {
            Double = value = Math.Floor(value);
            _sbyte = (sbyte)value;
            _byte = (byte)value;
            _char = (char)value;
            _int16 = (short)value;
            _uint16 = (ushort)value;
            _int32 = (int)value;
            _uint32 = (uint)value;
            _int64 = (long)value;
            _uint64 = (ulong)value;
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName, CanBeNull] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    internal sealed class InvalidBitwiseTypeException : Exception
    {
        public InvalidBitwiseTypeException()
        {
        }

        public InvalidBitwiseTypeException(string message) : base(message)
        {
        }

        public InvalidBitwiseTypeException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    internal abstract class BitwiseExpression : Expression, IEquatable<BitwiseExpression>, INotifyPropertyChanged
    {
        private readonly IBitFunction _bitFunction;
        private readonly IBitUnaryFunction _bitUnaryFunction;
        private NumberLiteralExpression _leftOperand;
        private NumberLiteralExpression _rightOperand;

        protected BitwiseExpression([NotNull] NumberLiteralExpression leftNumber, [CanBeNull] NumberLiteralExpression rightNumber) : this()
        {
            _leftOperand = leftNumber;
            _rightOperand = rightNumber;
        }

        private BitwiseExpression()
        {
            ConcreteType = GetType();
            CustomAttribute = (BitwiseFunctionAttribute)Attribute.GetCustomAttribute(ConcreteType, typeof(BitwiseFunctionAttribute));
            if ((CustomAttribute == null) || !CustomAttribute.Kind.IsBitwise())
            {
                throw new InvalidBitwiseTypeException($"{ConcreteType.FullName} does not have a valid {nameof(BitwiseFunctionAttribute)} attribute.");
            }

            Kind = CustomAttribute.Kind;
            Operator = Kind.GetBitwiseToken();
            IsUnary = Kind.IsUnary();

            _bitFunction = this as IBitFunction;
            _bitUnaryFunction = this as IBitUnaryFunction;

            if (((_bitFunction == null) && (_bitUnaryFunction == null)) || ((_bitFunction != null) && (_bitUnaryFunction != null)) || ((_bitFunction == null) && !IsUnary) || ((_bitUnaryFunction == null) && IsUnary))
            {
                throw new InvalidBitwiseTypeException();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public bool Equals([CanBeNull] BitwiseExpression other) => !ReferenceEquals(null, other) && (ReferenceEquals(this, other) || (base.Equals(other) && (ConcreteType == other.ConcreteType) && CustomAttribute.Equals(other.CustomAttribute) && (IsUnary == other.IsUnary) && string.Equals(Operator, other.Operator) && LeftOperand.Equals(other.LeftOperand) && RightOperand.Equals(other.RightOperand)));

        public sealed override ExpressionKind Kind
        {
            get;
        }

        public sealed override Expression BaseExpression => this;

        public Type ConcreteType
        {
            get;
        }

        public BitwiseFunctionAttribute CustomAttribute
        {
            get;
        }

        [NotNull]
        public NumberLiteralExpression LeftOperand
        {
            get
            {
                return _leftOperand;
            }
            set
            {
                if (Equals(value, _leftOperand))
                {
                    return;
                }

                _leftOperand = value;
                OnPropertyChanged();
            }
        }

        [CanBeNull]
        public NumberLiteralExpression RightOperand
        {
            get
            {
                return _rightOperand;
            }
            set
            {
                if (IsUnary || Equals(value, _rightOperand))
                {
                    return;
                }

                _rightOperand = value;
                OnPropertyChanged();
            }
        }

        [NotNull]
        public string Operator
        {
            get;
        }

        public NumberLiteralExpression Result
        {
            get;
            private set;
        }

        [NotNull]
        public NumberLiteralExpression SByte => (Result = Compute_SByte()).SByte;

        [NotNull]
        public NumberLiteralExpression Byte => (Result = Compute_Byte()).Byte;

        [NotNull]
        public NumberLiteralExpression Char => (Result = Compute_Char()).Char;

        [NotNull]
        public NumberLiteralExpression Int16 => (Result = Compute_Int16()).Int16;

        [NotNull]
        public NumberLiteralExpression UInt16 => (Result = Compute_UInt16()).UInt16;

        [NotNull]
        public NumberLiteralExpression Int32 => (Result = Compute_Int32()).Int32;

        [NotNull]
        public NumberLiteralExpression UInt32 => (Result = Compute_UInt32()).UInt32;

        [NotNull]
        public NumberLiteralExpression Int64 => (Result = Compute_Int64()).Int64;

        [NotNull]
        public NumberLiteralExpression UInt64 => (Result = Compute_UInt64()).UInt64;

        public bool IsUnary
        {
            get;
        }

        public static bool operator ==([CanBeNull] BitwiseExpression left, [CanBeNull] BitwiseExpression right) => Equals(left, right);

        public static bool operator !=([CanBeNull] BitwiseExpression left, [CanBeNull] BitwiseExpression right) => !Equals(left, right);

        public override bool Equals(object obj) => !ReferenceEquals(null, obj) && (ReferenceEquals(this, obj) || Equals(obj as BitwiseExpression));

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ ConcreteType.GetHashCode();
                hashCode = (hashCode * 397) ^ CustomAttribute.GetHashCode();
                hashCode = (hashCode * 397) ^ LeftOperand.GetHashCode();
                if (!IsUnary)
                {
                    hashCode = (hashCode * 397) ^ RightOperand.GetHashCode();
                }
                return hashCode;
            }
        }

        public override string ToString() => IsUnary ? Operator + (LeftOperand < 0 ? "(" + LeftOperand + ")" : LeftOperand.ToString()) : LeftOperand + Operator + RightOperand;

        [NotNull]
        public object Compute<T>() where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Char:
                    return Compute_Char();
                case TypeCode.SByte:
                    return Compute_SByte();
                case TypeCode.Byte:
                    return Compute_Byte();
                case TypeCode.Int16:
                    return Compute_Int16();
                case TypeCode.UInt16:
                    return Compute_UInt16();
                case TypeCode.Int32:
                    return Compute_Int32();
                case TypeCode.UInt32:
                    return Compute_UInt32();
                case TypeCode.Int64:
                    return Compute_Int64();
                case TypeCode.UInt64:
                    return Compute_UInt64();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private char Compute_Char() => (char)(Result = IsUnary ? _bitUnaryFunction.Compute(LeftOperand.Char) : _bitFunction.Compute(LeftOperand.Char, RightOperand.Char));

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private sbyte Compute_SByte() => (sbyte)(Result = IsUnary ? _bitUnaryFunction.Compute(LeftOperand.SByte) : _bitFunction.Compute(LeftOperand.SByte, RightOperand.SByte));

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private byte Compute_Byte() => (byte)(Result = IsUnary ? _bitUnaryFunction.Compute(LeftOperand.Byte) : _bitFunction.Compute(LeftOperand.Byte, RightOperand.Byte));

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private short Compute_Int16() => (short)(Result = IsUnary ? _bitUnaryFunction.Compute(LeftOperand.Int16) : _bitFunction.Compute(LeftOperand.Int16, RightOperand.Int16));

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private ushort Compute_UInt16() => (ushort)(Result = IsUnary ? _bitUnaryFunction.Compute(LeftOperand.UInt16) : _bitFunction.Compute(LeftOperand.UInt16, RightOperand.UInt16));

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private int Compute_Int32() => (int)(Result = IsUnary ? _bitUnaryFunction.Compute(LeftOperand.Int32) : _bitFunction.Compute(LeftOperand.Int32, RightOperand.Int32));

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private uint Compute_UInt32() => (uint)(Result = IsUnary ? _bitUnaryFunction.Compute(LeftOperand.UInt32) : _bitFunction.Compute(LeftOperand.UInt32, RightOperand.UInt32));

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private long Compute_Int64() => (long)(Result = IsUnary ? _bitUnaryFunction.Compute(LeftOperand.Int64) : _bitFunction.Compute(LeftOperand.Int64, RightOperand.Int64));

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private ulong Compute_UInt64() => (ulong)(Result = IsUnary ? _bitUnaryFunction.Compute(LeftOperand.UInt64) : _bitFunction.Compute(LeftOperand.UInt64, RightOperand.UInt64));

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CanBeNull, CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    [BitwiseFunction(ExpressionKind.BitwiseAnd), UsedImplicitly]
    internal sealed class BitwiseAndExpression : BitwiseExpression, IBitFunction
    {
        public BitwiseAndExpression() : base(default(int), default(int))
        {
        }

        public BitwiseAndExpression([NotNull] NumberLiteralExpression leftNumber, [NotNull] NumberLiteralExpression rightNumber) : base(leftNumber, rightNumber)
        {
        }

        public sbyte Compute(sbyte leftValue, sbyte rightValue) => (sbyte)(leftValue & rightValue);

        public byte Compute(byte leftValue, byte rightValue) => (byte)(leftValue & rightValue);

        public char Compute(char leftValue, char rightValue) => (char)(leftValue & rightValue);

        public short Compute(short leftValue, short rightValue) => (short)(leftValue & rightValue);

        public ushort Compute(ushort leftValue, ushort rightValue) => (ushort)(leftValue & rightValue);

        public int Compute(int leftValue, int rightValue) => leftValue & rightValue;

        public uint Compute(uint leftValue, uint rightValue) => leftValue & rightValue;

        public long Compute(long leftValue, long rightValue) => leftValue & rightValue;

        public ulong Compute(ulong leftValue, ulong rightValue) => leftValue & rightValue;
    }

    [BitwiseFunction(ExpressionKind.BitwiseLeftShift), UsedImplicitly]
    internal sealed class BitwiseLeftShiftExpression : BitwiseExpression, IBitFunction
    {
        public BitwiseLeftShiftExpression() : base(default(int), default(int))
        {
        }

        public BitwiseLeftShiftExpression([NotNull] NumberLiteralExpression leftNumber, [NotNull] NumberLiteralExpression rightNumber) : base(leftNumber, rightNumber)
        {
        }

        public sbyte Compute(sbyte leftValue, sbyte rightValue) => (sbyte)(leftValue << rightValue);

        public byte Compute(byte leftValue, byte rightValue) => (byte)(leftValue << rightValue);

        public char Compute(char leftValue, char rightValue) => (char)(leftValue << rightValue);

        public short Compute(short leftValue, short rightValue) => (short)(leftValue << rightValue);

        public ushort Compute(ushort leftValue, ushort rightValue) => (ushort)(leftValue << rightValue);

        public int Compute(int leftValue, int rightValue) => leftValue << rightValue;

        public uint Compute(uint leftValue, uint rightValue) => (uint)((int)leftValue << (int)rightValue);

        public long Compute(long leftValue, long rightValue) => (int)leftValue << (int)rightValue;

        public ulong Compute(ulong leftValue, ulong rightValue) => (ulong)((int)leftValue << (int)rightValue);
    }

    [BitwiseFunction(ExpressionKind.BitwiseNot), UsedImplicitly]
    internal sealed class BitwiseNotExpression : BitwiseExpression, IBitUnaryFunction
    {
        public BitwiseNotExpression() : base(default(int), null)
        {
        }

        public BitwiseNotExpression([NotNull] NumberLiteralExpression number, [CanBeNull] NumberLiteralExpression unaryReservedNullNumber = null) : base(number, null)
        {
        }

        public sbyte Compute(sbyte value) => (sbyte)~value;

        public byte Compute(byte value) => (byte)~value;

        public char Compute(char value) => (char)~value;

        public short Compute(short value) => (short)~value;

        public ushort Compute(ushort value) => (ushort)~value;

        public int Compute(int value) => ~value;

        public uint Compute(uint value) => ~value;

        public long Compute(long value) => ~value;

        public ulong Compute(ulong value) => ~value;
    }

    [BitwiseFunction(ExpressionKind.BitwiseOr), UsedImplicitly]
    internal sealed class BitwiseOrExpression : BitwiseExpression, IBitFunction
    {
        public BitwiseOrExpression() : base(default(int), default(int))
        {
        }

        public BitwiseOrExpression([NotNull] NumberLiteralExpression leftNumber, [NotNull] NumberLiteralExpression rightNumber) : base(leftNumber, rightNumber)
        {
        }

        public sbyte Compute(sbyte leftValue, sbyte rightValue) => (sbyte)(leftValue | rightValue);

        public byte Compute(byte leftValue, byte rightValue) => (byte)(leftValue | rightValue);

        public char Compute(char leftValue, char rightValue) => (char)(leftValue | rightValue);

        public short Compute(short leftValue, short rightValue) => (short)(leftValue | rightValue);

        public ushort Compute(ushort leftValue, ushort rightValue) => (ushort)(leftValue | rightValue);

        public int Compute(int leftValue, int rightValue) => leftValue | rightValue;

        public uint Compute(uint leftValue, uint rightValue) => leftValue | rightValue;

        public long Compute(long leftValue, long rightValue) => leftValue | rightValue;

        public ulong Compute(ulong leftValue, ulong rightValue) => leftValue | rightValue;
    }

    [BitwiseFunction(ExpressionKind.BitwiseRightShift), UsedImplicitly]
    internal sealed class BitwiseRightShiftExpression : BitwiseExpression, IBitFunction
    {
        public BitwiseRightShiftExpression() : base(default(int), default(int))
        {
        }

        public BitwiseRightShiftExpression([NotNull] NumberLiteralExpression leftNumber, [NotNull] NumberLiteralExpression rightNumber) : base(leftNumber, rightNumber)
        {
        }

        public sbyte Compute(sbyte leftValue, sbyte rightValue) => (sbyte)(leftValue >> rightValue);

        public byte Compute(byte leftValue, byte rightValue) => (byte)(leftValue >> rightValue);

        public char Compute(char leftValue, char rightValue) => (char)(leftValue >> rightValue);

        public short Compute(short leftValue, short rightValue) => (short)(leftValue >> rightValue);

        public ushort Compute(ushort leftValue, ushort rightValue) => (ushort)(leftValue >> rightValue);

        public int Compute(int leftValue, int rightValue) => leftValue >> rightValue;

        public uint Compute(uint leftValue, uint rightValue) => (uint)((int)leftValue >> (int)rightValue);

        public long Compute(long leftValue, long rightValue) => (int)leftValue >> (int)rightValue;

        public ulong Compute(ulong leftValue, ulong rightValue) => (ulong)((int)leftValue >> (int)rightValue);
    }

    [BitwiseFunction(ExpressionKind.BitwiseXor), UsedImplicitly]
    internal sealed class BitwiseXorExpression : BitwiseExpression, IBitFunction
    {
        public BitwiseXorExpression() : base(default(int), default(int))
        {
        }

        public BitwiseXorExpression([NotNull] NumberLiteralExpression leftNumber, [NotNull] NumberLiteralExpression rightNumber) : base(leftNumber, rightNumber)
        {
        }

        public sbyte Compute(sbyte leftValue, sbyte rightValue) => (sbyte)(leftValue ^ rightValue);

        public byte Compute(byte leftValue, byte rightValue) => (byte)(leftValue ^ rightValue);

        public char Compute(char leftValue, char rightValue) => (char)(leftValue ^ rightValue);

        public short Compute(short leftValue, short rightValue) => (short)(leftValue ^ rightValue);

        public ushort Compute(ushort leftValue, ushort rightValue) => (ushort)(leftValue ^ rightValue);

        public int Compute(int leftValue, int rightValue) => leftValue ^ rightValue;

        public uint Compute(uint leftValue, uint rightValue) => leftValue ^ rightValue;

        public long Compute(long leftValue, long rightValue) => leftValue ^ rightValue;

        public ulong Compute(ulong leftValue, ulong rightValue) => leftValue ^ rightValue;
    }
}