namespace SchoolSystem;
public class ClaseBase
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Nombre { get; set; }
}
public class Estudiante : ClaseBase
{
    public int Edad { get; set; }
    public Curso Curso { get; set; }
    public decimal CantidadQueDebe { get; set; } = new Random().Next(5000, 7000);
}

public class Curso : ClaseBase
{
    public Curso(string Nombre)
    {
        this.Nombre = Nombre;
    }
}
public class Escuela : ClaseBase
{
    public Escuela(string Nombre)
    {
        this.Nombre = Nombre;
        Console.WriteLine("Escuela " + Nombre + " creada");
    }
    public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
    public List<Curso> Cursos { get; set; } = new List<Curso>();

    public void AgregarCurso(string nombre)
    {
        Curso curso = new Curso(nombre);
        Cursos.Add(curso);
        Console.WriteLine("Curos " + nombre + " agregado");

    }

    public void AgregarEstudiante(string nombre, int edad)
    {
        Random random = new Random();
        int randomIndex = random.Next(0, Cursos.Count);

        Estudiante estudiante = new Estudiante
        {
            Nombre = nombre,
            Edad = edad,
            Curso = Cursos[randomIndex]
        };

        Estudiantes.Add(estudiante);
        Console.WriteLine("Estudiante agregado a curson " + estudiante.Curso.Nombre);
    }
    public void MostrarTodoEstudiantes()
    {
        foreach (Estudiante estudiante in Estudiantes)
        {
            Console.WriteLine($"Nombre: {estudiante.Nombre}, Cursor: {estudiante.Curso.Nombre}, Edad: {estudiante.Edad}, Monto restante: " + estudiante.CantidadQueDebe.ToString("$#,##0.00"));
        }
    }
    public void BorrarEstudiante()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, Estudiantes.Count);
        Console.WriteLine(Estudiantes[randomIndex].Nombre + " retirado por mala paga");
        Estudiantes.Remove(Estudiantes[randomIndex]);
    }

    public void RegistrarUnPago()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, Estudiantes.Count);

        decimal pago = new Random().Next(2000, 3000);

        Estudiantes[randomIndex].CantidadQueDebe = Estudiantes[randomIndex].CantidadQueDebe - pago;

        Console.WriteLine(Estudiantes[randomIndex].Nombre + " pago " + pago.ToString("$#,##0.00") + " y ahora debe " + Estudiantes[randomIndex].CantidadQueDebe.ToString("$,##0.00"));
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Escuela escuela = new Escuela("Invasor Academy");
        escuela.AgregarCurso("1A");
        escuela.AgregarCurso("1B");
        escuela.AgregarCurso("2A");
        escuela.AgregarCurso("2B");
        escuela.AgregarCurso("3A");
        escuela.AgregarCurso("3B");
        escuela.AgregarCurso("4A");
        escuela.AgregarCurso("4B");

        escuela.AgregarEstudiante("Miguel Cuevas", 18);
        escuela.AgregarEstudiante("Chris Brown", 17);
        escuela.AgregarEstudiante("Javier Hernandez", 14);
        escuela.AgregarEstudiante("Jordan Guajemio", 19);
        Console.WriteLine("-----------------------------");
        Console.WriteLine("Todos los estudiates agregados");
        Console.WriteLine("-----------------------------");
        escuela.MostrarTodoEstudiantes();
        Console.WriteLine("-----------------------------");
        escuela.BorrarEstudiante();
        Console.WriteLine("-----------------------------");
        Console.WriteLine("Todos los estudiates agregados");
        Console.WriteLine("-----------------------------");
        escuela.MostrarTodoEstudiantes();
        Console.WriteLine("-----------------------------");
        escuela.RegistrarUnPago();
        escuela.RegistrarUnPago();
        escuela.RegistrarUnPago();
        Console.WriteLine("-----------------------------");
        Console.WriteLine("Todos los estudiates agregados");
        Console.WriteLine("-----------------------------");
        escuela.MostrarTodoEstudiantes();
        Console.ReadLine();
    }
}