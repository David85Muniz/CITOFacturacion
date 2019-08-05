using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITOFacturacion.Models.Entities
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Clave de Cliente")]
        public Guid ClientID { get; set; }
        [Display(Name = "Nombre de la Compañia")]
        public string Name { get; set; }
        [Display(Name = "Telefono del Contacto")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Direcciones de Facturación")]
        public virtual List<BillingAddress> BillingAddresses { get; set; }
        [Display(Name = "Nombre del Contacto")]
        public string ClientContactName { get; set; }
        [Display(Name = "Correo de Contacto")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail no valido")]
        public string ClientContactEMail { get; set; }
        [Display(Name = "Notas")]
        public string Notes { get; set; }
        [Display(Name = "RFC")]
        public string RFC { get; set; }
    }

    public class BillingAddressViewModel
    {
        [Display(Name = "Clave de Dirección de Facturación")]
        public Guid BillingAddressId { get; set; }
        [Display(Name = "RFC")]
        public string RFC { get; set; }
        [Display(Name = "País")]
        public Guid CountryId { get; set; }
        [Display(Name = "Estado")]
        public Guid SubDivisionId { get; set; }
        [Display(Name = "Municipio")]
        public Guid SubDivision2ndLvId { get; set; }
        [Display(Name = "Ciudad")]
        public Guid CityId { get; set; }
        [Display(Name = "Colonia")]
        public Guid NeighborhoodId { get; set; }
        [Display(Name = "Calle")]
        public string Street { get; set; }
        [Display(Name = "Numero Exterior")]
        public string OutsideNumber { get; set; }
        [Display(Name = "Numero Interior")]
        public string InsideNumber { get; set; }
        [Display(Name = "Codigo Postal")]
        public string PostalCode { get; set; }
    }
}