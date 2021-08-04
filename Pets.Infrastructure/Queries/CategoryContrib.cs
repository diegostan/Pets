using System;
using Dapper.Contrib.Extensions;

namespace Pets.Infrastructure.Queries
{
    [Table("[dbo].[Category]")]
    public class CategoryContrib
    {        
        public Guid Id { get; set; }
        public string Despcription { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }
}