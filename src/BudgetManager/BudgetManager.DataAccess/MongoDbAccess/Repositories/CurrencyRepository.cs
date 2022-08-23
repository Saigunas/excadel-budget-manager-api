﻿using BudgetManager.Model;
using BudgetManager.Shared.DataAccess.MongoDB.BaseImplementation;
using BudgetManager.Shared.DataAccess.MongoDB.DatabaseSettings;
using MongoDB.Driver;

namespace BudgetManager.DataAccess.MongoDbAccess.Repositories
{
    public class CurrencyRepository : BaseRepository<Currency>
    {
        public CurrencyRepository(IMongoDbSettings settings, IMongoClient client)
            : base(settings, client)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (client is null)
            {
                throw new ArgumentNullException(nameof(client));
            }
        }
    }
}