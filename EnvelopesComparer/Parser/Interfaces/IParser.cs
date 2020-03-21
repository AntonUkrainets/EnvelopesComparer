using EnvelopesComparer.Business.Model.Interfaces;

namespace EnvelopesComparer.Parser.Interfaces
{
    public interface IParser
    {
        bool CanParse(string[] args);
        IEnvelope[] Parse(string[] args);
    }
}