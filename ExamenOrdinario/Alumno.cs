using System;

public class Alumno
{
    public string cuenta;
    public string nombre;
    public string semestre;
    public string grupo;
    public string promedio_1;
    public string promedio_2;
    public string promedio_3;
    public string promedio_4;
    public string promedio_5;
    public string promedio_6;
}

public class Comparacion : IFunction<Alumno>
{

    public bool Same(Alumno a, Alumno b)
    {
        return a.cuenta == b.cuenta;
    }

}