using System.ComponentModel.DataAnnotations;
using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Requests;
using Connection.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class OfferRepository : IOfferRepository
    {
        private readonly AppDbContext _appDbContext;
        public OfferRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> CreatOffer(Offer offer)
        {
            var WantedOffer= await _appDbContext.Offers.AsNoTracking().FirstOrDefaultAsync(x=>x.RequestId==offer.RequestId && x.ExpertId==offer.ExpertId);
            if (WantedOffer == null)
            {
                Offer offer1 = new Offer();
                offer1.ExpertId = offer.ExpertId;
                offer1.RequestId = offer.RequestId;
                offer1.OfferedPrice= offer.OfferedPrice;
                offer1.OfferedTime= offer.OfferedTime;
                offer1.Description= offer.Description;
                offer1.Request=offer.Request;
                offer1.Expert=offer1.Expert;
                offer1.SetAt = DateTime.Now;
                await _appDbContext.Offers.AddAsync(offer1);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteOffer(int OfferId)
        {
            var Offer=await _appDbContext.Offers.FirstOrDefaultAsync(x=>x.Id==OfferId);
            if(Offer != null)
            {
                _appDbContext.Offers.Remove(Offer);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Offer>> GetAllOffersAsync()
        {
            return await _appDbContext.Offers.AsNoTracking().ToListAsync();
        }

        public async Task<Offer> GetOfferByExpertAsync(int ExpertId)
        {
            return await _appDbContext.Offers.AsNoTracking().FirstOrDefaultAsync(x=>x.ExpertId==ExpertId);    
        }

        public async Task<Offer> GetOfferByIdAsync(int Id)
        {
            return await _appDbContext.Offers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Offer>> GetRequestOffersAsync(int Requestid)
        {
            return await _appDbContext.Offers.AsNoTracking().Where(x => x.RequestId == Requestid).ToListAsync();
        }

        public async Task<bool> SetOfferAsAcceptedAsync(int OfferId, int RequestId, Request AcceptedRequest)
        {
            var Offer = await _appDbContext.Offers.FirstOrDefaultAsync(x => x.Id == OfferId);
            if (Offer != null)
            {
                Offer.AcceptedRequest = AcceptedRequest;
                Offer.AcceptedRequestId = RequestId;
                Offer.AcceptedAt=DateTime.Now;
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateOfferAsync(Offer offer, int OfferId)
        {
            var Offer = await _appDbContext.Offers.FirstOrDefaultAsync(x => x.Id == OfferId);
            if (Offer != null)
            {
                Offer.OfferedPrice=offer.OfferedPrice;
                Offer.OfferedTime=offer.OfferedTime;
                Offer.Description=offer.Description;
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
