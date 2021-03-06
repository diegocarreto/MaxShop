﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using posb = PosBusiness;
using UtilitiesForm.Extensions;

namespace WindowsFormsApplication1
{
    public partial class Location : FormBase
    {
        #region Properties

        private posb.Location Entity { get; set; }

        private string EntityName
        {
            get
            {
                return gvList[1, this.SelectRowIndex].Value.ToString();
            }
        }

        private int EntityId
        {
            get
            {
                return int.Parse(gvList[0, this.SelectRowIndex].Value.ToString());
            }
        }

        private int SelectRowIndex
        {
            get
            {
                return gvList.CurrentRow.Index;
            }
        }

        #endregion

        #region Builder

        public Location()
        {
            InitializeComponent();

            this.Entity = new posb.Location();
        }

        #endregion

        #region Events

        private void Measure_Load(object sender, EventArgs e)
        {
            this.ConfigureGridView();

            this.FillGridView();
        }

        private void bntFind_Click(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.Confirm("¿Realmente deseas eliminar la ubicacion [" + this.EntityName + "]?"))
            {
                this.Entity.Id = this.EntityId;

                if (this.Entity.Delete())
                {
                    this.Entity.Id = null;

                    this.FillGridView();
                }
                else
                    this.Alert("Ocurrió un error al intentar eliminar la ubicacion [" + this.EntityName + "]", eForm.TypeError.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
           this.OpenEdit(this.EntityId);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.OpenEdit();
        }

        private void Result(bool IsCorrect, String ErrorMessage, int Id)
        {
            FillGridView();
        }

        private void Measure_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Entity.Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            this.FillGridView();
        }

        #endregion

        #region Methods

        private void OpenEdit(int? Id = null)
        {
            LocationEdit locationEdit = new LocationEdit(Id);

            locationEdit.Result += new LocationEdit.Communication(Result);

            locationEdit.ShowDialog();
        }

        private void ConfigureGridView()
        {
            this.gvList.AutoGenerateColumns = false;

            this.gvList.AllowUserToResizeColumns = false;
        }

        private void FillGridView()
        {
            this.Entity.Name = txtFind.Text;

            this.gvList.DataSource = this.Entity.List();
        }

        #endregion

    }
}
