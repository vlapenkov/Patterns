using ConfigureServices.Models;
using System;

namespace ConfigureServices.Services
{
    public class BaseTypeFactory : IBaseTypeFactory
    {
        private readonly Func<int, ITypeService> _initFunc;

        public BaseTypeFactory(Func<int, ITypeService> initFunc)
        {
            _initFunc = initFunc;
        }

        public ITypeService Create(int parameter)
        {
            return _initFunc(parameter);
        }
    }
}
