using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using Etapa1.Entidades;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            //Printer.Beep(10000, cantidad:10);
            ImpimirCursosEscuela(engine.Escuela);

            var listaObjetos = engine.GetObjetosEscuela();

            /*for(var i = 0; i < 3; i++)
            {
                Printer.DrawLine(20);
            }*/

            //Printer.WriteTitle("Pruebas de Polimorfismo");
            //Printer.DrawLine();

            /*
             * Las múltiples formas que puede obtener un objeto si comparte la misma clase o interfaz
             * Puede hacerse de dos formas:
             * - Interfaces: Son un contrato que obliga a una clase a implementar las propiedades y/o métodos definidos
             * - Clases abstractas: Son clases que no se pueden instanciar, sólo pueden ser implementadas a través de la herencia
             * 
             * Un objeto de la superclase puede almacenar un objeto de cualquier subclase en una relación de herencia.
             * La clase padre es compatible con sus hijos, pero no al revés.
             * 
             * Un objeto hijo que hereda de una clase padre puede ser tratado como objeto padre, pero al ser convertido en objeto padre ya no se podrá acceder a los atributos del objeto hijo.
             * Un objeto padre no puede tratarse como un objeto hijo a menos que el objeto padre estuviera guardando un objeto hijo.
            */

            /*var alumnoTest = new Alumno { Nombre = "Claire UnderWood" };

            ObjetoEscuelaBase obj = alumnoTest;

            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre} \n Id: {alumnoTest.UniqueId} \n Tipo: {alumnoTest.GetType()}");

            Printer.WriteTitle("Objeto Escuela");
            WriteLine($"Objeto: {obj.Nombre} \n Id: {obj.UniqueId}  \n Tipo: {obj.GetType()}");
            */

            /*
             * No se puede mientras la clase sea abstracta
            var objDummy = new ObjetoEscuelaBase()
            {
                Nombre = "Frank Underwood"
            };

            * Nos deja compilar pero arroja error
            alumnoTest = (Alumno)objDummy;
            */
            /*
            var evaluacion = new Evaluacion()
            {
                Nombre = "Evaluación de Matemáticas",
                Nota = 4.5f
            };

            Printer.WriteTitle("Objeto Evaluación");
            WriteLine($"Objeto: {evaluacion.Nombre} \n Nota: {evaluacion.Nota} \n Id: {evaluacion.UniqueId}  \n Tipo: {evaluacion.GetType()}");

            obj = evaluacion; // Aquí no encontramos nota, evaluación se convierte en su padre
            */
            //alumnoTest = evaluacion; // No se puede
            //alumnoTest = (ObjetoEscuelaBase) evaluacion; // No se puede
            //alumnoTest = (Alumno) evaluacion; // No se puede
            //alumnoTest = (Alumno) (ObjetoEscuelaBase) evaluacion; // No lanza error pero no está bien, en tiempo de ejecución marcará error

            /* La razón por la que no se puede es porque estamos utilizando mal el polimorfismo, convirtiendo alumnoTest (hijo) a su padre ObjescuelaBasee, y luego intentando convertir el resultado (obj) en evaluacion (otro hijo) */

/*            if(obj is Alumno)
            {
                Alumno alumnoRecuperado = (Alumno) obj;
            }
            */
            // Esto es más recomendado que la condición anterior
            // Si lo puede tomar, lo asigna. Caso contrario me devuelve null
            
            /* Alumno alumnoRecuperado2 = obj as Alumno;

            if(alumnoRecuperado2 != null)
            {

            }
            */
        }

        private static void ImpimirCursosEscuela(Escuela escuela)
        {
            
            Printer.WriteTitle("Cursos de la Escuela");
            
            
            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre  }, Id  {curso.UniqueId}");
                }
            }
        }
    }
}
