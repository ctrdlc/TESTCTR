using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TESTCTR.Models
{
    public class mVentas_Cliente
    {
        private Int32 m_ID_Cliente;

        private string m_NombreCliente;
        private Int32 m_ID_Contacto;

        private string m_Direccion;

        private string m_Ciudad;

        private string m_Region;

        private string m_CodigoPostal;

        private string m_Pais;

        private string m_Telefono;

        private string m_email;

        [Key]
        public Int32 ID_Cliente
        {
            get { return this.m_ID_Cliente; }
            set { m_ID_Cliente = value; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Nombre del Cliente no puede estar vacio.")]
        [StringLength(50)]
        public string NombreCliente
        {
            get { return this.m_NombreCliente; }
            set { m_NombreCliente = value; }
        }

        public Int32 ID_Contacto
        {
            get { return this.m_ID_Contacto; }
            set { m_ID_Contacto = value; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La direccion del Cliente no puede estar vacio.")]
        public string Direccion
        {
            get { return this.m_Direccion; }
            set { m_Direccion = value; }
        }

        public string Ciudad
        {
            get { return this.m_Ciudad; }
            set { m_Ciudad = value; }
        }
        [Required(AllowEmptyStrings = false, ErrorMessage = "La Region del Cliente no puede estar vacio.")]
        public string Region
        {
            get { return this.m_Region; }
            set { m_Region = value; }
        }

        public string CodigoPostal
        {
            get { return this.m_CodigoPostal; }
            set { m_CodigoPostal = value; }
        }

        public string Pais
        {
            get { return this.m_Pais; }
            set { m_Pais = value; }
        }
        [Required]
        public string Telefono
        {
            get { return this.m_Telefono; }
            set { m_Telefono = value; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Correo del Cliente no puede estar vacio.")]
        public string email
        {
            get { return this.m_email; }
            set { m_email = value; }
        }
    }

}
