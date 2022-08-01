﻿using BudgetManager.CQRS.Queries.WalletQueries;
using BudgetManager.Model;
using BudgetManager.SDK.DTOs;
using BudgetManager.Shared.DataAccess.MongoDB.BaseImplementation;
using MediatR;
using MongoDB.Driver;

namespace BudgetManager.CQRS.Handlers.WalletHandlers
{
    public class GetUserWalletTransactionsHandler : IRequestHandler<GetUserWalletTransactionsQuery, WalletTransactionsDTO>
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Transaction> _transactionRepository;

        public GetUserWalletTransactionsHandler(IBaseRepository<User> userRepository, IBaseRepository<Transaction> transactionRepository)
        {
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<WalletTransactionsDTO> Handle(GetUserWalletTransactionsQuery request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.FindByIdAsync(request.userId, cancellationToken);
            Wallet wallet = user.Wallets.Find(w => w.Id == request.walletId);

            var builder = Builders<Transaction>.Filter;
            var transactionFilter = builder.Eq(t => t.UserId, request.userId) & builder.Eq(t => t.WalletId, request.walletId);
            var userWalletTransactions = await _transactionRepository.FilterBy(transactionFilter, cancellationToken);

            WalletTransactionsDTO walletTransactions = new WalletTransactionsDTO
            {
                Wallet = wallet,
                IsDefaultWallet = wallet.Id == request.walletId,
                Transactions = userWalletTransactions.ToList(),
            };

            return walletTransactions;
        }
    }
}