using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Allegory.Sample.Products
{
    public class ProductAlreadyExistsException : BusinessException
    {
        public ProductAlreadyExistsException(string code) : base (SampleDomainErrorCodes.ProductAlreadyExists)
        {
            WithData(nameof(code), code);
        }
    }
}
