using CITOFacturacion.Models;
using CITOFacturacion.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace CITOFacturacion.Controllers
{
    public class FacturacionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        static private string path = @"C:\Users\Guest 1\source\repos\CITOFacturacion\CITOFacturacion\";
        static private string pathXML = path + @"CITOXMLPrueba.xml";
        //Index......
        //GET: Facturacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CrearXML(int? FreightRequestId)
        {
            FreightRequestId = 1;
            if (FreightRequestId != null)
            {
                FreightRequest FR = db.FreightRequests.Find(FreightRequestId);
                Client client = FR.Client;

                //Obtener numero certificado con la llave el certificado y una contraseña.......
                string pathCer = path + @"CSD01_AAA010101AAA.cer"; //Sellos de Prueba
                string pathKey = path + @"CSD01_AAA010101AAA.key"; //Sellos de Prueba
                string ClavePrivada = "12345678a";

                //Aquí se obtiene el numero  certificado.......
                string numeroCertificado, a, b, c;  //La función requiere los arametros a b c y por eso se incluyen
                SelloDigital.leerCER(pathCer, out a, out b, out c, out numeroCertificado);

                //Llenamos la clase Comprobante
                Comprobante comprobante = new Comprobante();
                comprobante.Version = "3.3"; //(Requerido)
                comprobante.Folio = "502";  //Folio de la Factura de Netlog (Opcional)
                comprobante.Fecha = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss"); //(Requerido)
                //comprobante.Sello = "Pendiente";  //Pendiente (Requerido)
                comprobante.FormaPago = "99"; //(Opcional)
                comprobante.NoCertificado = numeroCertificado; //Luego le agregamos el certificado a la propiedad del comprobante....
                //comprobante.Certificado = ""; //Pendiente
                comprobante.SubTotal = 10m;
                comprobante.Descuento = 1;
                comprobante.Moneda = "MXN";
                comprobante.Total = 9;
                comprobante.TipoDeComprobante = "I";
                comprobante.MetodoPago = "PUE";
                comprobante.LugarExpedicion = "66463";

                ComprobanteEmisor emisor = new ComprobanteEmisor();
                emisor.Rfc = "NSO190107V46";
                emisor.Nombre = "Netlog Solitions SRL de C:V";
                emisor.RegimenFiscal = "Regimen Fiscal";

                ComprobanteReceptor receptor = new ComprobanteReceptor();
                //receptor.Nombre = "Trane sa de cv";
                receptor.Nombre = client.Name; //Razón social SA de CV
                receptor.Rfc = client.RFC;

                comprobante.Emisor = emisor;
                comprobante.Receptor = receptor;

                //Accesar a los Conceptos
                List<ComprobanteConcepto> lstConceptos = new List<ComprobanteConcepto>();
                ComprobanteConcepto concepto = new ComprobanteConcepto();
                concepto.Importe = 10m;
                concepto.ClaveProdServ = "95125303";
                concepto.Cantidad = 1;
                concepto.ClaveUnidad = "C81";
                concepto.Descripcion = "Un Embarque";
                concepto.ValorUnitario = 10m;
                concepto.Descuento = 1;

                lstConceptos.Add(concepto);

                comprobante.Conceptos = lstConceptos.ToArray();

                //Serializamos....................
                XmlSerializerNamespaces xmlNameSpace = new XmlSerializerNamespaces();
                xmlNameSpace.Add("cfdi", "http://www.sat.gob.mx/cfd/3");
                xmlNameSpace.Add("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
                xmlNameSpace.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

                XmlSerializer oxmlSerializer = new XmlSerializer(typeof(Comprobante));

                string sXml = "";

                using (var sww = new StringWriterWithEncoding(Encoding.UTF8))
                {
                    using (XmlWriter writter = XmlWriter.Create(sww))
                    {
                        oxmlSerializer.Serialize(writter, comprobante, xmlNameSpace);
                        sXml = sww.ToString();
                    }
                }

                //guardamos el String en un archivo
                System.IO.File.WriteAllText(pathXML, sXml);
            }

            return View("Index", "Home", null);
        }
    }
}