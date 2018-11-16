using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EMDI.Business.Entities
{
    /// <summary>
    /// Entidad Base
    /// </summary>
    /// <typeparam name="T"> Clase Genérica de entidad </typeparam>
    public abstract class BaseEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
