using Documento.Net.Validators;

namespace Documento.Net.Entities;

internal abstract class Document
{
    public string FormattedNumber { get; private set; }
    public DocumentType DocumentType { get; private set; }
    private IValidator Validator { get; set; }
    public bool IsValid { get { return Validator.IsValid(FormattedNumber); } }

    public Document(string number, DocumentType documentType, IValidator validator)
    {
        FormattedNumber = number;
        DocumentType = documentType;
        Validator = validator;
    }
}

