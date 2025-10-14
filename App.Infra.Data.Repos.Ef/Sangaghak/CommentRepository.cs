using App.Domain.Core.Sangaghak.Data.Repositories;
using App.Domain.Core.Sangaghak.DTOs.Comments;
using App.Domain.Core.Sangaghak.Entities.Comments;
using App.Domain.Core.Sangaghak.Entities.Users;
using App.Domain.Core.Sangaghak.Enum;
using Connection.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Sangaghak
{
    public class CommentRepository : ICommentRepository
    {
        #region Dependency Injection
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        #endregion
        #region Create
        public async Task<bool> CreateCommentAsync(CommentForCreateDTO comment, CancellationToken cancellationToken)
        {
            try
            {
                var Comment = new Comment()
                {
                    Description = comment.Description,
                    Rate = comment.Rate,
                    ExpertId = comment.ExpertId,
                    RequestId = comment.RequestId,
                    CustomerId = comment.CustomerId,
                    SetAt = DateTime.Now,
                    Status = CommentStatusEnum.Pending
                };
                await _context.Comments.AddAsync(Comment, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception("Exception");
            }
        }
        #endregion
        #region Read
        public async Task<List<CommentDTO>> GetAllCommentsAsync(CancellationToken cancellationToken)
        {
            var query = _context.Comments
                .Include(c => c.Customer)
                    .ThenInclude(cu => cu.UserBase)  
                .Include(c => c.Expert)
                    .ThenInclude(e => e.UserBase)    
                .Include(c => c.Request)
                    .ThenInclude(r => r.City)        
                .Include(c => c.Request)
                    .ThenInclude(r => r.ServicePackage)  
                .AsNoTracking()
                .Where(c => c.IsDeleted == false)
                .Select(c => new
                {
                    c.id,
                    c.Description,
                    c.Rate,
                    c.CustomerId,
                    CustomerFirstName = c.Customer != null && c.Customer.UserBase != null ? c.Customer.UserBase.FirstName : (string?)null,
                    CustomerLastName = c.Customer != null && c.Customer.UserBase != null ? c.Customer.UserBase.LastName : (string?)null,
                    c.ExpertId,
                    ExpertFirstName = c.Expert != null && c.Expert.UserBase != null ? c.Expert.UserBase.FirstName : (string?)null,
                    ExpertLastName = c.Expert != null && c.Expert.UserBase != null ? c.Expert.UserBase.LastName : (string?)null,
                    c.RequestId,
                    PackageId = c.Request != null ? c.Request.ServicePackageId : 0,
                    PackageTitle = c.Request != null && c.Request.ServicePackage != null ? c.Request.ServicePackage.Title : "",
                    CityId = c.Request != null ? c.Request.CityId : 0,
                    CityTitle = c.Request != null && c.Request.City != null ? c.Request.City.Title : "",
                    c.Status,
                    c.SetAt
                });

            var results = await query.ToListAsync(cancellationToken);

            return results.Select(x => new CommentDTO()
            {
                Id = x.id,
                Description = x.Description,
                Rate = x.Rate,
                CustomerId = x.CustomerId,
                CustomerName = string.Join(" ", new[] { x.CustomerFirstName, x.CustomerLastName }.Where(s => !string.IsNullOrEmpty(s))).Trim(),
                ExpertId = x.ExpertId,
                ExpertName = string.Join(" ", new[] { x.ExpertFirstName, x.ExpertLastName }.Where(s => !string.IsNullOrEmpty(s))).Trim(),
                RequestId = x.RequestId,
                PackageId = x.PackageId,
                PackageTiltle = x.PackageTitle,
                CityId = x.CityId,
                CityName = x.CityTitle,
                Status = x.Status,
                SetAt = x.SetAt
            }).ToList();
        }

        public async Task<List<CommentDTO>> GetCommentByCustomerIdAsync(int CustomerId, CancellationToken cancellationToken)
        {
            var query = _context.Comments
                .Include(x => x.Customer)
                    .ThenInclude(cu => cu.UserBase)
                .Include(x => x.Expert)
                    .ThenInclude(e => e.UserBase)
                .Include(x => x.Request)
                    .ThenInclude(r => r.City)
                .Include(x => x.Request)
                    .ThenInclude(r => r.ServicePackage)
                .AsNoTracking()
                .Where(x => x.CustomerId == CustomerId && x.IsDeleted == false)
                .Select(x => new
                {
                    x.id,
                    x.Description,
                    x.Rate,
                    x.CustomerId,
                    CustomerFirstName = x.Customer != null && x.Customer.UserBase != null ? x.Customer.UserBase.FirstName : (string?)null,
                    CustomerLastName = x.Customer != null && x.Customer.UserBase != null ? x.Customer.UserBase.LastName : (string?)null,
                    x.ExpertId,
                    ExpertFirstName = x.Expert != null && x.Expert.UserBase != null ? x.Expert.UserBase.FirstName : (string?)null,
                    ExpertLastName = x.Expert != null && x.Expert.UserBase != null ? x.Expert.UserBase.LastName : (string?)null,
                    x.RequestId,
                    PackageId = x.Request != null ? x.Request.ServicePackageId : 0,
                    PackageTitle = x.Request != null && x.Request.ServicePackage != null ? x.Request.ServicePackage.Title : "",
                    CityId = x.Request != null ? x.Request.CityId : 0,
                    CityTitle = x.Request != null && x.Request.City != null ? x.Request.City.Title : "",
                    x.Status,
                    x.SetAt
                });

            var results = await query.ToListAsync(cancellationToken);

            return results.Select(x => new CommentDTO()
            {
                Id = x.id,
                Description = x.Description,
                Rate = x.Rate,
                CustomerId = x.CustomerId,
                CustomerName = string.Join(" ", new[] { x.CustomerFirstName, x.CustomerLastName }.Where(s => !string.IsNullOrEmpty(s))).Trim(),
                ExpertId = x.ExpertId,
                ExpertName = string.Join(" ", new[] { x.ExpertFirstName, x.ExpertLastName }.Where(s => !string.IsNullOrEmpty(s))).Trim(),
                RequestId = x.RequestId,
                PackageId = x.PackageId,
                PackageTiltle = x.PackageTitle,
                CityId = x.CityId,
                CityName = x.CityTitle,
                Status = x.Status,
                SetAt = x.SetAt
            }).ToList();
        }

        public async Task<List<CommentDTO>> GetCommentByExpertIdAsync(int ExpertId, CancellationToken cancellationToken)
        {
            var query = _context.Comments
                .Include(x => x.Customer)
                    .ThenInclude(cu => cu.UserBase)
                .Include(x => x.Expert)
                    .ThenInclude(e => e.UserBase)
                .Include(x => x.Request)
                    .ThenInclude(r => r.City)
                .Include(x => x.Request)
                    .ThenInclude(r => r.ServicePackage)
                .AsNoTracking()
                .Where(x => x.ExpertId == ExpertId && x.IsDeleted == false && x.Status == CommentStatusEnum.Confirmed)
                .Select(x => new
                {
                    x.id,
                    x.Description,
                    x.Rate,
                    x.CustomerId,
                    CustomerFirstName = x.Customer != null && x.Customer.UserBase != null ? x.Customer.UserBase.FirstName : (string?)null,
                    CustomerLastName = x.Customer != null && x.Customer.UserBase != null ? x.Customer.UserBase.LastName : (string?)null,
                    x.ExpertId,
                    ExpertFirstName = x.Expert != null && x.Expert.UserBase != null ? x.Expert.UserBase.FirstName : (string?)null,
                    ExpertLastName = x.Expert != null && x.Expert.UserBase != null ? x.Expert.UserBase.LastName : (string?)null,
                    x.RequestId,
                    PackageId = x.Request != null ? x.Request.ServicePackageId : 0,
                    PackageTitle = x.Request != null && x.Request.ServicePackage != null ? x.Request.ServicePackage.Title : "",
                    CityId = x.Request != null ? x.Request.CityId : 0,
                    CityTitle = x.Request != null && x.Request.City != null ? x.Request.City.Title : "",
                    x.Status,
                    x.SetAt
                });

            var results = await query.ToListAsync(cancellationToken);

            return results.Select(x => new CommentDTO()
            {
                Id = x.id,
                Description = x.Description,
                Rate = x.Rate,
                CustomerId = x.CustomerId,
                CustomerName = string.Join(" ", new[] { x.CustomerFirstName, x.CustomerLastName }.Where(s => !string.IsNullOrEmpty(s))).Trim(),
                ExpertId = x.ExpertId,
                ExpertName = string.Join(" ", new[] { x.ExpertFirstName, x.ExpertLastName }.Where(s => !string.IsNullOrEmpty(s))).Trim(),
                RequestId = x.RequestId,
                PackageId = x.PackageId,
                PackageTiltle = x.PackageTitle,
                CityId = x.CityId,
                CityName = x.CityTitle,
                Status = x.Status,
                SetAt = x.SetAt
            }).ToList();
        }

        public async Task<List<CommentDTO>> GetPendingCommentAsync(CancellationToken cancellationToken)
        {
            var query = _context.Comments
                .Include(x => x.Customer)
                    .ThenInclude(cu => cu.UserBase)
                .Include(x => x.Expert)
                    .ThenInclude(e => e.UserBase)
                .Include(x => x.Request)
                    .ThenInclude(r => r.City)
                .Include(x => x.Request)
                    .ThenInclude(r => r.ServicePackage)
                .AsNoTracking()
                .Where(x => x.Status == CommentStatusEnum.Pending && x.IsDeleted == false)
                .Select(x => new
                {
                    x.id,
                    x.Description,
                    x.Rate,
                    x.CustomerId,
                    CustomerFirstName = x.Customer != null && x.Customer.UserBase != null ? x.Customer.UserBase.FirstName : (string?)null,
                    CustomerLastName = x.Customer != null && x.Customer.UserBase != null ? x.Customer.UserBase.LastName : (string?)null,
                    x.ExpertId,
                    ExpertFirstName = x.Expert != null && x.Expert.UserBase != null ? x.Expert.UserBase.FirstName : (string?)null,
                    ExpertLastName = x.Expert != null && x.Expert.UserBase != null ? x.Expert.UserBase.LastName : (string?)null,
                    x.RequestId,
                    PackageId = x.Request != null ? x.Request.ServicePackageId : 0,
                    PackageTitle = x.Request != null && x.Request.ServicePackage != null ? x.Request.ServicePackage.Title : "",
                    CityId = x.Request != null ? x.Request.CityId : 0,
                    CityTitle = x.Request != null && x.Request.City != null ? x.Request.City.Title : "",
                    x.Status,
                    x.SetAt
                });

            var results = await query.ToListAsync(cancellationToken);

            return results.Select(x => new CommentDTO()
            {
                Id = x.id,
                Description = x.Description,
                Rate = x.Rate,
                CustomerId = x.CustomerId,
                CustomerName = string.Join(" ", new[] { x.CustomerFirstName, x.CustomerLastName }.Where(s => !string.IsNullOrEmpty(s))).Trim(),
                ExpertId = x.ExpertId,
                ExpertName = string.Join(" ", new[] { x.ExpertFirstName, x.ExpertLastName }.Where(s => !string.IsNullOrEmpty(s))).Trim(),
                RequestId = x.RequestId,
                PackageId = x.PackageId,
                PackageTiltle = x.PackageTitle,
                CityId = x.CityId,
                CityName = x.CityTitle,
                Status = x.Status,
                SetAt = x.SetAt
            }).ToList();
        }

        public async Task<int> GetPendingCommentCountAsync(CancellationToken cancellationToken)
        {
            return await _context.Comments.Where(x => x.Status == CommentStatusEnum.Pending && x.IsDeleted == false).CountAsync(cancellationToken);
        }
        #endregion
        #region Update
        public async Task<bool> UpdateCommentStatusAsync(int CommentId, CommentStatusEnum status, CancellationToken cancellationToken)
        {
            var Comment = await _context.Comments.FirstOrDefaultAsync(x => x.id == CommentId, cancellationToken);
            if (Comment != null)
            {
                Comment.Status = status;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteCommentStatusAsync(int CommentId, CancellationToken cancellationToken)
        {
            var Comment = await _context.Comments.FirstOrDefaultAsync(x => x.id == CommentId && x.IsDeleted == false, cancellationToken);
            if (Comment != null)
            {
                Comment.IsDeleted = true;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion
    }
}