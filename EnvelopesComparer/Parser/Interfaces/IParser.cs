using System.Collections.Generic;
using EnvelopesComparer.Business.Model.Interfaces;

namespace EnvelopesComparer.Parser.Interfaces
{
    public interface IParser
    {
        bool CanParse(string[] args);
        IEnumerable<IEnvelope> Parse(string[] args);
    }
}