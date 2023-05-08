using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class program
{
public static void Main(string[] args)
{

string nombre;
double edad;
double ID;

Console.WriteLine("Bienvenido a la JCE");

Console.WriteLine("Digite su ID");
ID = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Digite su nombre");
nombre = Console.ReadLine();

Console.WriteLine("Digite su edad");
edad = Convert.ToDouble(Console.ReadLine());

}

}