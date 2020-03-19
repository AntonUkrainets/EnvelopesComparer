using EnvelopesComparer.Business.Model.Interfaces;

namespace EnvelopesComparer.Model
{
    public class RectangularEnvelope : IEnvelope
    {
        public double Width { get; }
        public double Height { get; }

        public RectangularEnvelope(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }
}