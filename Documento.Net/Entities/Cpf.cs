using Documento.Net.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documento.Net.Entities;

public class Cpf : Document
{
    public Cpf(string number) : base(number, DocumentType.RG, new CpfValidator()) { }
}
