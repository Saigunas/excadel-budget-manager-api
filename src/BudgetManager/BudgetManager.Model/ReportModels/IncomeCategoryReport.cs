﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BudgetManager.Model.ReportModels
{
    public class IncomeCategoryReport
    {
        public string CategoryName { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? TransactionSum { get; set; }
    }
}
