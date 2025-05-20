using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace PedidosApp
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable Datos = NTrabajador.Login(txtUsuario.Text.Trim(),
                txtPassword.Text.Trim());
            //Evaluar si existe el usuario
            try
            {
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("No tiene acceso al sistema", "Sistema de Ventas",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    FrmPrincipal frm = new FrmPrincipal();
                    frm.Idtrabajador = Datos.Rows[0][0].ToString();
                    frm.Apellidos = Datos.Rows[0][1].ToString();
                    frm.Nombre = Datos.Rows[0][2].ToString();
                    frm.Acceso = Datos.Rows[0][3].ToString();
                    frm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
