// See https://aka.ms/new-console-template for more information




using System.Text.Json;
using Formulatrix.TraficLights;

// var openA= new int[] {3,5,7};
// var openB= new int[] {4,10,12};
var openA= new int[] {4,7,9,16};
var openB= new int[] {2,5,12,14,20};


var swithA = new bool[500];
var swithB = new bool[500];

foreach(var o in openA)
{
    swithA[o] = true;
}

foreach(var o in openB)
{
    swithB[o] = true;
}




var lastState = "CLOSE";
var counter=0;
for (int i = 0; i < 500; i++)
{
    if(lastState=="CLOSE" && swithA[i]==true)
    {

        lastState="OPEN";
    }
    if (swithB[i]==true)
    {
        ///
         lastState="CLOSE";
    }

    if (lastState=="OPEN")
    {
        counter++;
    }


}

  Console.WriteLine(counter);









