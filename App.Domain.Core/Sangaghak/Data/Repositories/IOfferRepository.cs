using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Entities.Requests;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface IOfferRepository
    {
        #region Create
        public Task<bool> CreatOffer(OfferForCreateAndUpdateDTO Model, CancellationToken cancellationToken);
        #endregion
        #region Read
        public Task<int> GetAllExpertOffersCount(int expertId, CancellationToken cancellationToken);
        public Task<List<OfferDTO>> GetAllOffersAsync(CancellationToken cancellationToken);
        public Task<List<OfferDTO>> GetRequestOffersAsync(int Requestid, CancellationToken cancellationToken);
        public Task<OfferDTO> GetOfferByIdAsync(int Id, CancellationToken cancellationToken);
        public Task<OfferDTO> GetOfferByExpertAsync(int ExpertId, CancellationToken cancellationToken);
        public Task<int> GetExpertIdByOfferIdAysnc(int OfferId, CancellationToken cancellationToken);
        public Task<List<OfferDTO>> GetAllExpertOffersByExpertIdAsync(int ExpertId, CancellationToken cancellationToken);
        #endregion
        #region Update
        public Task<bool> UpdateOfferAsync(OfferForCreateAndUpdateDTO offer, int OfferId, CancellationToken cancellationToken);
        #endregion
        #region Delete
        public Task<bool> DeleteOffer(int OfferId, CancellationToken cancellationToken);
        #endregion
    }
}
