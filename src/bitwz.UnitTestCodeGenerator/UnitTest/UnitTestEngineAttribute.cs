using System;
using System.ComponentModel;

namespace bitwz.CodeGenerator.UnitTest
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    internal sealed class UnitTestEngineAttribute : Attribute
    {
        internal UnitTestEngineAttribute(EngineType engineType)
        {
            if (!Enum.IsDefined(typeof(EngineType), engineType))
            {
                throw new InvalidEnumArgumentException(nameof(engineType), (int)engineType, typeof(EngineType));
            }

            Type = engineType;
        }

        public EngineType Type
        {
            get;
        }
    }
}