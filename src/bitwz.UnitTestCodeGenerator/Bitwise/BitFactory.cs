using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace bitwz.CodeGenerator.Bitwise
{
    internal sealed class BitFactory : IEquatable<BitFactory>
    {
        private static readonly object SyncRoot;
        private static volatile BitFactory _instance;
        private readonly Dictionary<ExpressionKind, BitwiseExpression> _operations;

        static BitFactory()
        {
            SyncRoot = new object();
        }

        private BitFactory()
        {
            if (!ReferenceEquals(_instance, null))
            {
                throw new TypeLoadException();
            }

            _operations = new Dictionary<ExpressionKind, BitwiseExpression>();
        }

        public bool Equals([CanBeNull] BitFactory other) => !ReferenceEquals(null, other) && (ReferenceEquals(this, other) || _operations.Equals(other._operations));

        internal static BitFactory Instance
        {
            get
            {
                if (!ReferenceEquals(_instance, null))
                {
                    return _instance;
                }

                lock (SyncRoot)
                {
                    if (ReferenceEquals(_instance, null))
                    {
                        _instance = new BitFactory();
                    }
                }

                return _instance;
            }
        }

        internal BitwiseExpression this[ExpressionKind type]
        {
            get
            {
                if (!type.IsBitwise())
                {
                    throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(ExpressionKind));
                }

                if (_operations.ContainsKey(type))
                {
                    return _operations[type];
                }

                Type concreteType = Type.GetType(GetType().Namespace + "." + Enum.GetName(typeof(ExpressionKind), type) + "Expression");
                if ((concreteType == null) || !concreteType.IsBitwiseExpression())
                {
                    throw new InvalidBitwiseTypeException();
                }

                BitwiseExpression obj = (BitwiseExpression)Activator.CreateInstance(concreteType);
                _operations.Add(type, obj);
                return obj;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==([CanBeNull] BitFactory left, [CanBeNull] BitFactory right) => Equals(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=([CanBeNull] BitFactory left, [CanBeNull] BitFactory right) => !Equals(left, right);

        public override bool Equals([CanBeNull] object obj) => !ReferenceEquals(null, obj) && (ReferenceEquals(this, obj) || Equals(obj as BitFactory));

        public override int GetHashCode() => _operations.GetHashCode();
    }
}