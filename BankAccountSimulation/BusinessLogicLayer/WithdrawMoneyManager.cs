using BusinessLogicLayer.BaseBLL;
using BusinessLogicLayer.Contracts;
using Models;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class WithdrawMoneyManager : BaseManager<WithdrawMoney>, IWithdrawMoneyManager 
    {
        private readonly IWithdrawMoneyRepository _iWithdrawMoneyRepository;

        public WithdrawMoneyManager(IWithdrawMoneyRepository iWithdrawMoneyRepository) : base(iWithdrawMoneyRepository)
        {
            _iWithdrawMoneyRepository = iWithdrawMoneyRepository;
        }
    }
}
