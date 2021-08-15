using AppIot.Funciones;
using AppIot.Metodos;
using System;
using System.Collections.Generic;
using System.IO;

namespace AppIot
{
    class Program
    {
        
        [STAThread]
        static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            clsArchivo clsfile = new clsArchivo();
            clsCalculo clscalculo = new clsCalculo();
            string nombrearchivo = "";
            goPresentarMenu();
            bool menu = true;
            while (menu)
            {
                Console.Write("\r\n Seleccione una opcion: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        if(!nombrearchivo.Equals(""))
                        {
                            Console.WriteLine("\r\n"+"El archivo seleccionado es " + nombrearchivo+ "\r\n");
                            foreach (var item in lines)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                            Console.WriteLine("\r\n"+"No hay ningun archivo");
                        break;
                    case "2":
                        lines = clsfile.obtenerarchivo(ref nombrearchivo);
                        if(lines!= null  && lines.Count > 0)
                            Console.WriteLine("\r\n" + "El archivo: " + nombrearchivo + " fue cargado con exito.");
                         else
                            Console.WriteLine("\r\n" + "Error al cargar archivo");

                        break;
                    case "3":
                        ////////calculo de salario por horas//////////////
                        Exception ex = null;
                        if (lines != null && lines.Count > 0)
                        {
                            var salario = clscalculo.calculoSalario(lines,ref ex);
                            if (ex == null)
                            {
                                //ok
                                foreach (var item in salario)
                                {
                                    string[] spl = item.Split(';');
                                    Console.WriteLine("\r\n" + "El monto a pagar de " + spl[0] + " = "+ spl[1]);
                                }

                            }
                            else
                            {
                                //error al procesar formato de archivo incorrecto 
                                Console.WriteLine("\r\n" + "Formato incorrecto");
                            }
                        }
                        else
                            Console.WriteLine("\r\n" + "No hay datos");
                        break;
                    case "4":
                        Console.Clear();
                        goPresentarMenu();
                        break;
                    case "5":
                        menu = false;
                        break;
                    default:
                        break;
                }
                
            }

        }


        static void goPresentarMenu()
        {
            Console.WriteLine("Escoja una opcion");
            Console.WriteLine("1) Ver archivo seleccionado");
            Console.WriteLine("2) Seleccionar archivo");
            Console.WriteLine("3) Calcular sueldo");
            Console.WriteLine("4) Limpiar");
            Console.WriteLine("5) Salir");
           
        }
    }
}
