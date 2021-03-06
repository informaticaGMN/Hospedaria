﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospedaria.fdrQuartos
{
    public partial class frmListReservas : Form
    {
        private ConnectionClass db = new ConnectionClass();
        public Form getform { get; set; }
        public string TelaAnterior { get; set; }
        
        public frmListReservas()
        {
            
            InitializeComponent();
            //getform.Visible = true;


        }

        private void frmListReservas_Load(object sender, EventArgs e)
        {
            db.SqlConnection();
            string query = "select hospedagem.nome as NomeHospedagem, clientes.nome as NomeCliente ,reservas.datareserva, reservas.datasaida from hospedagem inner join reservas on reservas.idhospedagem = hospedagem.idhospedagem inner join clientes on clientes.idclientes = reservas.idclientes ";
            db.SqlQuery(query);  Clipboard.SetText(query);

            db.QueryRun();
            DataTable _dt = db.QueryDT();
            dataGridView1.DataSource = _dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (TelaAnterior == "altera")
                {
                    fdrQuartos.frmAlteraReserva objAlt = new fdrQuartos.frmAlteraReserva(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), 'd');

                    objAlt.Show();
                }
                else if (TelaAnterior == "CheckIn")
                {
                    fdrQuartos.CheckIn objAlt = new fdrQuartos.CheckIn(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), 'd');

                    objAlt.Show();
                    
                }
                else
                {
                    Form1 obj = new Form1
                    {
                        Visible = true
                    };
                }

                


                this.Hide();


            }
            else
            {
                MessageBox.Show("Selecione um cliente");
            }
        }

        private void frmListReservas_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaAnterior = "";
        }
        
    }
}
