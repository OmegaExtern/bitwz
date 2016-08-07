using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace bitwz.CodeGenerator.UnitTest
{
    internal sealed class EngineFactory : IEquatable<EngineFactory>
    {
        private static readonly object SyncRoot;
        private static volatile EngineFactory _instance;
        private readonly Dictionary<EngineType, UnitTestEngine> _engines;

        static EngineFactory()
        {
            SyncRoot = new object();
        }

        private EngineFactory()
        {
            if (!ReferenceEquals(_instance, null))
            {
                throw new TypeLoadException();
            }

            _engines = new Dictionary<EngineType, UnitTestEngine>();
        }

        public bool Equals([CanBeNull] EngineFactory other) => !ReferenceEquals(null, other) && (ReferenceEquals(this, other) || _engines.Equals(other._engines));

        internal static EngineFactory Instance
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
                        _instance = new EngineFactory();
                    }
                }

                return _instance;
            }
        }

        internal UnitTestEngine this[EngineType type]
        {
            get
            {
                if (!Enum.IsDefined(typeof(EngineType), type))
                {
                    throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(EngineType));
                }

                if (_engines.ContainsKey(type))
                {
                    return _engines[type];
                }

                Type concreteType = Type.GetType(GetType().Namespace + "." + Enum.GetName(typeof(EngineType), type));
                if (concreteType == null)
                {
                    return null;
                }

                UnitTestEngine obj = (UnitTestEngine)Activator.CreateInstance(concreteType);
                _engines.Add(type, obj);
                return obj;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==([CanBeNull] EngineFactory left, [CanBeNull] EngineFactory right) => Equals(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=([CanBeNull] EngineFactory left, [CanBeNull] EngineFactory right) => !Equals(left, right);

        public override bool Equals([CanBeNull] object obj) => !ReferenceEquals(null, obj) && (ReferenceEquals(this, obj) || Equals(obj as EngineFactory));

        public override int GetHashCode() => _engines.GetHashCode();
    }
}