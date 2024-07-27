using Documento.Net.Validators;

namespace Documento.Net.Entities;

public class Cpf : Document
{
    public Cpf(string number) : base(number, DocumentType.RG, new CpfValidator()) { }
}
