using ConfigureServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureServices.Services
{
    public class BaseTypeFactory : IBaseTypeFactory
    {
        private readonly Func<int, BaseTypeService> _initFunc;

        public BaseTypeFactory(Func<int, BaseTypeService> initFunc)
        {
            _initFunc = initFunc;
        }

        public BaseTypeService Create(int parameter)
        {
            return _initFunc(parameter);
        }
    }
}
