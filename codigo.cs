using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace caja_fiscal
{
    public partial class Codigo : Form
    {
        SqlCommandBuilder constructor;
        SqlDataAdapter guardar;
        DataSet ds;
        public Codigo()
    
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuprincipal frm = new menuprincipal();
            frm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            constructor = new SqlCommandBuilder(guardar);
            bindingSource1.EndEdit();
            guardar.Update(ds.Tables[0]);
        }

        private void codigo_Load(object sender, EventArgs e)
        {
            ConexionBD conexion = new ConexionBD();
            ds = new DataSet();
            try
            {
                guardar = new SqlDataAdapter();
                guardar = ConexionBD.almacenarDatos("SELECT * FROM Codigo");
                guardar.Fill(ds);
                bindingSource1.DataSource = ds.Tables[0];

                enlazarTexbox(CafStrCodigo, bindingSource1);
                enlazarTexbox(CafStrDescripcion, bindingSource1);
                enlazarTexbox(CafNumCodNomencl, bindingSource1);

                bindingNavigator1.BindingSource = bindingSource1;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }       

       private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
        private void enlazarTexbox(TextBox cajita, BindingSource bds, string CampoTabla = "")
        {
            try
            {
                if (CampoTabla == "")
                    CampoTabla = cajita.Name;

                cajita.DataBindings.Clear();
                cajita.DataBindings.Add(
                    new Binding("Text", bds, CampoTabla, true)

                    );

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
