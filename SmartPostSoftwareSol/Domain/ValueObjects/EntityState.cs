using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public enum EntityState
    {
        Unchanged,  // Estado sin cambios
        Added,      // Estado añadido (nueva entidad)
        Modified,   // Estado modificado
        Deleted     // Estado eliminado
    }
}
