using BackEndBookingTravel.Application.Interfaces;
using BackEndBookingTravel.Domain.Entities;
using BackEndBookingTravel.Domain.Repository;
using BackEndBookingTravel.Utility.Helpers;
using BackEndBookingTravel.Utility;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEndBookingTravel.Application.Dtos;

namespace BackEndBookingTravel.Application.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly ILog _logger;
        public DocumentTypeService(IDocumentTypeRepository documentTypeRepository, ILog logger) {
        _documentTypeRepository = documentTypeRepository;
        _logger = logger;
        }

        public async Task<List<DocumentType>> GetAllDocumentTypesAsync()
        {
            return await _documentTypeRepository.GetAllDocumentTypesAsync();
        }

    }
}
