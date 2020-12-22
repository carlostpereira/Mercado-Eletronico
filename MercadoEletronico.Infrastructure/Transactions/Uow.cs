using MercadoEletronico.Infrastructure.Contexts;
using System.Threading.Tasks;

namespace MercadoEletronico.Infrastructure.Transactions
{
    public class Uow : IUow
    {
        private readonly MercadoEletronicoContext _context;

        public Uow(MercadoEletronicoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
        }


    }
}
