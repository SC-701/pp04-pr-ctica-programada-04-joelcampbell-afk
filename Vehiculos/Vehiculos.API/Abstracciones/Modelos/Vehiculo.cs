using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Abstracciones.Modelos
{
    public class VehiculoBase
    {
        [Required(ErrorMessage ="La propiedad placa es requerida")]
        [RegularExpression(@"[A-Za-z]{3}-[0-9]{3}",ErrorMessage ="El formato de la placa debe ser ###-ABC")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "La propiedad Color es requerida")]
        [StringLength(40,ErrorMessage="El color no debe exceder los 40 caracteres", MinimumLength =4)]
        public string Color { get; set; }
        [Required(ErrorMessage = "La propiedad anio es requerida")]
        [RegularExpression(@"^(19|20)\d\d", ErrorMessage = "El formato del ano no es valido")]
        public int Año { get; set; }
        [Required(ErrorMessage = "La propiedad Precio es requerida")]
        public Decimal Precio { get; set; }
        [Required(ErrorMessage = "La propiedad CorreoPropietario es requerida")]
        [EmailAddress]
        public string CorreoPropietario { get; set; }
        [Required(ErrorMessage = "La propiedad TelefonoPropietario es requerida")]
        [Phone]
        public string TelefonoPropietario { get; set; }
    }
    public class VehiculoRequest : VehiculoBase
    {
        [Required]
        public Guid IdModelo { get; set; }
    }
    public class VehiculoResponse : VehiculoBase
    {
        public Guid Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
    }   
    public class VehiculoDetalle: VehiculoResponse
    {
        public bool RevisionValida { get; set; }
        public bool RegistroValido { get; set; }
    }
}
