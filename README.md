# Escenas CardBoard
## Sergio Guerra Arencibia
---  
Para el desarrollo de esta práctica se hará uso del siguiente [paquete](https://github.com/googlevr/gvr-unity-sdk/releases).  
Para realizar esta práctica, lo primero que hay que hacer es configurar nuestro proyecto para que, a la hora de la compilación se nos cree la aplicación correctamente.  
Esto se hace de manera análoga a como se hizo en la práctica pasada, donde probabamos a compilar y generar la aplicación apk de una escena ya construida.
  
Una vez y tengamos esta configuración, vamos a comenzar añadiendo un plano y una esfera. Estos elementos básicos nos serán suficiente para comenzar a trabajar. 
Posteriormente, cuando tengamos todo preparado pasaremos a terminar el entorno y añadir nuevos elementos.   

![alt_text](https://github.com/ULL-GII-InterfacesII/EscenasCardBoard-SergioGuerra/blob/main/images%26gifs/Esfera.png)
  
Con esto ya podemos comenzar con la realidad virtual como tal. 
En primer lugar añadimos un prefab llamado*GvrEditorEmulator*. Este elemento está incluido en el módulo que hemos importado y nos permitirá emular el funcionamiento de nuestra aplicación de realidad virutal
en nuestro ordenador.  

![alt_text](https://github.com/ULL-GII-InterfacesII/EscenasCardBoard-SergioGuerra/blob/main/images%26gifs/gvrEditorEmulator.png)

Una vez lo añadimos y ejecutemos nuestra aplicación, podemos ver que podemos girar la cámara hacia los lados pulsando "alt + flecha" como si estuvieramos girando la cabeza. También podemos inclinarla usando "control + flechas".  
En el siguiente gif podemos ver estos movimientos en el entorno básico que hemos creado
  
![alt_text](https://github.com/ULL-GII-InterfacesII/EscenasCardBoard-SergioGuerra/blob/main/images%26gifs/Emulator.gif)


Ya tenemos el emulador, pero falta algo vital para nuestra aplicación, la retícula que nos permitirá interactuar con el entorno.  
Para ello creamos un objeto vacío (camera rig), del cual desciende nuestra cámara (mainCamera) y a su vez, descendiendo de la cámara
colocamos otro prefab llamado "GvrReticlePointer".  
Esta jerarquía de tres niveles consigue que tengamos la retícula asociada a la cámara, moviéndose esta junto a nuestro movimiento.  

![alt_text](https://github.com/ULL-GII-InterfacesII/EscenasCardBoard-SergioGuerra/blob/main/images%26gifs/ReticleHierarchy.png)  

Para que la retícula sea funcional (y no algo meramente visual) debemos añadirle el componente "Gvr Pointer physics Raycaster".  
![alt_text](https://github.com/ULL-GII-InterfacesII/EscenasCardBoard-SergioGuerra/blob/main/images%26gifs/ReticleEmulator.gif)  

---  
Ya estamos listos para interactuar y afectar al mundo de nuestro alrededor.  
Comenzaremos cambiándole el color a una esfera cuando comencemos a mirarla, cuando hagamos click mientras a miramos y cuando dejemos de mirarla. 
Esto se logra mediante la adición de eventos a la esfera. Para lograr lo mencionado debemos añadir los siguientes eventos:

  - Pointer Enter
  - Pointer Exit
  - Pointer Click  
  
Existen muchos más eventos disponibles, aunque para esta práctica nos limitaremos a usar estos tres.  
Cuando tengamos creados los eventos hemos de añadirles la acción que queremos que se realice. Como solo deseamos un cambio de color, el script será el siguiente  

```c#  
    public class changeColor : MonoBehaviour  {
      public void Red() {
        GetComponent<Renderer>().material.color = Color.red;
      }
      public void Blue() {
        GetComponent<Renderer>().material.color = Color.blue;
      }
      public void Green() {
        GetComponent<Renderer>().material.color = Color.green;
      }
    }
```  

Y lo añadimos con la interfaz gráfica de unity de una manera muy sencilla. La asiganción de los eventos a los métodos nos deja esta situación.  

![alt_text](https://github.com/ULL-GII-InterfacesII/EscenasCardBoard-SergioGuerra/blob/main/images%26gifs/Events.png)  

probando su funcionamiento, vemos que procede de manera correcta.  

![alt_text](https://github.com/ULL-GII-InterfacesII/EscenasCardBoard-SergioGuerra/blob/main/images%26gifs/changeColor.gif)  
  
   
Para realizar la recolección de cubos es de manera muy similar.  
Creamos un cubo, añadimos un evento *Pointer Click* y en su script asignado -a modo de recolección- destruimos el objeto.  
Este elemento y su script quedan de la siguiente manera  

```c#
    public class deleteOnClick : MonoBehaviour {
      public int cubes = 0;

      public void delete() {
        Destroy(gameObject);
        cubes++;
      }
    }

```  

![alt_text](https://github.com/ULL-GII-InterfacesII/EscenasCardBoard-SergioGuerra/blob/main/images%26gifs/pickCube.gif)  
  
Solo resta añadir diferentes esferas y cubos, distribuyendolos de una manera (en mi caso) no uniforme por el entorno.  

![alt_text](https://github.com/ULL-GII-InterfacesII/EscenasCardBoard-SergioGuerra/blob/main/images%26gifs/finalResult.gif)
