using Documento.Net.Validators;

namespace Documento.Net.Entities;

public class Rg : Document
{
    public Rg(string number) : base(number, DocumentType.RG, new RgValidator()) { }
}
