using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace bitwz.CodeGenerator.UnitTest
{
    internal abstract class UnitTestEngine : IUnitTestEngine, IEquatable<UnitTestEngine>
    {
        protected UnitTestEngine()
        {
            ConcreteType = GetType();
            CustomAttribute = (UnitTestEngineAttribute)Attribute.GetCustomAttribute(ConcreteType, typeof(UnitTestEngineAttribute));
            if (CustomAttribute == null)
            {
                throw new NullReferenceException();
            }
        }

        public bool Equals([CanBeNull] UnitTestEngine other) => !ReferenceEquals(null, other) && (ReferenceEquals(this, other) || ((Type == other.Type) && (ConcreteType == other.ConcreteType) && CustomAttribute.Equals(other.CustomAttribute)));

        public abstract string Equal(string expected, string actual);

        public abstract EngineType Type
        {
            get;
        }

        public Type ConcreteType
        {
            get;
        }

        public UnitTestEngineAttribute CustomAttribute
        {
            get;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==([CanBeNull] UnitTestEngine left, [CanBeNull] UnitTestEngine right) => Equals(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=([CanBeNull] UnitTestEngine left, [CanBeNull] UnitTestEngine right) => !Equals(left, right);

        public override bool Equals([CanBeNull] object obj) => !ReferenceEquals(null, obj) && (ReferenceEquals(this, obj) || Equals(obj as UnitTestEngine));

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)Type * 397) ^ CustomAttribute.GetHashCode();
            }
        }

        public override string ToString() => Type.ToString();
    }
}