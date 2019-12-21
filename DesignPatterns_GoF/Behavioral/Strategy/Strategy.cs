using System;
using System.Collections.Generic;
using System.Text;

// http://msdn.microsoft.com/it-it/library/cc185068.aspx#ID0EOBAC
//
// --------------------------------------------------------------------------------------------------------------------------------------------
// Il pattern Strategy permette di definire una famiglia di algoritmi, di incapsularli e renderli intercambiabili fra loro. 
// Questo pattern consente agli algoritmi di variare in modo indipendente rispetto al loro contesto di utilizzo, fornendo un basso accoppiamento 
// tra le classi partecipanti del pattern e una alta coesione funzionale delle diverse strategie di implementazione.
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Strategy (SortAlgorithm)
// Dichiara l’interfaccia di riferimento per tutti gli algoritmi concreti.
//
// ConcreteStrategy (QuickSort, BubbleSort e MergeSort)
// Implementa un particolare algoritmo utilizzando l’interfaccia definita da Strategy.
//
// Context (Context)
// Carica un oggetto ConcreteStrategy e utilizza un riferimento a Strategy per eseguire l’algoritmo concreto. Definisce l’interfaccia per accedere ai membri dell’algoritmo caricato.
namespace DesignPatterns_GoF.Behavioral.Strategy
{
    #region Strategy
    // Strategy (SortAlgorithm)
    // Dichiara l’interfaccia di riferimento per tutti gli algoritmi concreti.
    abstract class SortAlgorithm
    {
        public abstract int[] Sort(int[] array);
    }
    #endregion

    #region ConcreteStrategy
    // ConcreteStrategy (QuickSort, BubbleSort e MergeSort)
    // Implementa un particolare algoritmo utilizzando l’interfaccia definita da Strategy.
    class QuickSort : SortAlgorithm
    {
        public override int[] Sort(int[] array)
        {
            Array.Sort<int>(array);
            return array;
        }
    }

    class BubbleSort : SortAlgorithm
    {
        public override int[] Sort(int[] array)
        {
            throw new NotImplementedException();
        }
    }

    class MergeSort : SortAlgorithm
    {
        public override int[] Sort(int[] array)
        {
            throw new NotImplementedException();
        }
    } 
    #endregion

    #region Context
    // Context (Context)
    // Carica un oggetto ConcreteStrategy e utilizza un riferimento a Strategy per eseguire l’algoritmo concreto. Definisce l’interfaccia per accedere ai membri dell’algoritmo caricato.
    class Context
    {
        private SortAlgorithm _algorithm;

        public Context(SortAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public int[] SortArray(int[] array)
        {
            return _algorithm.Sort(array);
        }
    }
    #endregion

    #region test
    class TestProgram
    {
        public static void Test()
        {
            int[] array = { 21, 10, 71, 18, 8, 5, 20, 1, 67 };

            Context ctx = new Context(new QuickSort());
            array = ctx.SortArray(array);

            foreach (int i in array)
                Console.WriteLine(i.ToString());
        }
    } 
    #endregion
}
