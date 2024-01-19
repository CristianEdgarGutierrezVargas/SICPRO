﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using ManejadorMetodos.CDBSicPro;
using ManejadorModelo;
using System.Data;
using Common;
using System.Security.Cryptography;
namespace Logica.Consumo
{
    public class ConsumoModComision
    {
        #region Contructor Principal

        private readonly Cpr_pagocompania cpr_Pagocompania;
        private readonly Cpr_recibo cpr_Recibo;
        private readonly Cgr_persona cgr_Persona;
        public static sicproEntities dbContext;
        public ConsumoModComision()
        {
            if (dbContext != null) dbContext.Dispose();
            dbContext = new sicproEntities();
            cpr_Pagocompania = new Cpr_pagocompania(dbContext);
            cpr_Recibo = new Cpr_recibo(dbContext);
            cgr_Persona = new Cgr_persona(dbContext);


        }

        #endregion

        public pr_pagocompania InsertarPagoComp(pr_pagocompania objPagoComision)
        {

            try
            {
                var dt = cpr_Pagocompania.InsertarPagoComp(objPagoComision);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }


        }

        public List<pr_recibo> ObtenerAnio()
        {

            try
            {
                var dt = cpr_Recibo.ObtenerAnio();
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }


        }
        public List<gr_persona> ObtenerCobrador(string dato)
        {

            try
            {
                var dt = cgr_Persona.ObtenerCobrador(dato);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }


        }
        public List<pr_recibo> ObtenerRecibo(string dato)
        {

            try
            {
                var dt = cpr_Recibo.ObtenerRecibo(dato);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }
        }
        public bool EntregarRecibo(pr_recibo dato, int anio_recibo, int i, int j)
        {

            try
            {
                var dt = cpr_Recibo.EntregarRecibo(dato, anio_recibo, i, j);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }
        }
        public List<pr_recibo> GenerarRecibo(int anio)
        {

            try
            {
                var dt = cpr_Recibo.GenerarRecibo(anio);
                return dt;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al Generar la Consulta", secureException);

            }
        }

        public bool InsertarRecibo( int del, int al, string anio)
        {
            try
            {
              
                for (int j = (int)del; j <= (int)al; j += 1)
                {
                    cpr_Recibo.InsertRecibo(j, anio);
                }
                return true;
               
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error al generar la Transacción", secureException);
            }
        }



    }
}