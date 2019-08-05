using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITOFacturacion.Models.Entities
{
    /// <summary>
    /// Clase que representa una dirección o ubicación
    /// </summary>
    public abstract class Address
    {
        [Display(Name = "Colonia")]
        public virtual Neighborhood Neighborhood { get; set; }
        [Display(Name = "Codigo Postal")]
        public string PostalCode { get; set; }
        [Display(Name = "Calle")]
        public string Street { get; set; }
        [Display(Name = "Numero Exterior")]
        public string OutsideNumber { get; set; }
        [Display(Name = "Numero Interior")]
        public string InsideNumber { get; set; }

        public string FullAddress
        {
            get
            {

                string value = string.Empty;
                if (!string.IsNullOrEmpty(this.Street)) value = $"{this.Street}";
                if (!string.IsNullOrEmpty(this.OutsideNumber)) value = $"{value} #{this.OutsideNumber}";
                if (!string.IsNullOrEmpty(this.InsideNumber)) value = $"{value} Int {this.InsideNumber}";

                if (this.Neighborhood != null)
                {
                    value = $"{value}, {this.Neighborhood.Name}";
                    if (this.Neighborhood.SubDivision2ndLv != null)
                    {
                        value = $"{value}, {this.Neighborhood.SubDivision2ndLv.ShortName}";
                        if (this.Neighborhood.SubDivision2ndLv.SubDivision != null)
                        {
                            value = $"{value}, {this.Neighborhood.SubDivision2ndLv.SubDivision.ShortName}";
                            if (this.Neighborhood.SubDivision2ndLv.SubDivision.Country != null)
                            {
                                value = $"{value}, {this.Neighborhood.SubDivision2ndLv.SubDivision.Country.Code2Char}";
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(this.PostalCode)) value = $"{value}, CP {this.PostalCode}";

                return value;
            }
        }

        public override string ToString()
        {
            string value = string.Empty;
            if (!string.IsNullOrEmpty(this.Street)) value = $"{this.Street}";
            if (!string.IsNullOrEmpty(this.OutsideNumber)) value = $"{value} #{this.OutsideNumber}";
            if (!string.IsNullOrEmpty(this.InsideNumber)) value = $"{value} Int {this.InsideNumber}";
            if (!string.IsNullOrEmpty(this.Neighborhood.Name)) value = $"{value}, {this.Neighborhood.Name}";
            if (!string.IsNullOrEmpty(this.Neighborhood.SubDivision2ndLv.ShortName)) value = $"{value}, {this.Neighborhood.SubDivision2ndLv.ShortName}";
            if (!string.IsNullOrEmpty(this.Neighborhood.SubDivision2ndLv.SubDivision.ShortName)) value = $"{value}, {this.Neighborhood.SubDivision2ndLv.SubDivision.ShortName}";
            if (!string.IsNullOrEmpty(this.Neighborhood.SubDivision2ndLv.SubDivision.Country.ShortName)) value = $"{value}, {this.Neighborhood.SubDivision2ndLv.SubDivision.Country.ShortName}";
            if (!string.IsNullOrEmpty(this.PostalCode)) value = $"{value}, CP {this.PostalCode}";
            return value;
        }
    }

    public class BillingAddress : Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Clave de Dirección de Facturación")]
        public Guid BillingAddressId { get; set; }
    }
}