﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EnvelopesComparer.Business.Model;

namespace EnvelopesComparerTests.Comparer
{
    public class RectangularEnvelopeEqualityComparer : EqualityComparer<RectangularEnvelope>
    {
        public override bool Equals(
            [AllowNull] RectangularEnvelope a,
            [AllowNull] RectangularEnvelope b
        )
        {
            return a.Height == b.Height
                && a.Width == b.Width;
        }

        public override int GetHashCode([DisallowNull] RectangularEnvelope obj)
        {
            return obj.GetHashCode();
        }
    }
}