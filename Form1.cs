using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Examen_Práctico_RA2_Charlini
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {


            DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres salir del programa?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_datos.Rows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int fila;
                fila = dgv_datos.CurrentRow.Index;
                DialogResult respuesta;
                respuesta = MessageBox.Show("Este seguro que desea eliminar este registro?", "Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    dgv_datos.Rows.RemoveAt(fila);
                    MessageBox.Show("Registro eliminado");

                }
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_matricula.Clear();
            txt_direccion.Clear();
            txt_email.Clear();
            txt_nombre.Clear();
            txt_telefono.Clear();
            txt_maestro_titular.Clear();
            dgv_datos.Rows.Clear();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            btn_eliminar.Enabled = false;
            btn_guardar.Enabled = true;


            txt_direccion.Clear();
            txt_email.Clear();
            txt_nombre.Clear();
            txt_telefono.Clear();
            txt_matricula.Clear();
            txt_maestro_titular.Clear();
            cbo_curso.Items.Clear();
            cbo_seccion.Items.Clear();
            cbo_area_tecnica.Items.Clear();

            foreach (Control control in Controls)
            {
                if (control is RadioButton radioButton)
                {
                    rbo_masculino.Checked = false;
                    rbo_femenino.Checked = false;
                }


            }
        }

            private void btn_guardar_Click(object sender, EventArgs e)
            {
                btn_guardar.Enabled = true;

                btn_guardar.Enabled = false;
                btn_eliminar.Enabled = true;
                btn_agregar.Enabled = true;
                btn_nuevo.Enabled = true;

                if (dlg_guardar.ShowDialog() == DialogResult.OK)
                {

                    DialogResult resultado = dlg_guardar.ShowDialog();

                    // Verificar si el usuario presionó el botón Guardar
                    if (resultado == DialogResult.OK)
                    {

                        string ruta_archivo = dlg_guardar.FileName;
                        string crea_texto = ruta_archivo;
                        using (StreamWriter archivo = File.CreateText(ruta_archivo))
                        {
                            archivo.WriteLine(txt_matricula.Text); archivo.WriteLine(txt_nombre.Text); archivo.WriteLine(cbo_curso); archivo.WriteLine(cbo_seccion.Text); archivo.WriteLine(cbo_area_tecnica.Text);
                            foreach (DataGridViewRow fila in dgv_datos.Rows)
                            {
                                // Obtiene los valores de las celdas (supongamos que son 4 columnas)
                                string valorColumna1 = fila.Cells[0].Value?.ToString() ?? "";
                                string valorColumna2 = fila.Cells[1].Value?.ToString() ?? "";
                                string valorColumna3 = fila.Cells[5].Value?.ToString() ?? "";
                                string valorColumna4 = fila.Cells[6].Value?.ToString() ?? "";
                                string valorColumna5 = fila.Cells[7].Value?.ToString() ?? "";

                                // Escribe los valores en el archivo de texto
                                archivo.WriteLine($"{valorColumna1}, {valorColumna2}, {valorColumna3},{valorColumna4},{valorColumna5}");


                            }
                        }




                    }

                }
            }

        private void btn_agregar_Click_1(object sender, EventArgs e)
        {
            btn_eliminar.Enabled = true;


            string genero;

            if (rbo_masculino.Checked)
            {
                genero = "Maculino";
            }
            else
            {
                genero = "Femenino";
            }
            dgv_datos.Rows.Add(txt_nombre.Text, txt_matricula.Text, txt_direccion.Text, txt_telefono.Text, genero, cbo_curso.Text, cbo_seccion.Text, cbo_area_tecnica.Text, txt_maestro_titular.Text);

        }
    }

}

