using Documento.Net.Validators;

namespace Documento.Net.Entities;

public class Cnpj : Document
{
    public Cnpj(string number) : base(number, DocumentType.CNPJ, new CnpjValidator()) { }
}
