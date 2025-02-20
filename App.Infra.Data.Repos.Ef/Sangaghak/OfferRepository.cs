using System.ComponentModel.DataAnnotations;
using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.Entities.Requests;
using Connection.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class OfferRepository : IOfferRepository
    {
        #region Dependency Injection
        private readonly AppDbContext _appDbContext;
        public OfferRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #endregion
        #region Create
        public async Task<bool> CreatOffer(Offer offer,CancellationToken cancellationToken)
        {
            var WantedOffer = await _appDbContext.Offers.AsNoTracking().FirstOrDefaultAsync(x => x.RequestId == offer.RequestId && x.ExpertId == offer.ExpertId, cancellationToken);
            if (WantedOffer == null)
            {
                Offer offer1 = new Offer();
                offer1.ExpertId = offer.ExpertId;
                offer1.RequestId = offer.RequestId;
                offer1.OfferedPrice = offer.OfferedPrice;
                offer1.OfferedTime = offer.OfferedTime;
                offer1.Description = offer.Description;
                offer1.Request = offer.Request;
                offer1.Expert = offer1.Expert;
                offer1.SetAt = DateTime.Now;
                await _appDbContext.Offers.AddAsync(offer1, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
        #region Read
        public async Task<List<Offer>> GetAllOffersAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.Offers.AsNoTracking().Where(x =>x.IsDeleted == false).ToListAsync(cancellationToken);
        }

        public async Task<Offer> GetOfferByExpertAsync(int ExpertId,CancellationToken cancellationToken)
        {
            return await _appDbContext.Offers.AsNoTracking().FirstOrDefaultAsync(x => x.ExpertId == ExpertId && x.IsDeleted == false, cancellationToken);
        }

        public async Task<Offer> GetOfferByIdAsync(int Id, CancellationToken cancellationToken)
        {
            return await _appDbContext.Offers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false,cancellationToken);
        }

        public async Task<List<Offer>> GetRequestOffersAsync(int Requestid, CancellationToken cancellationToken)
        {
            return await _appDbContext.Offers.AsNoTracking().Where(x => x.RequestId == Requestid && x.IsDeleted == false).ToListAsync(cancellationToken);
        }
        #endregion
        #region Update
        public async Task<bool> SetOfferAsAcceptedAsync(int OfferId, Request AcceptedRequest,CancellationToken cancellationToken)
        {
            var Offer = await _appDbContext.Offers.FirstOrDefaultAsync(x => x.Id == OfferId,cancellationToken);
            if (Offer != null)
            {
                Offer.AcceptedRequest = AcceptedRequest;
                Offer.AcceptedAt = DateTime.Now;
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateOfferAsync(Offer offer, int OfferId, CancellationToken cancellationToken)
        {
            var Offer = await _appDbContext.Offers.FirstOrDefaultAsync(x => x.Id == OfferId, cancellationToken);
            if (Offer != null)
            {
                Offer.OfferedPrice = offer.OfferedPrice;
                Offer.OfferedTime = offer.OfferedTime;
                Offer.Description = offer.Description;
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteOffer(int OfferId, CancellationToken cancellationToken)
        {
            var Offer = await _appDbContext.Offers.FirstOrDefaultAsync(x => x.Id == OfferId && x.IsDeleted == false,cancellationToken);
            if (Offer != null)
            {
                Offer.IsDeleted = true;
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
    }
}
