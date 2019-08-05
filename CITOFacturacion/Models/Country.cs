using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITOFacturacion.Models.Entities
{
    /// <summary>
    /// Clase que representa un país
    /// </summary>
    public class Country
    {
        List<SubDivision> _SubDivisions;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Clave")]
        public Guid CountryId { get; set; }
        [Display(Name = "Nombre Corto")]
        public string ShortName { get; set; }
        [Display(Name = "Nombre Largo")]
        public string LongName { get; set; }
        [Display(Name = "Código 2 dígitos")]
        public string Code2Char { get; set; }
        [Display(Name = "Código 3 dígitos")]
        public string Code3Char { get; set; }
        [Display(Name = "Código numérico")]
        public int CodeNum { get; set; }
        [Display(Name = "Estados")]
        public virtual List<SubDivision> SubDivisions { get { return this._SubDivisions ?? (this._SubDivisions = new List<SubDivision>()); } }
    }
}
