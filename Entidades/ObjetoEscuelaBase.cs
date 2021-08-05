using System;
using System.Collections.Generic;
using System.Text;

namespace Etapa1.Entidades
{
    /*
     * Clase sin herencia pero con instancia -> SEALED
       Clase con herencia pero sin instancia -> ABSTRACT
    */
    public abstract class ObjetoEscuelaBase
    {
        public ObjetoEscuelaBase()
        {
            UniqueId = Guid.NewGuid().ToString();
        }

        public String UniqueId { get; private set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return $"{Nombre}, {UniqueId}";
        }
    }
}
