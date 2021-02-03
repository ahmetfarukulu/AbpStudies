using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Allegory.Sample.Products
{
    public class Product : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; private set; }
        public string Name { get; set; }
        private Product() { }
        internal Product(Guid id, [NotNull] string code, [CanBeNull] string name = null) : base(id)
        {
            SetCode(code);
            Name = name;
        }
        internal Product ChangeCode([NotNull] string code)
        {
            SetCode(code);
            return this;
        }
        private void SetCode([NotNull] string code)
        {
            Code = Check.NotNullOrWhiteSpace(code, nameof(code), maxLength: ProductConsts.MaxCodeLength);
        }
    }
}
