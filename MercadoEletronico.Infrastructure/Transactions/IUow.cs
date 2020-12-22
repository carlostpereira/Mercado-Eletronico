using System.Threading.Tasks;

namespace MercadoEletronico.Infrastructure.Transactions
{
    public interface IUow
    {
        Task Commit();
        void Rollback();
    }
}
