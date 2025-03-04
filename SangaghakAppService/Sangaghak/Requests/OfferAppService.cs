using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Service;

namespace SangaghakAppService.Sangaghak.Requests
{
    public class OfferAppService : IOfferAppService
    {
        private readonly IOfferService _offerService;
        private readonly IUserBaseService _userBaseService;
        public OfferAppService(IOfferService offerService, IUserBaseService userBaseService)
        {
            _offerService = offerService;
            _userBaseService = userBaseService;
        }

        public Task<bool> CreatOffer(OfferForCreateAndUpdateDTO Model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOffer(int OfferId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<OfferDTO>> GetAllOffersAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetExpertIdByOfferIdAysnc(int OfferId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OfferDTO> GetOfferByExpertAsync(int ExpertId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OfferDTO> GetOfferByIdAsync(int Id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OfferDTO>> GetRequestOffersAsync(int Requestid, CancellationToken cancellationToken)
        {
            var Offers= await _offerService.GetRequestOffersAsync(Requestid, cancellationToken);
            foreach (var offer in Offers)
            {
                offer.ExpertFullName = await _userBaseService.GetExpertNameByExpertIdAsync(offer.ExpertId,cancellationToken)??string.Empty;
            }
            return Offers;
        }

        public Task<bool> UpdateOfferAsync(OfferForCreateAndUpdateDTO offer, int OfferId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
