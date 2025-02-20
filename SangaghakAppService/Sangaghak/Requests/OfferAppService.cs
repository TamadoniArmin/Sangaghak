using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.Requests
{
    public class OfferAppService : IOfferAppService
    {
        private readonly IOfferService _offerService;
        public OfferAppService(IOfferService offerService)
        {
            _offerService = offerService;
        }
        public async Task<bool> CreatOffer(Offer offer, CancellationToken cancellationToken)
        {
            return await _offerService.CreatOffer(offer, cancellationToken);
        }

        public async Task<bool> DeleteOffer(int OfferId, CancellationToken cancellationToken)
        {
            return await _offerService.DeleteOffer(OfferId, cancellationToken);
        }

        public async Task<List<Offer>> GetAllOffersAsync(CancellationToken cancellationToken)
        {
            return await _offerService.GetAllOffersAsync(cancellationToken);
        }

        public async Task<Offer> GetOfferByExpertAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _offerService.GetOfferByExpertAsync(ExpertId, cancellationToken);
        }

        public async Task<Offer> GetOfferByIdAsync(int Id, CancellationToken cancellationToken)
        {
            return await _offerService.GetOfferByIdAsync(Id, cancellationToken);
        }

        public async Task<List<Offer>> GetRequestOffersAsync(int Requestid, CancellationToken cancellationToken)
        {
            return await _offerService.GetRequestOffersAsync(Requestid, cancellationToken);
        }

        public async Task<bool> SetOfferAsAcceptedAsync(int OfferId, Request AcceptedRequest, CancellationToken cancellationToken)
        {
            return await _offerService.SetOfferAsAcceptedAsync(OfferId, AcceptedRequest,cancellationToken);
        }

        public async Task<bool> UpdateOfferAsync(Offer offer, int OfferId, CancellationToken cancellationToken)
        {
            return await _offerService.UpdateOfferAsync(offer, OfferId, cancellationToken);
        }
    }
}
