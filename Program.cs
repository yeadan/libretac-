using System;
using System.IO;
using System.Collections.Generic;


namespace LibretaC_
{
    class Program
    {
        static void Main(string[] args)
        {   
            string ciudad ="";
            string apellido ="";
            string nombre="";
            string archivo="datos.csv";

            try {
                // Creamos el diccionario base (diccionario ciudades, diccionario (personas, teléfonos))
                var registro = new Dictionary<string, Dictionary<string,string>>();

                //Solo funcionará con 1 argumento
                if (args.Length != 1) 
                {
                    Console.WriteLine("Numero de argumentos incorrecto");
                    return; 
                }
                // Leemos el archivo .csv creado en https://extendsclass.com
                string[] lines = System.IO.File.ReadAllLines(archivo);

                // Miramos el número de argumentos
                    if (args[0].ToLower() == "nombre")
                    {
                        Console.Write("Introduce el nombre:");
                        nombre=Console.ReadLine().ToLower();
                    }
                    else if (args[0].ToLower() == "apellido")
                    {
                        Console.Write("Introduce el apellido:");
                        apellido=Console.ReadLine().ToLower();
                    }
                    else if (args[0].ToLower() == "ciudad")
                    {
                        Console.Write("Introduce la ciudad:");
                        ciudad=Console.ReadLine().ToLower();
                    }
                    else if (args[0].ToLower() == "buscar")
                    {
                        Console.Write("Introduce la ciudad:");
                        ciudad=Console.ReadLine().ToLower();
                        Console.Write("Introduce el nombre:");
                        nombre=Console.ReadLine().ToLower();
                        if (nombre.Length == 0) 
                        {
                            Console.Write("Introduce el apellido:");
                            apellido=Console.ReadLine().ToLower();
                        }
                    }
                    else {
                        Console.WriteLine("El primer argumento debe ser 'nombre', 'apellido', ciudad o 'buscar'");
                        return;
                    }
                
                // Recorremos el archivo para añadirlo a nuestra estructura
                foreach(string line in lines)
                {
                    // Dividimos las filas en tres: 0 nombres, 1 ciudades, 2 telefonos
                    var cols = line.Split('|',StringSplitOptions.RemoveEmptyEntries);

                    // Prevenimos líneas erróneas y los System.IndexOutOfRangeException
                    if (cols.Length != 3)
                        continue;

                    // Si la ciudad ya existe añadimos el value
                    if (registro.ContainsKey(cols[1]))
                    {   
                        var person = new Dictionary<string, string>();
                        person = registro[cols[1]];
                        if (!person.ContainsKey(cols[0])) {
                            person.Add(cols[0],cols[2]);
                            registro[cols[1]] = person;
                        }
                    }
                    // Si no existe, lo creamos y añadimos el value
                    else { 
                        var person = new Dictionary<string, string>();
                        person.Add(cols[0],cols[2]);
                        registro.Add(cols[1],person);
                    }
                }
                // Recorremos el diccionario y aplicamos los filtros
                foreach(var data in registro) {
                    if (data.Key.ToLower().StartsWith(ciudad))
                        foreach(KeyValuePair<string,string> pair in data.Value) 
                        {
                            // Se busca nombre
                            if (nombre.Length >0 && pair.Key.ToLower().StartsWith(nombre)) 
                                Console.WriteLine(pair.Key+" - "+pair.Value+" in "+data.Key);
                            // Se busca apellido
                            else if (apellido.Length >0 && pair.Key.ToLower().Contains(" "+apellido)) {
                                Console.WriteLine(pair.Key+" - "+pair.Value+" in "+data.Key);
                            }
                            // Se busca solo ciudad
                            else if (ciudad.Length > 0 && nombre.Length == 0 && apellido.Length == 0)
                                Console.WriteLine(pair.Key+" - "+pair.Value+" - "+data.Key);
                        }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Archivo "+ archivo +" no encontrado");
            }

        }
    }
}
