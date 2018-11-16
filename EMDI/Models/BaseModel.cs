
namespace EMDI.API.Models
{
    /// <summary>
    /// Entidad Base
    /// </summary>
    /// <typeparam name="T"> Clase Genérica de modelo </typeparam>
    public abstract class BaseModel<T>
    {
        public virtual T Id { get; set; }
    }
}
