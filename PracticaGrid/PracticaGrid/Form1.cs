using grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaGrid
{
    public partial class Form1 : Form
    {
        ArrayList listaPersonas = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            if (txtEmpleado.Text == "")
            {
                errorProvider1.SetError(txtEmpleado, "Ingrese un ID");
                txtEmpleado.Focus();
                return; // Interrumpe y finaliza la ejecucion del metodo actual
            }
            else
            {
                errorProvider1.SetError(txtEmpleado, "");
            }

            if (txtNombres.Text == "")
            {
                errorProvider1.SetError(txtNombres, "Ingrese los nombres del colaborador");
                txtNombres.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtNombres, "");
            }

            if (txtApellidos.Text == "")
            {
                errorProvider1.SetError(txtApellidos, "Ingrese los apellidos del colaborador");
                txtApellidos.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtApellidos, "");
            }

            if (Utilidades.EsCorreoValido(txtEmail.Text) == false)
            {
                errorProvider1.SetError(txtEmail, "Ingrese un correo valido");
                txtEmail.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }

            decimal salario1;
            if (!decimal.TryParse(txtSalario.Text, out salario1))
            {
                errorProvider1.SetError(txtSalario, "Ingrese un salario Valido");
                txtSalario.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtSalario, "");
            }

            Persona colaborador1 = new Persona();
            colaborador1.Id = int.Parse(txtEmpleado.Text);
            colaborador1.Nombres = txtNombres.Text;
            colaborador1.Apellidos = txtApellidos.Text;
            colaborador1.Correo = txtEmail.Text;
            colaborador1.Salario = salario1;
            colaborador1.FechaNacimiento = dateTimePicker1.Value;
            listaPersonas.Add(colaborador1);
            dgvdatos.DataSource = null; //Limpiar el datadource antes de asignar la nueva linea
            dgvdatos.DataSource = listaPersonas;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Persona miColaborador1 = new Persona();

            miColaborador1.Id = 1;
            miColaborador1.Nombres = "Elena Carolina";
            miColaborador1.Apellidos = "Gonzalez Rodríguez";
            miColaborador1.Correo = "elena.gonzalez@ejemplo.com";
            miColaborador1.FechaNacimiento = new DateTime(1990, 5, 15);
            listaPersonas.Add(miColaborador1);
            dgvdatos.DataSource = listaPersonas;

            
        }

        private void dgvdatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdatos.CurrentRow != null && e.RowIndex >= 0)
            {
                // Obtenemos el índice de la fila seleccionada
                int indice = dgvdatos.CurrentRow.Index;

                // Extraemos el objeto Persona del ArrayList y lo casteamos
                Persona p = (Persona)listaPersonas[indice];

                // Pasamos los datos a los TextBox
                txtEmpleado.Text = p.Id.ToString();
                txtNombres.Text = p.Nombres;
                txtApellidos.Text = p.Apellidos;
                txtEmail.Text = p.Correo;
                txtSalario.Text = p.Salario.ToString();
                dateTimePicker1.Value = p.FechaNacimiento;
            }
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            if (dgvdatos.CurrentRow != null)
            {
                //Aquí Ponemos las mismas validaciones de campos 
                if (txtEmpleado.Text == "")
                {
                    errorProvider1.SetError(txtEmpleado, "Ingrese un ID");
                    txtEmpleado.Focus();
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtEmpleado, "");
                }

                if (txtNombres.Text == "")
                {
                    errorProvider1.SetError(txtNombres, "Ingrese los nombres del colaborador");
                    txtNombres.Focus();
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtNombres, "");
                }

                if (txtApellidos.Text == "")
                {
                    errorProvider1.SetError(txtApellidos, "Ingrese los apellidos del colaborador");
                    txtApellidos.Focus();
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtApellidos, "");
                }

                if (Utilidades.EsCorreoValido(txtEmail.Text) == false)
                {
                    errorProvider1.SetError(txtEmail, "Ingrese un correo valido");
                    txtEmail.Focus();
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtEmail, "");
                }

                decimal salario1;
                if (!decimal.TryParse(txtSalario.Text, out salario1))
                {
                    errorProvider1.SetError(txtSalario, "Ingrese un salario Valido");
                    txtSalario.Focus();
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtSalario, "");
                }

                //Obtenemos la posición actual
                int indice = dgvdatos.CurrentRow.Index;

                //Obtenemos el objeto actual de la lista
                Persona p = (Persona)listaPersonas[indice];

                //Actualizamos sus propiedades con lo que haya en los TextBox
                p.Id = int.Parse(txtEmpleado.Text);
                p.Nombres = txtNombres.Text;
                p.Apellidos = txtApellidos.Text;
                p.Correo = txtEmail.Text;
                p.Salario = decimal.Parse(txtSalario.Text);
                p.FechaNacimiento = dateTimePicker1.Value;

                //Refrescamos el DataGridView
                dgvdatos.DataSource = null;
                dgvdatos.DataSource = listaPersonas;

                MessageBox.Show("Registro modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor seleccione un registro de la tabla para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvdatos.CurrentRow != null)
            {
                // Mensaje de confirmación antes de borrar
                DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar este colaborador?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    // Obtenemos el índice de la fila seleccionada
                    int indice = dgvdatos.CurrentRow.Index;

                    // Removemos el objeto del ArrayList
                    listaPersonas.RemoveAt(indice);

                    // Refrescamos el DataGridView
                    dgvdatos.DataSource = null;
                    dgvdatos.DataSource = listaPersonas;

                    // Limpiamos los TextBox (opcional)
                    txtEmpleado.Clear();
                    txtNombres.Clear();
                    txtApellidos.Clear();
                    txtEmail.Clear();
                    txtSalario.Clear();
                    dateTimePicker1.Value = DateTime.Now;
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un registro de la tabla para borrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
