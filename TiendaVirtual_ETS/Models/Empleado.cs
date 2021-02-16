using System;
using System.ComponentModel.DataAnnotations;

namespace TiendaVirtual_ETS.Models
{
    public class Empleado
    {
       
   

        // ingresamos los datos del empleado
        [Key]
        public int EmpleadoID { get; set; }

        [Display (Name = "Nombre Empleado")]                    // se personaliza el nombre de la etiqueta del campo
        [Required(ErrorMessage = "Se necesita ingresar {0}")]  // {0} se inidca el campo en el que  se esta trabajando 
        [StringLength(30, ErrorMessage ="El registro {0} No esta en el rango de {2} a {1} caracteres", MinimumLength =3)]

        public string Nombre { get; set; }

        [Display(Name = "Apellidos Empleado")]
        [Required(ErrorMessage = "Se necesita ingresar {0}")]
        [StringLength(30, ErrorMessage = "El registro {0} No esta en el rango de {2} a {1} caracteres", MinimumLength = 3)]


        public string Apellido { get; set; }

        [Required(ErrorMessage = "Se necesita ingresar {0}")]
        [DisplayFormat(DataFormatString ="{0:C2}",ApplyFormatInEditMode =false)]  // cambia el formato de los datos en la vista y/o en la BD
                                                  // currensi 
        
        public Decimal Salario { get; set; }


        [Display(Name = "% De Bono")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]  // cambia el formato de los datos en la vista y/o en la BD



        public float PorcentajeBono { get; set; }





        [Display(Name = " Fec. Nacimiento")]
        [Required(ErrorMessage = "Se necesita ingresar {0}")]
        [DisplayFormat(DataFormatString = "{0:yyy/MM/dd}", ApplyFormatInEditMode = true)]  // cambia el formato de los datos en la vista y/o en la BD
        [DataType(DataType.Date)]

        public DateTime FechaNacimiento { get; set; }





        [Display(Name = " Hora Inicio")]
        [Required(ErrorMessage = "Se necesita ingresar {0}")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]  // cambia el formato de los datos en la vista y/o en la BD
        [DataType(DataType.Time)]

        public DateTime HoraInicio { get; set; }



        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }




        [DataType(DataType.Url)]
        public string URL { get; set; }



        [Required(ErrorMessage = "Se necesita ingresar {0}")]

        public int TipoDocumentoID { get; set; }


        // campo calculado , solo tiene get 
        [NotMapperd]
        public int Edad { get { return DateTime.Now.Year - FechaNacimiento.Year ; } }
        

        // propiedad con modificador de acceso virtual para tipoDocumento
                                                                            
        public virtual TipoDocumento TipoDocumento { get; set; }

    }
}