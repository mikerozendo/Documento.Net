using Documento.Net.Entities;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text.RegularExpressions;

namespace Documento.Net
{

    /// <summary>
    /// Realiza validação de calculo de DV (RG,CPF ou CNPJ)
    /// </summary>
    /// <param name="numberToValidate">Documento para validar</param>
    public class DocumentNet
    {
        private string _numberToValidate;
        private Dictionary<DocumentType, Func<string, Document>> DocumentBuildersDictionary =
            new Dictionary<DocumentType, Func<string, Document>>()
        {
            {  DocumentType.RG, BuilRg } ,
            {  DocumentType.CPF, BuilCpf } ,
            {  DocumentType.CNPJ, BuilCnpj }
        };

        public DocumentNet(string numberToValidate)
        {
            _numberToValidate = numberToValidate;
        }

        /// <summary>
        /// Valida documento
        /// </summary>
        /// <returns>true ou falso</returns>
        public bool IsValid()
        {
            try
            {
                if (string.IsNullOrEmpty(_numberToValidate))
                    return false;

                _numberToValidate = GetCleanDocumentNumber(_numberToValidate);
                DocumentType documentType = GetDocumentType(_numberToValidate.Length);

                if (documentType is DocumentType.Outros)
                    return false;

                var areAllDigitsEqual = Regex.Match(_numberToValidate, @"^(\d)\1*$");
                if (areAllDigitsEqual.Success)
                    return false;

                var validSearch = DocumentBuildersDictionary.TryGetValue(documentType, out var document);
                var isDocumentValid = document?.Invoke(_numberToValidate)?.IsValid ?? false;
                return isDocumentValid;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DocumentType GetDocumentType(int cleanDigitsCount)
        {
            switch (cleanDigitsCount)
            {
                case 9:
                    return DocumentType.RG;
                case 11:
                    return DocumentType.CPF;
                case 14:
                    return DocumentType.CNPJ;
                default:
                    return DocumentType.Outros;
            }
        }

        private string GetCleanDocumentNumber(string number)
        {
            string numberWithoutWhiteSpaces = number.Trim();
            string numberWithoutHyphen = numberWithoutWhiteSpaces.Contains('-') ? numberWithoutWhiteSpaces.Replace("-", "") : numberWithoutWhiteSpaces;
            string numberWithoutSlash = numberWithoutHyphen.Contains('/') ? numberWithoutHyphen.Replace("/", "") : numberWithoutHyphen;
            string numberWithoutDot = numberWithoutSlash.Contains('.') ? numberWithoutSlash.Replace(".", "") : numberWithoutSlash;
            return numberWithoutDot;
        }

        private static Rg BuilRg(string formattedDocumentNumber)
        {
            return new Rg(formattedDocumentNumber);
        }

        private static Cpf BuilCpf(string formattedDocumentNumber)
        {
            return new Cpf(formattedDocumentNumber);
        }

        private static Cnpj BuilCnpj(string formattedDocumentNumber)
        {
            return new Cnpj(formattedDocumentNumber);
        }
    }
}
