using EnvelopesComparer.Business.Model;
using EnvelopesComparer.Business.Model.Interfaces;

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