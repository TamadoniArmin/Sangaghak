using App.Domain.Core.Sangaghak.Entities.Requests;

namespace App.Domain.Core.Sangaghak.App.Domain.Core
{
    public interface IOfferAppService
    {
        #region Create
        public Task<bool> CreatOffer(Offer offer, CancellationToken cancellationToken);
        #endregion
        #region Read
        public Task<List<Offer>> GetAllOffersAsync(CancellationToken cancellationToken);
        public Task<List<Offer>> GetRequestOffersAsync(int Requestid, CancellationToken cancellationToken);
        public Task<Offer> GetOfferByIdAsync(int Id, CancellationToken cancellationToken);
        public Task<Offer> GetOfferByExpertAsync(int ExpertId, CancellationToken cancellationToken);
        #endregion
        #region Update
        public Task<bool> UpdateOfferAsync(Offer offer, int OfferId, CancellationToken cancellationToken);
        public Task<bool> SetOfferAsAcceptedAsync(int OfferId, Request AcceptedRequest, CancellationToken cancellationToken);
        #endregion
        #region Delete
        public Task<bool> DeleteOffer(int OfferId, CancellationToken cancellationToken);
        #endregion
    }
}
