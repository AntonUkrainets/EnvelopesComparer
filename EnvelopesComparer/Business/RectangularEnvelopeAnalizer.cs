using EnvelopesComparer.Business.Interfaces;
using EnvelopesComparer.Business.Model.Interfaces;
using EnvelopesComparer.Extensions;
using EnvelopesComparer.Model;

namespace EnvelopesComparer.Business
{
    public class RectangularEnvelopeAnalizer : IEnvelopeAnalizer
    {
        public bool CanAnalize(IEnvelope envelope)
        {
            return envelope is RectangularEnvelope;
        }

        public bool Analize(
            RectangularEnvelope envelopeA,
            RectangularEnvelope envelopeB
        )
        {
            return envelopeA.IsLessThan(envelopeB)
                || envelopeB.IsLessThan(envelopeA);
        }
    }
}