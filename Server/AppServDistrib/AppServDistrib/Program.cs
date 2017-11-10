using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibRNMantenimiento.Transacciones;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

namespace AppServDistrib
{
    class Program
    {
        static void Main(string[] args)
        {

            string strNomClassTrn = "clsTrnPedido.rem";

            try
            {
                HttpServerChannel serverCh = new HttpServerChannel(9016);

                ChannelServices.RegisterChannel(serverCh, false);

                RemotingConfiguration.RegisterWellKnownServiceType(typeof(clsTrnPedido), strNomClassTrn, WellKnownObjectMode.Singleton);

                Console.WriteLine("Clase remota --{0}-- servida", strNomClassTrn);
                Console.WriteLine("Presione <ENTER> para finalizar Servicio");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: {0}", ex.Message);
                
            }
            finally
            {
                Console.Read();
            }
        }
    }
}
