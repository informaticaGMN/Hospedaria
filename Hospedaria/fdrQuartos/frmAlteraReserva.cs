﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospedaria.fdrQuartos
{
    public partial class frmAlteraReserva : Form
    {
        private ConnectionClass db = new ConnectionClass();
        public  Form getform { get; set; }
        private bool control = true;

        List<string> listNames = new List<string>();// LISTAS COM OS NOMES
        List<int> idNames = new List<int>();// LISTAS COM OS NOMES
        List<string> listHospedagem = new List<string>();// LISTAS COM OS NOMES
        List<int> idHospedagem = new List<int>();// LISTAS COM OS NOMES
        List<int> idReserva = new List<int>();// LISTAS COM OS NOMES
        List<DateTime> DataCheckin = new List<DateTime>();// LISTAS COM OS NOMES
        List<DateTime> DataCheckout = new List<DateTime>();// LISTAS COM OS NOMES

        public frmAlteraReserva(string _pNomeSuite = "", string _pNomeCliente = "", string _pDatareserva = "", string _pDataSaida = "", char reserva = 'c', bool exit = false)
        {
            InitializeComponent();
            control = true;


        }
        private void popComboBoxes()
        {

            db.SqlConnection();
            string query = "select hospedagem.nome  as NomeHospedagem, hospedagem.idhospedagem, clientes.nome as NomeCliente , clientes.idclientes,reservas.datareserva, reservas.datasaida, reservas.idreserva from hospedagem inner join reservas on reservas.idhospedagem = hospedagem.idhospedagem inner join clientes on clientes.idclientes = reservas.idclientes  order by reservas.idreserva";
            db.SqlQuery(query); Clipboard.SetText(query);

            SqlDataReader _dr = db.QueryReader();
            if (_dr.HasRows)
            {
                while (_dr.Read())
                {
                    listNames.Add(_dr["NomeCliente"].ToString().Trim());//ADICIONA O QUE FOI LIDO NO SQL A LISTA NOME
                    idNames.Add(Convert.ToInt32(_dr["idclientes"]));
                    idReserva.Add(Convert.ToInt32(_dr["idreserva"]));
                    idHospedagem.Add(Convert.ToInt32(_dr["idhospedagem"]));
                    listHospedagem.Add(_dr["NomeHospedagem"].ToString().Trim());
                    DataCheckin.Add(Convert.ToDateTime(_dr["datareserva"]));
                    DataCheckout.Add(Convert.ToDateTime(_dr["datareserva"]));

                }
                foreach (string item in listHospedagem)
                {
                    cbQuarto.Items.Add(item);
                }
                foreach (string item in listNames)
                {
                    cbNomeCheckIn.Items.Add(item);
                }
                db.closeConnection();
                button3.Visible = true;
                button2.Visible = true;
                if (idReserva.Count > 0)
                {
                    

                }
                else
                {
                    
                }


                cbNomeCheckIn.SelectedIndex = 0;//SELECIONA O PRIMEIRO INDEX PARA SER MOSTRADO LOGO NO INICIO
                cbQuarto.SelectedIndex = 0;

            }
            else
            {
                button3.Visible = false;
                button2.Visible = false;
                MessageBox.Show("Nao existem reservas.");
                this.Hide();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmListReservas frmListReservas = new frmListReservas();
            frmListReservas.getform = this;
            frmListReservas.TelaAnterior = "altera";
            control = false;
            this.Hide();
            frmListReservas.Show();
        }

        private void frmAlteraReserva_Load(object sender, EventArgs e)
        {
            popComboBoxes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idReserva.Count > 0)
            {

                string query = "delete from reservas where idreserva = '" + idReserva[cbNomeCheckIn.SelectedIndex] + "'";
                db.SqlConnection();
                db.SqlQuery(query); Clipboard.SetText(query);
                db.QueryRun();
                db.closeConnection();
                MessageBox.Show("Reserva cancelada.");
                this.Hide();
                getform.Visible = true;
            }
            else
            {

                MessageBox.Show("Reserva nao excluida.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string query = "update reservas set idhospedagem = '" + (cbQuarto.SelectedIndex + 1) + "', idclientes = '" + idNames[cbNomeCheckIn.SelectedIndex] + "',datareserva = '" + datepicker1.Value.ToString("dd/MM/yyyy HH:mm") + "',datasaida = '" + datepicker2.Value.ToString("dd/MM/yyyy HH:mm") + "'  ";

            db.SqlConnection();
            db.SqlQuery(query); Clipboard.SetText(query);
            db.QueryRun();
            db.closeConnection();
            MessageBox.Show("Reserva alterada.");
            this.Close();
            getform.Visible = true;
        }

        private void cbNomeCheckIn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmAlteraReserva_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (control)
            {
                //Form1 form1 = new Form1
                //{
                //    Visible = true
                //};
                getform.Visible = true;
            }
            



        }
    }
}
