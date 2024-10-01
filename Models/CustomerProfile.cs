﻿using Azure;
using Azure.Data.Tables;
using System;

namespace Part1.Models
{
    public class CustomerProfile : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }

        public CustomerProfile()
        {
            PartitionKey = "CustomerProfile";
            RowKey = Guid.NewGuid().ToString();
        }

    }
}
