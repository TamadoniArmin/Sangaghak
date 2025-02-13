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
        public Task<bool> CreatOffer(Offer offer);
        public Task<List<Offer>> GetAllOffersAsync();
        public Task<List<Offer>> GetRequestOffersAsync(int Requestid);
        public Task<Offer> GetOfferByIdAsync(int Id);
        public Task<Offer> GetOfferByExpertAsync(int ExpertId);
        public Task<bool> UpdateOfferAsync(Offer offer, int OfferId);
        public Task<bool> SetOfferAsAcceptedAsync(int OfferId, int RequestId, Request AcceptedRequest);
        public Task<bool> DeleteOffer(int OfferId);
    }
}
