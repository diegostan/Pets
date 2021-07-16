using Pets.Domain.Enums;

namespace Pets.Domain.ValueObjects
{
    public record Document
    {
        public Document(string documentNumber, EDocumentType documentType)
        {
            DocumentNumber = documentNumber;
            DocumentType = documentType;
        }

        public string DocumentNumber { get; init; }
        public EDocumentType DocumentType { get; init; }
    }
}