using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITOFacturacion.Models.Entities
{
    /// <summary>
    /// Clase que representa las divisiones territoriales de un país (Estados)
    /// </summary>
    public class SubDivision
    {
        private List<SubDivision2ndLv> _SubDivisions2ndLv;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Clave")]
        public Guid SubDivisionId { get; set; }
        [Display(Name = "Nombre Corto")]
        public string ShortName { get; set; }
        [Display(Name = "Nombre Largo")]
        public string LongName { get; set; }
        [Display(Name = "También conocido como")]
        public string AKA { get; set; }
        [Display(Name = "Abreviación")]
        public string Abbreviation { get; set; }
        [Display(Name = "Código 2 dígitos")]
        public string Code2Char { get; set; }
        [Display(Name = "Código 2 dígitos")]
        public string CountryCode2Char
        {
            get
            {
                string returnvalue = string.Empty;
                if (this.Country == null)
                    returnvalue = this.Code2Char;
                else
                    returnvalue = $"{this.Country.Code2Char}-{this.Code2Char}";
                return returnvalue;
            }
        }
        [Display(Name = "Código 3 dígitos")]
        public string Code3Char { get; set; }
        [Display(Name = "Código 3 dígitos")]
        public string CountryCode3Char
        {
            get
            {
                string returnvalue = string.Empty;
                if (this.Country == null)
                    returnvalue = this.Code3Char;
                else
                    returnvalue = $"{this.Country.Code2Char}-{this.Code3Char}";
                return returnvalue;
            }
        }
        [Display(Name = "Clave País")]
        public Guid? CountryId { get; set; }
        [ForeignKey("CountryId")]
        [Display(Name = "País")]
        public virtual Country Country { get; set; }
        [Display(Name = "Zona")]
        public virtual Zone Zone { get; set; }
        [Display(Name = "Municipios")]
        public virtual List<SubDivision2ndLv> SubDivisions2ndLv { get { return this._SubDivisions2ndLv ?? (this._SubDivisions2ndLv = new List<SubDivision2ndLv>()); } }
        
    }
}