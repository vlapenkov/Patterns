using ConfigureServices.Models;

namespace ConfigureServices.Services
{
    public interface IBaseTypeFactory
    {
        BaseTypeService Create(int parameter);
    }
}