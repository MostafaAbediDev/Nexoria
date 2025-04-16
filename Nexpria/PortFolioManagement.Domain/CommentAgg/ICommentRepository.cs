using _0_FrameWork.Domain;
using PortFolioManagement.Application.Contracts.Comment;

namespace PortFolioManagement.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long,  Comment>
    {
        List<CommentViewModel> GetComments();
        List<CommentViewModel> Search(CommentSearchModel searchModel);
    }
}
