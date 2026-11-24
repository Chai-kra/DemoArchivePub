using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models;

#nullable disable warnings

public class DB(DbContextOptions options) : DbContext(options) //options extended from context
{
    // DbSet, prop -> tab for auto fill property
    //Highest level, these are the tables you have in the database
    //public, DbSet<Table name>, 
    public DbSet<Program> Programs { get; set; }
    public DbSet<Student> Students { get; set; }
}

// Entity Classes -------------------------------------------------------------

public class Program // class = table
{
    // Column
    [Key, MaxLength(3)]
    public String Id { get; set; }
    [MaxLength(100)]
    public String Name { get; set; }

    // Navigation
    public List<Student> Students { get; set; } = [];
}

public class Student
{
    // Column
    [Key, MaxLength(10)]
    public String Id { get; set; }
    [MaxLength(100)]
    public String Name { get; set; }
    [MaxLength(1)]
    public String Gender { get; set; }

    // FK
    public String ProgramId { get; set; } // ProgramId, Program;table, Id;Attribute

    // Navigation
    public Program Program { get; set; }
}
