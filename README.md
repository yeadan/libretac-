# LibretaC#
__Primera versión de listín de teléfonos en C#s__   

## Descripción
Tenemos una libreta de direcciones que se encuentra en un fichero de texto .csv, creado en https://extendsclass.com, de la forma:   
   
Miguel Fernan | Tenerife | 971456789   
Cati Rier | Palma de Mallorca | 45673928   
Miguel Castán | Madrid | 2234234252   
   
El archivo dispone de unos 200.000 registros y tenemos la posibilidad de hacer listados por nombre, apellido o ciudad y también de listar nombres o apellidos dentro de una ciudad.    
   
La implementaciín se ha llevado a cabo con un dictionary del tipo "string,dictionary(string,string)", haciendo un diccionario por ciudades y en cada ciudad ponerle su par persona/teléfono. Se han escogido los dictionaries porque para las búsquedas tiene un tiempo de ejecución de O(1), ya que está implementado siguiendo el concepto de las tablas de Hashing, y además elimina las posibles líneas repetidas.   
   
El proyecto ha sido creado con VS Code y .NET Core.   
   
## Funcionamiento
Primero se carga el archivo para después recorrerlo línea a línea, donde se van dividiendo en 3 columnas con un split, sabiendo que la primera columna pertenece al nombre y apellido, la segunda a la ciudad y la tercera al número de teléfono. Una vez procesados los datos se recorren y se visualizan dependiendo de las preferencias (por nombre, apellido, ciudad, o nombre/apellido dentro de una ciudad)   
   
## Ejecución
Se ejecuta añadiendo un argumento, que puede ser 'nombre', 'apellido' o 'ciudad' (para hacer un listado) o 'buscar', donde se podrá elegir primero una ciudad y luego un nombre o un apellido para filtrar más la búsqueda.   


