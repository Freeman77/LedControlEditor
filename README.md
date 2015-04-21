# Introducción
Herramienta de creación de arreglos de bytes para la librería LedControl, utilizada popularmente en controladores de matrices LED MAX7221 y MAX7219.

# Uso
Para utilizar el arreglo que genera la herramienta es necesario incluir las siguientes porciones de código en el sketch de Arduino:

```Arduino
//Incluir referencia a la librería
#include <LedControl.h>

//Declarar e instanciar objeto LedControl
// pin 12 conectado a DataIn 
// pin 11 conectado a CLK 
// pin 10 conectado a LOAD (CS)
// numero de dispositivos conectados en cascada
LedControl lc=LedControl(12,11,10,1);

//Declarar e instanciar el arreglo generado
byte array8x8 = {60,66,169,133,133,169,66,60};

void setup(){
  /* Habilitar matriz */
  lc.shutdown(0,false);
  /* Configurar el brillo 0 - 15 */
  lc.setIntensity(0,1);
  /* Limpiar display */
  lc.clearDisplay(0);
}

void loop(){
  //Establecer todas las filas segun nuestro arreglo generado
  for(int i=0;i<8;i++){
    lc.setRow(0,i,array8x8[i]);
  }
  
  //Agregamos delay para no saturar el Arduino
  delay(100);
}

```
Reemplazar 'array8x8' por el nombre que desees utilizar para el arreglo de bytes que se declara.

#Recomendaciones
- Preferir la utilización del método setRow() que es mucho más eficiente que el método setColumn().
- Se puede utilizar el cálculo de columnas o filas con el método setRow() en el caso de que la matriz esté invertida.

#Requisitos
- Microsoft .NET Framework 3.5

#Agradecimientos
Idea original: Ivan "Toymaker" Jimenez
