using System.Threading.Tasks;

namespace Bookstore.Data.Queries
{
    public interface IQueryObject<in TInput, TResult>
    {
        Task<TResult> ExecuteQuery(TInput input);
    }
}