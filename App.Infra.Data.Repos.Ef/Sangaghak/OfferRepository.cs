using System.ComponentModel.DataAnnotations;
using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Requests;
using App.Domain.Core.Sangaghak.Entities.Requests;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;
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
        public async Task<bool> CreatOffer(OfferForCreateAndUpdateDTO Model, CancellationToken cancellationToken)
        {
            var WantedOffer = await _appDbContext.Offers.AsNoTracking().FirstOrDefaultAsync(x => x.RequestId == Model.RequestId && x.ExpertId == Model.ExpertId, cancellationToken);
            if (WantedOffer == null)
            {
                Offer offer1 = new Offer();
                offer1.ExpertId = Model.ExpertId;
                offer1.RequestId = Model.RequestId;
                offer1.OfferedPrice = Model.OfferedPrice;
                offer1.OfferedTime = Model.OfferedTime;
                offer1.Description = Model.Description;
                offer1.Status=OfferStatusEnum.Pending;
                offer1.SetAt = DateTime.Now;
                await _appDbContext.Offers.AddAsync(offer1, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
        #region Read
        public async Task<List<OfferDTO>> GetAllOffersAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.Offers
                .AsNoTracking()
                .Where(x =>x.IsDeleted == false)
                .Select(x=> new OfferDTO()
                {
                    Id = x.Id,
                    ExpertId = x.ExpertId,
                    RequestId = x.RequestId,
                    OfferedPrice = x.OfferedPrice,
                    OfferedTime = x.OfferedTime,
                    Description = x.Description,
                    Status = x.Status,
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<OfferDTO> GetOfferByExpertAsync(int ExpertId,CancellationToken cancellationToken)
        {
            var FindOffer= await _appDbContext.Offers.AsNoTracking().FirstOrDefaultAsync(x => x.ExpertId == ExpertId && x.IsDeleted == false, cancellationToken);
            if (FindOffer == null) return null;
            var OfferToSend = new OfferDTO()
            {
                Id = FindOffer.Id,
                ExpertId = FindOffer.ExpertId,
                RequestId = FindOffer.RequestId,
                OfferedPrice = FindOffer.OfferedPrice,
                OfferedTime = FindOffer.OfferedTime,
                Description = FindOffer.Description,
                Status = FindOffer.Status,
            };
            return OfferToSend;
        }

        public async Task<OfferDTO> GetOfferByIdAsync(int Id, CancellationToken cancellationToken)
        {
            var FindOffer = await _appDbContext.Offers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false, cancellationToken);
            if (FindOffer == null) return null;
            var OfferToSend = new OfferDTO()
            {
                Id = FindOffer.Id,
                ExpertId = FindOffer.ExpertId,
                RequestId = FindOffer.RequestId,
                OfferedPrice = FindOffer.OfferedPrice,
                OfferedTime = FindOffer.OfferedTime,
                Description = FindOffer.Description,
                Status = FindOffer.Status,
            };
            return OfferToSend;
        }

        public async Task<List<OfferDTO>> GetRequestOffersAsync(int Requestid, CancellationToken cancellationToken)
        {
            return await _appDbContext.Offers
                .AsNoTracking()
                .Where(x => x.RequestId == Requestid && x.IsDeleted == false)
                .Select(x => new OfferDTO()
                {
                    Id = x.Id,
                    ExpertId = x.ExpertId,
                    RequestId = x.RequestId,
                    OfferedPrice = x.OfferedPrice,
                    OfferedTime = x.OfferedTime,
                    Description = x.Description,
                    Status = x.Status,
                }
                ).ToListAsync(cancellationToken);
        }
        public async Task<int> GetExpertIdByOfferIdAysnc(int OfferId, CancellationToken cancellationToken)
        {
            var Offer= await _appDbContext.Offers.FirstOrDefaultAsync(x=>x.Id == OfferId,cancellationToken);
            if (Offer==null) return 0;
            else return Offer.ExpertId;
        }
        #endregion
        #region Update

        public async Task<bool> UpdateOfferAsync(OfferForCreateAndUpdateDTO offer, int OfferId, CancellationToken cancellationToken)
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
