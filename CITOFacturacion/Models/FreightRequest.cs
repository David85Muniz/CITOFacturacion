using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CITOFacturacion.Models.Entities
{
    public class FreightRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Folio Cita")]
        public int FreightRequestId { get; set; }
        [Display(Name = "Requisitos y Restricciones")]
        public string Restrictions { get; set; }
        [Display(Name = "Clave de Cliente")]
        public Guid? ClientId { get; set; }
        [ForeignKey("ClientId")]
        [Display(Name = "Cliente")]
        public virtual Client Client { get; set; }
        [Display(Name = "Tarifa Solicitada al Cliente")]
        public decimal ReqClientRate { get; set; }
        ////[Display(Name = "Clave de Tarifa de Cliente")]
        ////public Guid? ClientRateId { get; set; }
        ////[ForeignKey("ClientRateId")]
        ////[Display(Name = "Tarifa del Cliente")]
        ////public virtual ClientRates ClientRate { get; set; }
        [Display(Name = "Fecha de Creación")]
        public DateTime CreateDate { get; set; }


    }
}