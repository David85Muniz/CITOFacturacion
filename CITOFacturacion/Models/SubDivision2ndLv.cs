using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITOFacturacion.Models.Entities
{
    /// <summary>
    /// Clase que representa las divisiones territoriales a segundo nivel de un país (Municipios)
    /// </summary>
    public class SubDivision2ndLv
    {
        private List<Neighborhood> _Neighborhoods;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Clave Municipio")]
        public Guid SubDivision2ndLvId { get; set; }
        [Display(Name = "Nombre Corto")]
        public string ShortName { get; set; }
        [Display(Name = "Nombre Largo")]
        public string LongName { get; set; }
        [Display(Name = "Abreviación")]
        public string Abbreviation { get; set; }
        [Display(Name = "Clave Estado")]
        public Guid? SubDivisionId { get; set; }
        [ForeignKey("SubDivisionId")]
        [Display(Name = "Estado")]
        public virtual SubDivision SubDivision { get; set; }
        [Display(Name = "Colonias")]
        public virtual List<Neighborhood> Neighborhoods { get { return this._Neighborhoods ?? (this._Neighborhoods = new List<Neighborhood>()); } }
        [Display(Name = "Clave de Ciudad de Origen")]
        public Guid? OriginCityId { get; set; }
        [Display(Name = "Clave de Ciudad de Destino")]
        public Guid? DestinationCityId { get; set; }
    }
}