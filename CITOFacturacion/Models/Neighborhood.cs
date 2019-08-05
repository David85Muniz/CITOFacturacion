using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITOFacturacion.Models.Entities
{
    /// <summary>
    /// Clase que representa una colonia
    /// </summary>
    public class Neighborhood
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Clave de Colonia")]
        public Guid NeighborhoodId { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Codigo Postal")]
        public string PostalCode { get; set; }
        [Display(Name = "Municipio")]
        public Guid? SubDivision2ndLvId { get; set; }
        [Display(Name = "Municipio")]
        public virtual SubDivision2ndLv SubDivision2ndLv { get; set; }
    }
}