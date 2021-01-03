using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace DepedencyInjection
{
    [ExposeServices(typeof(ITaxCalculator))]
    public class TaxCalculator3 : ICalculator, ITaxCalculator, ICanCalculate, ITransientDependency
    {
        //TaxCalculator class only exposes ITaxCalculator interface. That means you can only inject ITaxCalculator, but can not inject TaxCalculator or ICalculator in your application.

        //-----------Exposed Services by Convention
        //If you do not specify which services to expose, ABP expose services by convention.So taking the TaxCalculator defined above;

        //The class itself is exposed by default. That means you can inject it by TaxCalculator class.
        //Default interfaces are exposed by default. Default interfaces are determined by naming convention.In this example, ICalculator and ITaxCalculator are default interfaces of TaxCalculator, but ICanCalculate is not.
    }

    public interface ICalculator { }
    public interface ITaxCalculator { }
    public interface ICanCalculate { }
}
