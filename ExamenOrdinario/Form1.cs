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

namespace ExamenOrdinario
{
    public partial class Alumnos : Form
    {
        ListaD<Alumno> Alumnoss = new ListaD<Alumno>();
        int[] n_cuenta = new int[30];
        string[] alumno_datos = new string[10];

        public Alumnos()
        {
            InitializeComponent();

            Alumnoss = new ListaD <Alumno>();
            Alumnoss.Comparar = new Comparacion();
            correr();
        }

        private void correr()
        { 
            StreamReader leer_file = new StreamReader(@"C:\Users\Usuario\Documents\U\2do Semestre\Estructura de datos\ExamenOrdinario\Alumnos.txt");
            int cuenta = -1;
            
            while (!leer_file.EndOfStream)
            {
                string datos = leer_file.ReadLine();
                string[] alumno_datos = datos.Split(',');

                cuenta++;

                Alumno datoss = new Alumno();
                datoss.cuenta = Convert.ToString(alumno_datos[0]);
                n_cuenta[cuenta] = Convert.ToInt32(datoss.cuenta);
                datoss.nombre = Convert.ToString(alumno_datos[1]);
                datoss.semestre = Convert.ToString(alumno_datos[2]);
                datoss.grupo = Convert.ToString(alumno_datos[3]);
                datoss.promedio_1 = Convert.ToString(alumno_datos[4]);
                datoss.promedio_2 = Convert.ToString(alumno_datos[5]);
                datoss.promedio_3 = Convert.ToString(alumno_datos[6]);
                datoss.promedio_4 = Convert.ToString(alumno_datos[7]);
                datoss.promedio_5 = Convert.ToString(alumno_datos[8]);
                datoss.promedio_6 = Convert.ToString(alumno_datos[9]);

                Alumnoss.Add(datoss);
                tbx_num.Text = datoss.cuenta;
                txb_nombre.Text = datoss.nombre;
                txb_sem.Text = datoss.semestre;
                txb_grupo.Text = datoss.grupo;
                txb_p1.Text = datoss.promedio_1;
                txb_p2.Text = datoss.promedio_2;
                txb_p3.Text = datoss.promedio_3;
                txb_p4.Text = datoss.promedio_4;
                txb_p5.Text = datoss.promedio_5;
                txb_p6.Text = datoss.promedio_6;

            }
            pasar_primero();
        }

        

        public void buscar(int cuentaa)
        {
            int i = 0;

            while (cuentaa != n_cuenta[i])
            {
                i++;
            }
            MessageBox.Show("Alumno encontrado.", "Alerta", MessageBoxButtons.OK);
        }

        private void pasar_primero()
        {
            Alumno datoss = new Alumno();
            Alumnoss.MoveFirst();
            datoss = Alumnoss.getInfo();
            tbx_num.Text = datoss.cuenta;
            txb_nombre.Text = datoss.nombre;
            txb_sem.Text = datoss.semestre;
            txb_grupo.Text = datoss.grupo;
            txb_p1.Text = datoss.promedio_1;
            txb_p2.Text = datoss.promedio_2;
            txb_p3.Text = datoss.promedio_3;
            txb_p4.Text = datoss.promedio_4;
            txb_p5.Text = datoss.promedio_5;
            txb_p6.Text = datoss.promedio_6;
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            Alumno datoss = new Alumno();

            if (!Alumnoss.isFirst())
            {
                Alumnoss.MoveAnte();
                datoss = Alumnoss.getInfo();
                tbx_num.Text = datoss.cuenta;
                txb_nombre.Text = datoss.nombre;
                txb_sem.Text = datoss.semestre;
                txb_grupo.Text = datoss.grupo;
                txb_p1.Text = datoss.promedio_1;
                txb_p2.Text = datoss.promedio_2;
                txb_p3.Text = datoss.promedio_3;
                txb_p4.Text = datoss.promedio_4;
                txb_p5.Text = datoss.promedio_5;
                txb_p6.Text = datoss.promedio_6;
            }else{
                MessageBox.Show("Este es el primer alumno en la lista.", "Alerta", MessageBoxButtons.OK);
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            Alumno datoss = new Alumno();

            if (!Alumnoss.isLast())
            {
                Alumnoss.MoveNext();
                datoss = Alumnoss.getInfo();
                tbx_num.Text = datoss.cuenta;
                txb_nombre.Text = datoss.nombre;
                txb_sem.Text = datoss.semestre;
                txb_grupo.Text = datoss.grupo;
                txb_p1.Text = datoss.promedio_1;
                txb_p2.Text = datoss.promedio_2;
                txb_p3.Text = datoss.promedio_3;
                txb_p4.Text = datoss.promedio_4;
                txb_p5.Text = datoss.promedio_5;
                txb_p6.Text = datoss.promedio_6;
            }else{
                MessageBox.Show("Este es el ultimo alumnos en la lista.", "Alerta", MessageBoxButtons.OK);
            }
        }

        private void btn_ini_Click(object sender, EventArgs e)
        {
            Alumno datoss = new Alumno();
                Alumnoss.MoveFirst();
                datoss = Alumnoss.getInfo();
                tbx_num.Text = datoss.cuenta;
                txb_nombre.Text = datoss.nombre;
                txb_sem.Text = datoss.semestre;
                txb_grupo.Text = datoss.grupo;
                txb_p1.Text = datoss.promedio_1;
                txb_p2.Text = datoss.promedio_2;
                txb_p3.Text = datoss.promedio_3;
                txb_p4.Text = datoss.promedio_4;
                txb_p5.Text = datoss.promedio_5;
                txb_p6.Text = datoss.promedio_6;
        }

        private void btn_fin_Click(object sender, EventArgs e)
        {
            Alumno datoss = new Alumno();

            Alumnoss.MoveLast();
            datoss = Alumnoss.getInfo();
            tbx_num.Text = datoss.cuenta;
            txb_nombre.Text = datoss.nombre;
            txb_sem.Text = datoss.semestre;
            txb_grupo.Text = datoss.grupo;
            txb_p1.Text = datoss.promedio_1;
            txb_p2.Text = datoss.promedio_2;
            txb_p3.Text = datoss.promedio_3;
            txb_p4.Text = datoss.promedio_4;
            txb_p5.Text = datoss.promedio_5;
            txb_p6.Text = datoss.promedio_6;
        }

        private void brn_modificar_Click(object sender, EventArgs e)
        {
            txb_p1.Enabled = true;
            txb_p2.Enabled = true;
            txb_p3.Enabled = true;
            txb_p4.Enabled = true;
            txb_p5.Enabled = true;
            txb_p6.Enabled = true;
            btn_done.Visible = true;
                  
        }

        private void btn_done_Click(object sender, EventArgs e)
        {  
            Alumnoss.getInfo().promedio_1 = Convert.ToString(txb_p1.Text);
            Alumnoss.getInfo().promedio_2 = Convert.ToString(txb_p2.Text);
            Alumnoss.getInfo().promedio_3 = Convert.ToString(txb_p3.Text);
            Alumnoss.getInfo().promedio_4 = Convert.ToString(txb_p4.Text);
            Alumnoss.getInfo().promedio_5 = Convert.ToString(txb_p5.Text);
            Alumnoss.getInfo().promedio_6 = Convert.ToString(txb_p6.Text);
            txb_p1.Enabled = false;
            txb_p2.Enabled = false;
            txb_p3.Enabled = false;
            txb_p4.Enabled = false;
            txb_p5.Enabled = false;
            txb_p6.Enabled = false;
            btn_done.Visible = false;
            MessageBox.Show("Los promedios de este alumno han sido modificados.", "Alerta", MessageBoxButtons.OK);
        }

        private void btn_borrar_Click(object sender, EventArgs e)
        { 
            Alumno datoss = new Alumno();
            
            if (Alumnoss.getInfo()!= null)
            { 
                MessageBox.Show("Alumno Eliminado", "Alerta", MessageBoxButtons.OK);   
                         
                datoss = Alumnoss.getInfo();
                Alumnoss.Delete(datoss);
                Alumnoss.MoveAnte();
                datoss = Alumnoss.getInfo();
                tbx_num.Text = datoss.cuenta;
                txb_nombre.Text = datoss.nombre;
                txb_sem.Text = datoss.semestre;
                txb_grupo.Text = datoss.grupo;
                txb_p1.Text = datoss.promedio_1;
                txb_p2.Text = datoss.promedio_2;
                txb_p3.Text = datoss.promedio_3;
                txb_p4.Text = datoss.promedio_4;
                txb_p5.Text = datoss.promedio_5;
                txb_p6.Text = datoss.promedio_6;
            }
            else
            {
                MessageBox.Show("La lista a quedado vacia, la aplicacion se cerrara.", "Alerta", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscar(Convert.ToInt32(txb_find.Text));
            txb_find.Clear();
        }
    }
}
