using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibRNMantenimiento.Transacciones;
using LibRNMantenimiento.Pedido;
using System.Data;

namespace LibRNMantenimiento.Log
{
    public class clsLogMsg
    {
        #region Atributos
        


        #endregion

        #region Metodos Publicos

        public void MostrarVlrsEntCab(clsCabeceraOrd objCabOrd)
        {
            Console.WriteLine("VALORES DE CABECERA RECIBIDOS....");
            Console.WriteLine("Fecha Orden: {0}", objCabOrd.gsFecOrd);
            Console.WriteLine("Cliente: {0}", objCabOrd.gsCodCli);
            Console.WriteLine("Tecnico: {0}", objCabOrd.gsCodTec);
            Console.WriteLine("Valor: {0}", objCabOrd.gsVlr);
            Console.WriteLine("Iva: {0}", objCabOrd.gsIva);
            Console.WriteLine("\r\n");
        }

        public void MostrarVlrsEntDet(DataTable objDtDetalle)
        {
            Console.WriteLine("VALORES DE DETALLE RECIBIDOS....");

            for (int i = 0; i < objDtDetalle.Rows.Count; i++)
            {
                for (int j = 0; j < objDtDetalle.Columns.Count; j++)
                {
                    Console.WriteLine(objDtDetalle.Rows[i][j].ToString() + "\t");
                }

                Console.WriteLine("\r\n");
            }

            Console.WriteLine("\r\n");
        }

        public void MostrarVlrSal(object objValor)
        {
            Console.WriteLine("VALOR RETORNADO: {0}", objValor.ToString());
            Console.WriteLine("\r\n");
        }

        public void MostrarVlrSal(object objValor, string strMsj)
        {
            Console.WriteLine(strMsj + " {0}", objValor.ToString());
            Console.WriteLine("\r\n");
        }

        public void MostrarVlrSal(string strMsj)
        {
            Console.WriteLine(strMsj);
            Console.WriteLine("\r\n");
        }

        #endregion
    }
}
