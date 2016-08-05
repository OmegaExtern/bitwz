using System;
using System.ComponentModel;
using System.IO;
using JetBrains.Annotations;

namespace bitwz.CodeGenerator.UnitTest
{
    internal static class UnitTestExtensions
    {
        [NotNull]
        internal static string GetFileNamePrefix(this EngineType engineType, [NotNull] string fileName)
        {
            if (!Enum.IsDefined(typeof(EngineType), engineType))
            {
                throw new InvalidEnumArgumentException(nameof(engineType), (int)engineType, typeof(EngineType));
            }
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(fileName));
            }

            switch (engineType)
            {
                case EngineType.MsUnitEngine:
                case EngineType.NUnitEngine:
                case EngineType.XUnitEngine:
                    return $"{engineType.ToString().ToLowerInvariant()}-{Path.ChangeExtension(fileName, ".cs")}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(engineType), engineType, null);
            }
        }
    }
}