using EnvelopesComparer.Business.Model.Interfaces;
using EnvelopesComparer.Model;

namespace EnvelopesComparer.Business.Interfaces
{
    public interface IEnvelopeAnalizer
    {
        bool CanAnalize(IEnvelope envelop);

        bool Analize(
            RectangularEnvelope envelopeA,
            RectangularEnvelope envelopeB
        );
    }
}