using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Requests;
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

        public async Task<bool> CreatOffer(OfferForCreateAndUpdateDTO Model, CancellationToken cancellationToken)
        {
            return await _offerRepository.CreatOffer(Model, cancellationToken);
        }

        public async Task<bool> DeleteOffer(int OfferId, CancellationToken cancellationToken)
        {
            return await _offerRepository.DeleteOffer(OfferId, cancellationToken);
        }

        public async Task<List<OfferDTO>> GetAllOffersAsync(CancellationToken cancellationToken)
        {
            return await _offerRepository.GetAllOffersAsync(cancellationToken);
        }

        public async Task<int> GetExpertIdByOfferIdAysnc(int OfferId, CancellationToken cancellationToken)
        {
            return await _offerRepository.GetExpertIdByOfferIdAysnc(OfferId, cancellationToken);
        }

        public async Task<OfferDTO> GetOfferByExpertAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _offerRepository.GetOfferByExpertAsync(ExpertId, cancellationToken);
        }

        public async Task<OfferDTO> GetOfferByIdAsync(int Id, CancellationToken cancellationToken)
        {
            return await _offerRepository.GetOfferByIdAsync(Id, cancellationToken);
        }

        public async Task<List<OfferDTO>> GetRequestOffersAsync(int Requestid, CancellationToken cancellationToken)
        {
            return await _offerRepository.GetRequestOffersAsync(Requestid, cancellationToken);
        }

        public async Task<bool> UpdateOfferAsync(OfferForCreateAndUpdateDTO offer, int OfferId, CancellationToken cancellationToken)
        {
            return await _offerRepository.UpdateOfferAsync(offer, OfferId,cancellationToken);
        }
    }
}
