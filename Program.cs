using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace prueba_github
{
public class program
{
public static void Main(string[] args)
{
SqlConnection connection = new SqlConnection();
connection.ConnectionString = @"Data Source=MSI\MSICI;Initial Catalog=datos;Integrated Security=True";
connection.Open();
 SqlTransaction transaction = null;
  SqlCommand command = new SqlCommand();
 command.Connection = connection;
 usuarios usuarios = new usuarios();
 string salir = "N";
 Console.WriteLine("Registro");

    Console.WriteLine($"{connection.State}");

    Console.WriteLine("");

Console.WriteLine("Bienvenido a la JCE");

Console.WriteLine("Digite su ID");
usuarios.Cedula = Convert.ToInt32(Console.ReadLine());
 command.CommandText = "SPRegistro";
 command.Parameters.Clear();
 command.Parameters.AddWithValue("@Cedula", usuarios.Cedula);
command.CommandType = System.Data.CommandType.StoredProcedure;

Console.WriteLine("Digite su nombre");
 usuarios.Nombre = Console.ReadLine();

Console.WriteLine("Digite su edad");
usuarios.edad = Convert.ToInt32(Console.ReadLine());

try
{

transaction = connection.BeginTransaction();
command.Transaction = transaction;
command.CommandText = "SPRegistro";
command.Parameters.Clear();
command.Parameters.AddWithValue("@Cedula", usuarios.Cedula);
command.Parameters.AddWithValue("@Nombre", usuarios.Nombre);
command.Parameters.AddWithValue("@Edad", usuarios.edad);
command.CommandType = System.Data.CommandType.StoredProcedure;

int Respuesta = command.ExecuteNonQuery();

Respuesta = command.ExecuteNonQuery();

transaction.Commit();

Console.WriteLine($"{Respuesta}");

}

catch(Exception error)
{
 transaction.Rollback();
 
}


Console.WriteLine("Quiere salir? Y/N");
salir = Console.ReadLine();
Console.Clear();

}

}
}