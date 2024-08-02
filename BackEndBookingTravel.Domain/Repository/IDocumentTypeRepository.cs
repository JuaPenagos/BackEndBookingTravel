using BackEndBookingTravel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Domain.Repository
{
    public interface IDocumentTypeRepository
    {
        Task<List<DocumentType>> GetAllDocumentTypesAsync();

        Task<DocumentType?> CreateDocumentTypeAsync(DocumentType documentType);
    }
}
