using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CITOFacturacion.Models.Entities
{
    /// <summary>
    /// Clase que representa un Zona
    /// </summary>
    public class Zone
    {
        List<SubDivision2ndLv> _SubDivisions2ndLv = new List<SubDivision2ndLv>();
        List<SubDivision> _SubDivisions = new List<SubDivision>();


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Clave de Zona")]
        public Guid ZoneId { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Colonias")]
        public virtual List<Neighborhood> Neighborhoods { get; set; }
        [Display(Name = "Municipios")]
        public virtual List<SubDivision2ndLv> SubDivisions2ndLv { get; set; }
        [Display(Name = "Estados")]
        public virtual List<SubDivision> SubDivisions { get; set; }


        [Display(Name = "Colonia")]
        public virtual Neighborhood Neighborhood { get; set; }
    }
}