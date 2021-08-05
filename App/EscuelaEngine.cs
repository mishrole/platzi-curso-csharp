using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using Etapa1.Entidades;

namespace CoreEscuela
{
    /*
     * Clase sin herencia pero con instancia -> SEALED
       Clase con herencia pero sin instancia -> ABSTRACT
    */
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academay", 2012, TiposEscuela.Primaria,
            ciudad: "Bogotá", pais: "Colombia"
            );

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        private void CargarEvaluaciones()
        {
            _ = new List<Evaluacion>();

            foreach(var curso in Escuela.Cursos)
            {
                foreach(var asignatura in curso.Asignaturas)
                {
                    foreach(var alumno in curso.Alumnos)
                    {
                        var randomize = new Random(System.Environment.TickCount);

                        for(int i = 0; i < 5; i++)
                        {
                            var evaluacion = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * randomize.NextDouble()),
                                Alumno = alumno
                            };

                            alumno.Evaluaciones.Add(evaluacion);
                        }
                    }
                }
            }
        }

        public List<ObjetoEscuelaBase> GetObjetosEscuela()
        {
            List<ObjetoEscuelaBase> listObj = new List<ObjetoEscuelaBase>
            {
                Escuela
            };

            /*listObj.Add(Escuela);*/
            listObj.AddRange(Escuela.Cursos);
            
            foreach(var curso in Escuela.Cursos)
            {
                listObj.AddRange(curso.Asignaturas);
                listObj.AddRange(curso.Alumnos);

                foreach(var alumno in curso.Alumnos)
                {
                    listObj.AddRange(alumno.Evaluaciones);
                }
            }

            return listObj;
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                            new Asignatura{Nombre="Matemáticas"} ,
                            new Asignatura{Nombre="Educación Física"},
                            new Asignatura{Nombre="Castellano"},
                            new Asignatura{Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar( int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos =  from n1 in nombre1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new Alumno{ Nombre=$"{n1} {n2} {a1}" };
            
            return listaAlumnos.OrderBy( (al)=> al.UniqueId ).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                        new Curso(){ Nombre = "101", Jornada = TiposJornada.Mañana },
                        new Curso() {Nombre = "201", Jornada = TiposJornada.Mañana},
                        new Curso{Nombre = "301", Jornada = TiposJornada.Mañana},
                        new Curso(){ Nombre = "401", Jornada = TiposJornada.Tarde },
                        new Curso() {Nombre = "501", Jornada = TiposJornada.Tarde},
            };
            
            Random rnd = new Random();
            foreach(var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }
    }
}