using Documento.Net.Validators;

namespace Documento.Net.Entities
{
    internal class Cpf : Document
    {
        public Cpf(string number) : base(number, DocumentType.RG, new CpfValidator()) { }
    }
}
