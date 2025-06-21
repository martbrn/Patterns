// =============================================
// FACTORY PATTERN - Simple Factory
// =============================================
// Propósito: Encapsular la creación de objetos y centralizar la lógica de instanciación
// Cuándo usar: Cuando necesitas controlar cómo se crean los objetos o agregar lógica de creación

namespace Patterns.Creational.Factory;

/// <summary>
/// Clase Student que encapsula su lógica de creación usando Factory Pattern
/// El constructor es privado para forzar el uso del factory
/// </summary>
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Constructor privado - solo el factory puede crear instancias
    private Student(int id, string name)
    {
        Id = id;
        Name = name;
    }

    /// <summary>
    /// Factory interno que maneja la creación de estudiantes
    /// Mantiene un contador automático de IDs
    /// </summary>
    public static class StudentFactory
    {
        // Contador estático para generar IDs únicos
        private static int index = 001;

        /// <summary>
        /// Crea un nuevo estudiante con ID auto-generado
        /// </summary>
        /// <param name="name">Nombre del estudiante</param>
        /// <returns>Nueva instancia de Student</returns>
        public static Student Create(string name)
        {
            return new Student(index++, name);
        }
    }
}

/// <summary>
/// Clase User que demuestra múltiples métodos factory
/// Cada método factory proporciona una forma diferente de crear usuarios
/// </summary>
public class User
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Country { get; private set; }

    // Constructor privado para forzar uso de factory methods
    private User(string name, string email, string country)
    {
        Name = name;
        Email = email;
        Country = country;
    }

    /// <summary>
    /// Factory interno con diferentes métodos de creación
    /// Cada método proporciona valores por defecto para diferentes escenarios
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Crea usuario con país por defecto (Chile)
        /// </summary>
        public static User CreateWithDefaultCountry(string name, string email)
        {
            return new User(name, email, "Chile");
        }

        /// <summary>
        /// Crea usuario con email por defecto
        /// </summary>
        public static User CreateWithDefaultEmail(string name, string country)
        {
            return new User(name, "rodrigo@gmail.com", country);
        }
    }
}
