using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakService.Sangaghak.Requests
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        public OfferService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        public async Task<bool> CreatOffer(Offer offer, CancellationToken cancellationToken)
        {
            return await _offerRepository.CreatOffer(offer, cancellationToken);
        }

        public async Task<bool> DeleteOffer(int OfferId, CancellationToken cancellationToken)
        {
            return await _offerRepository.DeleteOffer(OfferId, cancellationToken);
        }

        public async Task<List<Offer>> GetAllOffersAsync(CancellationToken cancellationToken)
        {
            return await _offerRepository.GetAllOffersAsync(cancellationToken);
        }

        public async Task<Offer> GetOfferByExpertAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _offerRepository.GetOfferByExpertAsync(ExpertId, cancellationToken);
        }

        public async Task<Offer> GetOfferByIdAsync(int Id, CancellationToken cancellationToken)
        {
            return await _offerRepository.GetOfferByIdAsync(Id, cancellationToken);
        }

        public async Task<List<Offer>> GetRequestOffersAsync(int Requestid, CancellationToken cancellationToken)
        {
            return await _offerRepository.GetRequestOffersAsync(Requestid, cancellationToken);
        }

        public async Task<bool> SetOfferAsAcceptedAsync(int OfferId, Request AcceptedRequest, CancellationToken cancellationToken)
        {
            return await _offerRepository.SetOfferAsAcceptedAsync(OfferId, AcceptedRequest,cancellationToken);
        }

        public async Task<bool> UpdateOfferAsync(Offer offer, int OfferId, CancellationToken cancellationToken)
        {
            return await _offerRepository.UpdateOfferAsync(offer, OfferId, cancellationToken);
        }
    }
}
