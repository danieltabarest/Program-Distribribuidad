using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Data;
using LibRNMantenimiento.Transacciones;

namespace LibClientDistribMtto
{
    public class clsDistribPedido
    {
        #region Atributos

        //Atributos Cabecera Orden
        private Int32 intNroOrd;
        private DateTime datFecOrd;
        private string strCodCli;
        private string strCodTec;
        private decimal decVlr;
        private decimal decIva;

        //Atributo Detalle Orden;
        private DataTable dtDetalle;

        private string strError;

        private string strUrl;

        #endregion


        #region Propiedades

        public Int32 gsNroOrd
        {
            get { return intNroOrd; }
            set { intNroOrd = value; }
        }

        public DateTime gsFecOrd
        {
            get { return datFecOrd; }
            set { datFecOrd = value; }
        }

        public string gsCodCli
        {
            get { return strCodCli; }
            set { strCodCli = value; }
        }

        public string gsCodTec
        {
            get { return strCodTec; }
            set { strCodTec = value; }
        }

        public decimal gsVlr
        {
            get { return decVlr; }
            set { decVlr = value; }
        }

        public decimal gsIva
        {
            get { return decIva; }
            set { decIva = value; }
        }

        public DataTable gsDtDetalle
        {
            get { return dtDetalle; }
            set { dtDetalle = value; }
        }

        public string gError
        {
            get { return strError; }
        }

        #endregion



        #region Metodos Privados

        private bool InvoncarCanalPedido()
        {
            try
            {
                HttpClientChannel clientCh = new HttpClientChannel();

                if (ChannelServices.RegisteredChannels.Length == 0)
                {
                    ChannelServices.RegisterChannel(clientCh, false);

                    WellKnownClientTypeEntry ObjetoRemoto = new WellKnownClientTypeEntry(typeof(clsTrnPedido), strUrl);

                    RemotingConfiguration.RegisterWellKnownClientType(ObjetoRemoto);
                }

                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        #endregion

        #region Metodos Publicos

        public clsDistribPedido()
        {
            strUrl = "http://localhost:9016/clsTrnPedido.rem";
        }

        public bool GrabarPedidoRemoto()
        {
            if (!InvoncarCanalPedido())
            {
                return false;
            }

            clsTrnPedido objTrnPedRem = new clsTrnPedido();

            objTrnPedRem.gsNroOrd = intNroOrd;
            objTrnPedRem.gsFecOrd = datFecOrd;
            objTrnPedRem.gsCodCli = strCodCli;
            objTrnPedRem.gsCodTec = strCodTec;
            objTrnPedRem.gsVlr = decVlr;
            objTrnPedRem.gsIva = decIva;

            objTrnPedRem.gsDtDetalle = dtDetalle;

            if (!objTrnPedRem.GrabarTrnPedido())
            {
                strError = objTrnPedRem.gError;

                objTrnPedRem = null;
                return false;
            }

            intNroOrd = objTrnPedRem.gsNroOrd;

            objTrnPedRem = null;
            return true;
        
        }


        #endregion
    }
}
