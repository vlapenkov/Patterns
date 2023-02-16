using ConfigureServices.Models;

namespace ConfigureServices.Services
{
    public interface IBaseTypeFactory
    {
        ITypeService Create(int parameter);
    }
}