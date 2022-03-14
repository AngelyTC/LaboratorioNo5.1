using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LaboratorioNo5
{
    public partial class Form1 : Form
    {
        List<Empleado> personas = new List<Empleado>();
        List<Saldo> datos2 = new List<Saldo>();
        List<sueldo> sueldos = new List<sueldo>();
        int horas;
        int dinero;
        int SueldoMes;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            horas = Int16.Parse(txtHoraMes.Text);
            dinero = Int16.Parse(txtSueldoHora.Text);
            SueldoMes = horas * dinero;

            Empleado persona = new Empleado();
            persona.NoEmpleado = txtNoEmpleado.Text;
            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;
            persona.SueldoPorHora = Convert.ToInt16(txtSueldoHora.Text);

            Saldo datos1 = new Saldo();
            datos1.NoEmpleado2 = txtNoEmpleado.Text;
           datos1.horasDelMes = Convert.ToInt16(txtHoraMes.Text);
            datos1.Mes = txtMes.Text;


            //agregar a lista
            personas.Add(persona);
            datos2.Add(datos1);
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            Leer1("Arch1.txt");
            Leer2("Enero.txt");
        }

        private void Leer1(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1) //el -1 significa la ultima linea que no existe demostrando el final del archivo
            {
                Empleado persona = new Empleado();
                persona.NoEmpleado = reader.ReadLine();
                persona.Nombre = reader.ReadLine();
                persona.Apellido = reader.ReadLine();
                persona.SueldoPorHora = Convert.ToInt32(reader.ReadLine());

                //agregar a lista
                personas.Add(persona);
            }

            reader.Close();
        }

        private void Leer2(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1) //el -1 significa la ultima linea que no existe demostrando el final del archivo
            {

                Saldo datos1 = new Saldo();
                datos1.NoEmpleado2 = reader.ReadLine();
                datos1.horasDelMes = Convert.ToInt16(reader.ReadLine());
                datos1.Mes = reader.ReadLine();

                //agregar a lista
                datos2.Add(datos1);

            }

            reader.Close();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            dataGridView1.DataSource = personas;
            dataGridView1.Refresh();

            dataGridView2.DataSource = null;
            dataGridView2.Refresh();

            dataGridView2.DataSource = datos2;
            dataGridView2.Refresh();


            cmbEmpleados.Items.Add(txtNombre.Text);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar("Arch1.txt");
            Guardar2("Enero.txt");
        }

        private void Guardar(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);

            //las variables var utilizan cualquier tipo de variable ya sea string u otros
            foreach (var persona in personas)
            {
                writer.WriteLine(persona.NoEmpleado);
                writer.WriteLine(persona.Nombre);
                writer.WriteLine(persona.Apellido);
                writer.WriteLine(persona.SueldoPorHora);

            }
            //este writer.Close() ira fuera del ciclo
            writer.Close();

        }

        private void Guardar2(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);

            //las variables var utilizan cualquier tipo de variable ya sea string u otros
            foreach (var datos1 in datos2)
            {
                writer.WriteLine(datos1.NoEmpleado2);
                writer.WriteLine(datos1.horasDelMes);
                writer.WriteLine(datos1.Mes);

            }
            //este writer.Close() ira fuera del ciclo
            writer.Close();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtNoEmpleado.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtSueldoHora.Clear();

            txtNoEmpleado.Clear();
            txtHoraMes.Clear();
            txtMes.Clear();
        }

        private void btnVerCombo_Click(object sender, EventArgs e)
        {
         
            
                for (int i = 0; i < personas.Count; i++)
                {

                    for (int j = 0; j < datos2.Count; j++)
                    {
                    if (cmbEmpleados.Text == personas[i].NoEmpleado)
                    {
                        if (personas[i].NoEmpleado == datos2[j].NoEmpleado2)
                        {

                            sueldo sueldos1 = new sueldo();

                            sueldos1.NoEmpleado = personas[i].NoEmpleado;

                            sueldos1.Nombre = personas[i].Nombre;

                            sueldos1.Sueldo = personas[i].SueldoPorHora * datos2[j].horasDelMes;
                            sueldos1.Mes = datos2[j].Mes;

                            sueldos.Add(sueldos1);
                        }

                    }

                }
                dataGridView3.DataSource = sueldos;
                dataGridView3.Refresh();

            }
        }

        private void btncalcular_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < personas.Count; i++)
            {

                for (int j = 0; j < datos2.Count; j++)
                {

                    if (personas[i].NoEmpleado == datos2[j].NoEmpleado2)
                    {

                        sueldo sueldos1 = new sueldo();

                        sueldos1.NoEmpleado = personas[i].NoEmpleado;

                        sueldos1.Nombre = personas[i].Nombre;

                        sueldos1.Sueldo = personas[i].SueldoPorHora * datos2[j].horasDelMes;
                        sueldos1.Mes = datos2[j].Mes;

                        sueldos.Add(sueldos1);
                    }
                }
            }
            dataGridView4.DataSource = sueldos;
            dataGridView4.Refresh();
        }
    }
}

