using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Sangaghak.Entities.Requests;

namespace App.Domain.Core.Sangaghak.Data.Repositories
{
    public interface IOfferRepository
    {
        #region Create
        public Task<bool> CreatOffer(Offer offer);
        #endregion
        #region Read
        public Task<List<Offer>> GetAllOffersAsync();
        public Task<List<Offer>> GetRequestOffersAsync(int Requestid);
        public Task<Offer> GetOfferByIdAsync(int Id);
        public Task<Offer> GetOfferByExpertAsync(int ExpertId);
        #endregion
        #region Update
        public Task<bool> UpdateOfferAsync(Offer offer, int OfferId);
        public Task<bool> SetOfferAsAcceptedAsync(int OfferId, int RequestId, Request AcceptedRequest);
        #endregion
        #region Delete
        public Task<bool> DeleteOffer(int OfferId);
        #endregion
    }
}
