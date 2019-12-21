using System;
using System.Collections.Generic;
using System.Text;

// http://msdn.microsoft.com/it-it/library/cc185064.aspx#ID0ETCAC
//
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Lo scopo del pattern Proxy (detto anche Surrogate) è quello di fornire un surrogato o un segnaposto di un altro oggetto per controllarne l’accesso. 
// Questo pattern, di tipo strutturale basato sugli oggetti, è applicabile ogni volta che si voglia disporre di un riferimento a un oggetto più versatile 
// di un semplice puntatore, tale da permettere, per esempio, di controllare l’accesso all’oggetto vero e proprio piuttosto che di fornire una rappresentazione 
// locale di un oggetto remoto.
//
// - si parla di proxy remoto quando si vuole nascondere al client che un oggetto risiede in uno spazio di indirizzamento diverso (esempio classico: Web Service);
// - si parla di proxy virtuale quando si vuole eseguire un’ottimizzazione nella creazione di un oggetto particolarmente “costoso” e pesante piuttosto che memorizzare 
//   informazioni aggiuntive relative all’oggetto rappresentato per posticipare l’accesso all’oggetto stesso;
// - si parla di proxy di protezione quando si vuole gestire l’accesso a un oggetto tramite l’esecuzione di azioni preliminari di controllo.
//
// --------------------------------------------------------------------------------------------------------------------------------------------
//
// Proxy (ServiceProxy)
// Fornisce un’interfaccia identica a quella di Subject e agisce da sostituto di RealSubject.
//
// Subject (IService)
// Definisce l’interfaccia comune per Proxy e RealSubject, rendendo possibile l’uso di Proxy in tutte le situazioni in cui è possibile utilizzare RealSubject.
//
// RealSubject (MyService)
// Rappresenta l’oggetto vero e proprio di cui Proxy è il surrogato.
namespace DesignPatterns_GoF.Structural.Proxy
{
    #region Subject
    // Proxy (ServiceProxy)
    // Fornisce un’interfaccia identica a quella di Subject e agisce da sostituto di RealSubject.
    interface IService
    {
        void HandleRequest();
    }
    #endregion

    #region RealSubject
    // RealSubject (MyService)
    // Rappresenta l’oggetto vero e proprio di cui Proxy è il surrogato.
    class MyService : IService
    {
        public void HandleRequest()
        {
            Console.WriteLine("Handling the request...");
        }
    }
    #endregion

    #region Proxy
    // Proxy (ServiceProxy)
    // Fornisce un’interfaccia identica a quella di Subject e agisce da sostituto di RealSubject.
    class ServiceProxy : IService
    {
        private MyService _service;

        public ServiceProxy(MyService svc)
        {
            _service = svc;
        }

        public void HandleRequest()
        {
            Console.WriteLine("Preprocessing by proxy...");
            _service.HandleRequest();
            Console.WriteLine("Postprocessing by proxy...");
        }
    } 
    #endregion

    #region Factory
    static class ServiceFactory
    {
        public static IService CreateService()
        {
            return new ServiceProxy(new MyService());
        }
    } 
    #endregion

    #region test
    class TestProgram
    {
        public static void Test()
        {
            IService svc = ServiceFactory.CreateService();
            svc.HandleRequest();
        }
    } 
    #endregion
}
