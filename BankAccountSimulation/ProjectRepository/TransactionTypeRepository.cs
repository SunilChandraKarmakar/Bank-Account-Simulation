using Models;
using ProjectRepository.BaseRpository;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRepository
{
    public class TransactionTypeRepository : BaseRepository<TransactionsType>, ITransactionsTypeRepository 
    {
    }
}
