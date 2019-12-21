using System;
using System.Collections.Generic;
using System.Text;

// http://msdn.microsoft.com/it-it/library/cc185064.aspx#ID0EYF
//
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Il pattern Composite, di tipo strutturale basato sugli oggetti, consente di creare gerarchie di oggetti aggregando insieme elementi primitivi e compositi direttamente a runtime. 
// Questo pattern può essere applicato per rappresentare strutture ad albero in una logica parte-tutto (part-whole), dove ciascun elemento può a sua volta aggregare insieme altri 
// elementi della stessa specie e dove oggetti singoli e composizioni possono essere trattati in modo uniforme.
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Component (DocumentElement)
// Fornisce l’interfaccia di riferimento valida per tutti gli elementi della struttura ad albero, ovvero sia per gli elementi terminali che per gli elementi intermedi. 
// Rappresenta la classe base per Composite (oggetto composito) e per Leaf (oggetto primitivo).
//
// Composite (DocumentChapter)
// Definisce il comportamento degli elementi intermedi che hanno figli e che aggregano insieme altri Component.
//
// Leaf (DocumentParagraph)
// Definisce il comportamento degli elementi terminali che non hanno figli e che rappresentano gli oggetti primitivi.
//
// Client (Program)
// Utilizza la struttura composita, accedendo ai vari elementi tramite l’interfaccia Component.
namespace DesignPatterns_GoF.Structural.Composite
{
    #region Component
    // Component (DocumentElement)
    // Fornisce l’interfaccia di riferimento valida per tutti gli elementi della struttura ad albero, ovvero sia per gli elementi terminali che per gli elementi intermedi. 
    // Rappresenta la classe base per Composite (oggetto composito) e per Leaf (oggetto primitivo).
    abstract class DocumentElement
    {
        public abstract void Add(DocumentElement child);
        public abstract void Remove(DocumentElement child);
        public abstract void Write();
    } 
    #endregion

    #region Composite
    // Composite (DocumentChapter)
    // Definisce il comportamento degli elementi intermedi che hanno figli e che aggregano insieme altri Component.
    class DocumentChapter : DocumentElement
    {
        private int _chapterNumber;
        private List<DocumentElement> _children =
                                      new List<DocumentElement>();

        public DocumentChapter(int number)
        {
            _chapterNumber = number;
        }

        public override void Add(DocumentElement child)
        {
            _children.Add(child);
        }

        public override void Remove(DocumentElement child)
        {
            _children.Remove(child);
        }

        public override void Write()
        {
            Console.WriteLine("Chapter " + _chapterNumber.ToString());
            foreach (DocumentElement child in _children)
                child.Write();
        }
    } 
    #endregion

    #region Leaf
    // Leaf (DocumentParagraph)
    // Definisce il comportamento degli elementi terminali che non hanno figli e che rappresentano gli oggetti primitivi.
    class DocumentParagraph : DocumentElement
    {
        private string _text = string.Empty;
        public DocumentParagraph(string text) { _text = text; }

        public override void Add(DocumentElement child)
        {
            throw new NotSupportedException();
        }

        public override void Remove(DocumentElement child)
        {
            throw new NotSupportedException();
        }

        public override void Write()
        {
            Console.WriteLine(_text);
        }
    } 
    #endregion

    #region test - Client
    // Client (Program)
    // Utilizza la struttura composita, accedendo ai vari elementi tramite l’interfaccia Component.
    class TestProgram
    {
        public static void Test()
        {
            DocumentParagraph pg1 = new DocumentParagraph("1.1");
            DocumentParagraph pg2 = new DocumentParagraph("1.2");
            DocumentParagraph pg3 = new DocumentParagraph("2.1");
            DocumentParagraph pg4 = new DocumentParagraph("2.2");

            DocumentChapter chp1 = new DocumentChapter(1);

            chp1.Add(pg1);
            chp1.Add(pg2);
            chp1.Write();

            DocumentChapter chp2 = new DocumentChapter(2);

            chp2.Add(pg3);
            chp2.Add(pg4);
            chp2.Write();
        }
    } 
    #endregion
}
