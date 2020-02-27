using BusinessLogicLayer.BaseBLL;
using BusinessLogicLayer.Contracts;
using Models;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class TransferMoneyManager : BaseManager<TransferMoney>, ITransferMoneyManager 
    {
        private readonly ITransferMoneyRepository _iTransferMoneyRepository;

        public TransferMoneyManager(ITransferMoneyRepository iTransferMoneyRepository)
                                    : base(iTransferMoneyRepository)
        {
            _iTransferMoneyRepository = iTransferMoneyRepository;
        }
    }
}
