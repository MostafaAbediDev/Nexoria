using _0_FrameWork.Infrastructure;
using PortFolioManagement.Application.Contracts.Comment;
using PortFolioManagement.Domain.CommentAgg;

namespace PortFolioManagement.Infrastructure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly PortFolioContext _context;

        public CommentRepository(PortFolioContext context) : base(context)
        {
            _context = context;
        }


        public List<CommentViewModel> GetComments()
        {
            return _context.Comments.Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                Subject = x.Subject,
                IsCanceled = x.IsCanceled,
                IsConfirmed = x.IsConfirmed,
            }).ToList();
        }


        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var query = _context.Comments
                .Select(x => new CommentViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Subject = x.Subject,
                    Message = x.Message,
                    IsCanceled = x.IsCanceled,
                    IsConfirmed = x.IsConfirmed,
                    CommentDate = x.CreationDate.ToString()
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
                query = query.Where(x => x.Email.Contains(searchModel.Email));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
