using App.Domain.Core.Sangaghak.App.Domain.Core;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Service;
using Microsoft.IdentityModel.Tokens;

namespace SangaghakAppService.Sangaghak.Requests
{
    public class OfferAppService : IOfferAppService
    {
        private readonly IOfferService _offerService;
        private readonly IUserBaseService _userBaseService;
        private readonly IRequestAppService _requestAppService;
        private readonly IServicePackageAppService _servicePackageAppService;
        public OfferAppService(IOfferService offerService, 
            IUserBaseService userBaseService,
            IRequestAppService requestAppService,
            IServicePackageAppService servicePackageAppService)
        {
            _offerService = offerService;
            _userBaseService = userBaseService;
            _requestAppService = requestAppService;
            _servicePackageAppService = servicePackageAppService;
        }

        public async Task<bool> CreatOffer(OfferForCreateAndUpdateDTO Model, CancellationToken cancellationToken)
        {
            return await _offerService.CreatOffer(Model, cancellationToken);
        }

        public async Task<bool> DeleteOffer(int OfferId, CancellationToken cancellationToken)
        {
            return await _offerService.DeleteOffer(OfferId, cancellationToken);
        }

        public async Task<List<OfferDTO>> GetAllExpertOffersByExpertIdAsync(int ExpertId, CancellationToken cancellationToken)
        {
            var wantedOffers= await _offerService.GetAllExpertOffersByExpertIdAsync(ExpertId, cancellationToken);
            if (!wantedOffers.IsNullOrEmpty())
            {
                foreach (var offers in wantedOffers)
                {
                    if(offers.RequestId==0)
                    {
                        break;
                        //اینجا لاگ میخواد
                    }
                    else
                    {
                        var packageId = await _requestAppService.GetRequestPackageIdByRequestIdAsync(offers.RequestId, cancellationToken);
                        if (packageId!=0)
                        {
                            break;
                            //اینجا لاگ میخواد
                        }
                        else
                        {
                            offers.PackageTitle= await _servicePackageAppService.GetPackageTiltleById(packageId, cancellationToken); 
                        }
                    }
                }
            }
            return wantedOffers;
        }

        public async Task<List<OfferDTO>> GetAllOffersAsync(CancellationToken cancellationToken)
        {
            return await _offerService.GetAllOffersAsync(cancellationToken);
        }

        public async Task<int> GetExpertIdByOfferIdAysnc(int OfferId, CancellationToken cancellationToken)
        {
            return await _offerService.GetExpertIdByOfferIdAysnc(OfferId, cancellationToken);
        }

        public async Task<OfferDTO> GetOfferByExpertAsync(int ExpertId, CancellationToken cancellationToken)
        {
            return await _offerService.GetOfferByExpertAsync(ExpertId, cancellationToken);
        }

        public async Task<OfferDTO> GetOfferByIdAsync(int Id, CancellationToken cancellationToken)
        {
            return await _offerService.GetOfferByIdAsync(Id, cancellationToken);
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

        public async Task<bool> UpdateOfferAsync(OfferForCreateAndUpdateDTO offer, int OfferId, CancellationToken cancellationToken)
        {
            return await _offerService.UpdateOfferAsync(offer, OfferId,cancellationToken);
        }
    }
}
