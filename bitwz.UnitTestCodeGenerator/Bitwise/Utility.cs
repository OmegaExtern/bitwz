using System;
using System.Collections.Generic;
using System.Linq;
using bitwz.CodeGenerator.UnitTest;
using JetBrains.Annotations;

namespace bitwz.CodeGenerator.Bitwise
{
    internal static class Utility
    {
        [NotNull]
        internal static IEnumerable<BitwiseExpression> GetBitwiseExpressions() => from bitwiseType in (ExpressionKind[])Enum.GetValues(typeof(ExpressionKind)) where bitwiseType.IsBitwise() select BitFactory.Instance[bitwiseType];

        [NotNull]
        internal static IEnumerable<UnitTestEngine> GetUnitTestEngines() => from engineType in (EngineType[])Enum.GetValues(typeof(EngineType)) select EngineFactory.Instance[engineType];
    }
}