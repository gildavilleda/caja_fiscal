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
    public partial class Form1 : Form
    
    {
        SqlCommandBuilder constructor, c_dg1, c_dg2;
        SqlDataAdapter guardar;
        SqlDataAdapter guardar_dg1;
        SqlDataAdapter guardar_dg2;
        DataSet ds_dg1;
        DataSet ds_dg2;

        BindingSource bs_dg1 = new BindingSource(), bs_dg2 = new BindingSource();
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void llenadoCaja()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("valor");
            dt.Columns.Add("Mostrar");

            DataRow row = dt.NewRow();
            row["valor"] = "I";
            row["Mostrar"] = "Ingresos";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Valor"] = "E";
            row["Mostrar"] = "Egresos";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["valor"] = "R";
            row["Mostrar"] = "Resumen";
            dt.Rows.Add(row);

            CafStrCaja.DataSource = dt;
            CafStrCaja.DisplayMember = "Mostrar";
            CafStrCaja.ValueMember = "valor";

        }

        private double IsNull(TextBox cajita)
        {
            if (cajita.Text == "")
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(cajita.Text);
            }
        }

        private void total1 ()
        {
            try
            {


                CafNumSumasSalCaja.Text = Convert.ToString( IsNull(CafNumEfectivo) + IsNull(CafNumDocAbono) + IsNull(CafNumDeposBanco));
            }catch(Exception ex)
             
            {
                MessageBox.Show(ex.Message);  
            }

        }
        private void total2()
        {
            try
            {
                CafNumTotal.Text = Convert.ToString( IsNull(CafNumPrimaFianza) + IsNull(CafNumImpNombr) + IsNull(CafNumImpTimyPapel) + IsNull(CafNumImpAguaArdie) + IsNull(CafNumCuotasIgss) + IsNull(CafNumDeposVarios) + IsNull(CafNumDeposJudic) + IsNull(CafNumDeposMunic) + IsNull(CafNumRetencionIsr) + IsNull(CafNumFonPrevMil) + IsNull(CafNumBanTrab) + IsNull(CafNumDisponibil) );
            }catch(Exception ex)

            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {














        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConexionBD conexion = new ConexionBD();
            ds = new DataSet();
            try
            {

                //ds = ConexionBD.ObtenerDatos("select * from Form200");
                llenadoCaja();
                guardar = new SqlDataAdapter();
                guardar = ConexionBD.almacenarDatos("SELECT * FROM Form200");
                guardar.Fill(ds);
                bds.DataSource = ds.Tables[0];

                enlazarTexbox(CafNumForm200, bds);
                enlazarTexbox(CafStrOficina, bds);
                enlazarTexbox(CafStrLugar, bds);
                enlazarTexbox(CafStrDepartamento, bds);
                enlazarTexbox(CajStrSerie, bds);
                enlazarTexbox(CajNumNoFormulario, bds);
                enlazarComboBox(CafStrCaja, bds);
                enlazarDateTimePicker(CafDatCorrespondienteMesAnio, bds);
                enlazarTexbox(CafNumEfectivo, bds);
                enlazarTexbox(CafNumDocAbono, bds);
                enlazarTexbox(CafNumDeposBanco, bds);
                enlazarTexbox(CafNumSumasSalCaja, bds);
                enlazarTexbox(CafNumPrimaFianza, bds);
                enlazarTexbox(CafNumImpNombr, bds);
                enlazarTexbox(CafNumImpTimyPapel, bds);
                enlazarTexbox(CafNumImpAguaArdie, bds);
                enlazarTexbox(CafNumCuotasIgss, bds);
                enlazarTexbox(CafNumDeposVarios, bds);
                enlazarTexbox(CafNumDeposJudic, bds);
                enlazarTexbox(CafNumDeposMunic, bds);
                enlazarTexbox(CafNumRetencionIsr, bds);
                enlazarTexbox(CafNumFonPrevMil, bds);
                enlazarTexbox(CafNumBanTrab, bds);
                enlazarTexbox(CafNumDisponibil, bds);
                enlazarTexbox(CafNumTotal, bds);

                bindingNavigator1.BindingSource = bds;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
            
        {
            try
            {


                constructor = new SqlCommandBuilder(guardar);
                c_dg1 = new SqlCommandBuilder(guardar_dg1);
                c_dg2 = new SqlCommandBuilder(guardar_dg2);

                bds.EndEdit();
                bs_dg1.EndEdit();
                bs_dg2.EndEdit();
                guardar.Update(ds.Tables[0]);
                guardar_dg1.Update(ds_dg1.Tables[0]);
               guardar_dg2.Update(ds_dg2.Tables[0]);
            
            }catch (Exception ex)

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
        private void enlazarComboBox(ComboBox cajta, BindingSource bds, string CampoTabla = "")
        {
            try
            {
                if (CampoTabla == "")
                    CampoTabla = cajta.Name;

                cajta.DataBindings.Clear();
                cajta.DataBindings.Add(
                    new Binding("SelectedValue", bds, CampoTabla, true
                    ));
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void enlazarDateTimePicker(DateTimePicker dateTime, BindingSource bds, String CampoTabla = "")
        {
            try
            {

                if (CampoTabla == "")
                    CampoTabla = dateTime.Name;

                dateTime.DataBindings.Clear();
                dateTime.DataBindings.Add(
                    new Binding("Text", bds, CampoTabla, true));

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuprincipal frm = new menuprincipal();
            frm.Show();
        }

        private void CafNumCorrelativo_TextChanged(object sender, EventArgs e)
        {

        }

        private void CafStrCaja_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dg1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["dgCafNumForm200"].Value = CafNumForm200.Text;
        }

        private void dg2_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["dg2CafNumForm200"].Value = CafNumForm200.Text;
        }

        private void total1_TextChanged(object sender, EventArgs e)
        {
            total1();
        }

        private void total2_TextChanged(object sender, EventArgs e)
        {
            total2();
        }

        private void CafNumForm200_TextChanged(object sender, EventArgs e)
        {
            if (CafNumForm200.Text != "")
            {
                //MessageBox.Show("Entre aqui :)");
                dg1.AutoGenerateColumns = false;
                ds_dg1 = new DataSet();
                guardar_dg1 = new SqlDataAdapter();
                guardar_dg1 = ConexionBD.almacenarDatos("select * from Detalle1 where CafNumForm200 = " + CafNumForm200.Text);
                guardar_dg1.Fill(ds_dg1);
                bs_dg1.DataSource = ds_dg1.Tables[0];
                dg1.DataSource = bs_dg1;


                DataGridViewTextBoxColumn CafDatDia = dg1.Columns["CafDatDia"] as DataGridViewTextBoxColumn;
                DataGridViewTextBoxColumn dgCafNumForm200 = dg1.Columns["dgCafNumForm200"] as DataGridViewTextBoxColumn;
                DataGridViewTextBoxColumn CafStrDescripcion = dg1.Columns["CafStrDescripcion"] as DataGridViewTextBoxColumn;
                DataGridViewTextBoxColumn CafStrForma = dg1.Columns["CafStrForma"] as DataGridViewTextBoxColumn;
                DataGridViewTextBoxColumn CafNumRangoInicio = dg1.Columns["CafNumRangoInicio"] as DataGridViewTextBoxColumn;
                DataGridViewTextBoxColumn CafNumRangoFin = dg1.Columns["CafNumRangoFin"] as DataGridViewTextBoxColumn;
                DataGridViewTextBoxColumn CafNumSumasParc = dg1.Columns["CafNumSumasParc"] as DataGridViewTextBoxColumn;
                DataGridViewTextBoxColumn CafNumSumaTotal = dg1.Columns["CafNumSumaTotal"] as DataGridViewTextBoxColumn;
                

                CafDatDia.DataPropertyName = "CafDatDia";
                dgCafNumForm200.DataPropertyName = "CafNumForm200";
                CafStrDescripcion.DataPropertyName = "CafStrDescripcion";
                CafStrForma.DataPropertyName = "CafStrForma";
                CafNumRangoInicio.DataPropertyName = "CafNumRangoInicio";
                CafNumRangoFin.DataPropertyName = "CafNumRangoFin";
                CafNumSumasParc.DataPropertyName = "CafNumSumasParc";
                CafNumSumaTotal.DataPropertyName = "CafNumSumaTotal";

              dg2.AutoGenerateColumns = false;
              ds_dg2 = new DataSet();
              guardar_dg2 = new SqlDataAdapter();
              guardar_dg2 = ConexionBD.almacenarDatos("select * from Detalle2 where CafNumForm200 = " + CafNumForm200.Text);
              guardar_dg2.Fill(ds_dg2);
              bs_dg2.DataSource = ds_dg2.Tables[0];
              dg2.DataSource = bs_dg2;

             

                DataGridViewTextBoxColumn CafStrForm = dg2.Columns["CafStrForm"] as DataGridViewTextBoxColumn;
                DataGridViewTextBoxColumn dg2CafNumForm200 = dg2.Columns["dg2CafNumForm200"] as DataGridViewTextBoxColumn;
                DataGridViewTextBoxColumn dgCafNumCodNomencl = dg2.Columns["dgCafNumCodNomencl"] as DataGridViewTextBoxColumn;
                DataGridViewTextBoxColumn CafStrDesignacion = dg2.Columns["CafStrDesignacion"] as DataGridViewTextBoxColumn;
                DataGridViewTextBoxColumn CafNumRango1Inicio = dg2.Columns["CafNumRango1Inicio"] as DataGridViewTextBoxColumn;
                DataGridViewTextBoxColumn CafNumRango1Fin = dg2.Columns["CafNumRango1Fin"] as DataGridViewTextBoxColumn;
                DataGridViewTextBoxColumn CafNumCantHojas1 = dg2.Columns["CafNumCantHojas1"] as DataGridViewTextBoxColumn;
                DataGridViewTextBoxColumn CafNumRango2Inicio = dg2.Columns["CafNumRango2Inicio"] as DataGridViewTextBoxColumn;
                DataGridViewTextBoxColumn CafNumRango2Fin = dg2.Columns["CafNumRango2Fin"] as DataGridViewTextBoxColumn;
                DataGridViewTextBoxColumn CafNumCantHojas2 = dg2.Columns["CafNumCantHojas2"] as DataGridViewTextBoxColumn;


                dg2CafNumForm200.DataPropertyName = "CafNumForm200";
                CafStrForm.DataPropertyName = "CafStrForm";
                dgCafNumCodNomencl.DataPropertyName = "CafNumCodNomencl";
                CafStrDesignacion.DataPropertyName = "CafStrDesignacion";
                CafNumRango1Inicio.DataPropertyName = "CafNumRango1Inicio";
                CafNumRango1Fin.DataPropertyName = "CafNumRango1Fin";
                CafNumCantHojas1.DataPropertyName = "CafNumCantHojas1";
                CafNumRango2Inicio.DataPropertyName = "CafNumRango2Inicio";
                CafNumRango2Fin.DataPropertyName = "CafNumRango2Fin";
                CafNumCantHojas2.DataPropertyName = "CafNumCantHojas2";



            }
        }
    }
}