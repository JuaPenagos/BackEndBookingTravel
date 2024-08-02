using BackEndBookingTravel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Application.Interfaces
{
    public interface IDocumentTypeService
    {
        Task<List<DocumentType>> GetAllDocumentTypesAsync();
    }
}
