using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Extensions;

namespace WindowsFormsApplication1
{
    public partial class MaxShop : Form
    {
        #region Members

        private RefillList RefillList = null;

        private Client Client = null;

        private Provider Provider = null;

        private Configuration Configuration = null;

        private Location LocationW = null;

        private Refill Refill = null;

        private Loan Loan = null;

        private Employee Employee = null;

        private Concentrated Concentrated = null;

        private PurchasePM PurchasePM = null;

        private TruperBrowser TruperBrowser = null;

        private Income Income = null;

        private Expense Expense = null;

        private Calc Calc = null;

        private StockPM StockPM = null;

        private Product Product = null;

        private Measure Measure = null;

        private PM PM = null;

        private Sale Sale = null;

        private Group Group = null;

        private Material Material = null;

        private Labels Labels = null;

        private Brand Brand = null;

        private AddProduct AddProduct = null;

        private Purchase Purchase = null;

        private Budgetary Budgetary = null;

        private Wizard Wizard = null;

        private SalePM SalePM = null;

        #endregion

        #region Builder

        public MaxShop()
        {
            //Solution test = new Solution();

            //int[] array =
            //    { 
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //     1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,1,1000,1,200,1,300,2,90,2,100,2,100,2,3000,4,5000,
            //    };

            //var timer = Stopwatch.StartNew();

            //int moves = test.Paint(array);

            //timer.Stop();

            //var time = timer.Elapsed;

            //var sss = 0;



            //Solution test = new Solution();

            //int[] array =
            //    { 
            //      5,5,5,4,5,5,5,5
            //    };

            //var timer = Stopwatch.StartNew();

            //int moves = test.StudentsPhoto(array);

            //timer.Stop();

            //var time = timer.Elapsed;

            //var sss = 0;

            //int result = test.Jumps(10, 85, 30);

            //int[] array = 
            //{ 
            //    -1000,
            //    1000,
            //    2,
            //     3,
            //    567,
            //    100,
            //    8994,
            //    23234,
            //    34,
            //    343,
            //    987654,
            //    3343,
            //    2333,
            //    234234,
            //};

            //var timer2 = Stopwatch.StartNew();

            //int result2 = test.TapeEquilibrium(array);

            //timer2.Stop();

            //var timere2 = timer2.Elapsed;


            ////*********************************************
            //int[] array2 = 
            //{ 
            //    2,
            //    3,
            //    1,
            //    5
            //};


            //var timer2 = Stopwatch.StartNew();

            //int result3 = test.PermMissingElem(array2);

            //timer2.Stop();

            //var time2 = timer.Elapsed;

            InitializeComponent();
        }

        #endregion

        #region Events

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Provider = ShowOrActiveForm(Provider, typeof(Provider)) as Provider;
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Refill = ShowOrActiveForm(Refill, typeof(Refill)) as Refill;
        }

        private void ubicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ubicacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LocationW = ShowOrActiveForm(LocationW, typeof(Location)) as Location;
        }

        private void accionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration = ShowOrActiveForm(Configuration, typeof(Configuration), true) as Configuration;
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Loan = ShowOrActiveForm(Loan, typeof(Loan)) as Loan;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Employee = ShowOrActiveForm(Employee, typeof(Employee)) as Employee;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Concentrated = ShowOrActiveForm(Concentrated, typeof(Concentrated)) as Concentrated;
        }

        private void toolStripTextBox1_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(toolStripTextBox1.Text))
            {
                string url = "https://www.truper.com.mx/CatVigente/buscador.php?palabra=" + toolStripTextBox1.Text.Trim().Replace(" ", "+");

                if (toolStripMenuItem7.Checked)
                {
                    LoadProcessInControl("chrome.exe", this, false, url);
                }
                else
                {
                    TruperBrowser = ShowOrActiveForm(TruperBrowser, typeof(TruperBrowser)) as TruperBrowser;

                    TruperBrowser.ChangeUrl(url);
                }

                for (int x = 0; x < menuStrip1.Items.Count; x++)
                    ((System.Windows.Forms.ToolStripDropDownItem)menuStrip1.Items[x]).HideDropDown();

                toolStripTextBox1.Text = string.Empty;
            }
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            string url = "https://www.truper.com.mx";

            LoadProcessInControl("chrome.exe", this, false, url);
        }

        private void toolStripMenuItem7_Click_1(object sender, EventArgs e)
        {
            if (toolStripMenuItem7.Checked)
                toolStripMenuItem7.Checked = false;
            else
                toolStripMenuItem7.Checked = true;
        }

        private void MaxShop_Load(object sender, EventArgs e)
        {
            PosBusiness.Configuration conf = new PosBusiness.Configuration();

            this.timer1.Interval = conf.GetValue<int>("checkBackUpHours") * 60000;
            this.BackUp();

            var currentIp = this.AppSet<string>("DataSource");
            this.AddStatusBar(currentIp);

            if (!this.AppSet<bool>("ItIsRepository"))
            {
                var ipinfo = IPInfo.GetIPInfo(this.AppSet<string>("MacAddress"));

                if (ipinfo == null)
                {
                    // Machine Not Found!
                }
                else
                {
                    var ip = ipinfo.IPAddress;
                    //var hostname = ipinfo.HostName;

                    if (!ip.Equals(currentIp))
                    {
                        this.SetConfig("DataSource", ip);

                        MessageBox.Show("Cambio la dirección del repositorio, se reiniciara la aplicación.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        Application.Restart();
                    }
                }
            }


            this.Text = "MaxShop V1.0.0 - " + this.AppSet<string>("shopName").Replace("°", " ").Trim() + " - Suc. " + this.AppSet<string>("branchOffice") + " - Caja " + this.AppSet<string>("CashRegister");

            toolStripMenuItem3.Visible = this.AppSet<bool>("ShowOptionTruper");


            using (PosBusiness.Box box = new PosBusiness.Box 
            {
                IdUser = 1,
                CashRegister = this.AppSet<int>("CashRegister")
            })
            {
                if (!box.Exist())
                {
                    Box boxUi = new Box(true);
                    boxUi.ShowDialog();
                }
            }

            //int[] arr = { 3, 8, 9, 7, 6 };
            //int[] arr = { 3, 8, 9, 7, 6 };


            //int[] arr = { 3 };

            //new Codility().CyclicRotation(arr, -1);

            this.comprasToolStripMenuItem1.ShortcutKeys = Keys.Alt | Keys.C;
            this.googleToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.G;
            this.mnCatalogosPM.ShortcutKeys = Keys.Alt | Keys.P;
            this.toolStripMenuItem12.ShortcutKeys = Keys.Alt | Keys.R;
            this.ventasToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.V;

            this.OpenSale();
        }

        private void gastosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Expense = ShowOrActiveForm(Expense, typeof(Expense)) as Expense;
        }

        private void MaxShop_FormClosing(object sender, FormClosingEventArgs e)
        {
            //int hwnd = FindWindow("Shell_TrayWnd", "");
            //ShowWindow(hwnd, SW_SHOW);
        }

        private void toolStripTextBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(toolStripTextBox3.Text))
            {
                string find = toolStripTextBox3.Text.Trim().Replace(" ", "+");

                LoadProcessInControl("chrome.exe", this, false, "https://www.google.com.mx/search?q=" + find + "&source=lnms&tbm=isch&sa=X&ved=0ahUKEwj0wIT4pv_JAhVB5iYKHUEoBr0Q_AUIBygB&biw=1366&bih=667");
            }
        }

        private void googleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LoadProcessInControl("chrome.exe", this, false, "https://www.google.com.mx");
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Income = ShowOrActiveForm(Income, typeof(Income)) as Income;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Income = ShowOrActiveForm(Income, typeof(Income)) as Income;
        }

        private void blockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadProcessInControl("notepad.exe", this);
        }

        private void calculadoraPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calc = ShowOrActiveForm(Calc, typeof(Calc)) as Calc;
        }

        private void gastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expense = ShowOrActiveForm(Expense, typeof(Expense)) as Expense;
        }

        private void etiquetasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Labels = ShowOrActiveForm(Labels, typeof(Labels)) as Labels;
        }

        private void materialesOTiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Material = ShowOrActiveForm(Material, typeof(Material)) as Material;
        }

        private void mnCatalogosProductos_Click(object sender, EventArgs e)
        {
            Product = ShowOrActiveForm(Product, typeof(Product)) as Product;
        }

        private void pMToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void wizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wizard = ShowOrActiveForm(Wizard, typeof(Wizard)) as Wizard;
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockPM = ShowOrActiveForm(StockPM, typeof(StockPM)) as StockPM;
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SalePM = ShowOrActiveForm(SalePM, typeof(SalePM)) as SalePM;
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadProcessInControl("calc.exe", this);
        }

        private void mnArchivoReiniciar_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void mnArchivoSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnVentanasCascada_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void mnVentanasHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void mnVentanasVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void mnCatalogosPM_Click(object sender, EventArgs e)
        {
            PM = ShowOrActiveForm(PM, typeof(PM)) as PM;

            PM.UpdateList += new PM.Communication(UpdateList);
        }

        private void UpdateList(bool IsCorrect, string ErrorMessage)
        {
            if (this.Purchase != null)
                this.Purchase.SetAutoCompleteProducts();

            if (this.Sale != null)
                this.Sale.SetAutoCompleteProducts();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Group = ShowOrActiveForm(Group, typeof(Group)) as Group;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void etiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {

        }

        private void mnCatalogosMedidas_Click_2(object sender, EventArgs e)
        {
            Measure = ShowOrActiveForm(Measure, typeof(Measure)) as Measure;
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brand = ShowOrActiveForm(Brand, typeof(Brand)) as Brand;
        }

        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProduct = ShowOrActiveForm(AddProduct, typeof(AddProduct)) as AddProduct;
        }

        private void comprasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Purchase = ShowOrActiveForm(Purchase, typeof(Purchase)) as Purchase;

            Purchase myPurchase = new Purchase();

            myPurchase.MdiParent = this;
            myPurchase.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenSale();
        }

        private void cotizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Budgetary = ShowOrActiveForm(Budgetary, typeof(Budgetary)) as Budgetary;
        }

        #endregion

        #region Methods

        public void OpenSale()
        {
            Sale mySale = new Sale();

            mySale.MdiParent = this;
            mySale.Show();
        }

        private void SetConfig(string key, string value)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            PurchasePM = ShowOrActiveForm(PurchasePM, typeof(PurchasePM)) as PurchasePM;
        }

        private Form ShowOrActiveForm(Form form, Type t, bool Dialog = false)
        {
            if (form == null)
            {
                form = (Form)Activator.CreateInstance(t);
                form.StartPosition = FormStartPosition.CenterScreen;

                if (!Dialog)
                {
                    form.MdiParent = this;
                    form.Show();
                }
                else
                {
                    form.MdiParent = null;
                    form.ShowDialog();
                }
            }
            else
            {
                form.StartPosition = FormStartPosition.CenterScreen;

                if (form.IsDisposed)
                {
                    form = (Form)Activator.CreateInstance(t);
                    form.MdiParent = this;

                    if (!Dialog)
                    {
                        form.MdiParent = this;
                        form.Show();
                    }
                    else
                    {
                        form.MdiParent = null;
                        form.ShowDialog();
                    }
                }
                else
                {
                    if (!Dialog)
                    {
                        form.Activate();
                    }
                    else
                    {
                        form.MdiParent = null;
                        form.ShowDialog();
                    }

                }
            }
            return form;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        public static void LoadProcessInControl(string _Process, Control _Control, bool IsMDI = true, string Arguments = "")
        {
            if (IsMDI)
            {
                System.Diagnostics.Process p = System.Diagnostics.Process.Start(_Process, Arguments);

                p.WaitForInputIdle();

                Thread.Sleep(1000);

                SetParent(p.MainWindowHandle, _Control.Handle);
            }
            else
            {

                Process.Start(_Process, Arguments);

            }
        }

        private void AddStatusBar(string Server)
        {
            StatusBar main = new StatusBar();

            StatusBarPanel statusPanel = new StatusBarPanel();
            StatusBarPanel statusVersion = new StatusBarPanel();
            StatusBarPanel dateTimePanel = new StatusBarPanel();
            StatusBarPanel serverPanel = new StatusBarPanel();


            statusPanel.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            statusPanel.Text = "Usuario.- Administrador";
            statusPanel.ToolTipText = "Administrador";
            statusPanel.AutoSize = StatusBarPanelAutoSize.Spring;

            main.Panels.Add(statusPanel);

            statusVersion.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            statusVersion.Text = "MaxShop V1.0.0 - " + this.AppSet<string>("shopName").Replace("°", " ").Trim() + " - Suc. " + this.AppSet<string>("branchOffice") + " - Caja " + this.AppSet<string>("CashRegister");
            statusVersion.AutoSize = StatusBarPanelAutoSize.Spring;

            main.Panels.Add(statusVersion);



            serverPanel.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            serverPanel.Text = "Repositorio.-" + Server;
            serverPanel.AutoSize = StatusBarPanelAutoSize.Spring;

            main.Panels.Add(serverPanel);



            dateTimePanel.BorderStyle = StatusBarPanelBorderStyle.Raised;
            dateTimePanel.Text = DateTime.Today.ToLongDateString();
            dateTimePanel.ToolTipText = "Fecha: " + DateTime.Today.ToString("dd/MM/yyyy");
            dateTimePanel.AutoSize = StatusBarPanelAutoSize.Spring;

            main.Panels.Add(dateTimePanel);

            main.ShowPanels = true;

            this.Controls.Add(main);
        }

        [DllImport("user32.dll")]
        private static extern int FindWindow(string lpszClassName, string lpszWindowName);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hWnd, int nCmdShow);
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        private void full_maximize(object sender, EventArgs e)
        {
            // First, Hide the taskbar

            int hWnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hWnd, SW_HIDE);

            // Then, format and size the window. 
            // Important: Borderstyle -must- be first, 
            // if placed after the sizing functions, 
            // it'll strangely firm up the taskbar distance.

            FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
            this.WindowState = FormWindowState.Maximized;

            //        The following is optional, but worth knowing.

            //        this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            //        this.TopMost = true;
        }

        #endregion

        public class Codility
        {
            /// <summary>
            /// A small frog wants to get to the other side of the road. The frog is currently located at position X and wants to get to a position greater than or equal to Y. The small frog always jumps a fixed distance, D.
            ///
            ///Count the minimal number of jumps that the small frog must perform to reach its target.
            ///
            ///Write a function:
            ///
            ///class Solution { public int solution(int X, int Y, int D); }
            ///
            ///that, given three integers X, Y and D, returns the minimal number of jumps from position X to a position equal to or greater than Y.
            ///
            ///For example, given:
            ///
            ///  X = 10
            ///  Y = 85
            ///  D = 30
            ///the function should return 3, because the frog will be positioned as follows:
            ///
            ///after the first jump, at position 10 + 30 = 40
            ///after the second jump, at position 10 + 30 + 30 = 70
            ///after the third jump, at position 10 + 30 + 30 + 30 = 100
            ///Assume that:
            ///
            ///X, Y and D are integers within the range [1..1,000,000,000];
            ///X ≤ Y.
            ///Complexity:
            ///
            ///expected worst-case time complexity is O(1);
            ///expected worst-case space complexity is O(1).
            /// </summary>
            /// <param name="X"></param>
            /// <param name="Y"></param>
            /// <param name="D"></param>
            /// <returns></returns>
            public int Jumps(int X, int Y, int D)
            {
                //Solucion al 100%
                int j1 = (Y - X);

                if (j1 % D == 0)
                    return j1 / D;
                else
                    return (j1 / D) + 1;

                //Solucion al 44%
                //int j1 = (Y - X);

                //int jumps = j1 / D + (j1 / D == 0 ? 0 : 1);

                //return jumps;

                //Solucion al 77%
                //int jumps = 0;

                //for (int i = X; i < Y; i += D)
                //{
                //    jumps++;
                //}

                //return jumps;

                //Solucion al 44%
                //int jumps = 0;

                //do
                //{
                //    X += D;

                //    jumps++;

                //} while (X < Y);

                //return jumps;
            }

            /// <summary>
            ///A non-empty zero-indexed array A consisting of N integers is given. Array A represents numbers on a tape.
            ///
            ///Any integer P, such that 0 < P < N, splits this tape into two non-empty parts: A[0], A[1], ..., A[P − 1] and A[P], A[P + 1], ..., A[N − 1].
            ///
            ///The difference between the two parts is the value of: |(A[0] + A[1] + ... + A[P − 1]) − (A[P] + A[P + 1] + ... + A[N − 1])|
            ///
            ///In other words, it is the absolute difference between the sum of the first part and the sum of the second part.
            ///
            ///For example, consider array A such that:
            ///
            ///  A[0] = 3
            ///  A[1] = 1
            ///  A[2] = 2
            ///  A[3] = 4
            ///  A[4] = 3
            ///We can split this tape in four places:
            ///
            ///P = 1, difference = |3 − 10| = 7 
            ///P = 2, difference = |4 − 9| = 5 
            ///P = 3, difference = |6 − 7| = 1 
            ///P = 4, difference = |10 − 3| = 7 
            ///Write a function:
            ///
            ///class Solution { public int solution(int[] A); }
            ///
            ///that, given a non-empty zero-indexed array A of N integers, returns the minimal difference that can be achieved.
            ///
            ///For example, given:
            ///
            ///  A[0] = 3
            ///  A[1] = 1
            ///  A[2] = 2
            ///  A[3] = 4
            ///  A[4] = 3
            ///the function should return 1, as explained above.
            ///
            ///Assume that:
            ///
            ///N is an integer within the range [2..100,000];
            ///each element of array A is an integer within the range [−1,000..1,000].
            ///Complexity:
            ///
            ///expected worst-case time complexity is O(N);
            ///expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
            ///Elements of input arrays can be modified.
            /// </summary>
            /// <param name="A"></param>
            /// <returns></returns>
            public int TapeEquilibrium(int[] A)
            {
                int sumMin = A[0];
                int sumMax = 0;

                for (int i = 1; i < A.Length; i++)
                {
                    sumMax += A[i];
                }

                int minDif = Math.Abs(sumMin - sumMax);
                for (int i = 1; i < A.Length - 1; i++)
                {
                    sumMin += A[i];
                    sumMax -= A[i];
                    minDif = Math.Min(minDif, Math.Abs(sumMin - sumMax));
                }

                return minDif;
            }

            public int PermMissingElem(int[] A)
            {
                Array.Sort(A);

                int l = A.Length;
                int missing = l + 1;

                if (l == 0)
                    return missing = 1;

                for (int i = 0; i < l; i++)
                {
                    if (A[i] != i + 1)
                    {
                        missing = i + 1;
                        break;
                    }
                }

                return missing;
            }

            public int StudentsPhoto(int[] A)
            {
                int moves = 0,
                    lenf = A.Length - 1;

                Dictionary<int, int> dA = new Dictionary<int, int>();
                Dictionary<int, int> dB = new Dictionary<int, int>();

                for (int i = 0; i <= lenf; i++)
                {
                    dA.Add(i, A[i]);
                    dB.Add(i, A[i]);
                }

                dB = dB.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                for (int i = 0; i <= lenf; i++)
                {
                    if (dA.ElementAt(i).Key != dB.ElementAt(i).Key)
                        moves++;
                }

                return moves;

                //int move = 0,
                //    len = A.Length,
                //    lenf = A.Length - 1,
                //    valA = 0,
                //    valB = 0;

                //int[] B = new int[len];

                //Array.Copy(A, B,len);

                //Array.Sort(B);

                //if (len > 0)
                //{
                //    valA += A[0];
                //    valB += B[0];

                //    for (int i = 1; i <= lenf; i++)
                //    {
                //        valA += A[i];
                //        valB += B[i];

                //        if (!valA.Equals(valB) || (i.Equals(lenf) && A[i] != B[i]))
                //        {
                //            if (move.Equals(0))
                //                move += 2;
                //            else
                //                move++;
                //        }
                //    }
                //}

                //return move;

                //int jump = 0,
                //    len = A.Length - 1,
                //    val1 = 0,
                //    val2= 0;

                //int[] array = new int[1];

                //for (int i = 0; i < len; i++)
                //{
                //    val1 = A[i];
                //    val2 = A[i + 1];

                //    if (val1 > val2)
                //    {
                //        A[i + 1] = val1;
                //        A[i] = val2;

                //        if (jump.Equals(0))
                //            jump += 2;
                //        else
                //            jump ++;

                //        i = 0;
                //    }
                //}

                //return jump;


                //int jump = 0,
                //    max = 0,
                //    fe = A[0],
                //    len = A.Length,
                //    len2 = len - 1,
                //    val = 0;

                //for (int i = 0; i < len; i++)
                //{
                //    while (fe != 0 && i < len2)
                //    {
                //        val = A[i + 1];
                //        max = Math.Max(max, val);

                //        i++;
                //        fe--;
                //    }

                //    fe = max;
                //    jump++;
                //}

                //return jump;
            }

            public int Paint(int[] A)
            {
                int len = A.Length,
                    max = A.Max(),
                    val = 0,
                    total = 0;

                int? val2;

                bool fla = false;

                int?[,] mb = new int?[len, max];

                for (int i = 0; i < len; i++)
                {
                    val = A[i];

                    for (int j = 0; j < max; j++)
                    {
                        if (!val.Equals(0))
                        {
                            mb[i, j] = 1;
                            val--;
                        }
                    }
                }

                for (int i = 0; i < max; i++)
                {
                    fla = false;

                    for (int j = 0; j < len; j++)
                    {
                        val2 = mb[j, i];

                        if (val2 == 1)
                            fla = true;

                        if ((fla && !val2.HasValue) || (fla && j.Equals(len - 1)))
                        {
                            fla = false;
                            total++;

                            if (total > 1000000000)
                                return -1;
                        }
                    }
                }

                return total;
            }

            public int BinaryGap(int N)
            {
                //100% quitar la cadena
                String cad = "";

                int index = 0,
                    count = 0,
                    max = 0;

                bool e1 = true;

                while (N > 0)
                {
                    if ((N % 2).Equals(0))
                    {
                        if (index.Equals(0))
                            e1 = false;

                        if (e1)
                            count++;

                        cad = "0" + cad;
                    }
                    else
                    {
                        if (count > max)
                            max = count;

                        e1 = true;

                        count = 0;

                        cad = "1" + cad;
                    }

                    N = (int)(N / 2);

                    index++;
                }

                return max;

            }

            public int[] CyclicRotation(int[] A, int K)
            {
                //100%

                if (K < 1)
                    return A;

                int total = A.Length,
                    maxIndex = total - 1,
                    mov = 0;

                int[] B = new int[total];

                for (int j = 0; j < K; j++)
                {
                    for (int i = 0; i < total; i++)
                    {
                        mov = i + 1;

                        if (mov > maxIndex)
                            mov = 0 + (mov - maxIndex - 1);

                        B[mov] = A[i];
                    }

                    B.CopyTo(A, 0);
                }

                return B;
            }
        }

        public class IPInfo
        {
            public IPInfo(string macAddress, string ipAddress)
            {
                this.MacAddress = macAddress;
                this.IPAddress = ipAddress;
            }

            public string MacAddress { get; private set; }
            public string IPAddress { get; private set; }

            private string _HostName = string.Empty;
            public string HostName
            {
                get
                {
                    if (string.IsNullOrEmpty(this._HostName))
                    {
                        try
                        {
                            // Retrieve the "Host Name" for this IP Address. This is the "Name" of the machine.
                            this._HostName = Dns.GetHostEntry(this.IPAddress).HostName;
                        }
                        catch
                        {
                            this._HostName = string.Empty;
                        }
                    }
                    return this._HostName;
                }
            }


            #region "Static Methods"

            /// <summary>
            /// Retrieves the IPInfo for the machine on the local network with the specified MAC Address.
            /// </summary>
            /// <param name="macAddress">The MAC Address of the IPInfo to retrieve.</param>
            /// <returns></returns>
            public static IPInfo GetIPInfo(string macAddress)
            {
                var ipinfo = (from ip in IPInfo.GetIPInfo()
                              where ip.MacAddress.ToLowerInvariant() == macAddress.ToLowerInvariant()
                              select ip).FirstOrDefault();

                return ipinfo;
            }

            /// <summary>
            /// Retrieves the IPInfo for All machines on the local network.
            /// </summary>
            /// <returns></returns>
            public static List<IPInfo> GetIPInfo()
            {
                try
                {
                    var list = new List<IPInfo>();

                    foreach (var arp in GetARPResult().Split(new char[] { '\n', '\r' }))
                    {
                        // Parse out all the MAC / IP Address combinations
                        if (!string.IsNullOrEmpty(arp))
                        {
                            var pieces = (from piece in arp.Split(new char[] { ' ', '\t' })
                                          where !string.IsNullOrEmpty(piece)
                                          select piece).ToArray();
                            if (pieces.Length == 3)
                            {
                                list.Add(new IPInfo(pieces[1], pieces[0]));
                            }
                        }
                    }

                    // Return list of IPInfo objects containing MAC / IP Address combinations
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("IPInfo: Error Parsing 'arp -a' results", ex);
                }
            }

            /// <summary>
            /// This runs the "arp" utility in Windows to retrieve all the MAC / IP Address entries.
            /// </summary>
            /// <returns></returns>
            private static string GetARPResult()
            {
                Process p = null;
                string output = string.Empty;

                try
                {
                    p = Process.Start(new ProcessStartInfo("arp", "-a")
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true
                    });

                    output = p.StandardOutput.ReadToEnd();

                    p.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("IPInfo: Error Retrieving 'arp -a' Results", ex);
                }
                finally
                {
                    if (p != null)
                    {
                        p.Close();
                    }
                }

                return output;
            }

            #endregion
        }

        private void otroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Box boxUi = new Box(false);
            boxUi.ShowDialog();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            Client = ShowOrActiveForm(Client, typeof(Client)) as Client;
        }

        private void recargasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefillList = ShowOrActiveForm(RefillList, typeof(RefillList)) as RefillList;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BackUp();
        }

        private void BackUp()
        {
            PosBusiness.Configuration conf = new PosBusiness.Configuration();

            if (conf.CreateBakUp())
            {
                new Thread(() =>
                {
                    var path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BackUp";

                    conf.CreateBackUpDataBase(path);

                }).Start();
            }
        }
    }
}