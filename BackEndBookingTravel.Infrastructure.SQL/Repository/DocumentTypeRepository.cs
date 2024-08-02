using BackEndBookingTravel.Domain.Entities;
using BackEndBookingTravel.Domain.Repository;
using BackEndBookingTravel.Infrastructure.SQL.Context;
using BackEndBookingTravel.Infrastructure.SQL.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Infrastructure.SQL.Repository
{
    public class DocumentTypeRepository : BaseRepository<DocumentType>, IDocumentTypeRepository
    {
        public DocumentTypeRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<DocumentType>> GetAllDocumentTypesAsync()
        {
            var documentTypes = await GetAsync();
            return documentTypes.ToList();
        }

        public async Task<DocumentType?> CreateDocumentTypeAsync(DocumentType documentType)
        {
            var documentTypeDB = await AddAsync(documentType);
            return documentTypeDB;
        }
    }
}
