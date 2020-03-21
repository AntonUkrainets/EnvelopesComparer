using EnvelopesComparer.Business.Model;

namespace EnvelopesComparer.Extensions
{
    public static class RectangularEnvelopeExtensions
    {
        public static bool IsLessThan(
            this RectangularEnvelope a,
            RectangularEnvelope b
        )
        {
            return (a.Width < b.Width) && (a.Height < b.Height)
                || (a.Height < b.Width) && (a.Width < b.Height);
        }
    }
}