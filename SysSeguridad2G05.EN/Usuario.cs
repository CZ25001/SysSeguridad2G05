using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SysSeguridad2G05.EN
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Rol")]
        [Required(ErrorMessage = "Rol es obligatorio")]
        [Display( Name = "Rol")]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "Nombre de usuario es obligatorio")]
        [StringLength(40, ErrorMessage = "Maximo 40 caracteres")]
        [Display(Name = "Nombre Usuario")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es obligatorio")]
        [StringLength(40, ErrorMessage = "Maximo 40 caracteres")]
        [Display(Name = "Apellido Usuario")]
        public string? Apellido { get; set;}

        [Required(ErrorMessage = "Login es obligatorio")]
        [StringLength(200, ErrorMessage = "Maximo 200 caracteres")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Password es obligatoria")]
        [StringLength(40, ErrorMessage = "Maximo 40 caracteres")]
        [Display(Name = "contraseña")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Estado es obligatorio")]
        public byte Estatus { get; set; }

        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        public Rol? Rol { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirmar password es obligatorio")]
        [StringLength(40, ErrorMessage = "Maximo 40 caracteres")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password y confirmar password deben ser iguales")]
        [Display(Name = "Confirmar password")]
        public string? confirmPassword { get; set; }
    }

    public enum Estatus_Usuario //Tabla intermedia con falta de validaciones, se puede usar un enum para mejorar la legibilidad del código
    {
        Inactivo = 1,
        Activo = 2
    }
}
