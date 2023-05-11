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
 

 string salir = "N";
  int opcion;

while (salir.ToUpper() == "N")
{
 Console.WriteLine("Registro");

   

    Console.WriteLine("");

Console.WriteLine("Bienvenido a la JCE");


Console.WriteLine("");
Console.WriteLine("Para agregar o ver personas existentes pulse [0].");
opcion = Convert.ToInt32(Console.ReadLine());
Console.Clear();

 if (opcion == 0)
 {
usuarios usuarios = new usuarios();
 Console.WriteLine($"{connection.State}");
Console.WriteLine("Digite su ID");
usuarios.Cedula = Console.ReadLine();
   command.CommandText = "SPGetUsuarios3";
command.Parameters.Clear();
command.Parameters.AddWithValue("@Cedula", usuarios.Cedula);
command.CommandType = System.Data.CommandType.StoredProcedure;
SqlDataReader reader = command.ExecuteReader();
 
if (reader.HasRows)
{
if (reader.Read())
{
Console.WriteLine("Usuarios");
Console.WriteLine("");
Console.Write("Nombre: ");
Console.WriteLine(reader["Nombre"]);
usuarios.Nombre = reader["Nombre"].ToString();

}
reader.Close();

}

else
{
 reader.Close();

Console.WriteLine("Digite su nombre");
 usuarios.Nombre = Console.ReadLine();

Console.WriteLine("Digite su edad");
usuarios.edad = Convert.ToInt32(Console.ReadLine());
}
 

try
{

transaction = connection.BeginTransaction();
command.Transaction = transaction;
command.CommandText = "SPRegistro3";
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
}
}

