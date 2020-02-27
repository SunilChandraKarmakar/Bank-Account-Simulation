using BusinessLogicLayer.BaseBLL;
using BusinessLogicLayer.Contracts;
using Models;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class TransactionsTypeManager : BaseManager<TransactionsType>, ITransactionsTypeManager
    {
        private readonly ITransactionsTypeRepository _iTransactionsTypeRepository;

        public TransactionsTypeManager(ITransactionsTypeRepository iTransactionsTypeRepository) 
                                        : base(iTransactionsTypeRepository)
        {
            _iTransactionsTypeRepository = iTransactionsTypeRepository;
        }
    }
}
