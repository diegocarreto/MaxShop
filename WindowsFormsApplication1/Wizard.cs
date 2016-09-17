using System;
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
using Utilities.Extensions;

namespace WindowsFormsApplication1
{
    public partial class Wizard : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage, int IdPm, TextBox TxtFocus);

        public event Communication Result;

        private int IdProduct = 0;

        #endregion

        #region Properties

        public TextBox TxtFocus { get; set; }

        public bool IsActive
        {
            set { this.cbActive.Enabled = value; }
        }


        #endregion

        #region Builder

        public Wizard()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void button6_Click(object sender, EventArgs e)
        {
            this.cmbProduct.SelectedIndex = 0;
            this.cmbProduct.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int? id = null;

            if (this.cmbLocation.SelectedIndex > 0 && this.cbUpdate.Checked)
                id = int.Parse(this.cmbLocation.SelectedValue.ToString());

            LocationEdit LocationEdit = new LocationEdit(id);

            LocationEdit.Result += new LocationEdit.Communication(this.ResultEditLocation);

            LocationEdit.ShowDialog();
        }

        private void ProductEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.cmbProduct;
            this.cmbProduct.Focus();

            this.GetProducts();
            this.GetGroups();
            this.GetLabels();
            this.GetMaterials();
            this.GetBrands();
            this.GetMeasures();
            this.GetLocations();
            this.GetCompanies();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex.Equals(0))
            {
                if (cmbLabel.SelectedIndex > 0)
                {
                    if (cmbGroup.SelectedIndex > 0)
                    {
                        if (this.cmbCompany.SelectedIndex > 0)
                        {
                            if (!string.IsNullOrEmpty(txtPrice.Text))
                            {
                                this.SaveProduct();
                            }
                            else
                                this.Alert("Debe indicar el precio");
                        }
                        else
                            this.Alert("Debe indicar el negocio");
                    }
                    else
                        this.Alert("Debe indicar el grupo del producto");
                }
                else
                    this.Alert("Debe indicar la etiqueta del producto");
            }
            else
            {
                if (this.cmbCompany.SelectedIndex > 0)
                {
                    if (!string.IsNullOrEmpty(txtPrice.Text))
                    {
                        this.SaveProduct();
                    }
                    else
                        this.Alert("Debe indicar el precio");
                }
                else
                    this.Alert("Debe indicar el negocio");
            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex.Equals(0))
            {
                this.gbProduct.Enabled = true;
                //this.cbUpdate.Enabled = true;
            }
            else
            {
                this.gbProduct.Enabled = false;

                //this.cbUpdate.Checked = false;
                //this.cbUpdate.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int? id = null;

            if (this.cmbLabel.SelectedIndex > 0 && cbUpdate.Checked)
                id = int.Parse(this.cmbLabel.SelectedValue.ToString());

            LabelsEdit LabelsEdit = new LabelsEdit(id);

            LabelsEdit.Result += new LabelsEdit.Communication(ResultEditLabels);

            LabelsEdit.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = null;

            if (this.cmbMaterial.SelectedIndex > 0 && cbUpdate.Checked)
                id = int.Parse(this.cmbMaterial.SelectedValue.ToString());

            MaterialEdit mot = new MaterialEdit(id);

            mot.Result += new MaterialEdit.Communication(ResultEditMot);

            mot.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = null;

            if (this.cmbGroup.SelectedIndex > 0 && this.cbUpdate.Checked)
                id = int.Parse(this.cmbGroup.SelectedValue.ToString());

            GroupEdit GroupEdit = new GroupEdit(id);

            GroupEdit.Result += new GroupEdit.Communication(ResultEditGroups);

            GroupEdit.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int? id = null;

            if (this.cmbMeasure.SelectedIndex > 0 && this.cbUpdate.Checked)
                id = int.Parse(this.cmbMeasure.SelectedValue.ToString());

            MeasureEdit MeasureEdit = new MeasureEdit(id);

            MeasureEdit.Result += new MeasureEdit.Communication(ResultEditMeasures);

            MeasureEdit.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int? id = null;

            if (this.cmBrand.SelectedIndex > 0 && this.cbUpdate.Checked)
                id = int.Parse(this.cmBrand.SelectedValue.ToString());

            BrandEdit BrandsEdit = new BrandEdit(id);

            BrandsEdit.Result += new BrandEdit.Communication(ResultEditBrands);

            BrandsEdit.ShowDialog();
        }


        #endregion

        #region Methods

        private void GetCompanies()
        {
            using (posb.Company company = new posb.Company())
            {
                this.cmbCompany.Fill(company.List());
            }
        }

        private void GetLocations()
        {
            using (posb.Location Location = new posb.Location())
            {
                this.cmbLocation.Fill(Location.List());
            }
        }

        private void GetProducts()
        {
            using (posb.Product Product = new posb.Product())
            {
                this.cmbProduct.Fill(Product.List());
            }
        }

        private void GetLabels()
        {
            using (posb.Label Label = new posb.Label())
            {
                this.cmbLabel.Fill(Label.List());
            }
        }

        private void GetMaterials()
        {
            using (posb.Material Material = new posb.Material())
            {
                this.cmbMaterial.Fill(Material.List());
            }
        }

        private void GetGroups()
        {
            using (posb.Group Group = new posb.Group())
            {
                this.cmbGroup.Fill(Group.List());
            }
        }

        private void GetBrands()
        {
            using (posb.Brand Brand = new posb.Brand())
            {
                this.cmBrand.Fill(Brand.List());
            }
        }

        private void GetMeasures()
        {
            using (posb.Measure Measure = new posb.Measure())
            {
                this.cmbMeasure.Fill(Measure.List());
            }
        }

        private void SaveProduct()
        {
            if (cmbProduct.SelectedIndex.Equals(0))
            {
                using (posb.Product Entity = new posb.Product
                {
                    IdLabel = int.Parse(this.cmbLabel.SelectedValue.ToString()),
                    IdMaterial = int.Parse(this.cmbMaterial.SelectedValue.ToString()),
                    IdGroup = int.Parse(this.cmbGroup.SelectedValue.ToString()),
                    Active = true,
                })
                {
                    if (Entity.IdMaterial.Equals(0))
                        Entity.IdMaterial = null;

                    if (Entity.Exist())
                    {
                        string message = this.cmbLabel.Text + (this.cmbMaterial.SelectedIndex > 0 ? " de " + this.cmbMaterial.Text : string.Empty);

                        this.Alert("Ya se encuentra registrado el producto [" + message + "]");
                    }
                    else
                    {
                        Entity.Save();

                        this.IdProduct = Entity.Id.Value;

                        this.SavePM(this.IdProduct);
                    }
                }
            }
            else
            {
                this.IdProduct = int.Parse(this.cmbProduct.SelectedValue.ToString());

                this.SavePM(this.IdProduct);
            }
        }

        private void SavePM(int Id)
        {
            using (posb.PM Entity = new posb.PM
            {
                IdProduct = Id,
                IdMeasure = int.Parse(this.cmbMeasure.SelectedValue.ToString()),
                IdBrand = int.Parse(this.cmBrand.SelectedValue.ToString()),
                Price = decimal.Parse(this.txtPrice.Text),
                BarCode = txtCodigo.Text,
                Active = this.cbActive.Checked,
                CodeVendor = this.txtCodigoProveedor.Text,
                Freight = this.cbFreight.Checked,
                IdLocation = int.Parse(this.cmbLocation.SelectedValue.ToString()),
                IdCompany = int.Parse(this.cmbCompany.SelectedValue.ToString()),
            })
            {
                if (Entity.IdMeasure.Equals(0))
                    Entity.IdMeasure = null;

                if (Entity.IdBrand.Equals(0))
                    Entity.IdBrand = null;

                if (Entity.Exist())
                    this.Alert("Ya se encuentra registrado el PM [" + this.cmbLabel.Text + " " + this.cmbMeasure.Text + "]");
                else
                {
                    Entity.Save();

                    if (this.Result != null)
                        this.Result(true, "", Entity.Id.Value, this.TxtFocus);

                    if (this.AppSet<bool>("WizardCloseWhenFinishedAdding"))
                    {
                        this.Close();
                    }
                    else
                    {
                        this.GetProducts();

                        this.cmbProduct.SelectedValue = this.IdProduct;
                        this.cbUpdate.Checked = false;

                        this.cmbLabel.SelectedIndex = 0;
                        this.cmbMaterial.SelectedIndex = 0;
                        this.cmbGroup.SelectedIndex = 0;

                        this.cmbMeasure.SelectedIndex = 0;
                        this.cmBrand.SelectedIndex = 0;
                        this.cmbLocation.SelectedIndex = 0;

                        this.txtPrice.Text = string.Empty;
                        this.txtCodigo.Text = string.Empty;
                        this.txtCodigoProveedor.Text = string.Empty;

                        this.cbActive.Checked = true;

                        this.cmbProduct.Focus();
                    }
                }
            }
        }

        private void ResultEditLabels(bool IsCorrect, String ErrorMessage, int Id)
        {
            this.GetLabels();

            this.cmbLabel.SelectedValue = Id;
        }

        private void ResultEditMot(bool IsCorrect, String ErrorMessage, int Id)
        {
            this.GetMaterials();

            this.cmbMaterial.SelectedValue = Id;
        }

        private void ResultEditGroups(bool IsCorrect, String ErrorMessage, int Id)
        {
            this.GetGroups();

            this.cmbGroup.SelectedValue = Id;
        }

        private void ResultEditMeasures(bool IsCorrect, String ErrorMessage, int Id)
        {
            this.GetMeasures();

            this.cmbMeasure.SelectedValue = Id;
        }

        private void ResultEditBrands(bool IsCorrect, String ErrorMessage, int Id)
        {
            this.GetBrands();

            this.cmBrand.SelectedValue = Id;
        }

        private void ResultEditLocation(bool IsCorrect, String ErrorMessage, int Id)
        {
            this.GetLocations();

            this.cmbLocation.SelectedValue = Id;
        }

        #endregion
    }
}
